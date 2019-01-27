using System;
using System.Linq;

namespace moRFctrl
{
    /// <summary>
    /// Common methods used in multiple classes
    /// </summary>
    static class Tools
    {
        /// <summary>
        /// Output string to console
        /// </summary>
        public static void Log(string s)
        {
            Console.WriteLine(s);
        }

        /// <summary>
        /// Output string to console only if debug output is enabled
        /// </summary>
        public static void Debug(string s)
        {
            if (Program.debugOutput)
            {
                Console.WriteLine(s);
            }
        }

        public static bool ValidateIPv4(string ip)
        {
            if (String.IsNullOrWhiteSpace(ip))
            {
                return false;
            }

            string[] splitValues = ip.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }
    }
}
