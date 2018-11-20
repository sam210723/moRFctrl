using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moRFctrl
{
    /// <summary>
    /// Controls frequency generator sweep
    /// </summary>
    class Sweep
    {
        /// <summary>
        /// Begin frequency sweep
        /// </summary>
        /// <param name="start">Start frequency (Hz)</param>
        /// <param name="stop">Stop frequencu (Hz)</param>
        /// <param name="step">Step size (Hz)</param>
        /// <param name="dwell">Dwell time (s)</param>
        public Sweep(UInt64 start, UInt64 stop, UInt64 step, double dwell)
        {
            Console.WriteLine("\nSTARTING SWEEP");
            Console.Write(string.Format("Start:  {0} Hz\nStop:   {1} Hz\nStep:   {2} Hz\nDwell:  {3}s\n\n", start, stop, step, dwell));


        }

        /// <summary>
        /// Calculate time for sweep to complete
        /// </summary>
        /// <param name="start">Start frequency (Hz)</param>
        /// <param name="stop">Stop frequencu (Hz)</param>
        /// <param name="step">Step size (Hz)</param>
        /// <param name="dwell">Dwell time (s)</param>
        /// <returns>Sweep time in seconds</returns>
        public static double Time(UInt64 start, UInt64 stop, UInt64 step, double dwell)
        {
            UInt64 bandwidth = stop - start;
            UInt64 steps = bandwidth / step;
            double span = dwell * steps;

            return span;
        }
    }
}
