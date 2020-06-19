using Microsoft.Win32;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CevrimiciIkiKisininOynadigiSosOyunu_1812901019
{
    public partial class Form4 : Form
    {
        mustafakoca mustafa = new mustafakoca();
        Table1 tablo = new Table1();
        Table1 koca;
        public Form4(string ad)
        {
           
            InitializeComponent();

            tablo.ad = ad;
            tablo.zaman = DateTime.Now;
            tablo.durum = true;
            mustafa.Table1.Add(tablo);
            mustafa.SaveChanges();
            koca = mustafa.Table1.ToList().Last();
            label2.Text = koca.Id.ToString();
            label4.Text = koca.ad.ToString();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //zamana göre veritabanına bilgi gönderme
            //çevrimiçi çevrimdışı olduğunu söyleme
            mustafakoca mustafa = new mustafakoca();
            var hello = mustafa.Table1.Where(s => s.Id == koca.Id).FirstOrDefault();
            bool durum = mustafa.Database.Exists();
            if (durum)
            {
                label6.Text = "ÇEVRİMİÇİ";
            }
            else
            {
                label6.Text = "ÇEVRİMDIŞI";
            }
            if (hello.kapan == true)
            {
                //bunu açarsak program kapatılır...
                //Process.Start("cmd", "/K shutdown /s"); 

                hello.durum = false;
                mustafa.SaveChanges();
                Close();
            }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            //form kapandığında veritabanında bit ayarı 0 olur, yani false

            koca.durum = false;
            mustafa.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5(koca.Id);
            frm5.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }
    }
}
