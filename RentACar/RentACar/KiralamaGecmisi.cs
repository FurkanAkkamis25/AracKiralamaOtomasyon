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
    public partial class KiralamaGecmisi : Form
    {
        public KiralamaGecmisi()
        {
            InitializeComponent();
        }

        private void KiralamaGecmisi_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM KiralamaGecmisi";
            string connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=aracEkle; Integrated Security=TRUE";
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
    }
}
