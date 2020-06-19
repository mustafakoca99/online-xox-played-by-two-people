using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CevrimiciIkiKisininOynadigiSosOyunu_1812901019
{
    public partial class Form2 : Form
    {
        bool kontrol = true;
        mustafakoca mustafa = new mustafakoca();
        Table tablo = new Table();
        Table koca;
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                tablo.ad = textBox1.Text;
                tablo.soyad = textBox2.Text;
                tablo.kullaniciadi = textBox5.Text;
                tablo.sifre = textBox4.Text;
                tablo.sifretekrar = textBox3.Text;
                if (tablo.sifre == textBox4.Text&& tablo.sifretekrar == textBox3.Text)
                {
                    foreach (var item in mustafa.Tables)
                    {
                        if(item.kullaniciadi==tablo.kullaniciadi)
                        {
                            MessageBox.Show("Kullanıcı adı mevcut. Lütfen başka bir kullanıcı adı giriniz");
                            kontrol = false;
                        }
                    }
                    if(kontrol==true)
                    {
                        mustafa.Tables.Add(tablo);
                        mustafa.SaveChanges();
                        MessageBox.Show("KAYIT İŞLEMİ BAŞARILI :)","UYARI!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    kontrol = true;
                   
                }
                else
                {
                    MessageBox.Show("ŞİFRELER AYNI DEĞİL!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
           
        }
    }
}
