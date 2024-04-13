using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstTrass
{
        public partial class Form4 : Form
    { 
        public static double N;
        public static double Y;
        public static double alpha;
        public static double Ott;
        public static double U;
        public static double time;



        public static List<double> Ulist = new List<double>();
        public static List<double> alphalist = new List<double>();
        public static List<double> Nlist = new List<double>();
        public static List<double> Ottlist = new List<double>();
        public static List<double> Ylist = new List<double>();
        public static List<double> timelist = new List<double>();
        public Form4()
        {
            InitializeComponent();
        }
                           
        private void button2_Click(object sender, EventArgs e)
        {
            N = Form1.N;
            Y = Form1.Y;
            alpha = Form1.alpha;
            U = Form1.U;
            Ott = Form1.Ott;
            time = Form1.time;

            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();
            chart4.Series[0].Points.Clear();
            chart5.Series[0].Points.Clear();

            for (int i = 0; i < timelist.Count; i++)
            {
                chart1.Series[0].Points.AddXY(timelist[i], Nlist[i] * 180 / Math.PI);
                chart1.ChartAreas[0].AxisX.Title = "Время полета,c";
                chart1.ChartAreas[0].AxisY.Title = "Полярный угол, град";
                chart1.Series[0].Name = "Полярный угол";

                chart2.Series[0].Points.AddXY(timelist[i], Ylist[i] * 180 / Math.PI);
                chart2.ChartAreas[0].AxisX.Title = "Время полета,c";
                chart2.ChartAreas[0].AxisY.Title = "Угол к горизонту, град";
                chart2.Series[0].Name = "Наклон к горизонту";

                chart3.Series[0].Points.AddXY(timelist[i], alphalist[i]);
                chart3.ChartAreas[0].AxisX.Title = "Время полета,с";
                chart3.ChartAreas[0].AxisY.Title = "Угол атаки, град";
                chart3.Series[0].Name = "Угол атаки";

                chart4.Series[0].Points.AddXY(timelist[i], Ottlist[i]);
                chart4.ChartAreas[0].AxisX.Title = "Время полета,с";
                chart4.ChartAreas[0].AxisY.Title = "Угол траектории, град";
                chart4.Series[0].Name = "Угол наклона траектории";

                chart5.Series[0].Points.AddXY(timelist[i], Ulist[i] * 180 / Math.PI);
                chart5.ChartAreas[0].AxisX.Title = "Время полета,с";
                chart5.ChartAreas[0].AxisY.Title = "Угол тангажа, град";
                chart5.Series[0].Name = "Угол тангажа";
            }
    }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();

            this.Hide();
        }


    }





    }

