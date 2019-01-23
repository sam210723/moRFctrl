using System;

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
    }
}
