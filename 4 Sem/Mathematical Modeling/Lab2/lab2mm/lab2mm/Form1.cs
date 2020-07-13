using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace lab2mm
{
    public partial class Form1 : Form
    {
        private const double hiTable = 16.92;
        private double hiExperimental;

        public Form1()
        {
            InitializeComponent();
        }

        private int Factorial(int n) => (n == 0)? 1 : n*Factorial((n - 1));
        private void ChartsSet(Distribution dis)
        {
            panel1.Visible = true;
            GistagramChart.Visible = true;
            FunctionChart.Visible = true;
            hiExperimental = 0;

            GistagramChart.Series[0].Points.Clear();
            GistagramChart.Series[1].Points.Clear();
            FunctionChart.Series[0].Points.Clear();
            FunctionChart.Series[0].BorderWidth = 3;

            for (int i = 0; i <= dis.M; i++)
            {
                double pExp = (double)dis.StatArr.Count(x => x == i)/(double)dis.N;
                double pEmp = ((Factorial((int)dis.M) * Math.Pow(dis.P, i) * Math.Pow(1 - dis.P, dis.M - i)) / ((Factorial((int)dis.M - i)) * Factorial(i)));
                
                hiExperimental += Math.Pow(pExp - pEmp,2)/pEmp;

                GistagramChart.Series[0].Points.AddXY(i,  dis.N * pExp);
                GistagramChart.Series[1].Points.AddXY(i, (int)(dis.N * pEmp));
            }

            hiExperimental *= dis.N;

            for (int i = - 1; i <= dis.M; i++)
            {
                FunctionChart.Series[0].Points.AddXY(i , (double)dis.StatArr.Count(x => x <= i) / dis.N);
                FunctionChart.Series[0].Points.AddXY(i + 1, (double) dis.StatArr.Count(x => x <= i) / dis.N);
            }
        }

        private void SetLabels(Distribution dis)
        {
            LabelExpAvg.Text = dis.ExperimentalAvg.ToString("0.0000");
            LabelExpDis.Text = dis.ExperimentalDis.ToString("0.0000");
            LabelEmpAvg.Text = dis.EmpiricalAvg.ToString("0.0000");
            LabelEmpDis.Text = dis.EmpiricalDis.ToString("0.0000");

            LabelPearson.Text = (hiExperimental < hiTable).ToString();

            LabelExpAsym.Text = dis.ExperimentalAsymmetry.ToString("0.0000");
            LabelExpExc.Text = dis.ExperimentalExcess.ToString("0.0000");
            LabelEmpAsym.Text = dis.EmpiricalAsymmetry.ToString("0.0000");
            LabelEmpExc.Text = dis.EmpiricalExcess.ToString("0.0000");
        }

        private void BernoulliButton_Click(object sender, EventArgs e)
        {
            Distribution dis = new BernoulliDistribution(double.Parse(TextBoxP.Text),1000);
            ChartsSet(dis);
            SetLabels(dis);
        }

        private void BinomialButton_Click(object sender, EventArgs e)
        {
            Distribution dis = new BinomialDistribution(double.Parse(TextBoxM.Text), double.Parse(TextBoxP.Text), 1000);
            ChartsSet(dis);
            SetLabels(dis);
        }
    }
}
