using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace moRFctrl
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            ConfigUI();
        }

        /// <summary>
        /// Configure UI elements at runtime
        /// </summary>
        private void ConfigUI()
        {
            // Set close colours (control property doesn't work)
            closeBtn.BackColor = Color.FromArgb(70, 70, 70);
            closeBtn.ForeColor = Color.White;


            // Get current assembly version
            Assembly asm = Assembly.GetExecutingAssembly();
            Version v = AssemblyName.GetAssemblyName(asm.Location).Version;

            int maj = v.Major;
            int min = v.Minor;
            int build = v.Build;
            int rev = v.Revision;

            versionLabel.Text = $"v{maj}.{min}";
        }

        /// <summary>
        /// Close the dialog
        /// </summary>
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Open link to documentation
        /// </summary>
        private void vksdrLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vksdr.com/moRFctrl");
        }
    }
}
