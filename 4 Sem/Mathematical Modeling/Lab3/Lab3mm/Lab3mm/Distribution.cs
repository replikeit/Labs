using System;
using System.Linq;

namespace Lab3mm
{

    abstract class Distribution
    {
        public double ExperimentalAvg { get; protected set; }
        public double ExperimentalDis { get; protected set; }
        public double TheoreticalAvg { get; protected set; }
        public double TheoreticalDis { get; protected set; }
        public double[] StatArr { get; protected set; }
        public int Size { get; protected set; }
        protected void GetParams()
        {
            ExperimentalAvg = StatArr.Average();
            ExperimentalDis = StatArr.Select
                (x => Math.Pow(x - ExperimentalAvg, 2)).Sum() / (Size - 1);
        }
    }
}