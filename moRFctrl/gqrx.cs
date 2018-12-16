using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace moRFctrl
{
    /// <summary>
    /// Handles communication with Gqrx
    /// </summary>
    class gqrx
    {
        private TcpClient client;
        private string host_ = "127.0.0.1";
        private int port = 7356;

        /// <summary>
        /// Open socket to Gqrx
        /// </summary>
        public void Connect(string host)
        {
            host_ = host;
            Console.WriteLine(string.Format("Connecting to Gqrx ({0}:{1})", host_, port));

            // Open TCP socket to Gqrx remote control
            client = new TcpClient();
            client.BeginConnect(host_, port, new AsyncCallback(Connected), null);
        }

        /// <summary>
        /// Close socket
        /// </summary>
        public void Disconnect()
        {
            client.Close();
            client.Dispose();
        }

        /// <summary>
        /// On successful TcpClient connection
        /// </summary>
        private void Connected(IAsyncResult ar)
        {
            Console.WriteLine(string.Format("Connected to Gqrx ({0}:{1})", host_, port));

            // Initial config
            //SetDemod("AM");
        }

        /// <summary>
        /// Set demodulator frequency
        /// </summary>
        /// <param name="freq">Frequency in Hz</param>
        /// <returns>Command result</returns>
        public bool SetFrequency(UInt64 freq)
        {
            if (IsConnected)
            {
                Send("F " + freq.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Set demodulator mode
        /// </summary>
        /// <param name="demod">Demodulator type string</param>
        /// <returns>Command result</returns>
        public bool SetDemod(string demod)
        {
            if (IsConnected)
            {
                Send("M " + demod);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Get carrier strength in dBFS
        /// </summary>
        /// <returns>Carrier strength as string</returns>
        public string GetStrength()
        {
            return Get("l");
        }

        /// <summary>
        /// Set Gqrx parameter
        /// </summary>
        private void Send(string data)
        {
            if (IsConnected)
            {
                Stream sendStrm = client.GetStream();
                ASCIIEncoding asciiEnc = new ASCIIEncoding();

                byte[] dataBytes = asciiEnc.GetBytes(data + Environment.NewLine);

                try
                {
                    sendStrm.Write(dataBytes, 0, dataBytes.Length);
                }
                catch (IOException e)
                {
                    client.Close();
                    client.Dispose();
                    System.Windows.Forms.MessageBox.Show("Lost connection to Gqrx", "Gqrx connection", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    Program.MainClass.EnableUI();
                    Program.MainClass.DoSweep();  // Stop the current sequence
                }
            }
        }

        /// <summary>
        /// Get Gqrx parameter
        /// </summary>
        private string Get(string data)
        {
            if (IsConnected)
            {
                Send(data);

                Byte[] recv = new Byte[64];
                String responseData = "";

                Int32 bytes = client.GetStream().Read(recv, 0, recv.Length);
                responseData = System.Text.Encoding.ASCII.GetString(recv, 0, bytes);

                return responseData;
            }
            else
            {
                return String.Empty;
            }
        }

        #region Properties
        /// <summary>
        /// Socket connection status
        /// </summary>
        public bool IsConnected
        {
            get
            {
                try
                {
                    return client.Connected;
                }
                catch (NullReferenceException e)
                {
                    return false;
                }
            }
        }
        #endregion
    }
}
