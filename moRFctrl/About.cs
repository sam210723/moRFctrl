﻿using System;
using System.Drawing;
using System.Net.Http;
using System.Reflection;
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
            updateBtn.BackColor = Color.FromArgb(70, 70, 70);
            updateBtn.ForeColor = Color.Yellow;

            // Get current assembly version
            Assembly asm = Assembly.GetExecutingAssembly();
            Version v = AssemblyName.GetAssemblyName(asm.Location).Version;

            int maj = v.Major;
            int min = v.Minor;
            int build = v.Build;
            int rev = v.Revision;

            versionLabel.Text = $"v{maj}.{min}.{build}";

            UpdateCheckAsync();
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
            System.Diagnostics.Process.Start("https://vksdr.com/morfctrl");
        }

        /// <summary>
        /// Check for updates from GitHub
        /// </summary>
        private async void UpdateCheckAsync()
        {
            Console.WriteLine("Checking for update on GitHub");
            string ghLatestRelease = "https://api.github.com/repos/sam210723/moRFctrl/releases/latest";
            string ghJSONRes = "";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("sam210723/moRFctrl Update Checker");
                try
                {
                    ghJSONRes = await client.GetStringAsync(ghLatestRelease);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Update check exception: " + e.Message);
                    updateLabel.Text = "Update check failed";
                    return;
                }

                Console.WriteLine(ghJSONRes);///
            }

            string tagName = ghJSONRes.Substring(ghJSONRes.IndexOf("\"tag_name\":\"") + 12);
            tagName = tagName.Substring(0, tagName.IndexOf("\",\"target_commitish\":"));
            Console.WriteLine("Tag Name: " + tagName);

            string releaseName = ghJSONRes.Substring(ghJSONRes.IndexOf("\"name\":\"") + 8);
            releaseName = releaseName.Substring(0, releaseName.IndexOf("\",\"draft\":"));
            Console.WriteLine("Release Name: " + releaseName);

            // Get current assembly version
            Assembly asm = Assembly.GetExecutingAssembly();
            Version v = AssemblyName.GetAssemblyName(asm.Location).Version;

            int maj = v.Major;
            int min = v.Minor;
            int build = v.Build;
            int rev = v.Revision;

            if (tagName != $"v{maj}.{min}.{build}")
            {
                updateBtn.Text = "Download update (" + tagName + ")";
                updateBtn.Visible = true;
                updateLabel.Visible = false;
            }
            else
            {
                updateLabel.Text = "No update available";
            }
        }

        /// <summary>
        /// Open latest release on GitHub repo
        /// </summary>
        private void updateBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/sam210723/moRFctrl/releases/latest");
        }
    }
}
