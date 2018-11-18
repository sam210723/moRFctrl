using HidSharp;
using HidSharp.Reports;
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
                Program.MainClass.StatusMessage = "Found moRFeus";
                Console.WriteLine("Found moRFeus: ");
                Console.WriteLine(moRFeusDevice.DevicePath);

                ConfigDevice();
            }
            else
            {
                Program.MainClass.StatusMessage = "No moRFeus found";
                Console.WriteLine("No moRFeus found\n");
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
                moRFeusStream = hidStream;
                Console.WriteLine("Connected to moRFeus");
                Program.MainClass.StatusMessage = "Connected to moRFeus";
                moRFeusStream.ReadTimeout = Timeout.Infinite;


                byte[] inputReportBuffer = new byte[moRFeusDevice.GetMaxInputReportLength()];
                ReportDescriptor reportDescriptor = moRFeusDevice.GetReportDescriptor();
                HidSharp.Reports.Input.HidDeviceInputReceiver inputReceiver = reportDescriptor.CreateHidDeviceInputReceiver();

                inputReceiver.Received += (sender, e) =>
                {
                    Report report;
                    while (inputReceiver.TryRead(inputReportBuffer, 0, out report))
                    {
                        moRFeus.ParseReport(inputReportBuffer);
                    }
                };
                inputReceiver.Start(hidStream);
                
                moRFeusStream.Closed += new EventHandler(Disconnected);
                moRFeusOpen = true;

                // Initial polling of device values
                Task.Delay(10).ContinueWith(t => Program.MainClass.PollDevice());
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
        /// On device disconnect
        /// </summary>
        private void Disconnected(object sender, EventArgs e)
        {
            moRFeusOpen = false;
            Program.MainClass.StatusMessage = "Lost connection to moRFeus";
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
