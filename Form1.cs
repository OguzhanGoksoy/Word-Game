using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int harfsayisi, kelimeno, puan, hak, kactanevar, kelimesayisi;

        List<string> kelimeler = new List<string>();

        Label[] harf;

        Random rnd = new Random();

        private void BHARFAL_Click(object sender, EventArgs e)
        {
            byte var = 0; kactanevar = 0;
            LUYARI.Text = "";
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString() == TBTAHMİN.Text)
                {
                    var = 1;

                }
            }
            if (var == 0)
            {
                listBox1.Items.Add(TBTAHMİN.Text);
                for (int i = 0; i < harfsayisi; i++)
                {
                    if (kelimeler[kelimeno].Substring(i, 1) == TBTAHMİN.Text)
                    {
                        harf[i].Text = TBTAHMİN.Text;
                        kactanevar++;
                    }
                }
                if (kactanevar > 0)
                {
                    puan = puan + kactanevar * 10;
                    LPUAN.Text = puan.ToString();

                }
                else
                {
                    hak--;
                    LHAK.Text = hak.ToString();
                    BYENİ.Enabled = true;
                    
                    BYENİ.Enabled = true;
                TBTAHMİN: Enabled = true;
                }
                if (harfsayisi == (puan / 10))
                {
                    LUYARI.Text =  " TEBRİKLER! ";
                    TBTAHMİN.Enabled = false;
                    BYENİ.Enabled = true;
                TBTAHMİN: Enabled = true;
                }
                if (hak == 0)
                {
                    LUYARI.Text = "BİLEMEDİNİZ!  " + kelimeler[kelimeno] + "  OLACAKTI ";
                BHARFAL: Enabled = false;
                TBTAHMİN: Enabled = true;

                    

                }

            }
            else
            {
                LUYARI.Text = "BU HARF DAHA ÖNCE SÖYLENDİ!";

            }
            TBTAHMİN.Text = "";
            TBTAHMİN.Focus();
           
        


        }
        


        private void BYENİ_Click(object sender, EventArgs e)
        {
            for (int i = 0; i<harfsayisi; i++)
            {
                harf[i].Dispose();

            }
            BBASLA.Enabled = true;
            BYENİ.Enabled = true;
            TBTAHMİN.Enabled = false;

        }

        


        private void BBASLA_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            TBTAHMİN.Text = "";
            TBTAHMİN.Enabled = true;
            kelimeno = rnd.Next(kelimesayisi);
            harfsayisi = kelimeler[kelimeno].Length;

            harf = new Label[harfsayisi];

            for (int i = 0; i<harfsayisi; i++)
            {
                harf[i] = new Label();
                harf[i].Text = "___";
                harf[i].Parent = this;
                harf[i].Location = new Point(50 + i * 30, 220);
                harf[i].Size = new Size(25, 25);
                harf[i].Name = harf + i.ToString();

            }

            LPUAN.Text = "0"; puan = 0; LHAK.Text = "5"; hak = 5; kactanevar = 0;
            TBTAHMİN.Focus();
            BBASLA.Enabled = false;
            BYENİ.Enabled = true;
        TBTAHMİN: Enabled = true;

        }

        

       
        private void Form1_Load(object sender, EventArgs e)
        {
            kelimeler.Add("TÜRKİYE"); kelimeler.Add("LÜKSEMBURG"); kelimeler.Add("ARJANTİN"); kelimeler.Add("ENDONEZYA");
            kelimeler.Add("TOKYO"); kelimeler.Add("ABD"); kelimeler.Add("GANA"); kelimeler.Add("ŞİLİ"); kelimeler.Add("İTALYA");
            kelimeler.Add("ROMANYA"); kelimeler.Add("KENYA"); kelimeler.Add("BREZİLYA");
            kelimesayisi = kelimeler.Count();
        TBTAHMİN: Enabled = true;
        }
    }
}
