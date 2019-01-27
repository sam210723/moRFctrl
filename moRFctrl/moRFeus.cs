using System;
using System.Linq;

namespace moRFctrl
{
    /// <summary>
    /// moRFeus command handler
    /// </summary>
    static class moRFeus
    {
        static readonly byte[] typeGet = { 0x00, 0x72 };
        static readonly byte[] typeSet = { 0x00, 0x77 };
        static readonly byte[] paramFreq = { 0x81 };
        static readonly byte[] paramFunc = { 0x82 };
        static readonly byte[] paramMixI = { 0x83 };
        static readonly byte[] paramBias = { 0x84 };
        static readonly byte[] nullBytes = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        public static readonly int FUNC_MIXER = 0;
        public static readonly int FUNC_GENERATOR = 1;
        public static readonly int BIAS_OFF = 0;
        public static readonly int BIAS_ON = 1;

        #region Set
        /// <summary>
        /// Set generator frequency
        /// </summary>
        /// <param name="freq">Frequency in Hz</param>
        public static void SetFrequency(ulong freq)
        {
            byte[] padded = nullPad(BitConverter.GetBytes(freq), 8);
            SendCommand(typeSet, paramFreq, padded);
        }

        /// <summary>
        /// Set mode (mixer/generator)
        /// </summary>
        public static void SetFunction(int func)
        {
            byte[] padded = nullPad(BitConverter.GetBytes(func), 8);
            SendCommand(typeSet, paramFunc, padded);
        }

        /// <summary>
        /// Set mixer current
        /// </summary>
        /// <param name="i">0 to 7</param>
        public static void SetMixerCurrent(int mixI)
        {
            byte[] padded = nullPad(BitConverter.GetBytes(mixI), 8);
            SendCommand(typeSet, paramMixI, padded);
        }

        /// <summary>
        /// Set bias tee (on/off)
        /// </summary>
        public static void SetBiasTee(int bias)
        {
            byte[] padded = nullPad(BitConverter.GetBytes(bias), 8);
            SendCommand(typeSet, paramBias, padded);
        }
        #endregion

        #region Get
        /// <summary>
        /// Get generator frequency
        /// </summary>
        public static ulong GetFrequency()
        {
            SendCommand(typeGet, paramFreq, nullBytes);

            ulong freq = ParseReport(Program.HIDClass.ReceiveHIDReport());
            return freq;
        }

        /// <summary>
        /// Get mode (mixer/generator)
        /// </summary>
        public static int GetFunction()
        {
            SendCommand(typeGet, paramFunc, nullBytes);

            int func = (int) ParseReport(Program.HIDClass.ReceiveHIDReport());
            return func;
        }

        /// <summary>
        /// Get mixer current
        /// </summary>
        public static int GetMixerCurrent()
        {
            SendCommand(typeGet, paramMixI, nullBytes);

            int mixI = (int) ParseReport(Program.HIDClass.ReceiveHIDReport());
            return mixI;
        }

