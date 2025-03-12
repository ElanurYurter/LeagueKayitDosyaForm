using LeagueKayitDosyaForm.Model;
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

            //cb_koridor.Items.Add("Üst");
            //cb_koridor.Items.Add("Orta");
            //cb_koridor.Items.Add("Alt");
            //cb_koridor.Items.Add("Orman");

            //cb_rol.Items.Add("Nişancı");
            //cb_rol.Items.Add("Orman");
            //cb_rol.Items.Add("Destek");
            //cb_rol.Items.Add("Büyücü");
            //cb_rol.Items.Add("Tank");
            //cb_rol.Items.Add("Suikastçı");

            List<Koridor> Koridorlar = new List<Koridor>();
            Koridorlar.Add(new Koridor() { ID = 1, Isim = "Üst"});
            Koridorlar.Add(new Koridor() { ID = 2, Isim = "Orta" });
            Koridorlar.Add(new Koridor() { ID = 3, Isim = "Alt" });
            Koridorlar.Add(new Koridor() { ID = 4, Isim = "Orman" });

            List<Rol> Roller = new List<Rol>();
            Roller.Add(new Rol() { ID = 1, Isim = "Nişancı" });
            Roller.Add(new Rol() { ID = 2, Isim = "Orman" });
            Roller.Add(new Rol() { ID = 3, Isim = "Destek" });
            Roller.Add(new Rol() { ID = 4, Isim = "Büyücü" });
            Roller.Add(new Rol() { ID = 5, Isim = "Tank" });
            Roller.Add(new Rol() { ID = 6, Isim = "Suikastçı" });

            cb_rol.DataSource = Roller;
            cb_rol.DisplayMember = "Isim";
            cb_rol.ValueMember = "ID";

            cb_koridor.DataSource = Koridorlar;
            cb_koridor.DisplayMember = "Isim";
            cb_koridor.ValueMember = "ID";

            DosyalarıGetir();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                string isim = tb_isim.Text;
                string kayityolu = "Karakterler/" + isim + ".txt";

                StreamWriter yazici = new StreamWriter(kayityolu);
                yazici.WriteLine(tb_isim.Text);
                //yazici.WriteLine(cb_koridor.Text);
                //yazici.WriteLine(cb_rol.Text);
                yazici.WriteLine(tb_aciklama.Text);

                yazici.WriteLine(cb_rol.SelectedValue);
                yazici.WriteLine(cb_koridor.SelectedValue);


                yazici.Close();
                DosyalarıGetir();

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

        private void lb_karakterler_DoubleClick(object sender, EventArgs e)
        {
            string secilen =lb_karakterler.SelectedItem.ToString();
            string adres = "Karakterler/" + secilen + ".txt";
            StreamReader sr = new StreamReader(adres);
            tb_isim.Text = sr.ReadLine();
            //cb_koridor.SelectedText = sr.ReadLine();
            //cb_rol.SelectedText = sr.ReadLine();
            cb_koridor.SelectedValue = sr.ReadLine();
            cb_rol.SelectedValue = sr.ReadLine();
            tb_aciklama.SelectedText = sr.ReadLine();

        }

    }
}
