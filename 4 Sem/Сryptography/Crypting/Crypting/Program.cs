using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Crypting
{
    class Program 
    {
        

        private static void DoCrypt(Cipher cipher, string text)
        {
            string EnCryptStr = cipher.EnCrypt(text);
            string DeCryptStr = cipher.DeCrypt(EnCryptStr);

            using (var sw = new StreamWriter("crypt.txt"))
            {
                sw.Write(EnCryptStr);
            }
            using (var sw = new StreamWriter("decrypt.txt"))
            {
                sw.Write(DeCryptStr);
            }
        }

        static void Main(string[] args)
        {
            Dictionary<int, char> alphabet;
            string text, textToHack = "";
            string strKey;
            int[] key;
            Cipher cipher = null;

            using (StreamReader sr = new StreamReader("StringToHack.txt"))
            {
                textToHack = sr.ReadToEnd().ToLower();
                
            }
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                text = sr.ReadToEnd().ToLower();
            }
            using (StreamReader sr = new StreamReader("alphabet.txt"))
            {
                string inStr = sr.ReadLine();
                alphabet = new Dictionary<int, char>();
                for (int i = 0; i < inStr.Length; i++)
                {
                    alphabet.Add(i, inStr[i]);   
                }
            }
            using (StreamReader sr = new StreamReader("key.txt"))
            {
                strKey = sr.ReadLine();
            }

            Console.WriteLine("1 - EnCrypt string\t2 - Hack String");
            int x = int.Parse(Console.ReadLine());
            if (x == 1)
            {
                Console.WriteLine("1 - Affine cipher\t2 - Transposition cipher\t3 - Vigenere cipher");
                x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        key = strKey.Split(' ').Select(x => int.Parse(x)).ToArray();
                        cipher = new AffineCipher(key[0], key[1], alphabet);
                        break;
                    case 2:
                        key = strKey.Split(' ').Select(x => int.Parse(x)).ToArray();
                        cipher = new TransitionCipher(key);
                        break;
                    case 3:
                        cipher = new VigenereCipher(strKey, alphabet);
                        break;
                    default:
                        return;
                }

                DoCrypt(cipher, text);
            }
            else if (x == 2)
            {
                Console.WriteLine("1 - Affine cipher\t2 - Transposition cipher\t3 - Vigenere cipher");
                x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        using (var sw = new StreamWriter("AffineHack.txt"))
                        {
                            sw.Write(AffineCipher.Hack(textToHack, alphabet));
                        }
                        break;
                    case 2:
                        using (var sw = new StreamWriter("TransitionHack.txt"))
                        {
                            sw.Write(TransitionCipher.Hack(textToHack));
                        }
                        break;
                    case 3:
                        using (var sw = new StreamWriter("VegenereHack.txt"))
                        {
                            sw.Write(VigenereCipher.Hack(textToHack, alphabet));
                        }
                        break;
                    default:
                        return;
                }
            }   
        }
    }
}
