using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Cast_128
{
    static class Program
    {
        private static string BitsToString(this BitArray arr)
        {
            int j = 0;
            return new string(new char[arr.Length * 2].Select((_, i) => (i % 2 == 0) ? (arr.Get(j++) ? '1' : '0') : ' ').Where((_,i) => i < arr.Count - 1).ToArray());
        }


        static void Main(string[] args)
        {
            //Crypto Test 
            var key = new uint[] {0x01234567, 0x12345678, 0x23456789, 0x3456789A};
            var msgBlock = new uint[] { 0x01234567, 0x89ABCDEF };

            BitArray bitArr = BitsOperations.GetBitArray(key);
            var cast = new Cast128(bitArr);
            var mes = cast.EnCrypt(BitsOperations.GetBitArray(msgBlock));

            Console.WriteLine($"{BitsOperations.GetIntArr(mes)[0].ToString("x8")}  {BitsOperations.GetIntArr(mes)[1].ToString("x8")}");
            mes = cast.DeCrypt(mes);
            Console.WriteLine($"{BitsOperations.GetIntArr(mes)[0].ToString("x8")}  {BitsOperations.GetIntArr(mes)[1].ToString("x8")}");

            //Longest Ones test: 0,18059
            Console.WriteLine(LongestRunOnesInBlock.Test("11001100000101010110110001001100111000000000001001001101010100010001001111010110100000001101011111001100111001101101100010110010"));
        }
    }
}
