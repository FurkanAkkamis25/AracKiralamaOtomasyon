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
    public partial class musteriEkle : DevExpress.XtraEditors.XtraForm
    {
        public musteriEkle()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=musteriEkle; Integrated Security=TRUE";
            string tcKimlikNo = textBox1.Text;
            string ad = textBox2.Text;
            string soyAd = textBox3.Text;
            string cepTelefonu = textBox4.Text;
            int ehliyetNo = int.Parse(textBox5.Text);

            string query = "INSERT INTO musteriEkle (TcKimlikNo, Ad, SoyAd, CepTelefonu, EhliyetNo) VALUES (@TcKimlikNo, @Ad, @SoyAd, @CepTelefonu, @EhliyetNo) ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TcKimlikNo", tcKimlikNo);
                command.Parameters.AddWithValue("@Ad", ad);
                command.Parameters.AddWithValue("@SoyAd", soyAd);
                command.Parameters.AddWithValue("@CepTelefonu", cepTelefonu);
                command.Parameters.AddWithValue("@EhliyetNo", ehliyetNo);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {

                    MessageBox.Show("Müşteri Başarıyla Kaydedildi.");
                }
                else
                {
                    MessageBox.Show("Kayıt Başarısız.");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            anaSayfa ana = new anaSayfa();
            ana.Show();
            this.Hide();
        }
    }
}
