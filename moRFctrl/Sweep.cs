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
