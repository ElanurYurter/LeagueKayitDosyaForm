using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeagueKayitDosyaForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cb_koridor.Items.Add("Üst");
            cb_koridor.Items.Add("Orta");
            cb_koridor.Items.Add("Alt");
            cb_koridor.Items.Add("Orman");

            cb_rol.Items.Add("Nişancı");
            cb_rol.Items.Add("Orman");
            cb_rol.Items.Add("Destek");
            cb_rol.Items.Add("Büyücü");
            cb_rol.Items.Add("Tank");
            cb_rol.Items.Add("Suikastçı");
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                string isim = tb_isim.Text;
                string kayityolu = "Karakterler/" + isim + ".txt";

                StreamWriter yazici = new StreamWriter(kayityolu);
                yazici.WriteLine(tb_isim.Text);
                yazici.WriteLine(cb_koridor.Text);
                yazici.WriteLine(cb_rol.Text);
                yazici.WriteLine(tb_aciklama.Text);
            }
            else
            {
                MessageBox.Show("Karakter adı boş bırakılamaz!", "hata!");
            }
        }
        public void DosyalarıGetir()
        {
            DirectoryInfo di = new DirectoryInfo("Karakterler/");
            lb_karakterler.Items.Clear();
            foreach (FileInfo item in  di.GetFiles())
            {
                string dosyaadi = item.Name;
                lb_karakterler.Items.Add(dosyaadi.Substring(0, dosyaadi.Length - 4));
            }
        }
    }
}
