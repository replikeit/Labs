using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast_128
{
    public static class BitsOperations
    {
        public static BitArray GetBitArray(uint[] arr)
        {
            BitArray bitArr = new BitArray(BitConverter.GetBytes(arr[0]));

            for (int i = 1; i < arr.Length; i++)
            {
                bitArr = Append(bitArr, new BitArray(BitConverter.GetBytes(arr[i])));
            }

            return bitArr;
        }

        public static BitArray Append(BitArray current, BitArray after)
        {
            var bools = new bool[current.Count + after.Count];
            current.CopyTo(bools, 0);
            after.CopyTo(bools, current.Count);
            return new BitArray(bools);
        }

        public static byte[] ConvertToByte(BitArray bits)
        {
            if (bits.Count % 8 != 0)
                throw new ArgumentException("bits");

            int size = bits.Length / 8;

            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }

        public static uint[] GetIntArr(BitArray bits)
        {
            if (bits.Count % 32 != 0)
                throw new ArgumentException("bits");

            byte[] arrBytes = ConvertToByte(bits);
            int size = bits.Length / 32;
            uint[] resArr = new uint[size];

            for (int i = 0; i < size; i++)
            {
                resArr[i] = (uint)BitConverter.ToInt32(arrBytes, i * 4);
            }

            return resArr;
        }
    }
}
