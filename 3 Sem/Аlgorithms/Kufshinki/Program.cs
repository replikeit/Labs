using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Kufshinki
{

    class Program
    {
        public static bool checkEnd=false;
        private static void Jump(int k,int i,ref int[] mass)
        {
            if (massKam[k + i] + mass[k] > mass[k + i])
                mass[k + i] = massKam[k + i] + mass[k];
            if ((i + k) == mass.Length - 1)
                checkEnd = true;
        }
        public static void recKufsh(ref int[] massKam, int k)
        {
            if (k < massKam.Length)
            {
                if (k+2>= massKam.Length)
                    return;
                Jump(k,2,ref massKam);
                recKufsh(ref massKam, k + 2);
                if(k + 3 >= massKam.Length)
                    return;
                Jump(k, 3, ref massKam);
                recKufsh(ref massKam, k + 3);
            }
            
        }
        public static int[] massKam;
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("output.txt", false, System.Text.Encoding.Default);
            string[] info = File.ReadAllLines("input.txt");
            int Kufsh = int.Parse(info[0]);
            if (Kufsh == 1)
            {
                sw.Write(int.Parse(info[1]));
                return;
            }

            for (int i = 0; i < Kufsh; i++)
            {

            }
            massKam = info[1].Split(' ').Select(x => int.Parse(x)).ToArray();
            int[] massKam2 = new int[massKam.Length];
            Array.Copy(massKam,massKam2,massKam.Length);
            recKufsh(ref massKam2,0);
            if(checkEnd)
                sw.Write(massKam2[massKam2.Length-1]);
            else
                sw.Write(-1);
            sw.Close();
        }
    }
}
