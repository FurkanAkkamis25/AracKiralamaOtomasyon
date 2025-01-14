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
    public partial class aracEkle : DevExpress.XtraEditors.XtraForm
    {
        public aracEkle()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=aracEkle; Integrated Security=TRUE";
            string marka = textBox1.Text;
            string model = textBox2.Text;
            int yil = int.Parse(textBox3.Text);
            string renk = textBox4.Text;
            string yakitTur = textBox5.Text;
            string vitesTip = textBox6.Text;

            string query = "INSERT INTO aracEkle (Marka, Model, Yil, Renk, YakitTur, VitesTip) VALUES (@Marka, @Model, @Yil, @Renk, @YakitTur, @VitesTip) ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Marka", marka);
                command.Parameters.AddWithValue("@Model", model);
                command.Parameters.AddWithValue("@Yil",yil);
                command.Parameters.AddWithValue("@Renk", renk);
                command.Parameters.AddWithValue("@YakitTur", yakitTur);
                command.Parameters.AddWithValue("@VitesTip", vitesTip);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result>0)
                {

                    MessageBox.Show("Araç Başarıyla Kaydedildi.");
                }
                else
                {
                    MessageBox.Show("Kayıt Başarısız.");
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
    }
}