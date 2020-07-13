using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ElGamal
{
    class ElGamalDigitalSignature
    {
        public BigInteger P { get; set; }
        public BigInteger G { get; set; }
        public BigInteger X { get; set; }
        public BigInteger Y { get; set; }
        public BigInteger K { get; set; }

        public ElGamalDigitalSignature(BigInteger p, BigInteger g, BigInteger y)
        {
            P = p;
            G = g;
            Y = y;
        }

        public ElGamalDigitalSignature(BigInteger p, BigInteger g, BigInteger x, BigInteger k)
        {
            P = p;
            G = g;
            X = x;
            K = k;
        }


        public bool CheckSignature(BigInteger msg, BigInteger r, BigInteger s, BigInteger q)
        {
            BigInteger left, right;
            left = (BigInteger.ModPow(Y, r, P) * BigInteger.ModPow(r, BigInteger.Abs(s), P)) % P;
            right = BigInteger.ModPow(G,msg, P);
  
            return left == right;
        }

        public BigInteger[] GetDigital(BigInteger msg, BigInteger q)
        { 
            BigInteger[] result = new BigInteger[2];
            result[0] = BigInteger.ModPow(G, K, P);
            result[1] = K.ModInverse(q) * (msg  - X * result[0])  % (q);
            if (result[1] < 0)
                result[1] += q;
            return result;
        }

        public ElGamalDigitalSignature(int bytesSize)
        {
            P = SimpleNumbers.GetSimpleNumber(bytesSize);
            G = P.GetRoot();
            X = SimpleNumbers.GetRandomBigInteger(1, P - 1);
            Y = BigInteger.ModPow(G, X, P);
        }

        public BigInteger[] EnCrypt(BigInteger msg)
        {
            var sessionKey = SimpleNumbers.GetRandomBigInteger(1, P - 1);
            var a = BigInteger.ModPow(G, sessionKey, P);
            var b = (BigInteger.ModPow(Y, sessionKey, P) * msg) % P;
            return new BigInteger[] {a, b};
        }

        public BigInteger DeCrypt(BigInteger[] msg) => (BigInteger.ModPow(msg[0],X,P).ModInverse(P)*msg[1]) % P;
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

        public static BigInteger GetRoot(this BigInteger p)
        {
            List<BigInteger> fact = new List<BigInteger>();

            BigInteger phi = p - 1, n = phi;

            for (BigInteger i = 2; i * i <= n; ++i)
            {
                if (n % i == 0)
                {
                    fact.Add(i);
                    while (n % i == 0)
                        n /= i;
                }
            }

            if (n > 1)
                fact.Add(n);

            for (BigInteger res = 2; res <= p; ++res)
            {
                bool ok = true;
                for (int i = 0; i < fact.Count && ok; ++i)
                    ok &= BigInteger.ModPow(res, phi / fact[i], p) != 1;
                if (ok) return res;
            }
            return -1;
        }
    }

}
