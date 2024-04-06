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
    public partial class Form5 : Form
    {
        // Объявление переменных
        public static double mpn;
        public static double s1, s2, s3;
        public static double mb1, mb2, mb3, mt1, mt2, mt3, mk1, mk2, mk3;
        public static double D;
        public static double mg1, mg2, mg3;
        public static double mo1, mo2, mo3;
        public static double  PENGs;
        public static double time, T1, T2, T3, t, w, dM, m;
        public static bool stage1, stage2, stage3;



        double[] PENG = new double[3];
        double[] Leng = new double[3];

        public static double wg1, wg2, wg3;
        public static double wo1, wo2, wo3;
        public static double wk1, wk2, wk3;

        public static double wgo, kompsot, po, pg, psr,pk, wpo, wrocket, Lrocket;
        public static double Lg1, Lg2, Lg3, Lo1, Lo2, Lo3, Lgo, Lb1, Lb2, Lb3;
        public static double Lg1yr, Lg2yr, Lg3yr, Lo1yr, Lo2yr, Lo3yr;
        public static double Kg1yr, Kg2yr, Kg3yr, Ko1yr, Ko2yr, Ko3yr;
        public static double Ug1, Ug2, Ug3, Uo1, Uo2, Uo3;

        public static double K31o, K32o, K31g, K32g, K21o, K22o, K21g, K22g, K11o, K12o, K11g, K12g;
        public static double K1summ, K2summ, K3summ, K1summg, K2summg, K3summg, K1summo, K2summo, K3summo;
        public static double Sk1, Sk2, Sk3, Sk, Ik1, Ik2, Ik3, Ik;
        public static double Stg1, Stg2, Stg3, Sto1, Sto2, Sto3, Sto, Stg, Ssumm;
        public static double Itg1, Itg2, Itg3, Ito1, Ito2, Ito3, Ito, Itg, Isumm;
        public static double Xcm, Iz;
        public static double XF, dXF, KM, CIL, CON, CILCON, Mah;

        public static int i;
        //public static int j;

        public static List<double> Mahlist = new List<double>();
        public static List<double> timelist = new List<double>();
        public static List<double> KMlist = new List<double>();

        public Form5()
        {
            InitializeComponent();
        }
        // "Расчет"
        private void button1_Click(object sender, EventArgs e)

        {
            chart6.Series[0].Points.Clear();
            // Перенос исходных данных
            mb1 = Form3.mb1; mb2 = Form3.mb2; mb3 = Form3.mb3;
            mpn = Form3.mpn;
            po = Form3.po; pg = Form3.pg; kompsot = Form3.kompsot;
            s1 = Form3.s1; s2 = Form3.s2; s3 = Form3.s3;
            D = Form3.D;
            t = 1;
            PENG[0] = Form3.PENG1;
            PENG[1] = Form3.PENG2;
            PENG[2] = Form3.PENG3;

            // Массивы
            for (i = 0; i < 3; i++)
            { Leng[i] = 0.85 * 1.4 * 0.125 * Math.Pow(PENG[i] / 9.8, 0.25); }

            // Расчет основных стартовых параметров
            mt1 = mb1 * (s1 - 1) / s1; mt2 = mb2 * (s2 - 1) / s2; mt3 = mb3 * (s3 - 1) / s3;
            mk1 = mb1 - mt1; mk2 = mb2 - mt2; mk3 = mb3 - mt3;
            pk = 100;
            wk1 = mk1 / pk; wk2 = mk2 / pk; wk3 = mk3 / pk;
            psr = po * pg * (kompsot + 1) / (kompsot * pg + po);
            
            wgo = (mpn * 1.1 * 1.5) / 800;
            wpo = (mpn + mb1 + mb2 + mb3) * 0.0008 / 150;

            mg1 = mt1 * 1 / (1 + kompsot); mg2 = mt2 * 1 / (1 + kompsot); mg3 = mt3 * 1 / (1 + kompsot);
            mo1 = mt1 * kompsot / (1 + kompsot); mo2 = mt2 * kompsot / (1 + kompsot); mo3 = mt3 * kompsot / (1 + kompsot);

            wg1 = mg1 / pg; wg2 = mg2 / pg; wg3 = mg3  / pg;
            wo1 = mo1  / po; wo2 = mo2  / po; wo3 = mo3  / po;

            wrocket = (wg1 + wg2 + wg3 + wo1 + wo2 + wo3 + wk1 + wk2 + wk3 + wpo + wgo) / (1 - 0.15);
            textBox1.Text = Convert.ToString(wrocket);

            Lg1 = wg1 * 4 / (Math.PI * Math.Pow(D, 2)); Lg2 = wg2 * 4 / (Math.PI * Math.Pow(D, 2)); Lg3 = wg3 * 4 / (Math.PI * Math.Pow(D, 2));
            Lo1 = wo1 * 4 / (Math.PI * Math.Pow(D, 2)); Lo2 = wo2 * 4 / (Math.PI * Math.Pow(D, 2)); Lo3 = wo3 * 4 / (Math.PI * Math.Pow(D, 2));

            Lgo = (wgo+wpo) * 3 * 4 / (Math.PI * Math.Pow(D, 2)); 
            Lb1 = Lg1 + Lo1 + Leng[0]; Lb2 = Lg2 + Lo2 + Leng[1]; Lb3 = Lg3 + Lo3 + Leng[2];
            Ug1 = Lg1; Ug2 = Lg2; Ug3 = Lg3; Uo1 = Lo1; Uo2 = Lo2; Uo3 = Lo3;
            Lrocket = Lgo + Lb1 + Lb2 + Lb3 ; textBox2.Text = Convert.ToString(Lrocket);

            textBox3.Text = Convert.ToString(Lg1); textBox4.Text = Convert.ToString(Lg2); textBox5.Text = Convert.ToString(Lg3);
            textBox6.Text = Convert.ToString(Lo1); textBox7.Text = Convert.ToString(Lo2); textBox8.Text = Convert.ToString(Lo3);

            textBox16.Text = Convert.ToString(mg1); textBox17.Text = Convert.ToString(mg2); textBox18.Text = Convert.ToString(mg3);
            textBox19.Text = Convert.ToString(mo1); textBox20.Text = Convert.ToString(mo2); textBox21.Text = Convert.ToString(mo3);

            textBox22.Text = Convert.ToString(wg1); textBox23.Text = Convert.ToString(wg2); textBox24.Text = Convert.ToString(wg3);
            textBox25.Text = Convert.ToString(wo1); textBox26.Text = Convert.ToString(wo2); textBox27.Text = Convert.ToString(wo3);

            // Расчет стартовых инерционных характеристик
            K31o = Lgo + Uo3 - Lo3;
            K32o = Lgo + Uo3;
            K3summo = K31o + K32o;

            K31g = K32o + Ug3 - Lg3;
            K32g = K32o + Ug3;
            K3summg = K31g + K32g;

            K21o = K32g + Leng[2] + Uo2 - Lo2;
            K22o = K32g + Leng[2] + Uo2;
            K2summo = K21o + K22o;

            K21g = K22o + Uo2 - Lg2;
            K22g = K22o + Uo2;
            K2summg = K21g + K22g;

            K11o = K22g + Leng[1] + Uo1 - Lo1;
            K12o = K22g + Leng[1] + Uo1;
            K1summo = K11o + K12o;

            K11g = K12o + Ug1 - Lg1;
            K12g = K12o + Ug1;
            K1summg = K11g + K12g;

            K3summ = K31o + K32g; K2summ = K21o + K22g; K1summ = K11o + K12g;

            Sk3 = 0.5 * K3summ * mk3; Sk2 = 0.5 * K2summ * mk2; Sk1 = 0.5 * K1summ * mk1;
            Sk = Sk1 + Sk2 + Sk3;
            Ik3 = 0.25 * (Math.Pow(K3summ, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lb3, 2)) * mk3;
            Ik2 = 0.25 * (Math.Pow(K2summ, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lb2, 2)) * mk2;
            Ik1 = 0.25 * (Math.Pow(K1summ, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lb1, 2)) * mk1;
            Ik = Ik1 + Ik2 + Ik3;

            Stg1 = mg1 * K1summg * 0.5; Stg2 = mg2 * K2summg * 0.5; Stg3 = mg3 * K3summg * 0.5;
            Sto1 = mo1 * K1summo * 0.5; Sto2 = mo2 * K2summo * 0.5; Sto3 = mo3 * K3summo * 0.5;
            Sto = Sto1 + Sto2 + Sto3;
            Stg = Stg1 + Stg2 + Stg3;

            Itg1 = mg1 * (Math.Pow(K1summg, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lg1yr, 2)) * 0.25;
            Itg2 = mg2 * (Math.Pow(K2summg, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lg2yr, 2)) * 0.25;
            Itg3 = mg3 * (Math.Pow(K3summg, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lg3yr, 2)) * 0.25;

            Ito1 = mo1 * (Math.Pow(K1summo, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lo1yr, 2)) * 0.25;
            Ito2 = mo2 * (Math.Pow(K2summo, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lo2yr, 2)) * 0.25;
            Ito3 = mo3 * (Math.Pow(K3summo, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lo3yr, 2)) * 0.25;

            Ito = Ito1 + Ito2 + Ito3;
            Itg = Itg1 + Itg2 + Itg3;
            Isumm = Ito + Itg + Ik + (D * Math.Pow(Lgo, 3) / 12);
            textBox11.Text = Convert.ToString(Isumm);

            Ssumm = Sto + Stg + Sk + (D * Math.Pow(Lgo, 2) / 24);
            m = (mpn + mt1 + mt2 + mt3 + mk1 + mk2 + mk3);
            Xcm = Ssumm / m;
            textBox28.Text = Convert.ToString(m);
            textBox10.Text = Convert.ToString(Ssumm);
            textBox9.Text = Convert.ToString(Xcm);

            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();
            chart4.Series[0].Points.Clear();
            chart5.Series[0].Points.Clear();
            chart6.Series[0].Points.Clear();
            chart7.Series[0].Points.Clear();

/*            chart1.Series[0].Points.AddXY(time, Xcm);
            chart2.Series[0].Points.AddXY(time, Ssumm);
            chart3.Series[0].Points.AddXY(time, Isumm);
            chart4.Series[0].Points.AddXY(time, Lrocket);
            chart5.Series[0].Points.AddXY(time, Iz);*/



            T1 = Form1.v1;
            T2 = Form1.v2;
            T3 = Form1.v3;


                for (int j = 0; j < timelist.Count; j++)
                {
                    time = timelist[j];
                    Mah = Mahlist[j];


                mg1 = mt1 * 1 / (1 + kompsot); mg2 = mt2 * 1 / (1 + kompsot); mg3 = mt3 * 1 / (1 + kompsot);
                mo1 = mt1 * kompsot / (1 + kompsot); mo2 = mt2 * kompsot / (1 + kompsot); mo3 = mt3 * kompsot / (1 + kompsot);

                wg1 = mg1 / pg; wg2 = mg2 / pg; wg3 = mg3 * 1.1 / pg;
                wo1 = mo1 / po; wo2 = mo2 / po; wo3 = mo3 * 1.1 / po;

                wrocket = (wg1 + wg2 + wg3 + wo1 + wo2 + wo3 + wpo + wgo) / (1 - 0.15);
                Lg1 = wg1 * 4 / (Math.PI * Math.Pow(D, 2)); Lg2 = wg2 * 4 / (Math.PI * Math.Pow(D, 2)); Lg3 = wg3 * 4 / (Math.PI * Math.Pow(D, 2));
                Lo1 = wo1 * 4 / (Math.PI * Math.Pow(D, 2)); Lo2 = wo2 * 4 / (Math.PI * Math.Pow(D, 2)); Lo3 = wo3 * 4 / (Math.PI * Math.Pow(D, 2));
                Lgo = (wgo + wpo) * 3 * 4 / (Math.PI * Math.Pow(D, 2));

                K31o = Lgo + Uo3 - Lo3;
                K32o = Lgo + Uo3;
                K3summo = K31o + K32o;

                K31g = K32o + Ug3 - Lg3;
                K32g = K32o + Ug3;
                K3summg = K31g + K32g;

                K21o = K32g + Leng[2] + Uo2 - Lo2;
                K22o = K32g + Leng[2] + Uo2;
                K2summo = K21o + K22o;

                K21g = K22o + Uo2 - Lg2;
                K22g = K22o + Uo2;
                K2summg = K21g + K22g;

                K11o = K22g + Leng[1] + Uo1 - Lo1;
                K12o = K22g + Leng[1] + Uo1;
                K1summo = K11o + K12o;

                K11g = K12o + Ug1 - Lg1;
                K12g = K12o + Ug1;
                K1summg = K11g + K12g;


                /*K3summ = K31o + K32g; K2summ = K21o + K22g; K1summ = K11o + K12g;


                Sk3 = 0.5 * K3summ * mk3; Sk2 = 0.5 * K2summ * mk2; Sk1 = 0.5 * K1summ * mk1;
                Sk = Sk1 + Sk2 + Sk3;
                Ik3 = 0.25 * (Math.Pow(K3summ, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lb3, 2)) * mk3;
                Ik2 = 0.25 * (Math.Pow(K2summ, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lb2, 2)) * mk2;
                Ik1 = 0.25 * (Math.Pow(K1summ, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lb1, 2)) * mk1;*/



                Stg1 = mg1 * K1summg * 0.5; Stg2 = mg2 * K2summg * 0.5; Stg3 = mg3 * K3summg * 0.5;
                Sto1 = mo1 * K1summo * 0.5; Sto2 = mo2 * K2summo * 0.5; Sto3 = mo3 * K3summo * 0.5;


                Itg1 = mg1 * (Math.Pow(K1summg, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lg1yr, 2)) * 0.25;
                Itg2 = mg2 * (Math.Pow(K2summg, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lg2yr, 2)) * 0.25;
                Itg3 = mg3 * (Math.Pow(K3summg, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lg3yr, 2)) * 0.25;

                Ito1 = mo1 * (Math.Pow(K1summo, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lo1yr, 2)) * 0.25;
                Ito2 = mo2 * (Math.Pow(K2summo, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lo2yr, 2)) * 0.25;
                Ito3 = mo3 * (Math.Pow(K3summo, 2) + Math.Pow(D / 2, 2) + 0.333 * Math.Pow(Lo3yr, 2)) * 0.25;



                if (time <= T1)
                {
                    PENGs = Form3.PENG1;
                    w = Form3.w1;
                    dM = PENGs / w;
                    mt1 -= t * dM;
                    Lrocket = Lgo + Lb1 + Lb2 + Lb3;
                    m = (mpn + mt1 + mt2 + mt3 + mk1 + mk2 + mk3);
                    Sto = Sto1 + Sto2 + Sto3;
                    Stg = Stg1 + Stg2 + Stg3;
                    Ito = Ito1 + Ito2 + Ito3;
                    Itg = Itg1 + Itg2 + Itg3;
                    Sk = Sk1 + Sk2 + Sk3;
                    Ik = Ik1 + Ik2 + Ik3;
                }

                if (time > T1 && time <= T2)
                {

                    //m -= 38750;
                    PENGs = Form3.PENG2;
                    w = Form3.w2;
                    dM = PENGs / w;
                    mt1 = 0;
                    mt2 -= t * dM;
                    Lrocket = Lgo + Lb2 + Lb3;
                    m = (mpn + mt2 + mt3 + mk2 + mk3);
                    Sto = Sto2 + Sto3;
                    Stg = Stg2 + Stg3;
                    Ito = Ito2 + Ito3;
                    Itg = Itg2 + Itg3;
                    Sk = Sk2 + Sk3;
                    Ik = Ik2 + Ik3;
                }

                if (time > T2 && time <= T3)
                {

                    //m -= 19050;
                    PENGs = Form3.PENG3;
                    w = Form3.w3;
                    dM = PENGs / w;
                    mt1 = 0;
                    mt2 = 0;
                    mt3 -= t * dM;
                    Lrocket = Lgo + Lb3;
                    m = (mpn + mt3 + mk3);
                    Sto = Sto3;
                    Stg = Stg3;
                    Ito = Ito3;
                    Itg = Itg3;
                    Sk = Sk3;
                    Ik = Ik3;
                }

                if (time > T3)
                {
                    //m -= 6325;

                    //PENG = 0;
                    //w = 0;
                    dM = 0;
                    Lrocket = Lgo;
                    m = (mpn);
                    Sto = 0;
                    Stg = 0;
                    Ito = 0;
                    Itg = 0;
                    Sk = 0;
                    Ik = 0;
                }

                Isumm = Ito + Itg + Ik + (D * Math.Pow(Lgo, 3) / 12);
                Ssumm = Sto + Stg + Sk + (D * Math.Pow(Lgo, 2) / 24);
                Xcm = (Ssumm) / (m);
                Iz = Isumm - m * Math.Pow(Xcm, 2);

                CIL = (Form3.Lrocket - Form3.Lgo) / D; CON = (Form3.Lgo) / D; CILCON = CIL / CON;

                chart1.Series[0].Points.AddXY(time, Xcm);
                chart1.ChartAreas[0].AxisX.Title = "t,c";
                chart1.ChartAreas[0].AxisY.Title = "Xcm, м";
                chart1.Series[0].Name = "Центр масс";

                chart2.Series[0].Points.AddXY(time, Ssumm);
                chart2.ChartAreas[0].AxisX.Title = "t,c";
                chart2.ChartAreas[0].AxisY.Title = "Ssumm, м3";
                chart2.Series[0].Name = "Статический момент";

                chart3.Series[0].Points.AddXY(time, Isumm);
                chart3.ChartAreas[0].AxisX.Title = "t,c";
                chart3.ChartAreas[0].AxisY.Title = "Isumm, м4";
                chart3.Series[0].Name = "Момент инерции X";

                chart4.Series[0].Points.AddXY(time, Lrocket);
                chart4.ChartAreas[0].AxisX.Title = "t,c";
                chart4.ChartAreas[0].AxisY.Title = "Lrocket, м";
                chart4.Series[0].Name = "Длина ракеты";

                chart5.Series[0].Points.AddXY(time, Iz);
                chart5.ChartAreas[0].AxisX.Title = "t,c";
                chart5.ChartAreas[0].AxisY.Title = "Iz, м4";
                chart5.Series[0].Name = "Момент инерции Z";

                KM = (Math.Pow(Math.Abs(1 - Math.Pow(Mah, 2)), 0.5)) / CIL;
                    if (CILCON > 0.0 && CILCON <= 0.5) { if (Mah < 1) { dXF = -0.03 * Math.Pow(KM, 2) - 0.04 * KM + 0.09; } if (Mah >= 1) { dXF = -0.03 * Math.Pow(KM, 2) + 0.06 * KM + 0.09; }; }
                    if (CILCON > 0.5 && CILCON <= 1.0) { if (Mah < 1) { dXF = -0.03 * Math.Pow(KM, 2) - 0.04 * KM + 0.09; } if (Mah >= 1) { dXF = -0.03 * Math.Pow(KM, 2) + 0.16 * KM + 0.10; }; }
                    if (CILCON > 1.0 && CILCON <= 2.0) { if (Mah < 1) { dXF = -0.03 * Math.Pow(KM, 2) - 0.04 * KM + 0.09; } if (Mah >= 1) { dXF = -0.05 * Math.Pow(KM, 2) + 0.34 * KM + 0.05; }; }
                    if (CILCON > 2.0 && CILCON <= 3.0) { if (Mah < 1) { dXF = -0.03 * Math.Pow(KM, 2) - 0.04 * KM + 0.09; } if (Mah >= 1) { dXF = -0.07 * Math.Pow(KM, 2) + 0.42 * KM + 0.01; }; }
                    if (CILCON > 3.0                 ) { if (Mah < 1) { dXF = -0.03 * Math.Pow(KM, 2) - 0.04 * KM + 0.09; } if (Mah >= 1) { dXF = -0.08 * Math.Pow(KM, 2) + 0.51 * KM - 0.02; }; }
                    XF = Lgo - wgo / ((Math.PI * Math.Pow(D, 2)) / 4) + Lgo * dXF;
                    
                    chart6.Series[0].Points.AddXY(time, XF);
                    chart6.ChartAreas[0].AxisX.Title = "t,c";
                    chart6.ChartAreas[0].AxisY.Title = "Xf, м";
                    chart6.Series[0].Name = "Центр давления";

                    chart7.Series[0].Points.AddXY(time, ((XF - Xcm)*100)/Lrocket);
                    chart7.ChartAreas[0].AxisX.Title = "t,c";
                    chart7.ChartAreas[0].AxisY.Title = "R, %";
                    chart7.Series[0].Name = "Анализ устойчивости";
            }
             
            
            
            ////////////////////////////////
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            this.Hide();
        }
    }
    }

