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
    public partial class Form5 : Form
    {
        mustafakoca mustafa = new mustafakoca();
        Table1 tablo = new Table1();
        int id, s_id;
        public Form5(int ben)
        {
            InitializeComponent();
            id = ben;
            tablo = mustafa.Table1.Where(s => s.Id == ben).FirstOrDefault();
            timer2.Enabled = true;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            //entity veritabanı çağırma
            var listeleme = mustafa.Table1.ToList();
            //çevrimiçi olan pc leri combobox ekle ve listele
            var cevrimici = listeleme.Where(s => s.durum == true);
            foreach (var item in cevrimici)
            {
                comboBox1.Items.Add(item.ad.ToString());
            }
            
            //timer1.Interval = 100 * 3000;
            //timer1.Enabled = true;

            button1.Enabled = false;
            button3.Enabled = false;
        }
        
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //private olarak çağırdığımız için her yerde entity çağırmamız gerekiyor
            var listeleme = mustafa.Table1.ToList();
            var cevrimici = listeleme.Where(s => s.durum == true);
            var ara = cevrimici.Where(s => s.ad == comboBox1.SelectedItem.ToString()).FirstOrDefault();
            label5.Text = ara.zaman.ToString();
            button1.Enabled = true;
            button3.Enabled = true;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
           
            comboBox1.Items.Clear();
            //entity veritabanı çağırma
            mustafakoca mustafa = new mustafakoca();
            var listeleme = mustafa.Table1.ToList();
            //çevrimiçi olan pc leri combobox ekle ve listele
            var cevrimici = listeleme.Where(s => s.durum == true);
            foreach (var item in cevrimici)
            {
                comboBox1.Items.Add(item.ad.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mustafakoca mustafa = new mustafakoca();
            timer2.Enabled = false;
            string kullanici_adi = comboBox1.SelectedItem.ToString();
            Table1 secilen = mustafa.Table1.Where(s => s.ad == kullanici_adi).FirstOrDefault();
            secilen.oyun = id;
            s_id = secilen.Id;
            tablo.oyun = secilen.Id;
            mustafa.SaveChanges();
            Form8 frm8 = new Form8(id,s_id,"giden");
            frm8.ShowDialog();
            tablo.oyun = 0;
            mustafa.SaveChanges();
            timer2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7(id);
            frm7.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            mustafa = new mustafakoca();
            tablo = mustafa.Table1.Where(s => s.Id == tablo.Id).FirstOrDefault();
            if(tablo.oyun!=0)
            {
                timer2.Enabled = false;
                Form8 frm8 = new Form8(id,s_id,"gelen");
                frm8.ShowDialog();
                tablo.oyun = 0;
                mustafa.SaveChanges();
                timer2.Enabled = true;

            }
        }
    }
}
