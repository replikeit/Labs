using System.Linq;

namespace Lab3
{
    public class SpecialMatrix
    {
        public int Size { get; }

        private double[] DiagonalArr;
        private double[] LowerArr;
        private double[] UpperArr;

        public SpecialMatrix(int size)
        {
            Size = size;

            DiagonalArr = new double[Size].Select(_ => (double)size).ToArray();
            UpperArr = new double[2 * Size - 3].Select(_ => 1d).ToArray();
            LowerArr = new double[2 * Size - 3].Select(_ => 1d).ToArray();
        }

        public SpecialMatrix(double[,] matrix)
        {
            Size = matrix.GetUpperBound(0) + 1;

            DiagonalArr = new double[Size].Select((_, i) => matrix[i, i]).ToArray();
            UpperArr = new double[2 * Size - 3];
            LowerArr = new double[2 * Size - 3];

            int ind = 0;
            for (int j = 1; j < Size; j++, ind++)
            {
                UpperArr[ind] = matrix[0, j];
                LowerArr[ind] = matrix[j, 0];
            }

            for (int j = 1; j < Size - 1; j++, ind++)
            {
                UpperArr[ind] = matrix[j, Size - 1];
                LowerArr[ind] = matrix[Size - 1, j];
            }
        }

        public double this[int i, int j]
        {
            get
            {
                if (i == j) return DiagonalArr[i];

                if (i == 0)
                    return UpperArr[j - 1];
                if (j == Size - 1)
                    return UpperArr[i + Size - 2];
                if (j == 0)
                    return LowerArr[i - 1];
                if (i == Size - 1)
                    return UpperArr[j + Size - 2];

                return 0;
            }

            set
            {
                if (i == j) DiagonalArr[i] = value;

                if (i == 0)
                    UpperArr[j - 1] = value;
                if (j == Size - 1)
                    UpperArr[i + Size - 2] = value;
                if (j == 0)
                    LowerArr[i - 1] = value;
                if (i == Size - 1)
                    UpperArr[j + Size - 2] = value;
            }
        }
    }
}
