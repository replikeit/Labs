using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private static Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Task1()
        {
            double exact = 0.0003686601920987312;
            Func<double, double, double> f = (x,_) => Math.Exp(-x)/(x*(Math.Sqrt(1 + Math.Pow(x,3))));
            var experimental = MonteCarloMethod(f, 1000000, 4, 1000);
            initLables(exact, experimental, f, 4, 1000);
        }

        private static double MonteCarloMethod(Func<double, double, double> f, int n, double a1, double b1, double a2 = 0, double b2 = 1) =>
            (b1 - a1)*(b2 - a2) * new double[n].Select(x => f(a1 + rnd.NextDouble() * (b1 - a1), a2 + rnd.NextDouble() * (b2 - a2))).Sum() / n;

        private void Task2()
        {
            double exact = 7.09727338669441;
            Func<double, double, double> f = (x,y) => Math.Atan(x + y);
            var experimental = MonteCarloMethod(f, 1000000, Math.E, Math.PI, Math.Pow(Math.E, 3), Math.Pow(Math.PI, 3));
            initLables(exact, experimental, f, Math.E, Math.PI, Math.Pow(Math.E, 3), Math.Pow(Math.PI, 3));
        }

        private void initLables(double exact, double experimental, Func<double, double, double> f, double a1, double b1, double a2 = 0, double b2 = 1)
        {
            FunctionChart1.Series[0].Points.Clear();
            exactFunc1Label.Text = exact.ToString("0.000000000000");
            experimFunc1Label.Text = experimental.ToString("0.000000000000");

            for (int i = 10; i < 100000; i+=500)
            {
                var val = MonteCarloMethod(f, i, a1, b1, a2, b2);
                FunctionChart1.Series[0].Points.AddXY(i, Math.Abs(val - exact) * 100 / exact);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Task1();
            FunctionChart1.Series[0].BorderWidth = 2;
        }

        private void task1Button_Click(object sender, EventArgs e)
        {
            Task1();
        }

        private void task2Button_Click(object sender, EventArgs e)
        {
            Task2();
        }
    }
}
