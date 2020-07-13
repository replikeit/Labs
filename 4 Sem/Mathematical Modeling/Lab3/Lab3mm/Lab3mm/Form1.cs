using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3mm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SetLabels(Distribution dist)
        {
            PanelValues.Visible = true;
            LabelExpAvg.Text = dist.ExperimentalAvg.ToString("0.00000");
            LabelEmpAvg.Text = dist.TheoreticalAvg.ToString("0.00000");
            
            LabelExpDis.Text = dist.ExperimentalDis.ToString("0.00000");
            LabelEmpDis.Text = dist.TheoreticalDis.ToString("0.00000");

        }

        private void ButtonNormal_Click(object sender, EventArgs e)
        {
            Distribution normalDist = new NormalDistribution(
                double.Parse(NormalMTextBox.Text),
                double.Parse(NormalDivialTextBox.Text),
                int.Parse(NormalNTextBox.Text),
                int.Parse(SizeTextBox.Text));
            SetLabels(normalDist);
        }

        private void ButtonLaplace_Click(object sender, EventArgs e)
        {
            Distribution normalDist = new LaplaceDistribution(
                double.Parse(LaplaceATextBox.Text),
                int.Parse(SizeTextBox.Text));
            SetLabels(normalDist);
        }

        private void ButtonChiSquared_Click(object sender, EventArgs e)
        {
            Distribution normalDist = new СhiSquaredDistribution(
                int.Parse(ChiSquaredKTextBox.Text), 
                int.Parse(SizeTextBox.Text));
            SetLabels(normalDist);
        }

        private void ButtonLogNormal_Click(object sender, EventArgs e)
        {
            Distribution normalDist = new LogNormalDistribution(
                double.Parse(LogNormalMTextBox.Text),
                double.Parse(LogNormalDivialTextBox.Text), 
                int.Parse(SizeTextBox.Text));
            SetLabels(normalDist);
        }

        private void ButtonExponential_Click(object sender, EventArgs e)
        {
            Distribution normalDist = new ExponentialDistribution(
                int.Parse(ExponentialLambdaTextBox.Text), 
                int.Parse(SizeTextBox.Text));
            SetLabels(normalDist);
        }
    }
}
