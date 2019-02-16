using System;
using System.IO;
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
        TcpClient tcpClient;
        NetworkStream tcpStream;
        ASCIIEncoding asciiEnc = new ASCIIEncoding();

        readonly string CMD_FREQUENCY = "F";
        readonly string CMD_DEMODULATOR = "M";
        readonly string CMD_STRENGTH = "l";

        string gqrxAddress = string.Format(" ({0}:{1})", Properties.Settings.Default.gqrx_host, Properties.Settings.Default.gqrx_port);

        #region Socket
        /// <summary>
        /// Open socket to Gqrx
        /// </summary>
        public void Connect(string host, int port)
        {
            Host = host;
            Port = port;
            Tools.Debug("Connecting to Gqrx" + gqrxAddress);

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
            try
            {
                tcpStream = tcpClient.GetStream();
            }
            catch (ObjectDisposedException e)
            {
                return;
            }

            Tools.Debug(string.Format("Connected to Gqrx ({0}:{1})", Host, Port));

            // Initial Gqrx config
            //SetDemod("CW");
        }

        /// <summary>
        /// Handle unexpected disconnect
        /// </summary>
        public void Disconnected()
        {
            tcpClient.Close();
            tcpClient.Dispose();
            //tcpClient = null;

            System.Windows.Forms.MessageBox.Show("Unable to connect to Gqrx" + gqrxAddress, "Gqrx connection", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            Program.MainClass.EnableSweepUI();
            Program.MainClass.StopSweep();
        }
        #endregion

        #region Set
        /// <summary>
        /// Set demodulator frequency
        /// </summary>
        /// <param name="freq">Frequency in Hz</param>
        public void SetFrequency(ulong freq)
        {
            Send(CMD_FREQUENCY, freq.ToString());
        }

        /// <summary>
        /// Set demodulator mode
        /// </summary>
        /// <param name="demod">Demodulator type string</param>
        public void SetDemod(string demod)
        {
            Send(CMD_DEMODULATOR, demod);
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

                    // Empty response from buffer
                    while (tcpStream.DataAvailable)
                    {
                        byte[] recBuf = new byte[64];
                        int bytes = tcpStream.Read(recBuf, 0, recBuf.Length);
                    }
                }
                catch (IOException e)
                {
                    Disconnected();
                }
            }
        }
        #endregion

        #region Get
        /// <summary>
        /// Get SDR frequency
        /// </summary>
        public ulong GetFrequency()
        {
            Console.WriteLine("GFREQ \"" + Get(CMD_FREQUENCY.ToLower() + "\"").Result);
            return ulong.Parse("0") * 100;
        }

        /// <summary>
        /// Get carrier strength in dBFS
        /// </summary>
        /// <returns>Carrier strength as string</returns>
        public string GetStrength()
        {
            return Get(CMD_STRENGTH).Result;
        }

        /// <summary>
        /// Get Gqrx parameter
        /// </summary>
        private async Task<string> Get(string cmd)
        {
            if (IsConnected)
            {
                Send(cmd, null);

                byte[] recBuf = new byte[64];
                string responseData = "";

                //await tcpStream.FlushAsync();

                try
                {
                    int bytes = tcpStream.Read(recBuf, 0, recBuf.Length);
                    responseData = Encoding.ASCII.GetString(recBuf, 0, bytes);
                    responseData = responseData.Replace("RPRT 0", "").Trim();
                }
                catch (IOException e)
                {
                    Disconnected();
                }

                return responseData;
            }
            else
            {
                return "DISCONNECTED";
            }
        }
        #endregion

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
