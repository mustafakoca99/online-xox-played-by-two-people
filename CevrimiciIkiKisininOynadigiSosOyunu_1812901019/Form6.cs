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
    public partial class Form6 : Form
    {
        bool varmi = false;
        mustafakoca mustafa = new mustafakoca();
        Table kullanici = new Table();
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in mustafa.Tables)
            {
                if(item.kullaniciadi==textBox4.Text)
                {
                    varmi = true;
                    kullanici = item;
                }
            }
            if(varmi==true)
            {
                if(kullanici.sifre == textBox1.Text)
                {
                    if(textBox2.Text==textBox3.Text)
                    {
                        kullanici.sifre = textBox2.Text;
                        kullanici.sifretekrar = textBox3.Text;
                        mustafa.SaveChanges();
                        MessageBox.Show("ŞİFRE GÜNCELLEMESİ BAŞARILI :)","UYARI!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ŞİFRE GÜNCELLEMESİ BAŞARISIZ :(", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Eksi şifre hatalı");
                }
                    
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
