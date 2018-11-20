using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace moRFctrl
{
    /// <summary>
    /// Handles communication with GQRX
    /// </summary>
    class gqrx
    {
        private TcpClient client;
        private string host = "127.0.0.1";
        private int port = 7356;

        public gqrx()
        {
            Connect();
        }

        /// <summary>
        /// Open socket to GQRX
        /// </summary>
        /// <returns>Connection result</returns>
        private void Connect()
        {
            Console.WriteLine(string.Format("Connecting to GQRX ({0}:{1})", host, port));

            client = new TcpClient();
            client.BeginConnect(host, port, new AsyncCallback(Connected), null);
        }

        /// <summary>
        /// On successful TcpClient connection
        /// </summary>
        private void Connected(IAsyncResult ar)
        {
            Console.WriteLine(string.Format("Connected to GQRX ({0}:{1})", host, port));
        }

        public bool SetFrequency(UInt64 freq)
        {
            if (IsConnected)
            {
                return true;
            }
            else {
                return false;
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
                if (client != null)
                {
                    return client.Connected;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion
    }
}
