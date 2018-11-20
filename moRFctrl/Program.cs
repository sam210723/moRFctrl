using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace moRFctrl
{
    static class Program
    {
        // Classes
        public static Main MainClass;
        public static HID HIDClass;
        public static Sweep SweepClass;

        // Threads
        private static Thread MainThread;
        private static Thread HIDThread;
        public static Thread SweepThread;

        // Globals
        static bool confirmExit = false;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configure main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainClass = new Main();

            // Create threads
            MainThread = Thread.CurrentThread;
            HIDThread = new Thread(new ThreadStart(HIDThreadStart));

            // Start threads
            HIDThread.Start();

            // Start main form
            Application.Run(MainClass);
        }

        #region Threads
        private static void HIDThreadStart()
        {
            HIDClass = new HID();
        }

        public static void SweepThreadStart(UInt64 start, UInt64 stop, UInt64 step, double dwell)
        {
            SweepClass = new Sweep(start, stop, step, dwell);
        }
        #endregion

        /// <summary>
        /// Cleanly exit the application
        /// </summary>
        public static void CleanExit(int code, FormClosingEventArgs e)
        {
            // Check exit confirmation is enabled
            if (confirmExit)
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
            HIDThread.Abort();
            SweepThread?.Abort();

            //Environment.Exit(code);
            Application.Exit();
        }
    }
}
