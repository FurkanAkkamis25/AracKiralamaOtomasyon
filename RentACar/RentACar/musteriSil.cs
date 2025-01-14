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
using DevExpress.XtraGrid.Views.Base;

namespace RentACar
{
    public partial class musteriSil : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraGrid.Views.Grid.GridView gridView;
        public musteriSil()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void musteriSil_Load(object sender, EventArgs e)
        {

            gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if(gridView != null)
            {
                gridView.OptionsBehavior.Editable = true;// düzenleme
                gridView.OptionsBehavior.AllowAddRows=DevExpress.Utils.DefaultBoolean.True;// satır ekleme
                gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;// satır silme

                gridView.RowUpdated += GridView_RowUpdated;
            }

            string connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=musteriEkle; Integrated Security=TRUE";

            // SQL sorgusu
            string query = "SELECT * FROM musteriEkle"; // Tablo adınız 'aracEkle'

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

        private void GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            gridView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                int id = Convert.ToInt32(gridView.GetRowCellValue(e.RowHandle, "id"));

                string ad = gridView.GetRowCellValue(e.RowHandle, "Ad").ToString();

                string soyad = gridView.GetRowCellValue(e.RowHandle, "Soyad").ToString();

                string cepTelefonu = gridView.GetRowCellValue(e.RowHandle, "CepTelefonu").ToString();

                string ehliyetNo = gridView.GetRowCellValue(e.RowHandle, "EhliyetNo").ToString();

                string tcNo = gridView.GetRowCellValue(e.RowHandle, "TcKimlikNo").ToString();

                string connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=musteriEkle; Integrated Security=TRUE";
                string query = "UPDATE musteriEkle SET Ad = @Ad, Soyad = @Soyad, TcKimlikNo = @TcKimlikNo, CepTelefonu = @CepTelefonu WHERE id = @id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@Ad", ad);
                    command.Parameters.AddWithValue("@Soyad", soyad);
                    command.Parameters.AddWithValue("@TcKimlikNo", tcNo);
                    command.Parameters.AddWithValue("@CepTelefonu", cepTelefonu);
                    command.Parameters.AddWithValue("@EhliyetNo", ehliyetNo);

                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
        }

        private void gridView_ro(object sender, RowObjectEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gridView != null)
            {
                gridView.RowUpdated += GridView_RowUpdated;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowHandle = gridView.FocusedRowHandle;
            if (rowHandle >= 0)
            {
                string id = gridView.GetRowCellValue(rowHandle, "id").ToString();

                DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinize EMİN MİSİNİZ ?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=musteriEkle; Integrated Security=TRUE";
                    string query = "DELETE FROM musteriEkle WHERE id = @id";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command =new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }
                    }
                    gridView.DeleteRow(rowHandle);

                    MessageBox.Show("Kayıt Başarıyla Silindi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçin.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            anaSayfa ana = new anaSayfa();
            ana.Show();
            this.Hide();
        }
    }
}
