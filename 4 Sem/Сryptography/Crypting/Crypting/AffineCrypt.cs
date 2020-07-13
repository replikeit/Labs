using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using MathNet.Numerics;

namespace Crypting 
{
    class AffineCipher : Cipher
    {
        private int a;
        private static Dictionary<int, char> alphabetIntToChar;
        private static Dictionary<char, int> alphabetCharToInt;
        private static Dictionary<char, double> expStatDictionary;
        
        public int A
        {
            private set
            {

                if (GCD(value, M) != 1)
                {
                    throw new Exception("A and M not a simple");
                }
                else
                {
                    a = value;
                }
            }
            get => a;
        }
        public int B { get; }
        public int M { get; }
        
        public AffineCipher(int a, int b, Dictionary<int, char> alphabet)
        {
            M = alphabet.Count;
            A = a;
            B = b;

            alphabetIntToChar = alphabet;
            alphabetCharToInt = new Dictionary<char, int>();
            for (int i = 0; i < alphabet.Count; i++)
            {
                alphabetCharToInt.Add(alphabetIntToChar[i],i);
            }
        }

        private static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }

        public override string EnCrypt(string str)
        {
            char[] res = new char[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (alphabetCharToInt.ContainsKey(str[i]))
                {
                    res[i] = alphabetIntToChar[alphabetIntToChar[(alphabetCharToInt[str[i]] * A + B) % M] % M];
                }
                else
                {
                    res[i] = str[i];
                }
            }

            return new string(res);
        }

        public override string DeCrypt(string str)
        {
            long inverseA = 0;
            long y;
            Euclid.ExtendedGreatestCommonDivisor((long)A, (long)M, out inverseA, out y);
            inverseA = Math.Abs(inverseA);

            char[] resCharArr = str.ToCharArray();
            int lettersLen = 0;
            expStatDictionary = GetStatDictionary();
            for (int i = 0; i < str.Length; i++)
            {
                if (alphabetCharToInt.ContainsKey(str[i]))
                {
                    resCharArr[i] = alphabetIntToChar[(int)inverseA * (alphabetCharToInt[str[i]] + M - B) % M];
                }
                else
                {
                    resCharArr[i] = str[i];
                }

                if (expStatDictionary.ContainsKey(resCharArr[i]))
                {
                    lettersLen++;
                    expStatDictionary[resCharArr[i]]++;
                }
            }

            for (int i = 0; i < alphabetIntToChar.Count; i++)
            {
                if (expStatDictionary.ContainsKey(alphabetIntToChar[i]))
                {
                    expStatDictionary[alphabetIntToChar[i]] /= lettersLen;
                }
            }

            return new string(resCharArr);
        }

        public static string Hack(string str, Dictionary<int, char> alphabet)
        {

            List<int> possibleB = new List<int>();

            for (int i = 1; i < alphabet.Count; i++)
            {
                if (GCD(i,alphabet.Count) == 1)
                {
                    possibleB.Add(i);
                }
            }

            double minChiSquare = int.MaxValue;
            string result = null;

            for (int i = 0; i < possibleB.Count; i++)
            {
                for (int j = 0; j < alphabet.Count; j++)
                {
                    double chiSquare = 0;
                    string tmpStr = new AffineCipher(possibleB[i],j,alphabet).DeCrypt(str);

                    foreach (var val in statisticAlphabet)
                    {
                        chiSquare += Math.Pow(expStatDictionary[val.Key] - val.Value, 2) /
                                    val.Value;
                    }

                    if (chiSquare < minChiSquare)
                    {
                        result = tmpStr;
                        minChiSquare = chiSquare;
                    }
                }
            }

            return result;
        }

        
    }
}
