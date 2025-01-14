using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace RentACar
{
    public partial class kiradakiAraclar : Form
    {
        public kiradakiAraclar()
        {
            InitializeComponent();
        }
        private void kiradakiAraclariYukle()
        {
            // Bağlantı dizesini al
            string connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=aracEkle; Integrated Security=TRUE";

            // SQL sorgusu
            string query = "SELECT * FROM KiralananAraclar"; // Tablo adınız 

            // Veritabanına bağlan
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Verileri çekmek için SqlDataAdapter kullan
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // DataTable oluştur
                    DataTable dataTable = new DataTable();

                    // Verileri doldur
                    dataAdapter.Fill(dataTable);

                    // DataGridView'e yükle
                    gridControl1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void kiradakiAraclar_Load(object sender, EventArgs e)
        {
            kiradakiAraclariYukle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string aracMarka = gridView1.GetFocusedRowCellValue("Marka").ToString();
            int Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
            string aracModel = gridView1.GetFocusedRowCellValue("Model").ToString();
            int aracYil = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Yil"));
            string aracRenk = gridView1.GetFocusedRowCellValue("Renk").ToString();
            string aracYakitTur = gridView1.GetFocusedRowCellValue("YakitTur").ToString();
            string aracVitesTip = gridView1.GetFocusedRowCellValue("VitesTip").ToString();
           
            // Bağlantı dizesini al
            string connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=aracEkle; Integrated Security=TRUE";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deleteQuery = "DELETE FROM KiralananAraclar WHERE Id = @Id";

                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction))
                        {
                            deleteCommand.Parameters.AddWithValue("@Id", Id);

                            deleteCommand.ExecuteNonQuery();
                        }
                        string insertQuery = "INSERT INTO aracEkle (Marka, Model, Yil, Renk, YakitTur, VitesTip)" + "VALUES(@Marka, @Model, @Yil, @Renk, @YakitTur, @VitesTip)";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction))
                        {

                            insertCommand.Parameters.AddWithValue("@Marka", aracMarka);
                            insertCommand.Parameters.AddWithValue("@Model", aracModel);
                            insertCommand.Parameters.AddWithValue("@Yil", aracYil);
                            insertCommand.Parameters.AddWithValue("@Renk", aracRenk);
                            insertCommand.Parameters.AddWithValue("@YakitTur", aracYakitTur);
                            insertCommand.Parameters.AddWithValue("@vitesTip", aracVitesTip);

                            insertCommand.ExecuteNonQuery();
                        }
                        transaction.Commit();

                        MessageBox.Show("Araç Başarıyla Kiralama Listesinden Çıkarıldı ve Mevcut Araçlar Listesine Eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        MessageBox.Show($"Hata:{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            kiradakiAraclariYukle();
        }
    }
}
