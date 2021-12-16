using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int harfsayisi,kelimeno,puan,hak,kactanevar,kelimesayisi;

        List<string> kelimeler=new List<string>();

        //string[] kelimeler =  {"TÜRKİYE", "ESTONYA", "ROMANYA", "LİTVANYA", "İTALYA"};
        //Dizi tanımlaması, Kullanılacak kelimeleri tutan dizi.

        Label[] harf;
        //Harfler için kullanılacak label bileşen dizisi tanımlaması. Bileşenler runtime oluşturulacak.

        Random rnd = new Random();
        //Rasgele sayı üretecek değişken

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            TBTAHMİN.Text = "";
            TBTAHMİN.Enabled = true;
            kelimeno = rnd.Next(kelimesayisi); //Yeni bir rasgele sayı üretme işi, 0 ile 4 arası
            harfsayisi = kelimeler[kelimeno].Length; //length string uzunluğunu bulur.
            //textBox1.Text = kelimeno.ToString() + kelimeler[(kelimeno)] + harfsayisi.ToString(); ;
            harf=new Label[harfsayisi]; // harfsayısı kadar label tanımlanıyor.
            
            for (int i = 0; i < harfsayisi; i++) //her harf için tekrarla
            {
                harf[i] = new Label(); //bir label üret
                harf[i].Text = "___";  //labelın texti ___ yapıldı
                harf[i].Parent = this;  //labelın hangi bileşen üzerinde olduğunu belirtir,this aktif form
                harf[i].Location = new Point(50+i*30, 220); // location x ve y koordinatlarını vererek bileşeni konumlandırır
                harf[i].Size = new Size(25, 25); // bileşenin genişlik ve yüksekliğini aynı anda belirtir.
                harf[i].Name = harf + i.ToString(); //bileşene harf0, harf1, harf2, ... gibi isimler verdik.
            }

            LPUAN.Text = "0"; puan = 0; LHAK.Text = "5"; hak = 5; kactanevar = 0; //bileşen ve değişkenleri başlangıç durumuna getirdik
            TBTAHMİN.Focus(); //oyun başlayınca harf tahmin textboxına konumlandık.
            BBASLA.Enabled = false;
            BYENI.Enabled = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte var = 0; kactanevar = 0;
            LUYARI.Text = "";
            for (int i = 0; i < listBox1.Items.Count;i++ )  //seçilen harf daha önce söylenmişmi? Tümlistboxı tarar
            {
                if (listBox1.Items[i].ToString() == TBTAHMİN.Text)
                {
                    var = 1;
                }
            }
            if (var == 0) // harf dahaönce söylenmediyse aşağıdakileri yap
            {
                listBox1.Items.Add(TBTAHMİN.Text); //harfi söylenenler listesine ekle (listboxa)
                for (int i = 0; i < harfsayisi; i++) //harfi kelimenin tüm harfleriyle kontrol et
                {
                    if (kelimeler[kelimeno].Substring(i, 1) == TBTAHMİN.Text) //harf kelimenin harfine eşit ise 
                        //substring(başlangıç, harfsayısı) metnin içinden istenilen parçasını alır.
                    {
                        harf[i].Text = TBTAHMİN.Text; // harfi ilgili label bileşenine yaz
                        kactanevar++; //bilme sayısını artır
                    }
                }
                if (kactanevar>0) //en az 1 tane harf bildiyse
                {
                    puan = puan + kactanevar * 10; //harf sayısı kadar 10 puan ekle
                    LPUAN.Text = puan.ToString(); //puanı labela yazdır
                }
                else //seçilen harf hiç yoksa
                {
                    hak--; //hak sayısını 1 azalt
                    LHAK.Text = hak.ToString(); //hak sayısını labela yaz
                }

                if (harfsayisi==(puan/10)) //tüm harfle bilindiyse
                {
                    LUYARI.Text = "TEBRİKLER!"; 
                    TBTAHMİN.Enabled = false;
                }
                if (hak==0) //hiç hak kalmadıysa
                {
                    LUYARI.Text = "BİLEMEDİNİZ! "+kelimeler[kelimeno]+ " OLACAKTI."; //doğru cevabı yaz
                    TBTAHMİN.Enabled = false;
                }
                
            }
            else //seçilen harf daha önce söylendiyse
            {
                LUYARI.Text = "Bu Harf Daha Önce Söylendi!";
            }
            TBTAHMİN.Text = "";
            TBTAHMİN.Focus();
        }

        private void TBTAHMİN_TextChanged(object sender, EventArgs e)
        {
            if ((TBTAHMİN.Text).Length>0) // harf seçilince
            {
                BHARFAL.Enabled = true;
            }
            else
            {
                BHARFAL.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < harfsayisi; i++) //önceki kelimenin harf labellarını bellekten silmek
            {
                harf[i].Dispose(); //bileşeni siler
            }
            BBASLA.Enabled = true;
            BYENI.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kelimeler.Add("TÜRKİYE"); kelimeler.Add("LÜKSEMBURG"); kelimeler.Add("ARJANTİN");
            kelimeler.Add("ENDONEZYA"); kelimeler.Add("BREZİLYA"); kelimeler.Add("KAMBOÇYA");
            kelimeler.Add("MACARİSTAN"); kelimeler.Add("GUATEMALA"); kelimeler.Add("ROMANYA");
            kelimeler.Add("ESTONYA"); kelimeler.Add("İTALYA"); kelimeler.Add("HİNDİSTAN");
            kelimeler.Add("NİJERYA"); kelimeler.Add("GANA"); kelimeler.Add("ŞİLİ");
            kelimesayisi = kelimeler.Count();
        }
    }
}
