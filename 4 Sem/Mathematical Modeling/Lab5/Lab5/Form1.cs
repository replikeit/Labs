using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SolutionMatrix();
        }

        private double[,] GetMatrix() => new double[3, 3]
        {
            {double.Parse(A11TextBox.Text), double.Parse(A12TextBox.Text), double.Parse(A13TextBox.Text)},
            {double.Parse(A21TextBox.Text), double.Parse(A22TextBox.Text), double.Parse(A23TextBox.Text)},
            {double.Parse(A31TextBox.Text), double.Parse(A32TextBox.Text), double.Parse(A33TextBox.Text)}
        };

        private double[] GetVector() => new double[3]
        {
            double.Parse(F1TextBox.Text),
            double.Parse(F2TextBox.Text),
            double.Parse(F3TextBox.Text)
        };

        private void GetSolutionButton_Click(object sender, EventArgs e)
        {
            SolutionMatrix();
        }

        private static string VectorToString(double[] vector)
        {
            string result = "[" + vector[0].ToString("#0.000");
            for (int i = 1; i < vector.Length; i++)
            {
                result+= ", " + vector[i].ToString("#0.000");
            }

            result += "]";
            return result;
        }

        private void SolutionMatrix()
        {
            var matrix = GetMatrix();
            var vector = GetVector();

            var gaussSolution = new GaussMethod(matrix, vector).GetSolution();
            var monteSolution = MonteCarloMethod.GetSolution(matrix, vector, int.Parse(NTextBox.Text),
                int.Parse(MarkovCountTextBox.Text));

            MonteCarloLabel.Text = "Monte Carlo Vector " + VectorToString(monteSolution);
            GaussLabel.Text = "Gauss Vector " + VectorToString(gaussSolution);
        }
    }
}
