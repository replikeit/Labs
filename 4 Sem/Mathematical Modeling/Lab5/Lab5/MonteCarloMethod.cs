using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    static class MonteCarloMethod
    {
        public static double[] GetSolution(double[,] A, double[] f, int N, int MarkovChainsCount)
        {
            Random rnd = new Random();

            int size = f.Length;
            double[] result = new double[size];

            double[] h = new double[size];
            double[] pi = new double[size];
            double[,] P = new double[size, size];
            int[] markovСhain = new int[N + 1];
            double[] weights = new double[N + 1];
            double[] E = new double[MarkovChainsCount];

            for (int i = 0; i < size; i++)
            {
                double val = A[i, i];
                for (int j = 0; j < size; j++)
                {
                    A[i, j] /= -val;
                    if (j == i) A[i, j] = 0;
                    P[i, j] = 1d / 3d;
                }
                f[i] /= val;
                pi[i] = 1d / 3d;
            }

            for (int i = 0; i < size; i++)
            {
                Array.Clear(h, 0, h.Length);
                Array.Clear(E, 0, E.Length);

                h[i] = 1;

                for (int j = 0; j < MarkovChainsCount; j++)
                {
                    for (int k = 0; k <= N; k++)
                    {
                        markovСhain[k] = rnd.Next(0, 3);
                    }

                    weights[0] = pi[markovСhain[0]] > 0 ? h[markovСhain[0]] / pi[markovСhain[0]] : 0;

                    for (int k = 1; k <= N; k++)
                    {
                        weights[k] = P[markovСhain[k - 1], markovСhain[k]] > 0 ?
                            weights[k - 1] * A[markovСhain[k - 1], markovСhain[k]] /
                            P[markovСhain[k - 1], markovСhain[k]] : 0;
                    }

                    for (int k = 0; k <= N; k++)
                    {
                        E[j] += weights[k] * f[markovСhain[k]];
                    }
                }   

                result[i] = E.Sum() / MarkovChainsCount;
            }

            return result;
        }
    }
}
