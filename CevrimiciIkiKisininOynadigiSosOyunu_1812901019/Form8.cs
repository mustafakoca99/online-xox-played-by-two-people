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
    public partial class Form8 : Form
    {
        int idd,s_idd;
        mustafakoca mustafa = new mustafakoca();
        Tablemesaj tablemesajj = new Tablemesaj();
        game game = new game();
        galibiyet galibiyet = new galibiyet();
        galibiyet koca;
        public Form8(int id,int s_id,string nasil)
        {
            
            InitializeComponent();
            idd = id;
            s_idd = s_id;
            if (nasil == "giden")
            {
                game.oturum = s_id;
            }
            else if(nasil=="gelen")
            {
                game.oturum = id;
            }
            game.hamle = "";
            mustafa.games.Add(game);
            mustafa.SaveChanges();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            foreach (Control c in panel2.Controls)
            {
                if (c is Button)
                {
                    c.Click += new System.EventHandler(btn_click);
                }
            }
            //alt satıra geçmek için yaptım
            listBox1.Items.Clear();
            //entity veritabanı çağırma
            mustafakoca mustafa = new mustafakoca();
            var listeleme = mustafa.Tablemesajs.ToList();
            //çevrimiçi olan pc leri combobox ekle ve listele
            var cevrimici = listeleme.Where(s => s.icerik != "");
            foreach (var item in cevrimici)
            {
                    listBox1.Items.Add(" - " + item.icerik.ToString());
            }
        }
        int XorO = 0;
        public void btn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text.Equals(""))
            {
                if (XorO % 2 == 0)
                {
                    btn.Text = "X";
                    btn.ForeColor = Color.Blue;
                    label1.Text = "Sıra O'da";
                    getTheWinner();
                }
                else
                {
                    btn.Text = "O";
                    btn.ForeColor = Color.Red;
                    label1.Text = "Sıra X'de";
                    getTheWinner();
                }

                XorO++;
            }
        }
        bool win = false;
        public void getTheWinner()
        {
            if (!button1.Text.Equals("") && button1.Text.Equals(button2.Text) && button1.Text.Equals(button3.Text))
            {
                winEffect(button1, button2, button3);
                win = true;
            }
            if (!button4.Text.Equals("") && button4.Text.Equals(button5.Text) && button4.Text.Equals(button6.Text))
            {
                winEffect(button4, button5, button6);
                win = true;
            }
            if (!button7.Text.Equals("") && button7.Text.Equals(button8.Text) && button7.Text.Equals(button9.Text))
            {
                winEffect(button7, button8, button9);
                win = true;
            }
            if (!button1.Text.Equals("") && button1.Text.Equals(button4.Text) && button1.Text.Equals(button7.Text))
            {
                winEffect(button1, button4, button7);
                win = true;
            }
            if (!button2.Text.Equals("") && button2.Text.Equals(button5.Text) && button2.Text.Equals(button8.Text))
            {
                winEffect(button2, button5, button8);
                win = true;
            }
            if (!button3.Text.Equals("") && button3.Text.Equals(button6.Text) && button3.Text.Equals(button9.Text))
            {
                winEffect(button3, button6, button9);
                win = true;
            }
            if (!button1.Text.Equals("") && button1.Text.Equals(button5.Text) && button1.Text.Equals(button9.Text))
            {
                winEffect(button1, button5, button9);
                win = true;
            }
            if (!button3.Text.Equals("") && button3.Text.Equals(button5.Text) && button3.Text.Equals(button7.Text))
            {
                winEffect(button3, button5, button7);
                win = true;
            }

            if (AllBtnLength() == 9 && win == false)
            {
                label1.Text = "Kazanan Yok!";
            }

        }
        public int AllBtnLength()
        {
            int allTextButtonsLength = 0;
            foreach (Control c in panel2.Controls)
            {
                if (c is Button)
                {
                    allTextButtonsLength += c.Text.Length;
                }
            }
            return allTextButtonsLength;
        }
        public void winEffect(Button b1, Button b2, Button b3)
        {
            b1.BackColor = Color.Green;
            b2.BackColor = Color.Green;
            b3.BackColor = Color.Green;

            b1.ForeColor = Color.White;
            b2.ForeColor = Color.White;
            b3.ForeColor = Color.White;

            MessageBox.Show(b1.Text + " KAZANDI","KAZANAN KİM?",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void buttonPartie_Click(object sender, EventArgs e)
        {
            XorO = 0;
            win = false;
            label1.Text = "OYNA!";
            foreach (Control c in panel2.Controls)
            {
                if (c is Button)
                {
                    c.Text = "";
                    c.BackColor = Color.White;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                mustafakoca mustafa = new mustafakoca();
                var listeleme = mustafa.Table1.ToList();
                var cevrimici = listeleme.Where(s => s.durum == true);
                var ara = cevrimici.Where(s => s.ad == listBox1.SelectedItem.ToString()).FirstOrDefault();
                label4.Text = ara.zaman.ToString();
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
                    listBox1.Items.Add(" - " + item.icerik.ToString());
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7(idd);
            frm7.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            game.hamle = "button1";
            mustafa.games.Add(game);
            mustafa.SaveChanges();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            game.hamle = "button2";
            mustafa.games.Add(game);

            mustafa.SaveChanges();
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            game.hamle = "button3";
            mustafa.games.Add(game);

            mustafa.SaveChanges();
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            game.hamle = "button4";
            mustafa.games.Add(game);
            mustafa.SaveChanges();
            button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            game.hamle = "button5";
            mustafa.games.Add(game);
            mustafa.SaveChanges();
            button5.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            game.hamle = "button6";
            mustafa.games.Add(game);
            mustafa.SaveChanges();
            button6.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            game.hamle = "button7";
            mustafa.games.Add(game);
            mustafa.SaveChanges();
            button7.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            game.hamle = "button8";
            mustafa.games.Add(game);
            mustafa.SaveChanges();
            button8.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            game.hamle = "button9";
            mustafa.games.Add(game);
            mustafa.SaveChanges();
            button9.Enabled = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //X İÇİN
            galibiyet.x = textBox1.Text;
            mustafa.galibiyets.Add(galibiyet);
            mustafa.SaveChanges();
            koca = mustafa.galibiyets.ToList().Last();
            MessageBox.Show("X KAYDEDİLDİ!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //O İÇİN
            galibiyet.o = textBox2.Text;
            mustafa.galibiyets.Add(galibiyet);
            mustafa.SaveChanges();
            koca = mustafa.galibiyets.ToList().Last();
            MessageBox.Show("O KAYDEDİLDİ!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            mustafa = new mustafakoca();
            var hamle = mustafa.games.Where(s => s.oturum == s_idd).ToList();
            string buton = hamle.Last().hamle;
            if(buton=="button1")
            {
                button1.Enabled = false;
            }
            if (buton == "button2")
            {
                button1.Enabled = false;
            }
            if (buton == "button3")
            {
                button1.Enabled = false;
            }
            if (buton == "button4")
            {
                button1.Enabled = false;
            }
            if (buton == "button5")
            {
                button1.Enabled = false;
            }
            if (buton == "button6")
            {
                button1.Enabled = false;
            }
            if (buton == "button7")
            {
                button1.Enabled = false;
            }
            if (buton == "button8")
            {
                button1.Enabled = false;
            }
            if (buton == "button9")
            {
                button1.Enabled = false;
            }


        }
    }
}
