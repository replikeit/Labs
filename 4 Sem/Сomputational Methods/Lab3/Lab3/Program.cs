using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Lab3
{
    class Program
    {
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

        public static void PrintMatrix(SpecialMatrix matrix)
        {
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
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
                Console.Write(vector[i].ToString("0.#### "));
            }

            Console.WriteLine();
        }

        private static void TimeTest()
        {
            using (StreamWriter sw = new StreamWriter("Time Statistic.txt"))
            {
                for (int k = 1; k <= 12; k++)
                {
                    int size = (int)Math.Pow(10, k / 2d);
                    double[] b = new double[size].Select(_ => 1.0).ToArray();
                    SpecialMatrix matrixA = new SpecialMatrix(size);

                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    SpecialGaussSeidel.GetSolution(matrixA, b, out _);
                    stopwatch.Stop();

                    Console.WriteLine($"Time for a matrix with size {size}: {stopwatch.ElapsedMilliseconds}");
                    sw.WriteLine(stopwatch.ElapsedMilliseconds);
                }
            }
        }

        static void Main(string[] args)
        {
            //Task 1
            #region Task1RunTestCode

            Console.WriteLine("==============================Task 1==============================");
            double[,] matrix = new double[,]
            {{ 230, 1/23, 0, 0}, 
                { -2645/11, 230, 1/23, 0},
                { 2645/11, -2645/11, 230, 1/23},
                {-2645/11, 2645/11, -2645/11, 230}};
            double[] vectorX = new double[] { 6, 2, 3 };

            for (double i = 0.1; i < 2; i += 0.1)
            {
                var Method = new RelaxationMethod(matrix, i);
                try
                {
                    Console.WriteLine("Omega: " + i);
                    Console.Write("Evd: ");
                    PrintVector(Method.GetEigenvalues());
                    Console.Write("Iterations Solve: ");
                    PrintVector(Method.GetSolution(Method.GetVectorB(vectorX), out int k));
                    Console.WriteLine("Iterations count: " + k);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            #endregion

            //Task 2
            #region Task2RunTestCode

            Console.WriteLine("\n\n\n==============================Task 2==============================");

            SpecialMatrix specialMatrix1 = new SpecialMatrix(5);
            double[] vectorX1 = new double[] { 1, 2, 3, 4, 5 };
            double[] vectorB1 = SpecialGaussSeidel.GetVectorB(specialMatrix1, vectorX1);
            SpecialMatrix specialMatrix2 = new SpecialMatrix(6);
            double[] vectorX2 = new double[] { 1, 2, 3, 4, 5, 6 };
            double[] vectorB2 = SpecialGaussSeidel.GetVectorB(specialMatrix2, vectorX2);
            SpecialMatrix specialMatrix3 = new SpecialMatrix(7);
            double[] vectorX3 = new double[] { 1, 2, 3, 4, 5, 6, 7 };
            double[] vectorB3 = SpecialGaussSeidel.GetVectorB(specialMatrix3, vectorX3);

            Console.WriteLine("\n=========Matrix №1=========");
            PrintMatrix(specialMatrix1);
            Console.WriteLine("Vector X");
            PrintVector(vectorX1);
            Console.WriteLine("Vector B");
            PrintVector(vectorB1);
            Console.WriteLine("Gauss Seidel Solve");
            PrintVector(SpecialGaussSeidel.GetSolution(specialMatrix1, vectorB1, out _));
            Console.WriteLine("===========================");
            Console.WriteLine("\n=========Matrix №2=========");
            PrintMatrix(specialMatrix2);
            Console.WriteLine("Vector X");
            PrintVector(vectorX2);
            Console.WriteLine("Vector B");
            PrintVector(vectorB2);
            Console.WriteLine("Gauss Seidel Solve");
            PrintVector(SpecialGaussSeidel.GetSolution(specialMatrix2, vectorB2, out _));
            Console.WriteLine("===========================");
            Console.WriteLine("\n=========Matrix №3=========");
            PrintMatrix(specialMatrix3);
            Console.WriteLine("Vector X");
            PrintVector(vectorX3);
            Console.WriteLine("Vector B");
            PrintVector(vectorB3);
            Console.WriteLine("Gauss Seidel Solve");
            PrintVector(SpecialGaussSeidel.GetSolution(specialMatrix3, vectorB3, out _));
            Console.WriteLine("===========================");

            TimeTest();

            #endregion

            Console.ReadKey();
        }
    }
}
