using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {

        private static BigInteger GetBigSimple()
        {
            byte []byteArr = new byte[32];
            new Random().NextBytes(byteArr);

            BigInteger bigInt = BigInteger.Abs(new BigInteger(byteArr));

            while (!FermaTest(bigInt) && !SoloveyShtrassenTest(bigInt) && !MillerRabinTest(bigInt))
            {
                bigInt++;
            }

            return bigInt;
        }

        static BigInteger Jacobian(BigInteger a, BigInteger b)
        {

            if (a.IsEven)
                return Jacobian(a / 2, b) * CheckIsEven((b * b - 1) / 8);

            if (a == 1)
                return 1;

            if (a < b)
                return CheckIsEven((a - 1) * (b - 1) / 4) * Jacobian(b, a);

            return Jacobian(a % b, b);
        }

        private static int CheckIsEven(BigInteger temp)
        {
            return temp.IsEven ? 1 : -1;
        }

        static List<long> Sieve(int n)
        {
        
            bool[] boolArr = new bool[n];
            List<long> resArr = new List<long>();
            for (int i = 0; i < n; i++)
            {
                boolArr[i] = true;
            }

            for (int i = 2; i <= n; i++)
            {
                if (boolArr[i-2])
                {
                    int x = 2;
                    for (int j = i * x; j <= n; j=i*(++x))
                    {
                        boolArr[j-2] = false;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                if(boolArr[i])
                    resArr.Add(i+2);   
            }
            return resArr;
        }

        public static BigInteger GetRandomBigInteger(BigInteger min, BigInteger max)
        {
            byte[] bytes = max.ToByteArray();
            BigInteger R;

            new Random().NextBytes(bytes);
            R = 1 + BigInteger.Abs(new BigInteger(bytes)) % max;

            return R;
        }

        static bool FermaTest(BigInteger n)
        {
            if (n < 2)
                return false;
            if (n == 2)
                return true;
            if (n.IsEven)
                return false;

            for (int i = 1; i < 1000; i++)
            {
                BigInteger a = GetRandomBigInteger(2,n - 1);
                if (BigInteger.ModPow(i,n-1,n) != 1)
                {
                    if (i % n != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static bool SoloveyShtrassenTest(BigInteger n)
        {
            if (n < 2)
                return false;
            if (n == 2)
                return true;
            if (n.IsEven)
                return false;

            for (int i = 0; i < 10; i++)
            {
                BigInteger a = GetRandomBigInteger(2, n - 1);
                if (BigInteger.GreatestCommonDivisor(a, n) != 1)
                    return false;
                BigInteger mod = BigInteger.ModPow(a, (n - 1) / 2, n);
                BigInteger jacob = Jacobian(a, n);
                if (jacob < 0)
                    jacob += n;
                if (mod != jacob)
                    return false;
            }
            return true;
        }

        static bool MillerRabinTest(BigInteger n)
        {
            if (n < 2)
                return false;
            if (n == 2)
                return true;
            if (n.IsEven)
                return false;

            BigInteger r = 0, d = n - 1;
            while (d % 2 == 0)
            {
                d /= 2;
                r++;
            }

            var rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                BigInteger a = GetRandomBigInteger(2,n - 1);
                BigInteger x = BigInteger.ModPow(a, d, n);
                if (x == 1)
                    continue;
                for (int j = 0; j < r - 1; j++)
                {
                    if (x == n - 1)
                        break;
                    x = BigInteger.ModPow(x, 2, n);
                }
                if (x != n - 1)
                    return false;
            }
            return true;
        }

        static BigInteger DetermBigIntGeneration(BigInteger n)
        {
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
                        if (simple.ToByteArray().Length >= 256)
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

        
        static void Main(string[] args)
        {
            int n = 10000;
            List<long> simpleArr = Sieve(n);
            //Console.WriteLine("*****TABLE OF SIMPLE NUMBERS*****\n");
            //Console.Write($"{simpleArr[0]}");
            //for (int i = 1; i < simpleArr.Count; i++)
            //{
            //    Console.Write($"\t{simpleArr[i]}");
            //}

            //Console.WriteLine("\n\n*****TEST FERMA*****");
            //Random random = new Random();
            //for (int i = 0; i < 20; i++)
            //{
            //    int randNum = random.Next(simpleArr.Count - 1);

            //    long num = simpleArr[randNum];
            //    Console.WriteLine($"{num}:\t {FermaTest(num +2)}");
            //}

            //Console.WriteLine("\n\n*****MILLER - RABIN TEST*****");
            //for (int i = 0; i < 20; i++)
            //{
            //    int randNum = random.Next(simpleArr.Count - 1);

            //    long num = simpleArr[randNum];
            //    Console.WriteLine($"{num}:\t {MillerRabinTest(num+2)}");
            //}

            //Console.WriteLine("\n\n*****SOLOVEY - SHTRASSEN TEST*****");
            //for (int i = 0; i < 20; i++)
            //{
            //    int randNum = random.Next(simpleArr.Count - 1);

            //    long num = simpleArr[randNum];
            //    Console.WriteLine($"{num}:\t {SoloveyShtrassenTest(num + 2)}");
            //}


            int statCounter = 0;
            
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("\n*****DETERM GEN BIG SIMPLE INTEGER*****");
                
                BigInteger simple = DetermBigIntGeneration(simpleArr[new Random().Next(simpleArr.Count)]);
                Console.WriteLine(simple);

                //bool ss = SoloveyShtrassenTest(simple);
                //bool mr = MillerRabinTest(simple);
                //bool f = FermaTest(simple);

                //Console.WriteLine($"Solovey-Shtrassen test:\t {ss}");

                //Console.WriteLine($"Miller-Rabin test:\t {mr}");

                //Console.WriteLine($"ferma test:\t {f}");

                //if (ss && mr && f)
                //{
                //    statCounter++;
                //}
                //else
                //{
                //    int x = 0;
                //}
            }

            Console.WriteLine($"\n\nPercent of simple numbers: {statCounter}%");

            Console.ReadKey();
        }
    }
}   
