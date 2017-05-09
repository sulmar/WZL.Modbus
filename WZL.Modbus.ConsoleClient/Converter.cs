using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZL.Modbus.ConsoleClient
{
    public static class Converter
    {
        public static float ConvertToFloat(ushort lRegister, ushort hRegister)
        {
            byte l0 = (byte) lRegister;
            byte l1 = (byte)(lRegister >> 8);

            byte h0 = (byte) hRegister;
            byte h1 = (byte)(hRegister >> 8);

            byte[] bytes = new[] { h0, h1, l0, l1 };

            float result = BitConverter.ToSingle(bytes, 0);

            return result;

        }
    }
}
