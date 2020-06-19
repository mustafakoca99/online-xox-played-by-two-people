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
    public partial class Form7 : Form
    {
        mustafakoca mustafa = new mustafakoca();
        Tablemesaj tablemesajj = new Tablemesaj();
        Tablemesaj koca;
        int idd;
        public Form7(int id)
        {
            InitializeComponent();
            idd = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5(idd);
            frm5.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" ||textBox2.Text=="" || textBox3.Text=="" || textBox4.Text=="")
            {
                MessageBox.Show("BOŞ ALANLARI DOLDURUNUZ!!!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tablemesajj.gonderen = textBox1.Text;
                tablemesajj.alici = textBox2.Text;
                tablemesajj.baslik = textBox3.Text;
                tablemesajj.icerik = textBox4.Text;
                mustafa.Tablemesajs.Add(tablemesajj);
                mustafa.SaveChanges();
                koca = mustafa.Tablemesajs.ToList().Last();
                MessageBox.Show("Mesaj Gönderildi!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
       
        private void Form7_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //entity veritabanı çağırma
            mustafakoca mustafa = new mustafakoca();
            var listeleme = mustafa.Tablemesajs.ToList();
            //çevrimiçi olan pc leri combobox ekle ve listele
            var cevrimici = listeleme.Where(s => s.icerik !="");
            foreach (var item in cevrimici)
            {
                if (item.gonderen == null)
                    listBox1.Items.Add(" - " + item.icerik.ToString());
                else
                    listBox1.Items.Add(" - " + item.icerik.ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                mustafakoca mustafa = new mustafakoca();
                var listeleme = mustafa.Table1.ToList();
                var cevrimici = listeleme.Where(s => s.durum == true);
                var ara = cevrimici.Where(s => s.ad == listBox1.SelectedItem.ToString()).FirstOrDefault();
                label5.Text = ara.zaman.ToString();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            //entity veritabanı çağırma
            mustafakoca mustafa = new mustafakoca();
            var listeleme = mustafa.Tablemesajs.ToList();
            //çevrimiçi olan pc leri combobox ekle ve listele
            var cevrimici = listeleme.Where(s => s.icerik != "");
            foreach (var item in cevrimici)
            {
                if (item.gonderen == null)
                    listBox1.Items.Add(" - " + item.icerik.ToString());
                else
                    listBox1.Items.Add(" - " + item.icerik.ToString());
            }
        }
    }
}
