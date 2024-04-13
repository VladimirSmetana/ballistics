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
    public partial class Form6 : Form
    {
        public static double H, Mah, T, P, po, time;

        public static List<double> Mahlist = new List<double>();
        public static List<double> Tlist = new List<double>();
        public static List<double> polist = new List<double>();
        public static List<double> Plist = new List<double>();
        public static List<double> Hlist = new List<double>();
        public static List<double> timelist = new List<double>();

        public Form6()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {


            H = Form1.H;
            Mah = Form1.Mah;
            T = Form1.T;
            P = Form1.P;
            po = Form1.po;
            time = Form1.time;

            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();
            chart4.Series[0].Points.Clear();
            chart5.Series[0].Points.Clear();

            for (int i = 0; i < timelist.Count; i++)
            {

                chart1.Series[0].Points.AddXY(timelist[i], Mahlist[i]);
                chart1.ChartAreas[0].AxisX.Title = "Время полета,c";
                chart1.ChartAreas[0].AxisY.Title = "Число Маха";
                chart1.Series[0].Name = "Число Маха";

                chart2.Series[0].Points.AddXY(timelist[i], Tlist[i]);
                chart2.ChartAreas[0].AxisX.Title = "Время полета,c";
                chart2.ChartAreas[0].AxisY.Title = "Температура, К";
                chart2.Series[0].Name = "Температура";

                chart3.Series[0].Points.AddXY(timelist[i], Plist[i]);
                chart3.ChartAreas[0].AxisX.Title = "Время полета,с";
                chart3.ChartAreas[0].AxisY.Title = "Атм давление, Па";
                chart3.Series[0].Name = "Атмосферное давление";

                chart4.Series[0].Points.AddXY(timelist[i], polist[i]);
                chart4.ChartAreas[0].AxisX.Title = "Время полета,с";
                chart4.ChartAreas[0].AxisY.Title = "Плотность воздуха, кг/м3";
                chart4.Series[0].Name = "Плотность воздуха";


                chart5.Series[0].Points.AddXY(timelist[i], Hlist[i] / 1000);
                chart5.ChartAreas[0].AxisX.Title = "Время полета,с";
                chart5.ChartAreas[0].AxisY.Title = "Высота, км";
                chart5.Series[0].Name = "Высота полета";
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new Form1().Show();

            this.Hide();
        }






    }





}



