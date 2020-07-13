using System;
using System.Collections.Generic;

namespace Crypting
{
    class TransitionCipher : Cipher
    {
        public int[] Key { get; }

        private static string strHack;
        private static Dictionary<string, double> expStatThreegram;
        private static double minChiSquare;
        private int len;
        private int[] biKey;

        public TransitionCipher(int[] key)
        {
            Key = new int[key.Length];
            Array.Copy(key,Key,key.Length);
            len = key.Length;
            biKey = new int[len];
            for (int i = 0; i < key.Length; i++)
            {
                biKey[Key[i] - 1] = i;
            }
        }

        public override string EnCrypt(string str)
        {
            int k = 0;
            char[] res = new char[str.Length];
            
            for (int i = 0; i < len; i++)
            {
                int x = biKey[i];
                while (x < str.Length)
                {
                    res[k] = str[x];  
                    x += len;
                    k++;
                }
            }

            return new string(res);
        }

        public override string DeCrypt(string str)
        {
            char[] res = new char[str.Length];
            expStatThreegram = GetThreegramStatDictionary();

            int k = 0;
            for (int i = 0; i < len; i++)
            {
                int x = biKey[i];
                
                while (x < str.Length)
                {
                    res[x] = str[k];
                    x += len;
                    k++;
                }
            }

            for (int i = 0; i < res.Length - 2; i++)
            {
                string tmpStr = new string(new char[]{res[i], res[i + 1], res[i + 2]});

                if (expStatThreegram.ContainsKey(tmpStr))
                {
                    expStatThreegram[tmpStr]++;
                }
            }

            foreach (var val in empThreegramStatistic)
            {
                expStatThreegram[val.Key] /= (int)(str.Length/3);
            }

            return new string(res);
        }

        private static void SwapInKey(ref int[] key, int i, int j)
        {
            int tmp = key[i];
            key[i] = key[j];
            key[j] = tmp;
        }

        private static void RecTransitions(int index, int[] key, string str)
        {
            if (index == key.Length - 2)
            {

                for (int j = 0; j <= 1; j++)
                {
                    double chiSquare = 0;
                    SwapInKey(ref key, index, index + j);
                    
                    string deCryptStr = new TransitionCipher(key).DeCrypt(str);
                    foreach (var val in empThreegramStatistic)
                    {
                        chiSquare += Math.Pow(expStatThreegram[val.Key] - val.Value, 2) /
                                    val.Value;
                    }

                    if (chiSquare < minChiSquare)
                    {
                        strHack = deCryptStr;
                        minChiSquare = chiSquare;
                    }
                }

                SwapInKey(ref key, index, index + 1);
            }
            else
            {
                for (int j = 0; j < key.Length; j++)
                {
                    SwapInKey(ref key, index, j);
                    RecTransitions(index + 1, key, str);
                }
            }
        }

        public static string Hack(string str)
        {
            minChiSquare = double.MaxValue;

            for (int i = 2; i <= 7; i++)
            {
                int[] key = new int[i];
                for (int j = 0; j < i; j++)
                {
                    key[j] = j + 1;
                }

                RecTransitions(0, key, str);
            }

            return strHack;
        }
    }
}