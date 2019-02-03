using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace moRFctrl
{
    /// <summary>
    /// Main UI form
    /// </summary>
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            ConfigUI();
        }

        /// <summary>
        /// Configure UI elements at runtime
        /// </summary>
        private void ConfigUI()
        {
            // Set menu strip colours (control property doesn't work)
            menuStrip.BackColor = Color.FromArgb(70, 70, 70);
            menuStrip.ForeColor = Color.White;

            // Set status strip background colour (control property doesn't work)
            statusStrip.BackColor = Color.FromArgb(55, 55, 55);

            toolStripStatusLabel.Text = "Initialising";

            textFrequency.SelectionStart = textFrequency.TextLength;

            GetSettings();

            // Disable UI until moRFeus is detected
            DisableUI();
        }

        /// <summary>
        /// Get initial state of the device and update UI elements
        /// </summary>
        public void PollDevice() {
            moRFeusState state = moRFeus.GetAll();

            Frequency = state.Frequency.ToString();
            Function = state.Function;
            MixerCurrent = state.MixerCurrent;
            BiasTee = state.BiasTee;
        }

        /// <summary>
        /// Trigger full sweep time calculation and display in human readable form
        /// </summary>
        private void GetSweepTime()
        {
            ulong start = (ulong)numStartFreq.Value;
            ulong stop = (ulong)numStopFreq.Value;
            ulong step = (ulong)numStepSize.Value;
            double dwell = (double)numDwellTime.Value;

            // Keep stop bigger than start
            if (start > stop)
            {
                numStartFreq.Value = stop;
                numStopFreq.Value = start;
                return;
            }

            // Human readable time
            StatusMessage = "Sweep time: " + Sweep.PrettifyTime(Sweep.Time(start, stop, step, dwell));
        }

        /// <summary>
        /// Start frequency sweep
        /// </summary>
        public void StartSweep()
        {
            ulong start = (ulong)numStartFreq.Value;
            ulong stop = (ulong)numStopFreq.Value;
            ulong step = (ulong)numStepSize.Value;
            double dwell = (double)numDwellTime.Value;

            DisableSweepUI();
            SweepProgress = 0;

            // Start new sweep
            Program.SweepThread = new Thread(() => Program.SweepThreadStart(start, stop, step, dwell));
            Program.SweepThread.Start();
        }

        /// <summary>
        /// Stop frequency sweep
        /// </summary>
        public void StopSweep()
        {
            Program.SweepThread.Abort();
            Program.GQRXClass.Disconnect();

            EnableSweepUI();
            SweepProgress = 0;
        }

        /// <summary>
        /// Populate settings UI with values from file
        /// </summary>
        void GetSettings()
        {
            if (Tools.ValidateIPv4(Properties.Settings.Default.gqrx_host))
            {
                textGqrxIP.Text = Properties.Settings.Default.gqrx_host;
            }
            else
            {
                Tools.Debug("Bad Gqrx IP in settings file");
                textGqrxIP.Text = "INVALID";
            }

            int parsetemp;
            if (int.TryParse(Properties.Settings.Default.gqrx_port.ToString(), out parsetemp))
            {
                numGqrxPort.Value = Properties.Settings.Default.gqrx_port;
            }
            else
            {
                // Default port
                numGqrxPort.Value = 7356;
            }

            checkConfirmExit.Checked = Properties.Settings.Default.confirm_exit;

            // CSV filename
            CSVFilePath = Properties.Settings.Default.sweep_output_file;
            linkSweepOutFile.Text = Path.GetFileName(CSVFilePath);
        }

        #region UI
        /// <summary>
        /// Enable UI elements
        /// </summary>
        public void EnableUI()
        {
            if (textFrequency.InvokeRequired)
            {
                textFrequency.BeginInvoke(new MethodInvoker(delegate {
                    EnableUI();
                }));
            }
            else
            {
                EnableSweepUI();
                btnSweep.Enabled = true;
            }
        }

        /// <summary>
        /// Disable UI elements
        /// </summary>
        public void DisableUI()
        {
            if (textFrequency.InvokeRequired)
            {
                textFrequency.BeginInvoke(new MethodInvoker(delegate {
                    DisableUI();
                }));
            }
            else
            {
                DisableSweepUI();
                btnSweep.Enabled = false;
            }
        }

        /// <summary>
        /// Disable sweep UI elements
        /// </summary>
        public void DisableSweepUI()
        {
            if (textFrequency.InvokeRequired)
            {
                textFrequency.BeginInvoke(new MethodInvoker(delegate
                {
                    DisableSweepUI();
                }));
            }
            else
            {
                textFrequency.Enabled = false;
                trackMixerI.Enabled = false;
                labelMixerI.ForeColor = Color.DarkSlateGray;
                checkBiasTee.AutoCheck = false;
                checkBiasTee.ForeColor = Color.DarkSlateGray;
                radioFunctionMixer.AutoCheck = false;
                radioFunctionMixer.ForeColor = Color.DarkSlateGray;
                radioFunctionGenerator.AutoCheck = false;
                radioFunctionGenerator.ForeColor = Color.DarkSlateGray;
                btnSweep.Text = "Stop";
                numStartFreq.Enabled = false;
                labelSweepStart.ForeColor = Color.DarkSlateGray;
                numStopFreq.Enabled = false;
                labelSweepStop.ForeColor = Color.DarkSlateGray;
                numStepSize.Enabled = false;
                labelSweepStep.ForeColor = Color.DarkSlateGray;
                numDwellTime.Enabled = false;
                labelSweepDwell.ForeColor = Color.DarkSlateGray;
                btnSweep.Text = "Stop";
            }
        }

        /// <summary>
        /// Enable sweep UI elements
        /// </summary>
        public void EnableSweepUI()
        {
            if (textFrequency.InvokeRequired)
            {
                textFrequency.BeginInvoke(new MethodInvoker(delegate {
                    EnableSweepUI();
                }));
            }
            else
            {
                textFrequency.Enabled = true;
                trackMixerI.Enabled = true;
                labelMixerI.ForeColor = Color.White;
                checkBiasTee.AutoCheck = true;
                checkBiasTee.ForeColor = Color.White;
                radioFunctionMixer.AutoCheck = true;
                radioFunctionMixer.ForeColor = Color.White;
                radioFunctionGenerator.AutoCheck = true;
                radioFunctionGenerator.ForeColor = Color.White;
                btnSweep.Text = "Start";
                numStartFreq.Enabled = true;
                labelSweepStart.ForeColor = Color.White;
                numStopFreq.Enabled = true;
                labelSweepStop.ForeColor = Color.White;
                numStepSize.Enabled = true;
                labelSweepStep.ForeColor = Color.White;
                numDwellTime.Enabled = true;
                labelSweepDwell.ForeColor = Color.White;
                Program.SweepThread = null;
                btnSweep.Text = "Start";
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Tool strip status message
        /// </summary>
        public string StatusMessage
        {
            get
            {
                return toolStripStatusLabel.Text;
            }

            set
            {
                if (statusStrip.InvokeRequired)
                {
                    statusStrip.BeginInvoke(new MethodInvoker(delegate
                    {
                        toolStripStatusLabel.Text = value;
                    }));
                }
                else
                {
                    toolStripStatusLabel.Text = value;
                }
            }
        }

        /// <summary>
        /// Frequency text box
        /// </summary>
        public string Frequency
        {
            get
            {
                return textFrequency.Text;
            }

            set
            {
                if (textFrequency.InvokeRequired)
                {
                    textFrequency.BeginInvoke(new MethodInvoker(delegate
                    {
                        textFrequency.Text = value;
                        textFrequency.SelectionStart = textFrequency.TextLength;
                    }));
                }
                else
                {
                    textFrequency.Text = value;
                    textFrequency.SelectionStart = textFrequency.TextLength;
                }
            }
        }

        /// <summary>
        /// Function radio buttons
        /// </summary>
        public int Function
        {
            get
            {
                if (radioFunctionMixer.Checked)
                {
                    return moRFeus.FUNC_MIXER;
                }
                else if (radioFunctionGenerator.Checked)
                {
                    return moRFeus.FUNC_GENERATOR;
                }
                else {
                    return -1;
                }
                
            }

            set
            {
                if (value == moRFeus.FUNC_MIXER) {
                    if (radioFunctionMixer.InvokeRequired)
                    {
                        radioFunctionMixer.BeginInvoke(new MethodInvoker(delegate
                        {
                            radioFunctionMixer.Checked = true;
                        }));
                    }
                    else
                    {
                        radioFunctionMixer.Checked = true;
                    }

                    if (radioFunctionGenerator.InvokeRequired)
                    {
                        radioFunctionGenerator.BeginInvoke(new MethodInvoker(delegate
                        {
                            radioFunctionGenerator.Checked = false;
                        }));
                    }
                    else
                    {
                        radioFunctionGenerator.Checked = false;
                    }
                }
                else if (value == moRFeus.FUNC_GENERATOR)
                {
                    if (radioFunctionMixer.InvokeRequired)
                    {
                        radioFunctionMixer.BeginInvoke(new MethodInvoker(delegate
                        {
                            radioFunctionMixer.Checked = false;
                        }));
                    }
                    else
                    {
                        radioFunctionMixer.Checked = false;
                    }

                    if (radioFunctionGenerator.InvokeRequired)
                    {
                        radioFunctionGenerator.BeginInvoke(new MethodInvoker(delegate
                        {
                            radioFunctionGenerator.Checked = true;
                        }));
                    }
                    else
                    {
                        radioFunctionGenerator.Checked = true;
                    }
                }
            }
        }

        /// <summary>
        /// Mixer current track
        /// </summary>
        public int MixerCurrent
        {
            get
            {
                return trackMixerI.Value;
            }

            set
            {
                if (trackMixerI.InvokeRequired)
                {
                    trackMixerI.BeginInvoke(new MethodInvoker(delegate
                    {
                        trackMixerI.Value = value;
                    }));
                }
                else
                {
                    trackMixerI.Value = value;
                }
            }
        }

        /// <summary>
        /// Bias Tee checkbox
        /// </summary>
        public bool BiasTee
        {
            get
            {
                return checkBiasTee.Checked;
            }

            set
            {
                if (checkBiasTee.InvokeRequired)
                {
                    checkBiasTee.BeginInvoke(new MethodInvoker(delegate
                    {
                        checkBiasTee.Checked = value;
                    }));
                }
                else
                {
                    checkBiasTee.Checked = value;
                }
            }
        }

        /// <summary>
        /// Sweep progress bar
        /// </summary>
        public int SweepProgress
        {
            get
            {
                return progressSweep.Value;
            }

            set
            {
                if (progressSweep.InvokeRequired)
                {
                    progressSweep.BeginInvoke(new MethodInvoker(delegate
                    {
                        progressSweep.Value = value;
                    }));
                }
                else
                {
                    progressSweep.Value = value;
                }
            }
        }

        /// <summary>
        /// Full file path for sweep output CSV
        /// </summary>
        private string CSVFilePath { get; set; } = "";
        #endregion

        #region Events
        /// <summary>
        /// Set generator frequency
        /// </summary>
        private void textFrequency_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow digits to be entered
            if (!char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != 8)  // Special case for backspace
                {
                    e.Handled = true;
                }
            }

            if (e.KeyChar == (char)13 && textFrequency.Text != "")
            {
                // Frequency within moRFeus range
                if (ulong.Parse(textFrequency.Text) > 5400000000)
                {
                    textFrequency.Text = "5400000000";
                }
                else if (ulong.Parse(textFrequency.Text) < 85000000)
                {
                    textFrequency.Text = "85000000";
                }

                moRFeus.SetFrequency(ulong.Parse(textFrequency.Text));
            }
        }

        /// <summary>
        /// Set function to Mixer
        /// </summary>
        private void radioFunctionMixer_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFunctionMixer.Checked)
            {
                moRFeus.SetFunction(moRFeus.FUNC_MIXER);
            }
        }

        /// <summary>
        /// Set function to Generator
        /// </summary>
        private void radioFunctionGenerator_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFunctionGenerator.Checked)
            {
                moRFeus.SetFunction(moRFeus.FUNC_GENERATOR);
            }
        }

        /// <summary>
        /// Set mixer current
        /// </summary>
        private void trackMixerI_Scroll(object sender, EventArgs e)
        {
            moRFeus.SetMixerCurrent(trackMixerI.Value);
        }

        /// <summary>
        /// Set bias tee
        /// </summary>
        private void checkBiasTee_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBiasTee.Checked)
            {
                if (MessageBox.Show("Enable 5V bias-tee?\nThis can damage some devices!", "Bias-Tee", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    moRFeus.SetBiasTee(moRFeus.BIAS_ON);
                }
                else
                {
                    checkBiasTee.Checked = false;
                }
            }
            else
            {
                moRFeus.SetBiasTee(moRFeus.BIAS_OFF);
            }
        }

        /// <summary>
        /// Begin frequency sweep
        /// </summary>
        private void btnSweep_Click(object sender, EventArgs e)
        {
            if (Program.SweepThread == null)
            {
                StartSweep();
            }
            else
            {
                StatusMessage = "Step sequence stopped";
                StopSweep();
            }
        }

        /// <summary>
        /// Estimate full sweep time on change
        /// </summary>
        private void numStartFreq_ValueChanged(object sender, EventArgs e)
        {
            GetSweepTime();
        }

        /// <summary>
        /// Estimate full sweep time on change
        /// </summary>
        private void numStopFreq_ValueChanged(object sender, EventArgs e)
        {
            GetSweepTime();
        }

        /// <summary>
        /// Estimate full sweep time on change
        /// </summary>
        private void numStepSize_ValueChanged(object sender, EventArgs e)
        {
            GetSweepTime();
        }

        /// <summary>
        /// Estimate full sweep time on change
        /// </summary>
        private void numDwellTime_ValueChanged(object sender, EventArgs e)
        {
            GetSweepTime();
        }

        /// <summary>
        /// Trigger graceful exit
        /// </summary>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.CleanExit(0, e);
        }

        /// <summary>
        /// Trigger graceful exit
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.CleanExit(0, null);
        }

        /// <summary>
        /// Show About dialog
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutDialog = new About();
            aboutDialog.ShowDialog();
        }

        /// <summary>
        /// Save settings to file
        /// </summary>
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (Tools.ValidateIPv4(textGqrxIP.Text))
            {
                Properties.Settings.Default.gqrx_host = textGqrxIP.Text;
            }
            else
            {
                textGqrxIP.Text = "INVALID IP";
            }

            Properties.Settings.Default.gqrx_port = (int) numGqrxPort.Value;
            Properties.Settings.Default.confirm_exit = checkConfirmExit.Checked;
            Properties.Settings.Default.sweep_output_file = CSVFilePath;

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            StatusMessage = "Settings saved";
        }

        /// <summary>
        /// Load default settings into UI
        /// </summary>
        private void btnLoadDefaults_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to load default settings?\nAll current settings will be lost.", "Load Default Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // Default settings
            textGqrxIP.Text = "127.0.0.1";
            numGqrxPort.Value = 7356;
            checkConfirmExit.Checked = true;
            linkSweepOutFile.Text = "sweep.csv";
        }

        /// <summary>
        /// Set sweep CSV file path
        /// </summary>
        private void linkSweepOutFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sweepFileDialog.Title = "Save CSV file...";
            sweepFileDialog.AddExtension = true;
            sweepFileDialog.CheckFileExists = false;
            sweepFileDialog.CheckPathExists = true;
            sweepFileDialog.DefaultExt = ".csv";
            sweepFileDialog.FileName = Path.GetFileName(Properties.Settings.Default.sweep_output_file);
            sweepFileDialog.Filter = "CSV file (*.csv)|*.csv|All files (*.*)|*.*";
            sweepFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            sweepFileDialog.InitialDirectory = Path.GetDirectoryName(Properties.Settings.Default.sweep_output_file);
            sweepFileDialog.OverwritePrompt = true;
            sweepFileDialog.ValidateNames = true;

            sweepFileDialog.ShowDialog();
            CSVFilePath = sweepFileDialog.FileName;

            string path = Path.GetDirectoryName(CSVFilePath);
            string filename = Path.GetFileNameWithoutExtension(CSVFilePath);
            string ext = Path.GetExtension(CSVFilePath);

            Properties.Settings.Default.sweep_output_file = CSVFilePath;

            linkSweepOutFile.Text = Path.GetFileName(CSVFilePath);

            // Save settings
            btnSaveSettings_Click(null, null);
        }

        /// <summary>
        /// Shows full path on CSV file name hover
        /// </summary>
        private void linkSweepOutFile_MouseHover(object sender, EventArgs e)
        {
            tipCSVFilePath.Show(CSVFilePath, linkSweepOutFile, 0, 3, 5000);
        }
        #endregion
    }
}
