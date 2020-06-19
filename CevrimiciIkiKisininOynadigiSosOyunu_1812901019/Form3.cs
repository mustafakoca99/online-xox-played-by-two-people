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
    public partial class Form3 : Form
    {
        mustafakoca mustafa = new mustafakoca();
        Table hello;
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                hello = mustafa.Tables.Where(s => s.kullaniciadi == textBox5.Text).FirstOrDefault();
                // bool durum = mustafa.Database.Exists();
                if (hello.kullaniciadi == textBox5.Text && hello.sifre == textBox4.Text)
                {
                    MessageBox.Show("GİRİŞ BAŞARILI!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string ad = textBox5.Text;
                    Form4 frm4 = new Form4(ad);
                    frm4.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("GİRİŞ BAŞARILI DEĞİL!!!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception hatamustafa)
            {
                MessageBox.Show(hatamustafa.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form6 frm6 = new Form6();
            this.Hide();
            frm6.ShowDialog();
            this.Show();
            
        }
    }
}
