using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2mm
{

    abstract class Distribution
    {
        public double ExperimentalAvg { get; protected set; }
        public double ExperimentalDis { get; protected set; }
        public double ExperimentalAsymmetry { get; protected set; }
        public double ExperimentalExcess { get; protected set; }
        public double EmpiricalAvg { get; protected set; }
        public double EmpiricalDis { get; protected set; }
        public double EmpiricalAsymmetry { get; protected set; }
        public double EmpiricalExcess { get; protected set; }
        public int N { get; protected set; }
        public double[] StatArr { get; protected set; }
        public double M { get; protected set; }
        public double P { get; protected set; }
        protected void GetParams()
        {
            ExperimentalAvg = StatArr.Average();
            ExperimentalDis = StatArr.Select(x => Math.Pow(x - ExperimentalAvg, 2)).Sum() / (N - 1);
            double standardDeviation = Math.Sqrt(ExperimentalDis);
            ExperimentalAsymmetry = (StatArr.Select(x => Math.Pow(x - ExperimentalAvg, 3)).Sum() / ((N - 1)) * Math.Pow(standardDeviation, 3));
            ExperimentalExcess = (StatArr.Select(x => Math.Pow(x - ExperimentalAvg, 4)).Sum() / ((N - 1)) * Math.Pow(standardDeviation, 4)) - 3;
        }
    }
}
