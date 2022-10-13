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
    public partial class Form1 : Form
    {
        /// <summary>
        /// Скорость РН 
        /// </summary>
        public static double V, V0;
        /// <summary>
        /// Высота
        /// </summary>
        public static double H, H0;
        /// <summary>
        /// Плотность воздуха
        /// </summary>
        public static double po;
        /// <summary>
        /// Атмосферное давление
        /// </summary>
        public static double P;
        /// <summary>
        /// Температура окружающей среды
        /// </summary>
        public static double T;
        /// <summary>
        /// Скорость звука
        /// </summary>
        public static double a;
        /// <summary>
        /// Угол атаки
        /// </summary>
        public static double alpha, alpha0, alpha1, alpha2;
        /// <summary>
        /// Тяга двигательной установки
        /// </summary>
        public static double PENG, PENG1, PENG2, PENG3;
        /// <summary>
        /// Секундный расход топлива
        /// </summary>
        public static double dM;
        /// <summary>
        /// Радиус Земли
        /// </summary>
        public static double R;
        /// <summary>
        /// Скорость истечения газов из двигателя
        /// </summary>
        public static double w, w1, w2, w3;
        /// <summary>
        /// Стартовая масса РН
        /// </summary>
        public static double M1;
        /// <summary>
        /// Угол наклона вектора скорости к местному горизонту
        /// </summary>
        public static double Y, Y0;
        /// <summary>
        /// Текущая масса РН
        /// </summary>
        public static double m;
        /// <summary>
        /// Коэффициент лобового сопротивления
        /// </summary>
        public static double CX;
        /// <summary>
        /// Производная коэффициента подъемной силы
        /// </summary>
        public static double CY, CY1, CY2;
        /// <summary>
        /// Площадь Миделя РН
        /// </summary>
        public static double S;
        /// <summary>
        /// Ускорение свободного падения
        /// </summary>
        public static double g;
        /// <summary>
        /// Начальный полярный угол
        /// </summary>
        public static double N, N0;
        /// <summary>
        /// Шаг дифференцирования (шаг времени)
        /// </summary>
        public static double t;
        /// <summary>
        /// Время полета от начала пуска
        /// </summary>
        public static double time;
        /// <summary>
        /// Число Маха
        /// </summary>
        public static double Mah;
        /// <summary>
        /// Параметры Атмосферы
        /// </summary>
        public static double K2, K3, Na, RB, r, SOS, BS, hi, b,
                             Hp, Mol, B0, B1, B2, B3,
                             Mc, gc, ac, Hpc, n, nc, pc, Tc, vc, yc, nuc, muc, lac, poc, omegac, tCel, Bett, Tm, pp, yyd,
                             Hmas, A0, A1, A2, A3, A4, mstep, vsred, lsred, omega, lamb, mu, nu, Re, CfM2, XT, natr, CD, Cdnose;









        /// <summary>
        /// Параметры расчета геометрии
        /// </summary>
        public static double CILCON, CIL, CON, Leng1, Leng2, Leng3, pokl, pg, kompsot, s1, s2, s3,
                             mk1, mk2, mk3, pk, wk1, wk2, wk3, psr, wgo, wpo, mg1, mg2, mg3, wg1, wg2, wg3, mo1, mo2, mo3, wo1, wo2, wo3,
                             Lg1, Lg2, Lg3, Lo1, Lo2, Lo3, Lb1, Lb2, Lb3, Lgo, Lrocket, wrocket, Mhi, gipgo, Lkorp, FOM;
        /// <summary>
        /// Поверочный параметр (масса)
        /// </summary>
        public static double PRUV, xpruv;
        private void button4_Click(object sender, EventArgs e)
        {
            new Form4().Show();
            this.Hide();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            new Form6().Show();
            this.Hide();
        }
        /// <summary>
        /// Время начала пуска
        /// </summary>
        public static double t0;
        /// <summary>
        /// Максимальный диаметр блока РН
        /// </summary>
        public static double D;
        /// <summary>
        /// Время отделения ступени
        /// </summary>
        public static double T1, T2, T3, k1, k2, k3, v1, v2, v3;
        /// <summary>
        /// Угол наклона траектории (программный)
        /// </summary>
        public static double Ott;
        /// <summary>
        /// Угол тангажа
        /// </summary>
        public static double U;
        /// <summary>
        /// Угол наклона траектории (реальный)
        /// </summary>
        public static double ER, ER0;
        /// <summary>
        /// Координата РН
        /// </summary>
        public static double x,y;
        /// <summary>
        /// Масса топлива
        /// </summary>
        public static double mt1, mt2, mt3;
        /// <summary>
        /// Точка разделения
        /// </summary>
        public static bool stage1, stage2, stage3;
        /// <summary>
        /// Массы блоков
        /// </summary>
        public static double mb1, mb2, mb3;
        /// <summary>
        /// Масса ПН
        /// </summary>
        public static double mpn;

        private void button1_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            button6.Enabled = true;
            button5.Enabled = true;
            /// Объявление глобальных констант
            Mc = 28.964420; gc = 9.80665; ac = 340.294; Hpc = 8434.5;
            nc = 25.471 * Math.Pow(10, 24); pc = 101325.0; Tc = 288.15;
            vc = 458.94; yc = 12.013; nuc = 14.607 * Math.Pow(10, -6); muc = 17.894 * Math.Pow(10, -6);
            lac = 25.343 * Math.Pow(10, -3); omegac = 6.9193 * Math.Pow(10, 9); poc = 1.2250;
            Na = 602.257 * Math.Pow(10, 24);
            RB = 8314.32;
            r = 287.05287;
            SOS = 110.4;
            BS = 1.458 * Math.Pow(10, -6);
            hi = 1.4;
            b = 0.365 * Math.Pow(10, -9);
            g = gc * Math.Pow(R / (R + H), 2);
            Hp = (R * H) / (R + H);

            /// Начальная геометрия
            D = Form3.D; 
            S = Math.PI * Math.Pow((D/2), 2);
            Lkorp = Lrocket - Lgo;
            Leng1 = 0.85 * 1.4 * 0.125 * Math.Pow(PENG1 / 9.8, 0.25); Leng2 = 0.85 * 1.4 * 0.125 * Math.Pow(PENG2 / 9.8, 0.25); Leng3 = 0.85 * 1.4 * 0.125 * Math.Pow(PENG3 / 9.8, 0.25);
            FOM = Math.PI * D * Lkorp + Math.PI * D * Lgo/2;
            /// Плотность компонентов топлива
            pokl = Form3.po; pg = Form3.pg; kompsot = Form3.kompsot;

            H0 = 0; 
            Y0 = Math.PI/2;
            V0 = 0.1;
            R = 6371000;
            N0 = 0;
            t0 = 0;
            alpha0 = 0;
            t = 1;
            CY = 0;
            CX = 0;
            natr = 1;
            Re = 0;

            k1 = 0.1 + Convert.ToDouble(textBox14.Text); 
            k2 = 0.1 + Convert.ToDouble(textBox16.Text); 
            k3 = 0.1 + Convert.ToDouble(textBox17.Text);



            x = 0; y = 0;
            /// Объявление коэффициентов угла атаки
            alpha1 = Convert.ToDouble(textBox8.Text); alpha2 = Convert.ToDouble(textBox9.Text);

            /// Перенос исходных данных
            w1 = Form3.w1; w2 = Form3.w2; w3 = Form3.w3;
            PENG1 = Form3.PENG1; PENG2 = Form3.PENG2; PENG3 = Form3.PENG3;
            mb1 = Form3.mb1; mb2 = Form3.mb2; mb3 = Form3.mb3;
            mt1 = Form3.mt1; mt2 = Form3.mt2; mt3 = Form3.mt3;
            mpn = Form3.mpn;
            M1 = mpn+mb1+mb2+mb3;

            /// Расчет моментов времени работы ступеней
            T1 = (mt1 / (PENG1 / w1)); T2 = (mt2 / (PENG2 / w2)); T3 = (mt3 / (PENG3 / w3));
            v1 = T1;
            v2 = T1 + k1 + T2;
            v3 = T1 + k1 + T2 + k2 + T3;
            textBox10.Text = Convert.ToString(v1); textBox11.Text = Convert.ToString(v2); textBox12.Text = Convert.ToString(v3);

            /// Исходные данные расчета параметров Атмосферы
            Mol = Mc; g = gc; T = Tc; Tm = Tc * Mc / Mol; P = pc; n = nc;yyd = yc; a = ac; omega = omegac;
            
            /// Система дифференциальных уравнений движения РН
            double dV(double vv, double ii)
            {
                return (PENG * Math.Cos((Math.PI * alpha) / 180)) / m - CX * S * po * Math.Pow(vv, 2) / (2 * m) - g * Math.Sin(ii);
                ///if (time > T1 && time <= (T1 + k1)) { return 0; }
                ///if (time > (T1 + k1 + T2) && time <= (T1 + k1 + T2 + k2)) { return 0; }
                ///if (time > (T1 + k1 + T2 + k2 + T3) && time <= (T1 + k1 + T2 + k2 + T3 + k3)) { return 0; }
            }
            double dY(double hh, double vv, double ii)
            {
                return (PENG * Math.PI * alpha / 180) / (m*vv) + (CY * ((Math.PI * alpha) / 180) * S * (po * Math.Pow(vv, 2)) / 2) / (m*vv) - ((g * (1 - Math.Pow(vv, 2) / (g * (R+hh))) * Math.Cos(ii)))/vv;  
            }
            double dN(double hh, double vv, double ii)
            {
                return (vv /(R+hh))* Math.Cos(ii);
            }
            double dH(double vv, double ii)
            {
                return vv * Math.Sin(ii);
            }
            /// Объявление начальных значений параметров дифференциального расчета
            V = V0; H = H0; m = M1; time = t0; Y = Y0;
           
            alpha = alpha0;
            N = N0;
            U = Y - N + Math.PI*alpha/180;
            stage1 = true; stage2 = true; stage3 = true;

            /// Создание графиков
            chart1.Series[0].Points.Clear();
            chart4.Series[0].Points.Clear();
            chart6.Series[0].Points.Clear();
            chart8.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(time, m);
            chart4.Series[0].Points.AddXY(time, V);
            chart6.Series[0].Points.AddXY(time, H);
            chart8.Series[0].Points.AddXY(x, y);

            Form4.timelist.Clear();
            Form4.alphalist.Clear();
            Form4.Nlist.Clear();
            Form4.Ylist.Clear();
            Form4.Ulist.Clear();
            Form4.Ottlist.Clear();

            Form5.timelist.Clear();
            /// Задание параметров каждой ступени
            Y = Math.PI / 2.0;

            while (time < T1 + k1 + T2 + k2 + T3 + k3 + 1 && H >= 0)
                {
                if (time <= T1)
                {
                    PENG = PENG1;
                    w = w1;
                    dM = PENG1 / w1;
                    Lrocket = Form3.Lgo + Form3.Lb1 + Form3.Lb2 + Form3.Lb3; 
                }
                if (time > T1 && time <= (T1+k1))
                {
                    if (stage1)
                    {
                        m -= mb1 - mt1;
                        stage1 = false;
                    }
                    ///PENG = 0;
                    ///w = 0;
                    ///dM = 0;
                    PENG = 0;
                    w = w1;
                    dM = PENG1 / w1;
                    Lrocket = Form3.Lgo + Form3.Lb2 + Form3.Lb3;
                }

                if (time > (T1+k1) && time <= (T1 + k1 + T2))
                {
                    PENG = PENG2;
                    w = w2;
                    dM = PENG / w;
                    Lrocket = Form3.Lgo + Form3.Lb2 + Form3.Lb3;
                }

                if (time > (T1 + k1 + T2) && time <= (T1 + k1 + T2 + k2))
                {
                    if (stage2)
                    {
                        m -= mb2 - mt2;
                        stage2 = false;
                    }
                    ///PENG = 0;
                    ///w = 0;
                    ///dM = 0;
                    PENG = 0;
                    w = w2;
                    dM = PENG2 / w2;
                    Lrocket = Form3.Lgo + Form3.Lb3;
                }

                if (time > (T1 + k1 + T2 + k2) && time <= (T1 + k1 + T2 + k2 + T3))
                {
                    PENG = PENG3;
                    w = w3;
                    dM = PENG3 / w3;
                    Lrocket = Form3.Lgo + Form3.Lb3;
                }

                if (time > (T1 + k1 + T2 + k2 + T3) && time <= (T1 + k1 + T2 + k2 + T3 + k3))
                {
                    if (stage3)
                    {
                        m -= mb3 - mt3;
                        stage3 = false;
                    }
                    ///PENG = 0;
                    ///w = 0;
                    ///dM = 0;
                    PENG = 0;
                    w = w3;
                    dM = PENG3 / w3;
                    Lrocket = Form3.Lgo;
                }

                if (time > (T1 + k1 + T2 + k2 + T3 + k3)) 
                {
                    Lrocket = Form3.Lgo;
                    PENG = PENG3;
                    w = w3;
                    dM = PENG3 / w3;
                }
                /// Введение атмосферы
                
                    /// Коэффициенты полинома молярной массы
                    if (H >= 120000 && H < 250000)  { B0 = 46.9083;  B1 = -29.71210 * Math.Pow(10, -5); B2 = 12.08693 * Math.Pow(10, -10); B3 = -1.85675 * Math.Pow(10, -15); }
                    if (H >= 250000 && H < 400000)  { B0 = 40.4668;  B1 = -15.52722 * Math.Pow(10, -5); B2 = 3.55735 * Math.Pow(10, -10);  B3 = -3.02340 * Math.Pow(10, -16); }
                    if (H >= 400000 && H < 650000)  { B0 = 6.3770;   B1 = 6.25497 * Math.Pow(10, -5);   B2 = -1.10144 * Math.Pow(10, -10); B3 = 3.36907 * Math.Pow(10, -17); }
                    if (H >= 650000 && H < 900000)  { B0 = 75.6896;  B1 = -17.61243 * Math.Pow(10, -5); B2 = 1.33603 * Math.Pow(10, -10);  B3 = -2.87884 * Math.Pow(10, -17); }
                    if (H >= 900000 && H < 1050000) { B0 = 112.4838; B1 = -30.68086 * Math.Pow(10, -5); B2 = 2.90329 * Math.Pow(10, -10);  B3 = -9.20616 * Math.Pow(10, -17); }
                    if (H >= 1050000&& H < 1200000) { B0 = 9.8970;   B1 = -1.19732 * Math.Pow(10, -5);  B2 = 7.78247 * Math.Pow(10, -10);  B3 = -1.77541 * Math.Pow(10, -18); }
                    /// Молярная масса
                    if (H <  94000)                 { Mol = Mc; }
                    if (H >= 94000 && H < 97000)    { Mol = 28.82 + 0.158 * Math.Pow(1 - 7.5 * Math.Pow(10, -8) * Math.Pow((H - 94000), 2), 0.5) - 2.479 * Math.Pow(10, -4) * Math.Pow((97000 - H), 0.5); }
                    if (H >= 97000 && H < 120000)   { Mol -= 0.00015*dH(V,Y); }
                    if (H >= 120000 && H < 1200000) { Mol = B0 + B1 * H + B2 * Math.Pow(H, 2) + B3 * Math.Pow(H, 3); }

                    if (H < 120000)
                    { 
                    Bett = (7466*Math.Pow(H,3)- 1262795028*Math.Pow(H, 2)+61597340039789*H-833732588564247562) * Math.Pow(10,-20);
                    /// Давление
                    if (Bett == 0) { pp = Math.Log(P); P = Math.Exp(pp - (0.434294*gc / (r*T))*dH(V, Y)); }
                    if (Bett != 0) { pp = Math.Log(P); P = Math.Exp(pp - (gc * Math.Log((Tm + Bett * (R * dH(V, Y)) / (R + dH(V, Y))) / Tm)) / (Bett * r)); }
                    /// Температура
                    Tm += Bett * (R * dH(V, Y)) / (R + dH(V, Y));
                    T = Tm * Mol / Mc;
                    /// Плотность
                    po = (P * Mol) / (RB * T);
                    /// Концентрация частиц воздуха
                    n = 7.243611 * Math.Pow(10, 22) * P / T;
                    }
                    if (H >= 120000 && H < 1200000)
                    {
                        if (H >= 120000 && H < 140000) { Bett = 0.0112592;  A0 = 0.210005867 * Math.Pow(10, 4); A1 = 0.5618444757 * Math.Pow(10, -1); A2 = 0.5663986231 * Math.Pow(10, -6); A3 = 0.2547466858 * Math.Pow(10, -11); A4 = 0.4309844119 * Math.Pow(10, -17); mstep = 17; }
                        if (H >= 160000 && H < 200000) { Bett = 0.003970;   A0 = 0.10163937 * Math.Pow(10, 4);  A1 = 0.2119530830 * Math.Pow(10, -1); A2 = 0.1671627815 * Math.Pow(10, -6); A3 = 0.5894237068 * Math.Pow(10, -12); A4 = 0.7826684089 * Math.Pow(10, -18); mstep = 16; }
                        if (H >= 200000 && H < 250000) { Bett = 0.001750;   A0 = 0.7631575 * Math.Pow(10, 3);   A1 = 0.1150600844 * Math.Pow(10, -1); A2 = 0.6612598428 * Math.Pow(10, -7); A3 = 0.1708736137 * Math.Pow(10, -12); A4 = 0.1669823114 * Math.Pow(10, -18); mstep = 15; }
                        if (H >= 250000 && H < 325000) { Bett = 0.000570;   A0 = 0.1882203 * Math.Pow(10, 3);   A1 = 0.2265999519 * Math.Pow(10, -2); A2 = 0.1041726141 * Math.Pow(10, -7); A3 = 0.2155574922 * Math.Pow(10, -13); A4 = 0.1687430962 * Math.Pow(10, -19); mstep = 15; }
                        if (H >= 325000 && H < 400000) { Bett = 0.0001500;  A0 = 0.2804823 * Math.Pow(10, 3);   A1 = 0.2432231125 * Math.Pow(10, -2); A2 = 0.8055024663 * Math.Pow(10, -8); A3 = 0.1202418519 * Math.Pow(10, -13); A4 = 0.6805101379 * Math.Pow(10, -20); mstep = 14; }
                        if (H >= 400000 && H < 600000) { Bett = 0.0000200;  A0 = 0.5599362 * Math.Pow(10, 3);   A1 = 0.3714141392 * Math.Pow(10, -2); A2 = 0.9358870345 * Math.Pow(10, -8); A3 = 0.1058591881 * Math.Pow(10, -13); A4 = 0.4525531532 * Math.Pow(10, -20); mstep = 13; }
                        if (H >= 600000 && H < 800000) { Bett = 0.0000005;  A0 = 0.8358756 * Math.Pow(10, 3);   A1 = 0.4265393073 * Math.Pow(10, -2); A2 = 0.8252842085 * Math.Pow(10, -8); A3 = 0.7150127437 * Math.Pow(10, -14); A4 = 0.2335744331 * Math.Pow(10, -20); mstep = 12; }
                        if (H >= 800000 && H <1200000) { Bett = 0.000000;   A0 = 0.210005867 * Math.Pow(10, 2); A1 = 0.3162492458 * Math.Pow(10, -3); A2 = 0.4602064246 * Math.Pow(10, -9); A3 = 0.3021858469 * Math.Pow(10, -15); A4 = 0.4309844119 * Math.Pow(10, -22); mstep = 12; }
                        n = (A0 + A1 * H + A2 * Math.Pow(H, 2) + A3 * Math.Pow(H, 3) + A4 * Math.Pow(H, 4))*Math.Pow(10,mstep);
                    /// Давление
                    T += Bett *  dH(V, Y);
                    P = RB * T * n / Na;
                    po = (P*Mol) / (RB * T);
                    }
                    tCel = T - 273.15;
                    yyd = po * g;
                    Hmas = (RB / Mol) * (T / g);
                    a = 20.046796 * Math.Sqrt(T);
                    Mah = V / a;
                    vsred = 145.50685 * T / Mol;
                    lsred = 2.332376 * Math.Pow(10, -5) * T / P;
                    omega = 6.238629 * Math.Pow(10, 6) * P / Math.Sqrt(T*Mol);
                    lamb = (2.648151 * Math.Pow(10, -3) * Math.Pow(T, 3/2))/(T+245.4* Math.Pow(10, -(12/T)));

                ///Re = (a * Mah * Lrocket )/ nuc;

                ///Re = 485000;
                /// CY
                CIL = (Form3.Lrocket - Form3.Lgo) / D; CON = (Form3.Lgo) / D; CILCON = CIL / CON;
                Mhi = Math.Sqrt(Math.Abs(Math.Pow(Mah, 2) - 1)) / CON;


                if ((Mah > 0) && (Mah <= 0.25)) CY = 2.8;
                if ((Mah > 0.25) && (Mah <= 1.1)) CY = 2.8+0.447*(Mah-0.25);
                if ((Mah > 1.1) && (Mah <= 1.6)) CY = 3.18 - 0.660 * (Mah - 1.1);
                if ((Mah > 1.6) && (Mah <= 3.6)) CY = 2.85 + 0.350 * (Mah - 1.6);
                if (Mah > 3.6) CY = 12.78/Mah;

                if (Mah <= 0.8) { CX = 0.29; };
                if (Mah > 0.8 && Mah < 1.068) { CX = Mah-0.51; };
                if (Mah >= 1.068) { CX = 0.597/Mah; };
                if (CX > 1) { CX = 1; };


                //Решение дифференциальных уравнений методом Эйлера
                H += t * dH(V, Y);
                V += t * dV(V, Y);
                Y += t * dY(H, V, Y);
                N += t * dN(H, V, Y) ;



                x += t * V* Math.Cos(Y);
                y += t * V* Math.Sin(Y);

                /// Расчет угла тангажа
                U = Y - N + Math.PI*alpha/180;
                ER = Y - N;

                // Программа изменения угла атаки
                if (time > 15 && time < 20)
                {
                    alpha = alpha1;
                }
                else

                if (time >= T1)
                {
                    alpha = alpha2 * Math.Sqrt((time - T1));
                }
                else
                alpha = alpha0;
                /// Программа изменения угла наклона траектории

                if (time < 15) Ott = 90;
                if (time >= 15 && time <= v1) Ott = (90 - 30) * Math.Pow((v1 - time), 2) / Math.Pow((v1 - 15), 2) + 30;
                if (time > v1 && time <= v2) Ott = 30 - (30 - 0.2 * 30) * (time - v1) / (v2 - v1);
                if (time > v2 && time <= v3) Ott = 0.2 * 30 - (0.2 * 30 - 0) * (time - v2) / (v3 - v2);
                if (time > v3) Ott = 0;

                /// Время полета
                time += t;
                /// Изменение массы РН
                m -= t * dM;
                ///PRUV = nu;
                ///xpruv = time;
                /// Вывод результатов моделирования на графиках
                chart1.Series[0].Points.AddXY(time, m);
                chart1.ChartAreas[0].AxisX.Title = "t,c";
                chart1.ChartAreas[0].AxisY.Title = "m, кг";
                chart1.Series[0].Name = "Масса РН";

                ///
                chart4.Series[0].Points.AddXY(time, V);
                chart4.ChartAreas[0].AxisX.Title = "t,c";
                chart4.ChartAreas[0].AxisY.Title = "V, км/с";
                chart4.Series[0].Name = "Скорость РН";

                ///
                chart6.Series[0].Points.AddXY(time, H/1000);
                chart6.ChartAreas[0].AxisX.Title = "t,c";
                chart6.ChartAreas[0].AxisY.Title = "H, км";
                chart6.Series[0].Name = "Высота полета";

                ///
                chart8.Series[0].Points.AddXY(x/1000, y/1000);
                chart8.ChartAreas[0].AxisX.Title = "x, км";
                chart8.ChartAreas[0].AxisY.Title = "y, км";
                chart8.Series[0].Name = "Траектория";

                /// Вывод конечных значений параметров
                textBox1.Text = Convert.ToString(Ott);
                textBox2.Text = Convert.ToString(m);
                textBox5.Text = Convert.ToString(V);
                textBox6.Text = Convert.ToString(H/1000);
                textBox3.Text = Convert.ToString(N);
                textBox4.Text = Convert.ToString(Y*180/Math.PI);
                textBox7.Text = Convert.ToString(time);
                textBox13.Text= Convert.ToString(U * 180 / Math.PI);



                Form4.timelist.Add(time);
                Form4.alphalist.Add(alpha);
                Form4.Nlist.Add(N);
                Form4.Ylist.Add(Y);
                Form4.Ulist.Add(U);
                Form4.Ottlist.Add(Ott);

                Form5.timelist.Add(time);
                Form5.Mahlist.Add(Mah);

                Form6.timelist.Add(time);
                Form6.Mahlist.Add(Mah);
                Form6.Hlist.Add(H);
                Form6.Plist.Add(P);
                Form6.polist.Add(po);
                Form6.Tlist.Add(T);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
