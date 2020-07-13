using System;
using System.Linq;

namespace Lab3
{
    public static class SpecialGaussSeidel
    {
        public static double Eps = 0.0000001;

        private static double GetNorma(SpecialMatrix matrixA, double[] vectorX, double[] vectorB)
        {
            double[] tmpVec = new double[matrixA.Size];

            for (int i = 0; i < matrixA.Size; i+= matrixA.Size - 1)
            {
                for (int j = 0; j < matrixA.Size; j++)
                {
                    tmpVec[i] += matrixA[i, j] * vectorX[j];
                }

                tmpVec[i] -= vectorB[i];
            }
            for (int i = 1; i < matrixA.Size - 1; i ++)
            {
                for (int j = 0; j < matrixA.Size; j++)
                {
                    tmpVec[i] += matrixA[i, j] * vectorX[j];
                }

                tmpVec[i] -= vectorB[i];
            }

            return Math.Sqrt(tmpVec.Select(x => x * x).Sum());
        }

        private static double SpecialIteration1(SpecialMatrix MatrixA, double[] vectorB, double[] vectorX, int ind)
        {
            double sum = 0;

            for (int j = 0; j < ind; j++)
            {
                sum += MatrixA[ind, j] * vectorX[j];
            }

            for (int j = ind + 1; j < MatrixA.Size; j++)
            {
                sum += MatrixA[ind, j] * vectorX[j];
            }

            return (vectorB[ind] - sum) / MatrixA[ind, ind];
        }

        private static double SpecialIteration2(SpecialMatrix MatrixA, double[] vectorB, double[] vectorX, int ind)
        {
            double sum = 0;

            if(ind > 0)
                sum += MatrixA[ind, 0] * vectorX[0];
            if (ind + 1 < MatrixA.Size)
                sum += MatrixA[ind, MatrixA.Size - 1] * vectorX[MatrixA.Size - 1];

            return (vectorB[ind] - sum) / MatrixA[ind, ind];
        }

        public static double[] GetSolution(SpecialMatrix MatrixA, double[] vectorB, out int k)
        {
            double[] vectorX = new double[MatrixA.Size];

            k = 0;
            do
            {
                for (int i = 0; i < MatrixA.Size; i++)
                {
                    if (i == 0 || i == MatrixA.Size - 1)
                        vectorX[i] = SpecialIteration1(MatrixA, vectorB, vectorX, i);
                    else
                        vectorX[i] = SpecialIteration2(MatrixA, vectorB, vectorX, i);
                }
                k++;
            } while (GetNorma(MatrixA, vectorX, vectorB) > Eps);

            return vectorX;
        }

        public static double[] GetVectorB(SpecialMatrix matrixA, double[] vectorX)
        {
            double[] result = new double[matrixA.Size];

            for (int i = 0; i < matrixA.Size; i += matrixA.Size - 1)
            {
                for (int j = 0; j < matrixA.Size; j++)
                {
                    result[i] += matrixA[i, j] * vectorX[j];
                }
            }
            for (int i = 1; i < matrixA.Size - 1; i++)
            {
                for (int j = 0; j < matrixA.Size; j++)
                {
                    result[i] += matrixA[i, j] * vectorX[j];
                }
            }

            return result;
        }
    }
}
