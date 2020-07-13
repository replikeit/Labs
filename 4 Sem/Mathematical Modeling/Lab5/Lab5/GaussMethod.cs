using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class GaussMethodSolutionNotFound : Exception
    {
        public GaussMethodSolutionNotFound(string msg)
            : base($"Solution can't be found: {msg} \n")
        {
        }
    }

    class GaussMethod
    {
        private int[] transpositionX;
        private int size;
        
        public double[,] Matrix { get; }
        public double[] VectorB { get; }

        private void InitTransposition()
        {
            transpositionX = new int[size];
            transpositionX = transpositionX.Select((x, i) => x = i).ToArray();
        }

        public GaussMethod(double[,] matrix, double[] b)
        {
            Matrix = matrix.Clone() as double[,];
            VectorB = b.Clone() as double[];
            size = b.Length;
        }

        public double[] GetSolution()
        {
            InitTransposition();
            GaussForwardStroke();
            double[] tmpVector = GaussBackwardStroke();

            double[] result = new double[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = tmpVector[transpositionX[i]];
            }

            return result;
        }

        public double[] GetSolution(out double determinant)
        {
            var result = this.GetSolution();
            determinant = GetDeterminant();
            return result;
        }

        public double GetDeterminant()
        {
            double result = 1;

            for (int i = 0; i < size; i++)
            {
                result *= Matrix[i, i];
            }

            return result;
        }

        private void SwapDiagonalElement(int diagonalIndex, int i, int j)
        {
            for (int k = 0; k < size; k++)
            {
                double tmpI = Matrix[k, diagonalIndex];
                Matrix[k, diagonalIndex] = Matrix[k, j];
                Matrix[k, j] = tmpI;
            }

            for (int k = 0; k < size; k++)
            {
                double tmpJ = Matrix[diagonalIndex, k];
                Matrix[diagonalIndex, k] = Matrix[i, k];
                Matrix[i, k] = tmpJ;
            }

            double tmpB = VectorB[diagonalIndex];
            VectorB[diagonalIndex] = VectorB[i];
            VectorB[i] = tmpB;

            int tmpX = transpositionX[diagonalIndex];
            transpositionX[diagonalIndex] = transpositionX[j];
            transpositionX[j] = tmpX;
        }

        private void GetMaxElement(int diagonalIndex)
        {
            int maxI = 0;
            int maxJ = 0;
            double maxAbs = 0;

            for (int i = diagonalIndex; i < size; i++)
            {
                for (int j = diagonalIndex; j < size; j++)
                {
                    if (maxAbs < Math.Abs(Matrix[i, j]))
                    {
                        maxAbs = Math.Abs(Matrix[i, j]);  
                        maxI = i;
                        maxJ = j;
                    }
                }
            }

            SwapDiagonalElement(diagonalIndex, maxI, maxJ);
        }

        private void GaussForwardStroke()
        {
            for (int i = 0; i < size; i++)
            {
                GetMaxElement(i);
                if (Math.Abs(Matrix[i,i]) == 0.00000001)
                {
                    throw new GaussMethodSolutionNotFound("Determinant are singular");
                }

                for (int j = i + 1; j < size; j++)
                {
                    double coeff = Matrix[j,i]/Matrix[i, i];
                    for (int k = i + 1; k < size; k++)
                    {
                        Matrix[j, k] -= Matrix[i, k] * coeff;
                    }
                    VectorB[j] -= VectorB[i] * coeff;
                }
            }
        }

        private double[] GaussBackwardStroke()
        {
            double[] result = new double[size];

            for (int i = size - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < size; j++)
                {
                    VectorB[i] -= Matrix[i, j] * result[j];
                }
                result[i] = VectorB[i] / Matrix[i, i];
            }
            return result;
        }
    }
}
