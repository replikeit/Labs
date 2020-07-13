using System;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab3
{
    class RelaxationMethodException : Exception
    {
        public RelaxationMethodException(string msg) : base("Solution not found: " + msg) { }
    }

    class RelaxationMethod
    {
        private static MatrixBuilder<double> mb = Matrix<double>.Build;

        private Matrix<double> L;
        private Matrix<double> D;
        private Matrix<double> R;

        public Matrix<double> MatrixA { get; }
        public double Omega { get; }
        public int Size { get; }
        public Matrix<double> Bw { get; }
        public double Eps { get; set; }

        public RelaxationMethod(double[,] matrix, double omega)
        {
            Size = matrix.GetUpperBound(0) + 1;
            MatrixA = DenseMatrix.OfArray(matrix);
            Omega = omega;

            D = mb.DenseDiagonal(Size, Size, i => MatrixA[i, i]);
            L = MatrixA.LowerTriangle() - D;
            R = MatrixA.UpperTriangle() - D;

            Bw = ((D + (Omega * L)).Inverse() * ((1 - Omega) * D - Omega * R));

            Eps = 0.0000001;
        }

        public double[] GetEigenvalues() => Bw.Evd().EigenValues.Select(item => item.Magnitude).ToArray();

        public double[] GetSolution(double[] vec, out int k)
        {
            //CheckIterationsConverge();

            Vector<double> vectorB = DenseVector.OfArray(vec);
            Vector<double> vectorX = DenseVector.OfArray(vec);

            k = 0;
            do
            {
                for (int i = 0; i < MatrixA.RowCount; i++)
                {
                    vectorX[i] = (1 - Omega) * vectorX[i];
                    double sum = 0;

                    for (int j = 0; j < i; j++)
                    {
                        sum += MatrixA[i, j] * vectorX[j];
                    }

                    for (int j = i + 1; j < MatrixA.RowCount; j++)
                    {
                        sum += MatrixA[i, j] * vectorX[j];
                    }

                    vectorX[i] += (Omega / MatrixA[i, i]) * (vectorB[i] - sum);
                }
                k++;
            } while ((MatrixA * vectorX - vectorB).L2Norm() > Eps);


            return vectorX.ToArray();
        }

        private void CheckIterationsConverge()
        {       
            var evd = GetEigenvalues();
            for (int i = 0; i < evd.Length; i++)
                if (evd[i] >= 1)
                    throw new RelaxationMethodException("Iterations doesn't converge");
        }

        public double[] GetVectorB(double[] vectorX) => (MatrixA * DenseVector.OfArray(vectorX)).ToArray();
    }
}
