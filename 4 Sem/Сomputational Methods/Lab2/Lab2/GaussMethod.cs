using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab2
{

    class GaussMethod
    {
        private double[,] qMatrix;
        private double[,] transposeQMatrix;
        private double[,] rMatrix;

        public int Size { get; }
        public double Determinant { get; private set; }

        public static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write(matrix[i, j].ToString("0.###\t"));
                }

                Console.WriteLine();
            }
        }
        public static void PrintVector(double[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                Console.Write(vector[i].ToString("0.### "));
            }

            Console.WriteLine();
        }

        public GaussMethod(double[,] matrix)
        {
            Size = matrix.GetUpperBound(0) + 1;
            qMatrix = GetUnitMatrix();
            rMatrix = matrix.Clone() as double[,];

            RecursionQR(0);
            SetDeterminant();
            SetTranspose();
        }

        public double[] GetSolution(double[] vector)
        {
            if (vector.Length != Size)
                throw new Exception("Erorr: Wrong vector length.");
            if (Determinant == 0.0)
                throw new Exception("Erorr: The determinant is 0.");

            double[] result = new double[Size];

            vector = MatrixOnVectorMultiplication(transposeQMatrix, vector);
            
            for (int i = Size - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < Size; j++)
                {
                    vector[i] -= rMatrix[i, j]*result[j];
                }
                result[i] = vector[i] / rMatrix[i, i];
                result[i] = Math.Round(result[i], 12);
            }

            return result;
        }

        private void SetTranspose()
        {
            transposeQMatrix = new double[Size,Size];

            Console.WriteLine("[Matrix Q]");
            PrintMatrix(qMatrix);
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    transposeQMatrix[i, j] = qMatrix[j, i];
                }
            }
            Console.WriteLine("[Matrix Q transpose]");
            PrintMatrix(transposeQMatrix);
            Console.WriteLine("[Matrix R]");
            PrintMatrix(rMatrix);
        }


        private void SetDeterminant()
        {
            Determinant = 1;

            for (int i = 0; i < Size; i++)
            {
                Determinant *= rMatrix[i, i];
            }

            Determinant = Math.Round(Determinant, 13);
        }

        private void RecursionQR(int i)
        {
            if (i == Size - 1)
            {
                return;
            }

            var tmpMat = GetOmegaMatrix(rMatrix, i);
            rMatrix = MatrixMultiplication(tmpMat, rMatrix);
            qMatrix = MatrixMultiplication(tmpMat, qMatrix);
            RecursionQR(++i);
        }


        private double[,] MatrixMultiplication(double[,] matrixA, double[,] matrixB)
        {
            double[,] result = new double[Size, Size];

            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    result[i, j] = 0;

                    for (var k = 0; k < Size; k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return result;
        }

        private double[] MatrixOnVectorMultiplication(double[,] matrix, double[] vector)
        {
            double[] result = new double[Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    result[i] += vector[j] * matrix[j, i];
                }
            }

            return result;
        }

        private double[,] GetUnitMatrix()
        {
            double[,] res = new double[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                res[i, i] = 1;
            }

            return res;
        }
       
        private double[,] GetOmegaMatrix(double[,] matrix, int n)
        {
            double[,] res = GetUnitMatrix();
            double[] omega = new double[Size - n];
            double normal = 0;

            for (int i = n; i < Size; i++)
            {
                normal += Math.Pow(matrix[i, n], 2);
                omega[i - n] = matrix[i, n];
            }
            normal = Math.Sqrt(normal);
            omega[0] -= normal;

            normal = 0;
            for (int i = 0; i < Size - n; i++)
            {
                normal += Math.Pow(omega[i], 2);
            }

            Console.WriteLine($"Omega{n+1}");
            PrintVector(omega);

            for (int i = n; i < Size; i++)
            {
                for (int j = n; j < Size; j++)
                {
                    res[i, j] -= 2 * (omega[i - n] * omega[j - n])/normal;
                }
            }
            Console.WriteLine($"[Matrix H{n + 1}]");
            PrintMatrix(res);

            return res;
        }
        
       
    }
}
