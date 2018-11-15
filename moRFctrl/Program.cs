using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace moRFctrl
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configure main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        /// <summary>
        /// Cleanly exit the application
        /// </summary>
        public static void CleanExit(int code, FormClosingEventArgs e)
        {
            // Check exit confirmation is enabled
            if (Properties.Settings.Default.ConfirmExit)
            {
                // Confirm the user wants to exit
                if (MessageBox.Show("Do you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    // Cancel exit if not confirmed
                    if (e != null)
                    {
                        e.Cancel = true;
                    }

                    return;
                }
            }

            Console.WriteLine("Application exiting with code {0}", code);
            Properties.Settings.Default.Save();
            Console.WriteLine("Settings saved");

            //Environment.Exit(code);
            Application.Exit();
        }
    }
}
