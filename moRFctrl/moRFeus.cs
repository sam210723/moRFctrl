using System;
using System.Linq;

namespace moRFctrl
{
    /// <summary>
    /// moRFeus command handler
    /// </summary>
    static class moRFeus
    {
        static byte[] typeGet = { 0x00, 0x72 };
        static byte[] typeSet = { 0x00, 0x77 };
        static byte[] paramFreq = { 0x81 };
        static byte[] paramFunc = { 0x82 };
        static byte[] paramMixI = { 0x83 };
        static byte[] paramBias = { 0x84 };

        public static int FUNC_MIXER = 0;
        public static int FUNC_GENERATOR = 1;
        public static int BIAS_OFF = 0;
        public static int BIAS_ON = 1;

        #region Set
        /// <summary>
        /// Set generator frequency
        /// </summary>
        /// <param name="freq">Frequency in Hz</param>
        public static void SetFrequency(UInt64 freq)
        {
            byte[] type = typeSet;
            byte[] param = paramFreq;
            byte[] val = BitConverter.GetBytes(freq);
            byte[] valPadded = new byte[8];

            // Create padded value array
            byte[] nullByte = { 0x00 };
            for (int i = val.Length; i < 8; i++)
            {
                Buffer.BlockCopy(nullByte, 0, valPadded, 0, nullByte.Length);
            }
            Buffer.BlockCopy(val, 0, valPadded, 0, val.Length);
            valPadded = valPadded.Reverse().ToArray();

            SendCommand(type, param, valPadded);
        }

        /// <summary>
        /// Set mode (mixer/generator)
        /// </summary>
        public static void SetFunction(int func)
        {
            byte[] type = typeSet;
            byte[] param = paramFunc;

            if (func == FUNC_MIXER)
            {
                byte[] val = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                SendCommand(type, param, val);
            }
            else if (func == FUNC_GENERATOR)
            {
                byte[] val = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 };
                SendCommand(type, param, val);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Set mixer current
        /// </summary>
        /// <param name="i">0 to 7</param>
        public static void SetMixerCurrent(int mixI)
        {
            byte[] type = typeSet;
            byte[] param = paramMixI;
            byte[] val = BitConverter.GetBytes(mixI);
            byte[] valPadded = new byte[8];

            // Create padded value array
            byte[] nullByte = { 0x00 };
            for (int i = val.Length; i < 8; i++)
            {
                Buffer.BlockCopy(nullByte, 0, valPadded, 0, nullByte.Length);
            }
            Buffer.BlockCopy(val, 0, valPadded, 0, val.Length);
            valPadded = valPadded.Reverse().ToArray();

            SendCommand(type, param, valPadded);
        }

        /// <summary>
        /// Set bias tee (on/off)
        /// </summary>
        public static void SetBiasTee(int bias)
        {
            byte[] type = typeSet;
            byte[] param = paramBias;

            if (bias == BIAS_OFF)
            {
                byte[] val = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                SendCommand(type, param, val);
            }
            else if (bias == BIAS_ON)
            {
                byte[] val = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 };
                SendCommand(type, param, val);
            }
            else
            {
                return;
            }
        }
        #endregion

        #region Get
        /// <summary>
        /// Get generator frequency
        /// </summary>
        public static void GetFrequency()
        {
            byte[] val = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            SendCommand(typeGet, paramFreq, val);
        }

        /// <summary>
        /// Get mode (mixer/generator)
        /// </summary>
        public static void GetFunction()
        {
            byte[] val = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            SendCommand(typeGet, paramFunc, val);
        }

        /// <summary>
        /// Get mixer current
        /// </summary>
        public static void GetMixerCurrent()
        {
            byte[] val = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            SendCommand(typeGet, paramMixI, val);
        }

        /// <summary>
        /// Get bias tee (on/off)
        /// </summary>
        public static void GetBiasTee()
        {
            byte[] val = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            SendCommand(typeGet, paramBias, val);
        }
        #endregion

        /// <summary>
        /// Pasrse HID input report
        /// </summary>
        /// <param name="r">Input report</param>
        public static void ParseReport(byte[] r)
        {
            Console.WriteLine("\nFrom HID:");
            Console.WriteLine("Raw: " + BitConverter.ToString(r).Replace("-", string.Empty));
            Console.WriteLine("Length: " + r.Length);

            byte type = r[1];
            byte param = r[2];
            byte[] val = new byte[8];
            Array.Copy(r, 3, val, 0, 8);

            if (type == typeGet[1])
            {
                Console.WriteLine("Report Type: GET");
            }
            else if (type == typeSet[1])
            {
                Console.WriteLine("Report Type: SET");
                return;
            }

            if (param == paramFreq[0])
            {
                Console.WriteLine("Parameter: FREQUENCY");

                Program.MainClass.Frequency = BitConverter.ToInt64(val.Reverse().ToArray(), 0).ToString();
            }
            else if (param == paramFunc[0])
            {
                Console.WriteLine("Parameter: FUNCTION");

                Program.MainClass.Function = BitConverter.ToInt16(val.Reverse().ToArray(), 0);
            }
            else if (param == paramMixI[0])
            {
                Console.WriteLine("Parameter: MIXER CURRENT");

                Program.MainClass.MixerCurrent = BitConverter.ToInt16(val.Reverse().ToArray(), 0);
            }
            else if (param == paramBias[0])
            {
                Console.WriteLine("Parameter: BIAS TEE");

                if (BitConverter.ToInt16(val.Reverse().ToArray(), 0) == BIAS_OFF)
                {
                    Program.MainClass.BiasTee = false;
                }
                else
                {
                    Program.MainClass.BiasTee = true;
                }
            }

            Console.WriteLine("Value: " + BitConverter.ToString(val).Replace("-", string.Empty));
        }

        /// <summary>
        /// Build moRFeus protocol command and send as HID report
        /// </summary>
        static void SendCommand(byte[] type, byte[] param, byte[] val)
        {
            byte[] pad = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] cmd = new byte[type.Length + param.Length + val.Length + pad.Length];

            Buffer.BlockCopy(type, 0, cmd, 0, type.Length);
            Buffer.BlockCopy(param, 0, cmd, type.Length, param.Length);
            Buffer.BlockCopy(val, 0, cmd, type.Length + param.Length, val.Length);
            Buffer.BlockCopy(pad, 0, cmd, type.Length + param.Length + val.Length, pad.Length);

            Console.WriteLine("\nTo HID:");
            Console.WriteLine("Raw: " + BitConverter.ToString(cmd).Replace("-", string.Empty));
            Console.WriteLine("Length: " + cmd.Length);
            Program.HIDClass.WriteHIDReport(cmd);
        }
    }
}
