using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using MathNet.Numerics;
    
namespace RSA
{
    class RSA
    {
        public BigInteger[] OpenKey { get; }
        public BigInteger[] CloseKey { get; }

        public RSA(BigInteger p, BigInteger q)
        {
            BigInteger n = p * q;
            BigInteger fi = EulerFunction(p, q);
            BigInteger openExp = GetOpenExp(fi);
            BigInteger d;

            d = openExp.ModInverse(fi);

            OpenKey = new BigInteger[]{ openExp, n};
            CloseKey = new BigInteger[] { d, n };
        }

        
        private static BigInteger EulerFunction(BigInteger p, BigInteger q) => (p - 1) * (q - 1);

        private BigInteger GetOpenExp(BigInteger fi)
        {
            int size = fi.ToByteArray().Length;
            BigInteger result = SimpleNumbers.GetSimpleNumber(size, fi);
            return result;
        }

        public BigInteger EnCrypt(BigInteger num)=> BigInteger.ModPow(num, OpenKey[0], OpenKey[1]);

        public BigInteger DeCrypt(BigInteger num) => BigInteger.ModPow(num, CloseKey[0], CloseKey[1]);

    }

    static class BigIntExtension
    {
        public static BigInteger ModInverse(this BigInteger a, BigInteger n)
        {
            BigInteger i = n, v = 0, d = 1;
            while (a > 0)
            {
                BigInteger t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;
            return v;
        }
    }
}
