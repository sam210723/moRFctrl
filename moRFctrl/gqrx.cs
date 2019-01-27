using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace moRFctrl
{
    /// <summary>
    /// Handles communication with Gqrx
    /// </summary>
    class gqrx
    {
        TcpClient tcpClient;
        Stream tcpStream;
        ASCIIEncoding asciiEnc = new ASCIIEncoding();

        readonly string CMD_FREQUENCY = "F";
        readonly string CMD_DEMODULATOR = "M";
        readonly string CMD_STRENGTH = "l";

        /// <summary>
        /// Open socket to Gqrx
        /// </summary>
        public void Connect(string host)
        {
            Host = host;
            Port = 7356;
            Tools.Debug(string.Format("Connecting to Gqrx ({0}:{1})", Host, Port));

            // Open TCP socket to Gqrx remote control
            tcpClient = new TcpClient();
            tcpClient.BeginConnect(Host, Port, new AsyncCallback(Connected), null);
        }

        /// <summary>
        /// Close socket
        /// </summary>
        public void Disconnect()
        {
            tcpClient.Close();
            tcpClient.Dispose();
        }

        /// <summary>
        /// On successful TCP connection
        /// </summary>
        private void Connected(IAsyncResult ar)
        {
            Tools.Debug(string.Format("Connected to Gqrx ({0}:{1})", Host, Port));

            tcpStream = tcpClient.GetStream();

            // Initial Gqrx config
            //SetDemod("CW");
        }

        /// <summary>
        /// Set demodulator frequency
        /// </summary>
        /// <param name="freq">Frequency in Hz</param>
        /// <returns>Command result</returns>
        public void SetFrequency(UInt64 freq)
        {
            Send(CMD_FREQUENCY, freq.ToString());
        }

        /// <summary>
        /// Set demodulator mode
        /// </summary>
        /// <param name="demod">Demodulator type string</param>
        /// <returns>Command result</returns>
        public void SetDemod(string demod)
        {
            Send(CMD_DEMODULATOR, demod);
        }

        /// <summary>
        /// Get carrier strength in dBFS
        /// </summary>
        /// <returns>Carrier strength as string</returns>
        public string GetStrength()
        {
            return Get(CMD_STRENGTH);
        }

        /// <summary>
        /// Set Gqrx parameter
        /// </summary>
        private void Send(string cmd, string data)
        {
            if (IsConnected)
            {
                byte[] dataBytes = asciiEnc.GetBytes(cmd + " " + data + Environment.NewLine);

                try
                {
                    tcpStream.Write(dataBytes, 0, dataBytes.Length);
                }
                catch (IOException e)
                {
                    tcpClient.Close();
                    tcpClient.Dispose();

                    System.Windows.Forms.MessageBox.Show("Lost connection to Gqrx", "Gqrx connection", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                    // Stop the current sequence
                    Program.MainClass.DoSweep();
                    Program.MainClass.EnableUI();
                }
            }
        }

        /// <summary>
        /// Get Gqrx parameter
        /// </summary>
        private string Get(string cmd)
        {
            if (IsConnected)
            {
                Send(cmd, null);

                byte[] recBuf = new byte[64];
                string responseData = "";

                int bytes = tcpClient.GetStream().Read(recBuf, 0, recBuf.Length);
                responseData = Encoding.ASCII.GetString(recBuf, 0, bytes);

                return responseData;
            }
            else
            {
                return string.Empty;
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
                    return tcpClient.Connected;
                }
                catch (NullReferenceException e)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gqrx host IP address
        /// </summary>
        public string Host { get; private set; }

        /// <summary>
        /// Gqrx remote control port
        /// </summary>
        public int Port { get; private set; }
        #endregion
    }
}
