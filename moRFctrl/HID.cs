using HidSharp;
using HidSharp.Reports;
using HidSharp.Reports.Encodings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace moRFctrl
{
    /// <summary>
    /// Handles HID detection and communication
    /// </summary>
    class HID
    {
        DeviceList devList;
        HidDevice[] hidList;
        bool _moRFeusDetected = false;
        bool _moRFeusOpen = false;
        HidDevice moRFeusDevice;
        HidStream moRFeusStream;

        public HID()
        {
            Console.WriteLine("\nDetecting HIDs");

            // Get list of HIDs
            devList = DeviceList.Local;
            hidList = devList.GetHidDevices().ToArray();

            // Loop through HID list
            foreach (HidDevice dev in hidList)
            {
                // Check for moRFeus IDs
                if (dev.VendorID == 4292 && dev.ProductID == 60105)
                {
                    moRFeusDetected = true;
                    moRFeusDevice = dev;
                }
            }

            // Indicate connection status
            if (moRFeusDetected)
            {
                Program.MainClass.StatusMessage = "Found Othernet moRFeus";
                Console.WriteLine("Found Othernet moRFeus: ");
                Console.WriteLine(moRFeusDevice.DevicePath + "\n");

                ConfigDevice();
            }
            else
            {
                Program.MainClass.StatusMessage = "No Othernet moRFeus found";
                Console.WriteLine("No Othernet moRFeus found\n");
            }
        }

        /// <summary>
        /// Begin communication with moRFeus
        /// </summary>
        private void ConfigDevice()
        {
            HidStream hidStream;
            if (moRFeusDevice.TryOpen(out hidStream))
            {
                Console.WriteLine("Opened HID stream");
                hidStream.ReadTimeout = Timeout.Infinite;

                moRFeusStream = hidStream;
                moRFeusOpen = true;
            }
        }

        /// <summary>
        /// Write HID report to HID stream
        /// </summary>
        public void WriteHIDReport(byte[] report)
        {
            if (moRFeusOpen)
            {
                moRFeusStream.Write(report);
            }
        }

        #region Properties
        /// <summary>
        /// Is moRFeus device present
        /// </summary>
        public bool moRFeusDetected
        {
            get
            {
                return _moRFeusDetected;
            }

            set
            {
                _moRFeusDetected = value;
            }
        }
        
        /// <summary>
        /// Is moRFeus HID stream open
        /// </summary>
        public bool moRFeusOpen
        {
            get
            {
                return _moRFeusOpen;
            }

            set
            {
                _moRFeusOpen = value;
            }
        }
        #endregion
    }
}
