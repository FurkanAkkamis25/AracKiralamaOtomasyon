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
using System.Configuration;
namespace RentACar
{
    public partial class mevcutAraclar : DevExpress.XtraEditors.XtraForm
    {
        public mevcutAraclar()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mevcutAraclar_Load(object sender, EventArgs e)
        {
            mevcutAraclariYukle();
        }
        private void mevcutAraclariYukle()
        {
            // Bağlantı dizesini al
            string connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=aracEkle; Integrated Security=TRUE";

            // SQL sorgusu
            string query = "SELECT * FROM aracEkle"; // Tablo adınız 'aracEkle'

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
        private void button2_Click(object sender, EventArgs e)
        {
            anaSayfa ana = new anaSayfa();
            ana.Show();
            this.Hide();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int selectedRowHandle = gridView1.FocusedRowHandle;

            if (selectedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(selectedRowHandle, "id").ToString();

                // Bağlantı dizesini al
                string connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=aracEkle; Integrated Security=TRUE";

                // SQL sorgusu
                string query = "DELETE FROM aracEkle WHERE id=@id";

                // Veritabanına bağlan
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("Araç Başarıyla Silindi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata :" + ex.Message);
                    }
                }
                mevcutAraclariYukle();
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz aracı seçin.");

            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int selectedRowHandle = gridView1.FocusedRowHandle;
            if (selectedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(selectedRowHandle, "id").ToString();
                string marka = gridView1.GetRowCellValue(selectedRowHandle, "Marka").ToString();
                string model = gridView1.GetRowCellValue(selectedRowHandle, "Model").ToString();
                string yil = gridView1.GetRowCellValue(selectedRowHandle, "Yil").ToString();
                string renk = gridView1.GetRowCellValue(selectedRowHandle, "Renk").ToString();
                string yakitTur = gridView1.GetRowCellValue(selectedRowHandle, "YakitTur").ToString();
                string vitesTip = gridView1.GetRowCellValue(selectedRowHandle, "VitesTip").ToString();

                // Bağlantı dizesini al
                string connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=aracEkle; Integrated Security=TRUE";

                string query = "UPDATE aracEkle SET Marka = @Marka, Model = @Model, Yil = @Yil, Renk = @Renk, YakitTur = @YakitTur, VitesTip = @VitesTip WHERE id = @id ";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@Marka", marka);
                            command.Parameters.AddWithValue("@Model", model);
                            command.Parameters.AddWithValue("@Yil", yil);
                            command.Parameters.AddWithValue("@Renk", renk);
                            command.Parameters.AddWithValue("@YakitTur", yakitTur);
                            command.Parameters.AddWithValue("@VitesTip", vitesTip);

                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("Araç Bilgileri Başarıyla Güncellendi.");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata:" + ex.Message);
                    }
                }
                mevcutAraclariYukle();
            }
            else
            {
                MessageBox.Show("Lütfen Güncellemek İstediğiniz Aracı Seçiniz.");
            }
        }

        private void btnBakim_Click(object sender, EventArgs e)
        {
            var selectedRows = gridView1.GetSelectedRows();

            if (selectedRows.Length > 0)
            {
                // Bağlantı dizesini al
                string connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=aracEkle; Integrated Security=TRUE";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        foreach (int rowHandle in selectedRows)
                        {
                            string id = gridView1.GetRowCellValue(rowHandle, "id").ToString();
                            string marka = gridView1.GetRowCellValue(rowHandle, "Marka").ToString();
                            string model = gridView1.GetRowCellValue(rowHandle, "Model").ToString();
                            string yil = gridView1.GetRowCellValue(rowHandle, "Yil").ToString();
                            string renk = gridView1.GetRowCellValue(rowHandle, "Renk").ToString();
                            string yakitTur = gridView1.GetRowCellValue(rowHandle, "YakitTur").ToString();
                            string vitesTip = gridView1.GetRowCellValue(rowHandle, "VitesTip").ToString();

                            string insertQuery = "INSERT INTO BakimAraclar (id, Marka, Model, Yil, Renk, YakitTur, VitesTip)" + "VALUES(@id, @Marka, @Model, @Yil, @Renk, @YakitTur, @VitesTip)";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@id", id);
                                insertCommand.Parameters.AddWithValue("@Marka", marka);
                                insertCommand.Parameters.AddWithValue("@Model", model);
                                insertCommand.Parameters.AddWithValue("@Yil", yil);
                                insertCommand.Parameters.AddWithValue("@Renk", renk);
                                insertCommand.Parameters.AddWithValue("@YakitTur", yakitTur);
                                insertCommand.Parameters.AddWithValue("@vitesTip", vitesTip);

                                insertCommand.ExecuteNonQuery();

                            }
                            string deleteQuery = "DELETE FROM aracEkle WHERE id = @id";
                            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                            {
                                deleteCommand.Parameters.AddWithValue("@id", id);
                                deleteCommand.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Seçilen Araçlar Bakıma Gönderildi.");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata:" + ex.Message);
                    }
                }
                mevcutAraclariYukle();
            }
            else
            {
                MessageBox.Show("Lütfen Bakıma Göndermek İstediğiniz Araçları Seçin.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnKirala_Click(object sender, EventArgs e)
        {
            string aracMarka = gridView1.GetFocusedRowCellValue("Marka").ToString();
            string aracModel = gridView1.GetFocusedRowCellValue("Model").ToString();
            string yil = gridView1.GetFocusedRowCellValue("Yil").ToString();
            string renk = gridView1.GetFocusedRowCellValue("Renk").ToString();
            string yakitTur = gridView1.GetFocusedRowCellValue("YakitTur").ToString();
            string vitesTip = gridView1.GetFocusedRowCellValue("VitesTip").ToString();
            kirala kira = new kirala(aracMarka, aracModel, yil,renk,yakitTur,vitesTip);
            kira.ShowDialog();
            mevcutAraclariYukle();
        }
    }
}