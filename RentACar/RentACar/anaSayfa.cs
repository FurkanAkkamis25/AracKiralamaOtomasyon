using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
namespace RentACar
{
    public partial class anaSayfa : DevExpress.XtraEditors.XtraForm
    {
        public anaSayfa()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAracEkle_Click(object sender, EventArgs e)
        {
            aracEkle form2 = new aracEkle();
            form2.Show();
            this.Hide();
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            musteriEkle form1 = new musteriEkle();
            form1.Show();
            this.Hide();
        }

        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            musteriSil form4 = new musteriSil();
            form4.Show();
            this.Hide();
        }

        private void btnMevcutAraclar_Click(object sender, EventArgs e)
        {
            mevcutAraclar form3 = new mevcutAraclar();
            form3.Show();
            this.Hide();
        }

        private void btnMusteriDuzenle_Click(object sender, EventArgs e)
        {
            musteriSil form4 = new musteriSil();
            form4.Show();
            this.Hide();
        }

        private void btnAracSil_Click(object sender, EventArgs e)
        {
            mevcutAraclar mevcut = new mevcutAraclar();
            mevcut.Show();
            this.Hide();
        }

        private void btnBakimdakiAraclar_Click(object sender, EventArgs e)
        {
            bakımdakiAraclar form5 = new bakımdakiAraclar();
            form5.Show();
            this.Hide();
        }

        private void btnKiradakiAraclar_Click(object sender, EventArgs e)
        {
            kiradakiAraclar kira = new kiradakiAraclar();
            kira.Show();
            this.Hide();
        }

        private void btnKiralamaGecmisi_Click(object sender, EventArgs e)
        {
            KiralamaGecmisi kiralamaGecmisi = new KiralamaGecmisi();
            kiralamaGecmisi.Show();
            this.Hide();
        }

        private void btnFatura_Click(object sender, EventArgs e)
        {
            Fatura fatura = new Fatura();
            fatura.Show();
            this.Hide();
        }

        private void btnİadeVeUcret_Click(object sender, EventArgs e)
        {
            kullaniciEkle k = new kullaniciEkle();
            k.Show();
            this.Hide();
        }
    }
}