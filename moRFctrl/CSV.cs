using System;
using System.IO;

namespace moRFctrl
{
    /// <summary>
    /// CSV file IO handler
    /// </summary>
    static class CSV
    {
        /// <summary>
        /// Create CSV file, configure StreamWriter and write header
        /// </summary>
        /// <param name="path">Full file path</param>
        /// <returns>StreamWriter</returns>
        public static StreamWriter Create(string path)
        {
            // Create file
            StreamWriter sw = File.CreateText(path);
            sw.AutoFlush = true;

            // Write header
            //sw.WriteLine("Frequency (Hz),Strength (dBFS)");

            return sw;
        }

        /// <summary>
        /// Writes frequency/strength pair to CSV file
        /// </summary>
        /// <param name="sw">CSV StreamWriter</param>
        /// <param name="freq">Frequency in Hertz</param>
        /// <param name="snr">Strength in dBFS</param>
        /// <returns>True on success</returns>
        public static bool Write(StreamWriter sw, ulong freq, string snr)
        {
            try
            {
                sw.WriteLine(freq.ToString() + "," + snr);

                return true;
            }
            catch (Exception e)
            {
                Tools.Log("Error writing to CSV file: " + e.Message);

                return false;
            }
        }

        /// <summary>
        /// Close CSV file
        /// </summary>
        /// <param name="sw">CSV StreamWriter</param>
        public static void Close(StreamWriter sw)
        {
            sw.Close();
        }

        #region Utility
        /// <summary>
        /// Checks directory exists
        /// </summary>
        /// <param name="path">Full file path</param>
        /// <returns>True if directory exists</returns>
        public static bool DirectoryExists(string path)
        {
            return Directory.Exists(Path.GetDirectoryName(path));
        }

        /// <summary>
        /// Checks file exists
        /// </summary>
        /// <param name="path">Full file path</param>
        /// <returns>True if exists</returns>
        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }
        #endregion
    }
}
