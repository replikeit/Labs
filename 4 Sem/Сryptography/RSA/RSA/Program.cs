using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class Program
    {
        private static Random rnd = new Random();

        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                var p = SimpleNumbers.GetSimpleNumber(i + 1);
                var q = SimpleNumbers.GetSimpleNumber(i + 2);
                var msg = rnd.Next((int)(p*q%int.MaxValue));

                RSA rsa = new RSA(p, q);

                var en = rsa.EnCrypt(msg);
                var de = rsa.DeCrypt(en);

                Console.WriteLine($"\n\n===================Test {i}===================");
                Console.WriteLine($"p = {p}\tq = {q}");
                Console.WriteLine($"msg = {msg}");
                Console.WriteLine($"Encrypted msg = {en}");
                Console.WriteLine($"Decrypted msg = {de}");
            }

            Console.ReadKey();
        }
    }
}
