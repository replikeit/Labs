using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ElGamal
{
    static class SimpleNumbers
    {
        public static BigInteger GetRandomBigInteger(BigInteger min, BigInteger max)
        {
            byte[] bytes = max.ToByteArray();
            BigInteger R;

            new Random().NextBytes(bytes);
            R = 1 + BigInteger.Abs(new BigInteger(bytes)) % max;

            return R;
        }

        public static BigInteger GetSimpleNumber(int numSize)
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
                        if (simple.ToByteArray().Length >= numSize)
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
