using System;
using System.IO;
using System.Threading;

namespace moRFctrl
{
    /// <summary>
    /// Frequency sweep generator
    /// </summary>
    class Sweep
    {
        string gqrxAddress = string.Format(" ({0}:{1})", Properties.Settings.Default.gqrx_host, Properties.Settings.Default.gqrx_port);
        public StreamWriter CSVFile;

        /// <summary>
        /// Begin frequency sweep
        /// </summary>
        /// <param name="start">Start frequency (Hz)</param>
        /// <param name="stop">Stop frequencu (Hz)</param>
        /// <param name="step">Step size (Hz)</param>
        /// <param name="dwell">Dwell time (s)</param>
        public Sweep(ulong start, ulong stop, ulong step, double dwell)
        {
            // Initial moRFeus config
            moRFeus.SetFunction(moRFeus.FUNC_GENERATOR);
            moRFeus.SetFrequency(start);
            moRFeus.GetFrequency();

            // Initial Gqrx config
            Program.MainClass.StatusMessage = "Connecting to Gqrx " + gqrxAddress + "...";
            if (Program.GQRXClass.IsConnected != true)
            {
                Program.GQRXClass.Connect(Properties.Settings.Default.gqrx_host, Properties.Settings.Default.gqrx_port);
            }
            Thread.Sleep(250);

            if (Program.GQRXClass.IsConnected)
            {
                Program.MainClass.StatusMessage = "Gqrx connection ready";
            }
            else
            {
                Program.MainClass.StatusMessage = "Gqrx connection failed" + gqrxAddress;
                Program.GQRXClass.Disconnected();
                return;
            }
            Thread.Sleep(250);

            // Initial UI config
            Program.MainClass.SweepProgress = 0;
            Program.MainClass.StatusMessage = "Time remaining: " + PrettifyTime(Time(start, stop, step, dwell));

            // CSV setup
            string CSVPath = Properties.Settings.Default.sweep_output_file;
            string CSVDir = Path.GetDirectoryName(CSVPath);
            string CSVName = Path.GetFileName(CSVPath);
            Tools.Log("CSV file path: " + CSVPath);
            Tools.Log("CSV directory: " + CSVDir);
            Tools.Log("CSV file name: " + CSVName);

            // If CSV directory doesn't exist
            if (!CSV.DirectoryExists(CSVPath))
            {
                System.Windows.Forms.MessageBox.Show("Directory \"" + CSVDir + "\" does not exist.\nGo to Settings tab to change CSV file output path.", "moRFctrl", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Program.MainClass.SweepProgress = 0;
                Program.MainClass.StatusMessage = "Step sequence stopped";
                Program.MainClass.EnableUI();
                return;
            }
            
            // If CSV file already exists
            if (CSV.FileExists(CSVPath))
            {
                if (Properties.Settings.Default.confirm_overwrite)
                {
                    if (System.Windows.Forms.MessageBox.Show("\"" + CSVName + "\" already exists. Overwrite?", "moRFctrl", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                    {
                        Program.MainClass.SweepProgress = 0;
                        Program.MainClass.StatusMessage = "Step sequence stopped";
                        Program.MainClass.EnableUI();
                        return;
                    }
                }
                
                // Remove existing file
                try
                {
                    File.Delete(CSVPath);
                }
                catch (IOException e)
                {
                    System.Windows.Forms.MessageBox.Show("Could not delete CSV file", "moRFctrl", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    Program.MainClass.SweepProgress = 0;
                    Program.MainClass.StatusMessage = "Step sequence stopped";
                    Program.MainClass.EnableUI();
                    return;
                }
            }

            // Create CSV file
            CSVFile = CSV.Create(CSVPath);

            //Step sequence globals
            //Program.MainClass.StatusMessage = "Starting step sequence";
            ulong bandwidth = stop - start;
            ulong steps = bandwidth / step;
            ulong i = 0;
            ulong newFrequency = 0;

            // Step loop
            while (newFrequency < stop)
            {
                // Short delay between SNR reading and frequency change
                // Without this Gqrx will fall behind
                Thread.Sleep(125);

                //Calculate next frequency in sequence
                newFrequency = start + (step * i);

                // Cap step frequencies to 5.4 GHz
                if (newFrequency > 5400000000)
                {
                    newFrequency = 5400000000;
                }

                // Cap frequency to stop frequency
                if (newFrequency > stop)
                {
                    newFrequency = stop;
                }

                // Update moRFeus generator with next step in sequence
                moRFeus.SetFrequency(newFrequency);
                Program.MainClass.Frequency = newFrequency.ToString();

                // If Gqrx connection is active, tune SDR to moRFeus frequency
                if (Program.GQRXClass.IsConnected)
                {
                    Program.GQRXClass.SetFrequency(newFrequency);
                    Thread.Sleep(125);

                    /*
                    if (Program.GQRXClass.GetFrequency() != newFrequency)
                    {
                        Tools.Debug("Frequency mismatch");
                    }
                    else
                    {
                        Tools.Debug("Frequency check OK");
                    }
                    */
                }

                // Wait for specified dwell time
                Thread.Sleep((int)(dwell * 1000) - 250);

                // If Gqrx connection is active, get carrier level
                if (Program.GQRXClass.IsConnected)
                {
                    string snr = Program.GQRXClass.GetStrength();
                    Console.WriteLine("Strength: " + snr);

                    // Write to CSV file, stop on error
                    if (!CSV.Write(CSVFile, newFrequency, snr))
                    {
                        Program.MainClass.SweepProgress = 0;
                        Program.MainClass.StatusMessage = "Error writing to CSV file";
                        Program.MainClass.EnableUI();
                        return;
                    }
                }

                // Report remaining time
                Program.MainClass.StatusMessage = "Time remaining: " + PrettifyTime(Time(newFrequency, stop, step, dwell));
                
                // Cap progress bar to 100
                if ((int) Math.Round((double)i / steps * 100) > 100) {
                    Program.MainClass.SweepProgress = 100;
                }
                else  // Set sequence progress value
                {
                    Program.MainClass.SweepProgress = (int) Math.Round((double)i / steps * 100);
                }

                i += 1;
            }

            // Close CSV at end of sweep
            CSV.Close(CSVFile);

            // Reset UI to pre-sweep state
            Program.MainClass.SweepProgress = 100;
            Program.MainClass.StatusMessage = "Step sequence finished";
            Program.MainClass.EnableUI();
        }

        /// <summary>
        /// Calculate time for sweep to complete
        /// </summary>
        /// <param name="start">Start frequency (Hz)</param>
        /// <param name="stop">Stop frequencu (Hz)</param>
        /// <param name="step">Step size (Hz)</param>
        /// <param name="dwell">Dwell time (s)</param>
        /// <returns>Sweep time in seconds</returns>
        public static double Time(ulong start, ulong stop, ulong step, double dwell)
        {
            ulong bandwidth = stop - start;
            ulong steps = bandwidth / step;
            double span = dwell * steps;

            return span;
        }

        /// <summary>
        /// Convert seconds into human readable time string
        /// </summary>
        /// <param name="time">Length in seconds</param>
        /// <returns>Human readable time string</returns>
        public static string PrettifyTime(double time)
        {
            TimeSpan span = TimeSpan.FromSeconds(time);

            if (span.Hours == 0 && span.Minutes == 0)
            {
                return string.Format("{0}s", span.Seconds);
            }
            else if (span.Hours == 0)
            {
                return string.Format("{0}m {1}s", span.Minutes, span.Seconds);
            }
            else
            {
                return string.Format("{0}h {1}m {2}s", span.Hours, span.Minutes, span.Seconds);
            }
        }
    }
}
