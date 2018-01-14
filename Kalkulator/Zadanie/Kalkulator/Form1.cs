using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class frmKalkulator : Form
    {
        const int PLUS = 1;
        const int MINUS = 2;
        const int RAZY = 3;
        const int PODZIELIC = 4;

        double a = 0;
        double b = 0;
        int dzialanie = 0;
        bool kropka = false;
        int ilepoprzecinku = 0;
        int znak = PLUS;
        bool czykasowacekran = false;

        public void pokazznaki()
        {
            cmdSuma.Enabled = true;
            cmdRoznica.Enabled = true;
            cmdIloczyn.Enabled = true;
            cmdIloraz.Enabled = true;
            if (dzialanie != 0) cmdWynik.Enabled = true;
            cmdZnak.Enabled = true;
        }

        public void ukryjznaki()
        {
            cmdSuma.Enabled = false;
            cmdRoznica.Enabled = false;
            cmdIloczyn.Enabled = false;
            cmdIloraz.Enabled = false;
            cmdWynik.Enabled = false;
            cmdZnak.Enabled = false;
        }

        public void cyfry(int i)
        {
            pokazznaki();
            if (dzialanie != 0)
            {
                if (!kropka) a = 10 * a + i;
                else
                {
                    if (i != 0) a = a + i / (Math.Pow(10, ilepoprzecinku++));
                    else ++ilepoprzecinku;
                }
            }
            else
            {
                if (!kropka) b = 10 * b + i;
                else
                {
                    if (i != 0) b = b + i / (Math.Pow(10, ilepoprzecinku++));
                    else ++ilepoprzecinku;
                }
            }

            if (czykasowacekran)
            {
                txtWynik.Text = "";
                czykasowacekran = false;
                znak = PLUS;
            }
            txtWynik.Text += i.ToString();
        }

        public double dzialaj(double x, double y, int dz)
        {
            ukryjznaki();
            double wynik = 0;
            if (dzialanie != 0)
            {
                switch (dzialanie)
                {
                    case PLUS: wynik = y + x; break;
                    case MINUS: wynik = y - x; break;
                    case RAZY: wynik = y * x; break;
                    case PODZIELIC: wynik = y / x; break;
                }
                txtWynik.Text = wynik.ToString();
                a = 0;
            }
            else wynik = y;
            dzialanie = dz;
            czykasowacekran = true;
            cmdKropka.Enabled = true;
            ilepoprzecinku = 0;
            return wynik;
        }



        public frmKalkulator()
        {
            InitializeComponent();
        }

        private void cmd1_Click(object sender, EventArgs e)
        {
            cyfry(1);
        }

        private void cmd2_Click(object sender, EventArgs e)
        {
            cyfry(2);
        }

        private void cmd3_Click(object sender, EventArgs e)
        {
            cyfry(3);
        }

        private void cmd4_Click(object sender, EventArgs e)
        {
            cyfry(4);
        }

        private void cmd5_Click(object sender, EventArgs e)
        {
            cyfry(5);
        }

        private void cmd6_Click(object sender, EventArgs e)
        {
            cyfry(6);
        }

        private void cmd7_Click(object sender, EventArgs e)
        {
            cyfry(7);
        }

        private void cmd8_Click(object sender, EventArgs e)
        {
            cyfry(8);
        }

        private void cmd9_Click(object sender, EventArgs e)
        {
            cyfry(9);
        }

        private void cmd0_Click(object sender, EventArgs e)
        {
            cyfry(0);
        }

        private void cmdKropka_Click(object sender, EventArgs e)
        {
            if (czykasowacekran)
            {
                txtWynik.Text = "";
                czykasowacekran = false;
                znak = PLUS;
            }
            if (txtWynik.Text == "") txtWynik.Text = "0";
            txtWynik.Text += ",";
            cmdKropka.Enabled = false;
            kropka = true;
            ilepoprzecinku = 1;
        }

        private void cmdSuma_Click(object sender, EventArgs e)
        {
            b = dzialaj(a, b, PLUS);
        }

        private void cmdRoznica_Click(object sender, EventArgs e)
        {
            b = dzialaj(a, b, MINUS);
        }

        private void cmdIloczyn_Click(object sender, EventArgs e)
        {
            b = dzialaj(a, b, RAZY);
        }

        private void cmdIloraz_Click(object sender, EventArgs e)
        {
            b = dzialaj(a, b, PODZIELIC);
        }

        private void cmdZnak_Click(object sender, EventArgs e)
        {
            if (znak == PLUS) znak = MINUS;
            else znak = PLUS;

            if (dzialanie != 0) { a = -a; txtWynik.Text = a.ToString(); }
            else { b = -b; txtWynik.Text = b.ToString(); }
        }

        private void cmdWynik_Click(object sender, EventArgs e)
        {
            b = dzialaj(a, b, dzialanie);
            txtWynik.Text = b.ToString();
            cmdKropka.Enabled = true;
            dzialanie = PLUS;
            a = 0;
            pokazznaki();
            cmdWynik.Enabled = false;
            cmdZnak.Enabled = false;
        }

        private void cmdAnuluj_Click(object sender, EventArgs e)
        {
            a = b = 0;
            dzialanie = 0;
            kropka = false;
            ilepoprzecinku = 0;
            txtWynik.Text = "";
            znak = PLUS;
            czykasowacekran = false;
            ukryjznaki();
        }

        private void frmKalkulator_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '+': if (cmdSuma.Enabled) cmdSuma_Click(sender, e); return;
                case '-': if (cmdRoznica.Enabled) cmdRoznica_Click(sender, e); return;
                case '*': if (cmdIloczyn.Enabled) cmdIloczyn_Click(sender, e); return;
                case '/': if (cmdIloraz.Enabled) cmdIloraz_Click(sender, e); return;
                case (char)13: if (cmdWynik.Enabled) cmdWynik_Click(sender, e); return; // enter
                case (char)27: cmdAnuluj_Click(sender, e); return; // escape
                case '.':
                case ',': if (cmdKropka.Enabled) cmdKropka_Click(sender, e); return;
            }
            int n = (int)e.KeyChar;
            if (n < 48 || n > 57) return;
            n = int.Parse( e.KeyChar.ToString() );
            cyfry(n);
            return;
        }
    }
}