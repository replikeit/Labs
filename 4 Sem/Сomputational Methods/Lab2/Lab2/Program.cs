using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] x = new double[,]
            {
                {0, 4*Math.Sqrt(2),-2*Math.Sqrt(2)},
                {1/Math.Sqrt(2), 4, 2},
                {1/Math.Sqrt(2), -4, -2},
            };
            var vec = new GaussMethod(x).GetSolution(new double[]
            {
                24*Math.Sqrt(2),
                8,
                -8,
            });
            int d = 0;
            Console.Read();
        }
    }
}
