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
    public partial class kullaniciEkle : Form
    {
        public kullaniciEkle()
        {
            InitializeComponent();
        }

        private void kullaniciEkle_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=loginPage; Integrated Security=TRUE";
            string K_adi = textBox1.Text;
            string Sifre = textBox2.Text;
            string query = "INSERT INTO login (K_adi, Sifre) VALUES (@K_adi, @Sifre) ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@K_adi", K_adi);
                command.Parameters.AddWithValue("@Sifre", Sifre);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Kullanıcı Başarıyla Kaydedildi.");
                }
                else
                {
                    MessageBox.Show("Kayıt Başarısız.");
                }
            }
        }
    }
}
