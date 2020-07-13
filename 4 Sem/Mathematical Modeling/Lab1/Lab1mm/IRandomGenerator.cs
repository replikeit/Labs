using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1mm
{
    interface IRandomGenerator
    {
        double Dispersion { get; }

        double Average { get; }

        int Period { get; }

        Dictionary<int, int> statArr { get; }

        List<double> randValues { get; }

        void Generate();

        void SetDispersion();

        bool MomentsMethodAvg();

        bool MomentsMethodDis();

        bool KovMethod();

        List<Double> GetCorr(int t,int x);


    }
}
