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
        public bool moRFeusPresent = false;
        HidDevice moRfeusDevice;

        public HID()
        {
            Console.WriteLine("\nDetecting HIDs");

            devList = DeviceList.Local;
            hidList = devList.GetHidDevices().ToArray();

            foreach (HidDevice dev in hidList)
            {
                if (dev.VendorID == 4292 && dev.ProductID == 60105)
                {
                    moRFeusPresent = true;
                    moRfeusDevice = dev;
                }
            }

            if (moRFeusPresent)
            {
                Console.WriteLine("Found Othernet moRFeus: ");
                Console.WriteLine(moRfeusDevice.DevicePath + "\n");
            }
            else
            {
                Console.WriteLine("No Othernet moRfeus found\n");
            }
        }
    }
}
