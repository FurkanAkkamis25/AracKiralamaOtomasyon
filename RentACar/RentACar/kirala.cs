using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar
{
    public partial class kirala : Form


    {
        private string aracMarka;
        private string aracModel;
        private string yil;
        private string renk;
        private string yakitTur;
        private string vitesTip;
       
        public kirala(string aracMarka,string aracModel,string yil, string renk, string yakitTur, string vitesTip)
        {
            InitializeComponent();
            this.aracMarka = aracMarka;
            this.aracModel = aracModel;
            this.yil = yil;
            this.renk = renk;
            this.yakitTur = yakitTur;
            this.vitesTip = vitesTip;
        }
        private void kirala_Load(object sender, EventArgs e)
        {
            labelAracBilgisi.Text = $"Araç: {aracMarka}{aracModel}";
            string query = "SELECT Ad, Soyad FROM musteriEkle";
            string connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=musteriEkle; Integrated Security=TRUE";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    gridControl1.DataSource = dataTable;
                
                    }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata:{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            anaSayfa ana = new anaSayfa();
            ana.Show();
            this.Hide();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string musteriAd = gridView1.GetFocusedRowCellValue("Ad").ToString();
            string musteriSoyad = gridView1.GetFocusedRowCellValue("Soyad").ToString();

            decimal fiyat = Convert.ToDecimal(textBoxFiyat.Text);
            int kiralamaSuresi = Convert.ToInt32(textBoxGunSayisi.Text);
            

            string query = @"INSERT INTO KiralananAraclar (Marka, Model, MusteriAd, MusteriSoyad, Fiyat, KiralamaSuresi, Yil, VitesTip, YakitTur, Renk) VALUES (@Marka, @Model, @MusteriAd, @MusteriSoyad, @Fiyat, @KiralamaSuresi, @Yil, @VitesTip, @YakitTur, @Renk)";
            string connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=aracEkle; Integrated Security=TRUE";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection)) 
                {
                    command.Parameters.AddWithValue("@Marka" , aracMarka);
                    command.Parameters.AddWithValue("@Model", aracModel);
                    command.Parameters.AddWithValue("@MusteriAd", musteriAd);
                    command.Parameters.AddWithValue("@MusteriSoyad", musteriSoyad);
                    command.Parameters.AddWithValue("@Fiyat", fiyat);
                    command.Parameters.AddWithValue("@KiralamaSuresi", kiralamaSuresi);
                    command.Parameters.AddWithValue("@Yil", yil);
                    command.Parameters.AddWithValue("@VitesTip", vitesTip);
                    command.Parameters.AddWithValue("@YakitTur", yakitTur);
                    command.Parameters.AddWithValue("@Renk", renk);

                    connection.Open();

                    command.ExecuteNonQuery();
                    
                }
                string deleteQuery = @"DELETE FROM aracEkle WHERE Marka =@AracMarka AND Model=@AracModel";
                using (SqlCommand deleteCommand =new SqlCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@AracMarka", aracMarka);
                    deleteCommand.Parameters.AddWithValue("@AracModel", aracModel);

                    deleteCommand.ExecuteNonQuery();
                }
            }
            YenileGridControl();

            query = @"INSERT INTO KiralamaGecmisi (AracMarka, AracModel, MusteriAd, MusteriSoyad, Fiyat, KiralamaSuresi) VALUES (@Marka, @Model, @MusteriAd, @MusteriSoyad, @Fiyat, @KiralamaSuresi)";
            
            connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=aracEkle; Integrated Security=TRUE";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Marka", aracMarka);
                    command.Parameters.AddWithValue("@Model", aracModel);
                    command.Parameters.AddWithValue("@MusteriAd", musteriAd);
                    command.Parameters.AddWithValue("@MusteriSoyad", musteriSoyad);
                    command.Parameters.AddWithValue("@Fiyat", fiyat);
                    command.Parameters.AddWithValue("@KiralamaSuresi", kiralamaSuresi);

                    connection.Open();

                    command.ExecuteNonQuery();

                }
            }
            MessageBox.Show("Kiralama İşlemi Başarıyla Kaydedildi ve Araç Sistemden Kaldırıldı!");
            this.Hide();
        }

        private void YenileGridControl()
        {
            string connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=aracEkle; Integrated Security=TRUE";
            string selectQuery = "SELECT * FROM aracEkle";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gridControl1.DataSource = dt;
                }
            }
        }
    }

    
}
