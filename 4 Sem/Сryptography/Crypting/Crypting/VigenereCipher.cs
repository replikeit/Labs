using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Crypting
{
    class VigenereCipher : Cipher
    {
        public string Key { get; }
        public int M { get; }

        private Dictionary<int, char> alphabetIntToChar;
        private Dictionary<char, int> alphabetCharToInt;
        private static Dictionary<char, double> expStatDictionary;

        public VigenereCipher(string key, Dictionary<int, char> alphabet)
        {
            Key = key;
            M = alphabet.Count;

            alphabetIntToChar = alphabet;
            alphabetCharToInt = new Dictionary<char, int>();
            for (int i = 0; i < alphabet.Count; i++)
            {
                alphabetCharToInt.Add(alphabetIntToChar[i], i);
            }
        }

        public override string EnCrypt(string str)
        {
            int keyIndex = 0;
            char[] res = new char[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (alphabetCharToInt.ContainsKey(str[i]))
                {
                    res[i] = alphabetIntToChar[(alphabetCharToInt[str[i]] + alphabetCharToInt[Key[keyIndex]]) % M];
                    keyIndex++;
                }
                else
                {
                    res[i] = str[i];
                }
                if (keyIndex == Key.Length)
                    keyIndex = 0;
            }

            return new string(res);
        }

        public override string DeCrypt(string str)
        {
            int keyIndex = 0;
            char[] resCharArr = new char[str.Length];
            int lettersLen = 0;

            expStatDictionary = GetStatDictionary();
            for (int i = 0; i < str.Length; i++)
            {
                if (alphabetCharToInt.ContainsKey(str[i]))
                {
                     resCharArr[i] = alphabetIntToChar[(alphabetCharToInt[str[i]] + M - alphabetCharToInt[Key[keyIndex]]) % M];
                     keyIndex++;
                }
                else
                {
                    resCharArr[i] = str[i];
                }
                if (keyIndex == Key.Length)
                    keyIndex = 0;

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

        private static string DeleteNonLetter(string str)
        {
            var letters = GetStatDictionary();
            for (int i = 0; i < str.Length; i++)
            {
                if (!letters.ContainsKey(str[i]))
                    str = str.Replace(new string(new char[] { str[i] }), "");
            }

            return str;
        }

        private static List<int> GetKeyLengths(string str, string[] rows)
        {
            double maxCoincidInd = 0;
            List<int> maxIndexArr = new List<int>();

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i] = DeleteNonLetter(rows[i]);
            }

            for (int i = 2; i <= 200 && i <= str.Length; i++)
            {
                double avgCoincidInd = 0;
                int x = 0;

                while (x < i)
                {
                    double coincidInd = 0;
                    int lettersLen = 0;
                    var letterCounter = GetStatDictionary();
                    for (int k = 0; k < rows.Length; k++)
                    {
                        for (int j = x; j < rows[k].Length; j += i)
                        {
                            letterCounter[rows[k][j]]++;
                            lettersLen++;
                        }
                    }
               
                    foreach (var val in letterCounter)
                    {
                        coincidInd += val.Value * (val.Value - 1);
                    }
                    
                    coincidInd /= lettersLen * (lettersLen - 1);    

                    avgCoincidInd += coincidInd;

                    x++;
                }

                avgCoincidInd /= i;

                if (avgCoincidInd - maxCoincidInd >= 0.0000000005)
                {
                    maxCoincidInd = avgCoincidInd;
                    maxIndexArr.Add(i);
                }
            }
            
            return maxIndexArr;
        }

        public static string Hack(string str, Dictionary<int, char> alphabet)
        {
            string[] rows = str.Split('\n');
            List<int> keyLengthsArr = GetKeyLengths(str, rows);

            char[] trueKey = null;
            int minKeyIndex = 0;

            double minChiSquare = Double.MaxValue;
            for (int k = 0; k < keyLengthsArr.Count; k++)
            {
                int keyLength = keyLengthsArr[k];
                char[] key = new char[keyLength];

                for (int i = 0; i < keyLength; i++)
                {
                    key[i] = alphabet[0];
                }

                double localMinChiSquare = Double.MaxValue;
                for (int i = 0; i < keyLength; i++)
                {
                    localMinChiSquare = Double.MaxValue;
                    for (int j = 0; j < alphabet.Count; j++)
                    {
                        key[i] = alphabet[j];
                        double chiSquare = 0;

                        for (int l = 0; l < rows.Length; l++)
                        {
                            string tmpStr = new VigenereCipher(new string(key), alphabet).DeCrypt(rows[l]);

                            foreach (var val in statisticAlphabet)
                            {
                                chiSquare += Math.Pow(expStatDictionary[val.Key] - val.Value, 2) /
                                             val.Value;
                            }
                        }

                        if ((chiSquare - localMinChiSquare) < -0.000005)
                        {
                            minKeyIndex = j;
                            localMinChiSquare = chiSquare;
                           
                        }
                    }
                    key[i] = alphabet[minKeyIndex];
                }

                if ((localMinChiSquare - minChiSquare) < -0.1)
                {
                    minChiSquare = localMinChiSquare;
                    trueKey = new char[keyLength];
                    Array.Copy(key, trueKey, keyLength);
                }
            } 

            string resStr = "";
            for (int l = 0; l < rows.Length; l++)
            {
                resStr += new VigenereCipher(new string(trueKey), alphabet).DeCrypt(rows[l]) + "\n";
            }
            return resStr;

        }
    }
}
