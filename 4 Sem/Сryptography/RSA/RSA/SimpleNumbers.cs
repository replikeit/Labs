using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    static class SimpleNumbers
    {
        public static BigInteger GetSimpleNumber(int numSize) => GetSimpleNumber(numSize, 1);  
        public static BigInteger GetSimpleNumber(int numSize, BigInteger fi)
        {
            BigInteger n = 2;
            int evenNum = 2;
            List<BigInteger> simplesArr = new List<BigInteger>();

            while (true)
            {
                BigInteger simple = n * evenNum + 1;
                if (simple < BigInteger.Pow(2 * n + 1, 2))
                {
                    if (BigInteger.ModPow(2, n * evenNum, simple) == 1 &&
                        BigInteger.ModPow(2, evenNum, simple) != 1)
                    {
                        simplesArr.Add(simple);
                        if (simple.ToByteArray().Length >= numSize && BigInteger.GreatestCommonDivisor(fi, simple) == 1)
                            return simple;
                        n = simple;
                        evenNum = 2;
                    }
                    else
                    {
                        evenNum += 2;
                    }
                }
            }
        }
    }
}
