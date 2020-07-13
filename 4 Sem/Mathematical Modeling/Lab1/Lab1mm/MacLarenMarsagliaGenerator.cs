using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1mm
{
    class MaclarenMarsagliaGenerator : IRandomGenerator
    {
        public double Dispersion { get; private set; }

        public double Average { get; private set; }

        public int Period { get; private set; }

        public Dictionary<int, int> statArr { get; }
        public List<double> randValues { get; }

        public double A1 { get; }
        public long C1 { get; }
        public int K { get; }
        public double A2 { get; }
        public long C2 { get; }
        public long M { get; }

        public MaclarenMarsagliaGenerator(double a1, long c1, double a2, long c2,int k)
        {
            A1 = a1;
            C1 = c1;
            A2 = a2;
            C2 = c2;
            K = k;
            M = (long)Math.Pow(2, 31);
            statArr = new Dictionary<int, int>()
            {
                {0,0},
                {1,0},
                {2,0},
                {3,0},
                {4,0},
                {5,0},
                {6,0},
                {7,0},
                {8,0},
                {9,0},
            };
            randValues = new List<double>();
            Generate();
        }

        public void Generate()
        {
            List<double> randArr1 = new LinerCongruentGenerator(A1, C1).randValues;
            List<double> randArr2 = new LinerCongruentGenerator(A2, C2).randValues;
            Average = 0;
            for (int i = 0; i < 1000; i++)
            {
                int j = (int)(randArr2[i] * K);
                randValues.Add(randArr1[j]);
                int contInd = (int) (randArr1[j] * 10);
                statArr[contInd]++;
                randArr1[j] = randArr2[i];
                Average += randValues[i];
            }
            Average /= 1000;
            SetDispersion();
        }

        public void SetDispersion()
        {
            Dispersion = 0;
            for (int i = 0; i < 1000; i++)
            {
                Dispersion += Math.Pow(randValues[i] - Average, 2);
            }
            Dispersion /= 999;
        }

        public bool MomentsMethodAvg()
        {
            double c = Math.Sqrt(12000);
            double xsi = Math.Abs(Average - 0.5);
            if (c * xsi < 0.825)
                return true;
            return false;
        }

        public bool MomentsMethodDis()
        {
            double c = 0.999 * (1 / Math.Sqrt(0.00000560279));
            double xsi = Math.Abs(Dispersion - 0.083333);
            if (c * xsi < 0.825)
                return true;
            return false;
        }

        public bool KovMethod()
        {
            double r1 = 0.083333;

            double r2 = 0;
            for (int i = 0; i < 1000; i++) 
                r2 += (randValues[0] * randValues[0]) - (1.001001 * Math.Pow(Average,2));
            r2 /= 999;

            if (Math.Abs(r2 - r1) < 0.00308)
                return true;
            return false;
        }

        public List<Double> GetCorr(int t, int x)
        {
            List<double> res = new List<double>();

            for (int i = 1; i <= x; i++)
            {
                double tempCorr = (randValues[t] - Average) * (randValues[t + i] - Average) /
                                  Math.Sqrt(Math.Pow((randValues[t] - Average), 2) * Math.Pow((randValues[t + i] - Average), 2));
                res.Add(tempCorr);
            }

            return res;
        }

    }
}
