using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cast_128
{
    public static class ScenariosGeneration
    {
        private static Random rnd = new Random();
        private const int blocksCount = 1000_000 * 8 / 64;
        private const int blockLen = 64;
        private const int keyLen = 128;
        private const double HammingBlockProbability = 3d / 64d;
        private const double HammingKeyProbability = 3d / 128d;
       
        private static BitArray GetRandomKey() =>
            new BitArray(new bool[128].Select(x => x = rnd.Next(2) == 1).
                ToArray());

        private static BitArray GetRandomBlock() =>
            new BitArray(new bool[64].Select(x => x = rnd.Next(2) == 1).
                ToArray());

        private static BitArray GetNullKey()=>
            new BitArray(128);

        private static BitArray GetNullBlock() =>
            new BitArray(64);

        private static BitArray GetHammingWeightKey(bool isHigh) =>
            new BitArray(new bool[128].Select(x => (rnd.NextDouble() >= HammingBlockProbability) == isHigh).
                ToArray());

        private static BitArray GetHammingWeightBlock(bool isHigh) =>
            new BitArray(new bool[64].Select(x => (rnd.NextDouble() >= HammingBlockProbability) == isHigh).
                ToArray());

        public static BitArray ProbabilityTest(int mode = 0)
        {
            BitArray result = new BitArray(0);
            BitArray key = GetRandomKey();

            switch (mode)
            {
                case 0:
                    for (int i = 0; i < blocksCount; i++)
                        result = BitsOperations.Append(result, new Cast128(key).
                            EnCrypt(GetRandomBlock()));
                    break;
                case 1:
                    for (int i = 0; i < blocksCount; i++)
                        result = BitsOperations.Append(result, new Cast128(key).
                            EnCrypt(GetHammingWeightBlock(false)));
                    break;
                case 2:
                    for (int i = 0; i < blocksCount; i++)
                        result = BitsOperations.Append(result, new Cast128(key).
                            EnCrypt(GetHammingWeightBlock(true)));
                    break;
                case 3:
                    key = GetHammingWeightKey(false);

                    for (int i = 0; i < blocksCount; i++)
                        result = BitsOperations.Append(result, new Cast128(key).
                            EnCrypt(GetRandomBlock()));
                    break;
                case 4:
                    key = GetHammingWeightKey(true);

                    for (int i = 0; i < blocksCount; i++)
                        result = BitsOperations.Append(result, new Cast128(key).
                            EnCrypt(GetRandomBlock()));
                    break;
            }   
 
            return result;
        }

        public static BitArray ErrorSpreadWithKeyChanging()
        {
            BitArray result = new BitArray(0);

            BitArray key = GetRandomKey();

            for (int i = 0; i < blocksCount; i++)
            {
                for (int j = 0; j < keyLen; j++)
                {
                    BitArray block = GetNullBlock();
                    BitArray deltaKey = GetNullKey();
                    deltaKey.Set(j, true);

                    result = BitsOperations.Append(result, new Cast128(key.Xor(deltaKey)).EnCrypt(block));
                } 
            }

            return result;
        }

        public static BitArray ErrorSpreadWithBlockChanging()
        {
            BitArray result = new BitArray(0);

            BitArray key = GetNullKey();

            for (int i = 0; i < blocksCount; i++)
            {
                for (int j = 0; j < blockLen; j++)
                {
                    BitArray block = GetRandomBlock();
                    BitArray deltaBlock = GetNullBlock();
                    deltaBlock.Set(j, true);

                    BitArray EncryptingBlock1 = new Cast128(key).EnCrypt(block);
                    BitArray EncryptingBlock2 = new Cast128(key).EnCrypt(block.Xor(deltaBlock));

                    result = BitsOperations.Append(result, EncryptingBlock1.Xor(EncryptingBlock2));
                }
            }

            return result;
        }

        public static BitArray SimpleReplace()
        {
            BitArray result = new BitArray(0);
            BitArray key = GetRandomKey();

            for (int i = 0; i < blocksCount; i++)
            {
                BitArray block = GetRandomBlock();

                result = BitsOperations.Append(result, new Cast128(key).EnCrypt(block).Xor(block));
            }   

            return result;
        }

        public static BitArray ChainProcessing()
        {
            BitArray result = new BitArray(0);

            BitArray currentBlock = GetNullBlock();
            BitArray key = GetRandomKey();

            for (int i = 0; i < blocksCount; i++)
            {
                currentBlock = new Cast128(key).EnCrypt(currentBlock);
                result = BitsOperations.Append(result, currentBlock);
            }

            return result;
        }
    }
}
