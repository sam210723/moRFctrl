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
        }


        #region Events
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