        /// <summary>
        /// Get bias tee (on/off)
        /// </summary>
        public static bool GetBiasTee()
        {
            SendCommand(typeGet, paramBias, nullBytes);

            int bias = (int) ParseReport(Program.HIDClass.ReceiveHIDReport());

            if (bias == BIAS_OFF)
            {
                return false;
            }
            else if (bias == BIAS_ON)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Get all parameters
        /// </summary>
        public static moRFeusState GetAll()
        {
            moRFeusState state = new moRFeusState();

            state.Frequency = GetFrequency();
            state.Function = GetFunction();
            state.MixerCurrent = GetMixerCurrent();
            state.BiasTee = GetBiasTee();

            return state;
        }
        #endregion

        /// <summary>
        /// Pasrse HID input report
        /// </summary>
        /// <param name="r">Input report</param>
        public static ulong ParseReport(byte[] report)
        {
            Tools.Debug("\nFrom HID:");
            Tools.Debug("Raw: " + BitConverter.ToString(report).Replace("-", string.Empty));
            Tools.Debug("Length: " + report.Length);

            // Report fields
            byte type = report[1];
            byte param = report[2];
            byte[] value = new byte[8];
            Array.Copy(report, 3, value, 0, 8);

            // Detect report type
            if (type == typeGet[1])
            {
                Tools.Debug("Type: GET");
            }
            else if (type == typeSet[1])
            {
                Tools.Debug("Type: SET");
            }

            // Detect parameter
            if (param == paramFreq[0])
            {
                Tools.Debug("Parameter: FREQUENCY");

                ulong freq = BitConverter.ToUInt64(value.Reverse().ToArray(), 0);
                Tools.Debug("Value: " + freq + " Hz");
                
                return freq;
            }
            else if (param == paramFunc[0])
            {
                Tools.Debug("Parameter: FUNCTION");

                ulong func = BitConverter.ToUInt64(value.Reverse().ToArray(), 0);

                if (func == (ulong) FUNC_GENERATOR)
                {
                    Tools.Debug("Value: GENERATOR");
                }
                else if (func == (ulong) FUNC_MIXER)
                {
                    Tools.Debug("Value: MIXER");
                }

                return func;
            }
            else if (param == paramMixI[0])
            {
                Tools.Debug("Parameter: MIXER CURRENT");

                ulong mixI = BitConverter.ToUInt64(value.Reverse().ToArray(), 0);
                Tools.Debug("Value: " + mixI + "/7");

                return mixI;
            }
            else if (param == paramBias[0])
            {
                Tools.Debug("Parameter: BIAS TEE");

                ulong bias = BitConverter.ToUInt64(value.Reverse().ToArray(), 0);

                if (bias == (ulong) BIAS_OFF)
                {
                    Tools.Debug("Value: OFF");
                }
                else if (bias == (ulong) BIAS_ON)
                {
                    Tools.Debug("Value: ON");
                }

                return bias;
            }

            return 65535;
        }

        /// <summary>
        /// Build moRFeus protocol command and send as HID report
        /// </summary>
        private static void SendCommand(byte[] type, byte[] param, byte[] val)
        {
            byte[] pad = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] cmd = new byte[type.Length + param.Length + val.Length + pad.Length];

            Buffer.BlockCopy(type, 0, cmd, 0, type.Length);
            Buffer.BlockCopy(param, 0, cmd, type.Length, param.Length);
            Buffer.BlockCopy(val, 0, cmd, type.Length + param.Length, val.Length);
            Buffer.BlockCopy(pad, 0, cmd, type.Length + param.Length + val.Length, pad.Length);

            Tools.Debug("\nTo HID:");
            Tools.Debug("Raw: " + BitConverter.ToString(cmd).Replace("-", string.Empty));
            Tools.Debug("Length: " + cmd.Length);

            // Detect report type
            if (type == typeGet)
            {
                Tools.Debug("Type: GET");
            }
            else if (type == typeSet)
            {
                Tools.Debug("Type: SET");
            }

            // Detect parameter
            if (param == paramFreq)
            {
                Tools.Debug("Parameter: FREQUENCY");

                ulong freq = BitConverter.ToUInt64(val.Reverse().ToArray(), 0);
                Tools.Debug("Value: " + freq + " Hz");
            }
            else if (param == paramFunc)
            {
                Tools.Debug("Parameter: FUNCTION");
            }
            else if (param == paramMixI)
            {
                Tools.Debug("Parameter: MIXER CURRENT");
            }
            else if (param == paramBias)
            {
                Tools.Debug("Parameter: BIAS TEE");
            }

            Program.HIDClass.WriteHIDReport(cmd);
        }

        #region Tools
        /// <summary>
        /// Create padded byte array
        /// </summary>
        /// <returns>Byte array</returns>
        static byte[] nullPad(byte[] value, int len)
        {
            byte[] nullByte = { 0x00 };
            byte[] padded = new byte[len];

            // Create padding
            for (int i = value.Length; i < len; i++)
            {
                Buffer.BlockCopy(nullByte, 0, padded, 0, nullByte.Length);
            }

            // Add value to padding
            Buffer.BlockCopy(value, 0, padded, 0, value.Length);

            return padded.Reverse().ToArray();
        }
        #endregion
    }


    /// <summary>
    /// Status of all parameters in one struct
    /// </summary>
    public struct moRFeusState
    {
        public ulong Frequency;
        public int Function;
        public int MixerCurrent;
        public bool BiasTee;

        public moRFeusState(ulong freq, int func, int mixi, bool bias)
        {
            Frequency = freq;
            Function = func;
            MixerCurrent = mixi;
            BiasTee = bias;
        }
    }
}
