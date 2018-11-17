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

        /// <summary>
        /// Set generator frequency
        /// </summary>
        /// <param name="freq">Frequency in Hz</param>
        public static void SetFrequency(int freq)
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

            Console.WriteLine(BitConverter.ToString(cmd).Replace("-", string.Empty));
            Console.WriteLine(cmd.Length);
            Program.HIDClass.WriteHIDReport(cmd);
        }
    }
}
