using HidSharp;
using HidSharp.Reports;
using HidSharp.Reports.Input;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace moRFctrl
{
    /// <summary>
    /// Handles HID detection and communication
    /// </summary>
    class HID
    {
        // moRFeus IDs
        readonly int vid = 0x10C4;
        readonly int pid = 0xEAC9;

        DeviceList devList;
        HidDevice[] hidList;

        HidDevice moRFeusDevice;
        HidStream moRFeusStream;

        byte[] reportBuffer;
        HidDeviceInputReceiver reportReceiver;

        public HID()
        {
            Tools.Debug("\nDetecting HIDs");
            moRFeusDevice = DetectHID(vid, pid);

            // Indicate connection status
            if (moRFeusDevice is null)
            {
                Program.MainClass.StatusMessage = "No moRFeus found";
                Tools.Debug("No moRFeus found\n");
            }
            else
            {
                Program.MainClass.StatusMessage = "Found moRFeus";
                Tools.Debug("Found moRFeus: " + moRFeusDevice.DevicePath.ToString());
                moRFeusDetected = true;

                ConfigDevice();
            }
        }

        /// <summary>
        /// Detect HID with given Vendor and Product IDs
        /// </summary>
        /// <param name="vid">Vendor ID</param>
        /// <param name="pid">Product ID</param>
        /// <returns>HIDSharp.HidDevice or null</returns>
        private HidDevice DetectHID(int vid, int pid)
        {
            // Get list of HIDs
            devList = DeviceList.Local;
            hidList = devList.GetHidDevices().ToArray();

            // Loop through HID list
            foreach (HidDevice dev in hidList)
            {
                // Check for HID IDs
                if (dev.VendorID == vid && dev.ProductID == pid)
                {
                    return dev;
                }
            }

            return null;
        }

        /// <summary>
        /// Begin communication with moRFeus
        /// </summary>
        private void ConfigDevice()
        {
            // Report stream opened
            if (moRFeusDevice.TryOpen(out moRFeusStream))
            {
                moRFeusStream.ReadTimeout = Timeout.Infinite;

                // HIDSharp setup
                reportBuffer = new byte[moRFeusDevice.GetMaxInputReportLength()];
                ReportDescriptor reportDescriptor = moRFeusDevice.GetReportDescriptor();
                reportReceiver = reportDescriptor.CreateHidDeviceInputReceiver();

                // Receive event handling
                //reportReceiver.Received += ReportReceived;
                reportReceiver.Start(moRFeusStream);
                
                // Disconnect event handling
                moRFeusStream.Closed += new EventHandler(Disconnected);

                // Indicate successful connection
                Tools.Debug("Connected to moRFeus");
                Program.MainClass.StatusMessage = "Connected to moRFeus";
                Program.MainClass.EnableUI();
                moRFeusOpen = true;

                // Initial polling of device values
                Task.Delay(10).ContinueWith(t => Program.MainClass.PollDevice());
            }
        }

        /// <summary>
        /// Handle report received from HID
        /// </summary>
        private void ReportReceived(object sender, EventArgs e)
        {
            // Read report into buffer
            while (reportReceiver.TryRead(reportBuffer, 0, out Report report))
            {
                moRFeus.ParseReport(reportBuffer);
            }
        }

        /// <summary>
        /// Write HID report to HID stream
        /// </summary>
        public void WriteHIDReport(byte[] report)
        {
            if (moRFeusOpen)
            {
                try
                {
                    moRFeusStream.Write(report);
                }
                catch (System.IO.IOException e)
                {
                    Disconnected(null, null);
                }
            }
        }

        /// <summary>
        /// Receive HID report from device
        /// </summary>
        /// <returns>Report byte buffer</returns>
        public byte[] ReceiveHIDReport()
        {
            // Wait for report to be available, then read into buffer
            while (!reportReceiver.TryRead(reportBuffer, 0, out Report report))
            {
                Thread.Sleep(10);
            }

            // Return report buffer
            return reportBuffer;
        }

        /// <summary>
        /// On device disconnect
        /// </summary>
        private void Disconnected(object sender, EventArgs e)
        {
            // Only recoonect on IOException in WriteHIDReport
            if (sender is null)
            {
                moRFeusOpen = false;
                moRFeusDetected = false;

                Program.MainClass.StatusMessage = "Lost connection to moRFeus";
                Tools.Debug("\nLost connection to moRFeus");

                string msg = "Lost connection to moRFeus\nWill attempt to reconect";
                System.Windows.Forms.MessageBox.Show(msg, "moRFeus connection", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                // Determine if moRFeus sill present
                Thread.Sleep(1000);
                Tools.Debug("Re-detecting moRFeus...");
                moRFeusDevice = null;
                moRFeusDevice = DetectHID(vid, pid);

                // Indicate connection status
                if (moRFeusDevice is null)
                {
                    System.Windows.Forms.MessageBox.Show("Failed to reconnect to moRFeus", "moRFeus connection", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    Tools.Debug("No moRFeus found, re-detect failed\n");
                }
                else
                {
                    Program.MainClass.StatusMessage = "Found moRFeus";
                    Tools.Debug("Found moRFeus: " + moRFeusDevice.DevicePath.ToString());
                    moRFeusDetected = true;

                    ConfigDevice();
                }
            }
        }

        #region Properties
        /// <summary>
        /// Is moRFeus device present
        /// </summary>
        public bool moRFeusDetected { get; set; } = false;

        /// <summary>
        /// Is moRFeus HID stream open
        /// </summary>
        public bool moRFeusOpen { get; set; } = false;
        #endregion
    }
}
