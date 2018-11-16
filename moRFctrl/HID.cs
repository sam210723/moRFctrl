using HidSharp;
using HidSharp.Reports;
using HidSharp.Reports.Encodings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        HidDevice moRFeusDevice;

        public HID()
        {
            Console.WriteLine("\nDetecting HIDs");

            devList = DeviceList.Local;
            hidList = devList.GetHidDevices().ToArray();

            foreach (HidDevice dev in hidList)
            {
                if (dev.VendorID == 4292 && dev.ProductID == 60105)
                {
                    moRFeusDetected = true;
                    moRFeusDevice = dev;
                }
            }

            if (moRFeusDetected)
            {
                Program.MainClass.StatusMessage = "Found Othernet moRFeus";
                Console.WriteLine("Found Othernet moRFeus: ");
                Console.WriteLine(moRFeusDevice.DevicePath + "\n");
            }
            else
            {
                Program.MainClass.StatusMessage = "No Othernet moRFeus found";
                Console.WriteLine("No Othernet moRFeus found\n");
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
        #endregion
    }
}
