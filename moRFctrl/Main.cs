using System;
using System.Drawing;
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

            DisableUI();
        }

        /// <summary>
        /// Get initial state of the device and update UI elements
        /// </summary>
        public void PollDevice() {
            moRFeus.GetBiasTee();
            moRFeus.GetMixerCurrent();
            moRFeus.GetFunction();
            moRFeus.GetFrequency();
        }

        /// <summary>
        /// Trigger full sweep time calculation and display in human readable form
        /// </summary>
        private void GetSweepTime()
        {
            UInt64 start = (UInt64)numStartFreq.Value;
            UInt64 stop = (UInt64)numStopFreq.Value;
            UInt64 step = (UInt64)numStepSize.Value;
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
        /// Begin frequency sweep
        /// </summary>
        private void DoSweep()
        {
            // Start new sweep
            if (Program.SweepThread == null)
            {
                UInt64 start = (UInt64)numStartFreq.Value;
                UInt64 stop = (UInt64)numStopFreq.Value;
                UInt64 step = (UInt64)numStepSize.Value;
                double dwell = (double)numDwellTime.Value;

                DisableUI();

                // Start new sweep
                Program.SweepThread = new Thread(() => Program.SweepThreadStart(start, stop, step, dwell));
                Program.SweepThread.Start();
            }
            else  // Stop current sweep
            {
                StatusMessage = "Step sequence stopped";
                Program.SweepThread.Abort();

                EnableUI();
            }
        }

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
                // Enable UI elements
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
                SweepProgress = 0;

                Program.SweepThread = null;
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
                // Disable UI elements
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
            }
        }

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
        #endregion

        #region Events
        /// <summary>
        /// Set generator frequency
        /// </summary>
        private void textFrequency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && textFrequency.Text != "")
            {
                // Frequency within moRFeus range
                if (UInt64.Parse(textFrequency.Text) > 5400000000)
                {
                    textFrequency.Text = "5400000000";
                }
                else if (UInt64.Parse(textFrequency.Text) < 85000000)
                {
                    textFrequency.Text = "85000000";
                }

                moRFeus.SetFrequency(UInt64.Parse(textFrequency.Text));
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
            DoSweep();
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
        #endregion
    }
}
