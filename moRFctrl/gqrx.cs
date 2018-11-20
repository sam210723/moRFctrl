﻿using System;
using System.Collections.Generic;
using System.IO;
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
        private void Connect()
        {
            Console.WriteLine(string.Format("Connecting to GQRX ({0}:{1})", host, port));

            client = new TcpClient();
            client.BeginConnect(host, port, new AsyncCallback(Connected), null);

            //TODO: Handle disconnect
        }

        /// <summary>
        /// On successful TcpClient connection
        /// </summary>
        private void Connected(IAsyncResult ar)
        {
            Console.WriteLine(string.Format("Connected to GQRX ({0}:{1})", host, port));

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

        public int GetStrength()
        {
            if (IsConnected)
            {
                //TODO: Get signal strength and dump to CSV + UI
                return 0;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Send data out TCP socket
        /// </summary>
        private void Send(string data)
        {
            if (IsConnected)
            {
                Stream sendStrm = client.GetStream();
                ASCIIEncoding asciiEnc = new ASCIIEncoding();

                byte[] dataBytes = asciiEnc.GetBytes(data + Environment.NewLine);
                sendStrm.Write(dataBytes, 0, dataBytes.Length);
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