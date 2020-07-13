using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1mm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

    

        private static void DrawGrid(Graphics g, int width, int height)
        {

            g.Clear(Color.White);

            Pen p = new Pen(Color.Gray);
            for (int i = 0; i < 20; i++)
            {
                g.DrawLine(p,0,i*30,width,i*30);
                g.DrawLine(p, i * 30,0 , i * 30, height);
            }
            
            p.Color = Color.Black;
            p.Width = 3;
            g.DrawLine(p,30,30,30,height-90);
            g.DrawLine(p, 30, 30, 20,40);
            g.DrawLine(p, 30, 30, 40, 40);

            g.DrawLine(p, 30, height - 90, width - 40, height - 90);
            g.DrawLine(p, width - 40, height - 90, width - 50, height - 80);
            g.DrawLine(p, width - 40, height - 90, width - 50, height - 100);

            Font f = new Font("Arial", 10F);

            for (int i = 0; i < 11; i++)
            {
                g.DrawString(((float)i/10f).ToString(), f, new SolidBrush(Color.Black), new Point(30*(i+1), height - 85));
            }
            for (int i = 1; i < 6; i++)
            {
                g.DrawString((i*30).ToString(), f, new SolidBrush(Color.Black), new Point(0, height - 90 -(30*i)));
            }

        }

        private static void DrawDiagram(Graphics g,int width,int height, Dictionary<int,int> dictionary)
        {

            Pen p = new Pen(Color.Black);
            p.Width = 2;
            for (int i = 0; i < 10; i++)
            {
                g.FillRectangle(new SolidBrush(Color.Red), 30 + 30 * i, height - 90 - dictionary[i], 30, dictionary[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(p, 30 + 30 * i, height - 90, 30 + 30 * i, height - 90 - dictionary[i]);
                g.DrawLine(p, 60 + 30 * i, height - 90, 60 + 30 * i, height - 90 - dictionary[i]);
                g.DrawLine(p, 30 + 30 * i, height - 90 - dictionary[i], 60 + 30 * i, height - 90 - dictionary[i]);

            }
        }

        private void ButtonLiner_Click(object sender, EventArgs e)
        {
            Graphics g = this.panel1.CreateGraphics();
            int width = 400;
            int height = 300;
            
            var l = new LinerCongruentGenerator(int.Parse(textBoxA1.Text), int.Parse(textBoxC1.Text));
            var d = l.statArr;

            DrawGrid(g, width, height);
            DrawDiagram(g,width,height,d);
            SetInfo(l);

        }

        private void MacLarenButton_Click(object sender, EventArgs e)
        {
            Graphics g = this.panel1.CreateGraphics();
            int width = 400;
            int height = 300;

            var l = new MaclarenMarsagliaGenerator(int.Parse(textBoxA1.Text), int.Parse(textBoxC1.Text),
                int.Parse(textBoxA2.Text), int.Parse(textBoxC2.Text), int.Parse(textBoxK.Text));
            var d = l.statArr;

            DrawGrid(g, width, height); 
            DrawDiagram(g, width, height, d);
            SetInfo(l);
        }

        

        private void SetInfo(IRandomGenerator gen)
        {
            panel2.Visible = true;
            a100Label.Text = gen.randValues[99].ToString();
            a900Label.Text = gen.randValues[899].ToString();
            a1000Label.Text = gen.randValues[999].ToString();
            KovTestLabel.Text = gen.KovMethod().ToString();
            DisTestLabel.Text = gen.MomentsMethodDis().ToString();
            AvgTestLabel.Text = gen.MomentsMethodAvg().ToString();
            DisLabel.Text = gen.Dispersion.ToString();
            AvgLabel.Text = gen.Average.ToString();

            var arr = gen.GetCorr(0, 30);
            String s = "\tCorrelation\n";
            foreach (var val in arr)
            {
                s += $" {val.ToString()}\n";
            }

            MessageBox.Show(s);
        }


    }
}
