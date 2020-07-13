using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cast_128
{
    public static class LongestRunOnesInBlock
    {
        private const int K = 3;
        private const int M = 8;
        private static readonly double[] probabilitiesArr =
        {
            0.2148,
            0.3672,
            0.2305,
            0.1875,
        };

        public static double Test(string str) =>
            Test(new BitArray(str.Select((x) => x == '1').ToArray()));

        public static double Test(BitArray bitArr)
        {
            int[] vArr = new int[4];

            int bitsLength = bitArr.Length;
            int N = bitsLength / M;

            for (int i = 0; i + 8 <= bitsLength; i+=8)
            {
                int maxOnesInBlock = 0;
                int counter = 0;

                for (int j = i; j < i + 8; j++)
                {
                    if (bitArr.Get(j))
                        counter++;
                    else
                        counter = 0;

                    if (maxOnesInBlock <= counter)
                        maxOnesInBlock = counter;
                }

                if (maxOnesInBlock <= 1) vArr[0]++;
                else if (maxOnesInBlock >= 4) vArr[3]++;
                else vArr[maxOnesInBlock - 1]++;
            }

            double hiSquare = 0;
            for (int i = 0; i < 4; i++)
            {
                hiSquare += Math.Pow(vArr[i] - N * probabilitiesArr[i], 2)/(N * probabilitiesArr[i]);
            }

            return SpecialFunction.igamc(K/2d, hiSquare/2);
        }
	}
}
