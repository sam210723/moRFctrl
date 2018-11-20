﻿using System;
using System.Threading;

namespace moRFctrl
{
    /// <summary>
    /// Controls frequency generator sweep
    /// </summary>
    class Sweep
    {
        /// <summary>
        /// Begin frequency sweep
        /// </summary>
        /// <param name="start">Start frequency (Hz)</param>
        /// <param name="stop">Stop frequencu (Hz)</param>
        /// <param name="step">Step size (Hz)</param>
        /// <param name="dwell">Dwell time (s)</param>
        public Sweep(UInt64 start, UInt64 stop, UInt64 step, double dwell)
        {
            // Initial moRFeus config
            moRFeus.SetFunction(moRFeus.FUNC_GENERATOR);
            moRFeus.SetFrequency(start);
            moRFeus.GetFrequency();

            // Initial GQRX config
            Program.MainClass.StatusMessage = "Connecting to GQRX...";
            if (Program.GQRXThread.ThreadState != ThreadState.Running)
            {
                Program.GQRXThread.Start();
            }
            Thread.Sleep(500);

            if (Program.GQRXClass.IsConnected)
            {
                Program.MainClass.StatusMessage = "GQRX connection ready";
            }
            else
            {
                Program.MainClass.StatusMessage = "GQRX connection failed";
            }
            Thread.Sleep(1000);

            // Initial UI config
            Program.MainClass.SweepProgress = 0;
            Program.MainClass.StatusMessage = "Time remaining: " + PrettifyTime(Time(start, stop, step, dwell));


            // Do sweep
            Program.MainClass.StatusMessage = "Starting sweep";
            UInt64 bandwidth = stop - start;
            UInt64 steps = bandwidth / step;
            UInt64 i = 1;
            UInt64 newFrequency = 0;
            while (newFrequency < stop)
            {
                Thread.Sleep((int)(dwell * 1000));

                newFrequency = start + (step * i);
                if (newFrequency > 5400000000)
                {
                    newFrequency = 5400000000;
                }
                moRFeus.SetFrequency(newFrequency);
                
                if (Program.GQRXClass.IsConnected)
                {
                    Program.GQRXClass.SetFrequency(newFrequency);
                }


                Program.MainClass.StatusMessage = "Time remaining: " + PrettifyTime(Time(newFrequency, stop, step, dwell));
                
                // Cap progress bar to 100
                if ((int) Math.Round((double)i / steps * 100) > 100) {
                    Program.MainClass.SweepProgress = 100;
                }
                else
                {
                    Program.MainClass.SweepProgress = (int) Math.Round((double)i / steps * 100);
                }

                i += 1;
            }

            Program.MainClass.SweepProgress = 100;
            Program.MainClass.StatusMessage = "Sweep finished";
            Program.MainClass.EnableSweepUI();
        }

        /// <summary>
        /// Calculate time for sweep to complete
        /// </summary>
        /// <param name="start">Start frequency (Hz)</param>
        /// <param name="stop">Stop frequencu (Hz)</param>
        /// <param name="step">Step size (Hz)</param>
        /// <param name="dwell">Dwell time (s)</param>
        /// <returns>Sweep time in seconds</returns>
        public static double Time(UInt64 start, UInt64 stop, UInt64 step, double dwell)
        {
            UInt64 bandwidth = stop - start;
            UInt64 steps = bandwidth / step;
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
