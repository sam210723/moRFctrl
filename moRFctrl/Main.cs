using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace moRFctrl
{
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
                moRFeus.SetBiasTee(moRFeus.BIAS_ON);
            }
            else
            {
                moRFeus.SetBiasTee(moRFeus.BIAS_OFF);
            }
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
        #endregion
    }
}
