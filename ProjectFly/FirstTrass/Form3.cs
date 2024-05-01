using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace FirstTrass
{

    public partial class Form3 : Form
    {

        public static double w1,w2,w3;
        public static double PENG1, PENG2, PENG3;
        public static double PENG1n, PENG2n, PENG3n;
        public static double mb1, mb2, mb3;
        public static double mpn;
        public static double pg;
        public static double po;
        public static double kompsot;
        public static double mk1, mk2, mk3, pk, wk1, wk2, wk3, psr, wgo, wpo, mg1, mg2, mg3, wg1, wg2, wg3, mo1, mo2, mo3, wo1, wo2, wo3,
                             Lg1, Lg2, Lg3, Lo1, Lo2, Lo3, Lb1, Lb2, Lb3, Lgo, Lrocket, wrocket, mt1, mt2, mt3, Leng1, Leng2, Leng3;

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = SkyFlight.Properties.Settings.Default.s1;
            textBox2.Text = SkyFlight.Properties.Settings.Default.s2;
            textBox3.Text = SkyFlight.Properties.Settings.Default.s3;
            textBox6.Text = SkyFlight.Properties.Settings.Default.m1;
            textBox5.Text = SkyFlight.Properties.Settings.Default.m2;
            textBox4.Text = SkyFlight.Properties.Settings.Default.m3;
            textBox13.Text = SkyFlight.Properties.Settings.Default.mpn;
            textBox9.Text = SkyFlight.Properties.Settings.Default.w1;
            textBox8.Text = SkyFlight.Properties.Settings.Default.w2;
            textBox7.Text = SkyFlight.Properties.Settings.Default.w3;
            textBox14.Text = SkyFlight.Properties.Settings.Default.H;
            textBox18.Text = SkyFlight.Properties.Settings.Default.n1;
            textBox17.Text = SkyFlight.Properties.Settings.Default.n2;
            textBox19.Text = SkyFlight.Properties.Settings.Default.n3;
            textBox15.Text = SkyFlight.Properties.Settings.Default.Dr;
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            SkyFlight.Properties.Settings.Default.s1 = textBox1.Text;
            SkyFlight.Properties.Settings.Default.s2 = textBox2.Text;
            SkyFlight.Properties.Settings.Default.s3 = textBox3.Text;
            SkyFlight.Properties.Settings.Default.m1 = textBox6.Text;
            SkyFlight.Properties.Settings.Default.m2 = textBox5.Text;
            SkyFlight.Properties.Settings.Default.m3 = textBox4.Text;
            SkyFlight.Properties.Settings.Default.mpn = textBox13.Text;
            SkyFlight.Properties.Settings.Default.w1 = textBox9.Text;
            SkyFlight.Properties.Settings.Default.w2 = textBox8.Text;
            SkyFlight.Properties.Settings.Default.w3 = textBox7.Text;
            SkyFlight.Properties.Settings.Default.H = textBox14.Text;
            SkyFlight.Properties.Settings.Default.n1 = textBox18.Text;
            SkyFlight.Properties.Settings.Default.n2 = textBox17.Text;
            SkyFlight.Properties.Settings.Default.n3 = textBox19.Text;
            SkyFlight.Properties.Settings.Default.Dr = textBox15.Text;
            SkyFlight.Properties.Settings.Default.Save();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            mb1 = Convert.ToDouble(textBox6.Text);
            mb2 = Convert.ToDouble(textBox5.Text);
            mb3 = Convert.ToDouble(textBox4.Text);
            mpn = Convert.ToDouble(textBox13.Text);
            N1 = Convert.ToDouble(textBox18.Text);
            N2 = Convert.ToDouble(textBox17.Text);
            N3 = Convert.ToDouble(textBox19.Text);
            PENG1n = N1 * (mpn + mb1 + mb2 + mb3)*9.81;
            PENG2n = N2 * (mpn + mb2 + mb3) * 9.81;
            PENG3n = N3 * (mpn + mb3) * 9.81;
            PENG1n /= 1000; PENG1n = Math.Round(PENG1n, 0); PENG1n *= 1000;
            PENG2n /= 1000; PENG2n = Math.Round(PENG2n, 0); PENG2n *= 1000;
            PENG3n /= 1000; PENG3n = Math.Round(PENG3n, 0); PENG3n *= 1000;

            textBox12.Text = Convert.ToString(PENG1n);
            textBox11.Text = Convert.ToString(PENG2n);
            textBox10.Text = Convert.ToString(PENG3n);
            textBox16.Text = Convert.ToString(mpn*1.1+mb1+mb2+mb3);
            button1.Enabled = true;
        }

        public static double H;
        public static double N1, N2, N3;



        private void button3_Click(object sender, EventArgs e)
        {
            //new Form5().Show();
            this.Enabled = true;

            if (radioButton1.Checked) { pg = 840; po = 1140; kompsot = 2.7; }
            if (radioButton3.Checked) { pg = 500; po = 1140; kompsot = 3.5; }
            if (radioButton4.Checked) { pg = 71; po = 1140; kompsot = 5.5; }
            if (radioButton2.Checked) { pg = 1443; po = 793; kompsot = 3; }

            w1 = Convert.ToDouble(textBox9.Text);
            w2 = Convert.ToDouble(textBox8.Text);
            w3 = Convert.ToDouble(textBox7.Text);
            PENG1 = Convert.ToDouble(textBox12.Text);
            PENG2 = Convert.ToDouble(textBox11.Text);
            PENG3 = Convert.ToDouble(textBox10.Text);

            D = Convert.ToDouble(textBox15.Text);
            s1 = Convert.ToDouble(textBox1.Text);
            s2 = Convert.ToDouble(textBox2.Text);
            s3 = Convert.ToDouble(textBox3.Text);



            Leng1 = 0.85 * 1.4 * 0.125 * Math.Pow(PENG1 / 9.8, 0.25); Leng2 = 0.85 * 1.4 * 0.125 * Math.Pow(PENG2 / 9.8, 0.25); Leng3 = 0.85 * 1.4 * 0.125 * Math.Pow(PENG3 / 9.8, 0.25);
            mt1 = mb1 * (s1 - 1) / s1; mt2 = mb2 * (s2 - 1) /s2; mt3 = mb3 * (s3 - 1) / s3;
            mk1 = mb1 - mt1; mk2 = mb2 - mt2; mk3 = mb3 - mt3;
            pk = 100;
            wk1 = mk1 / pk; wk2 = mk2 / pk; wk3 = mk3 / pk;
            psr = po * pg * (kompsot + 1) / (kompsot * pg + po);

            wgo = (mpn * 1.1 * 1.5) / 800;
            wpo = (mpn + mb1 + mb2 + mb3) * 0.0008 / 150;

            mg1 = mt1 * 1 / (1 + kompsot); mg2 = mt2 * 1 / (1 + kompsot); mg3 = mt3 * 1 / (1 + kompsot);
            mo1 = mt1 * kompsot / (1 + kompsot); mo2 = mt2 * kompsot / (1 + kompsot); mo3 = mt3 * kompsot / (1 + kompsot);

            wg1 = mg1 / pg; wg2 = mg2 / pg; wg3 = mg3 / pg;
            wo1 = mo1 / po; wo2 = mo2 / po; wo3 = mo3 / po;

            wrocket = (wg1 + wg2 + wg3 + wo1 + wo2 + wo3 + wk1 + wk2 + wk3 + wpo + wgo) / (1 - 0.15);

            Lg1 = wg1 * 4 / (Math.PI * Math.Pow(D, 2)); Lg2 = wg2 * 4 / (Math.PI * Math.Pow(D, 2)); Lg3 = wg3 * 4 / (Math.PI * Math.Pow(D, 2));
            Lo1 = wo1 * 4 / (Math.PI * Math.Pow(D, 2)); Lo2 = wo2 * 4 / (Math.PI * Math.Pow(D, 2)); Lo3 = wo3 * 4 / (Math.PI * Math.Pow(D, 2));

            Lgo = (wgo + wpo) * 3 * 4 / (Math.PI * Math.Pow(D, 2));
            Lb1 = Lg1 + Lo1 + Leng1; Lb2 = Lg2 + Lo2 + Leng2; Lb3 = Lg3 + Lo3 + Leng3;
            Lrocket = Lgo + Lb1 + Lb2 + Lb3; //textBox15.Text = Convert.ToString(pg);
        }

        public static double D;
        public static double s1,s2,s3;
        public Form3()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Form1();
            f.Show();
            //this.Hide();

            if (radioButton1.Checked) { pg = 840; po = 1140; kompsot = 2.7; }
            if (radioButton3.Checked) { pg = 500; po = 1140; kompsot = 3.5; }
            if (radioButton4.Checked) { pg = 71; po = 1140; kompsot = 5.5; }
            if (radioButton2.Checked) { pg = 1443; po = 793; kompsot = 3; }
            // Form1 fm2 = new Form1();
            w1 = Convert.ToDouble(textBox9.Text);
            w2 = Convert.ToDouble(textBox8.Text);
            w3 = Convert.ToDouble(textBox7.Text);
            PENG1 = Convert.ToDouble(textBox12.Text);
            PENG2 = Convert.ToDouble(textBox11.Text);
            PENG3 = Convert.ToDouble(textBox10.Text);
            mb1 = Convert.ToDouble(textBox6.Text); 
            mb2 = Convert.ToDouble(textBox5.Text); 
            mb3 = Convert.ToDouble(textBox4.Text); 
            mpn = Convert.ToDouble(textBox13.Text); 
            D = Convert.ToDouble(textBox15.Text); 
            s1 = Convert.ToDouble(textBox1.Text); 
            s2 = Convert.ToDouble(textBox2.Text); 
            s3 = Convert.ToDouble(textBox3.Text);
            H = Convert.ToDouble(textBox14.Text);

            Leng1 = 0.85 * 1.4 * 0.125 * Math.Pow(PENG1 / 9.8, 0.25); Leng2 = 0.85 * 1.4 * 0.125 * Math.Pow(PENG2 / 9.8, 0.25); Leng3 = 0.85 * 1.4 * 0.125 * Math.Pow(PENG3 / 9.8, 0.25);
            mt1 = mb1 * (s1 - 1) / s1; mt2 = mb2 * (s2 - 1) / s2; mt3 = mb3 * (s3 - 1) / s3;
            mk1 = mb1 - mt1; mk2 = mb2 - mt2; mk3 = mb3 - mt3;
            pk = 100;
            wk1 = mk1 / pk; wk2 = mk2 / pk; wk3 = mk3 / pk;
            psr = po * pg * (kompsot + 1) / (kompsot * pg + po);

            wgo = (mpn * 1.1 * 1.5) / 800;
            wpo = (mpn + mb1 + mb2 + mb3) * 0.0008 / 150;

            mg1 = mt1 * 1 / (1 + kompsot); mg2 = mt2 * 1 / (1 + kompsot); mg3 = mt3 * 1 / (1 + kompsot);
            mo1 = mt1 * kompsot / (1 + kompsot); mo2 = mt2 * kompsot / (1 + kompsot); mo3 = mt3 * kompsot / (1 + kompsot);

            wg1 = mg1 / pg; wg2 = mg2 / pg; wg3 = mg3 / pg;
            wo1 = mo1 / po; wo2 = mo2 / po; wo3 = mo3 / po;

            wrocket = (wg1 + wg2 + wg3 + wo1 + wo2 + wo3 + wk1 + wk2 + wk3 + wpo + wgo) / (1 - 0.15);

            Lg1 = wg1 * 4 / (Math.PI * Math.Pow(D, 2)); Lg2 = wg2 * 4 / (Math.PI * Math.Pow(D, 2)); Lg3 = wg3 * 4 / (Math.PI * Math.Pow(D, 2));
            Lo1 = wo1 * 4 / (Math.PI * Math.Pow(D, 2)); Lo2 = wo2 * 4 / (Math.PI * Math.Pow(D, 2)); Lo3 = wo3 * 4 / (Math.PI * Math.Pow(D, 2));

            Lgo = (wgo + wpo) * 3 * 4 / (Math.PI * Math.Pow(D, 2));
            Lb1 = Lg1 + Lo1 + Leng1; Lb2 = Lg2 + Lo2 + Leng2; Lb3 = Lg3 + Lo3 + Leng3;
            Lrocket = Lgo + Lb1 + Lb2 + Lb3; //textBox15.Text = Convert.ToString(pg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
    static class FirstTrass
    {

    }
}
