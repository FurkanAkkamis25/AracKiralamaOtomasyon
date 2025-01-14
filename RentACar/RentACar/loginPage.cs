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
    public partial class loginPage : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-A592D5F\\SQLEXPRESS; initial catalog=loginpage; Integrated Security=TRUE");
        




        public loginPage()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string k_adi = textBox1.Text;
            string sifre = textBox2.Text;
            bool kayitli_mi = false;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from login", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (k_adi == dr["K_adi"].ToString() && sifre == dr["Sifre"].ToString())
                {
                    kayitli_mi = true;
                    break;

                }
                else kayitli_mi = false;
            }
            conn.Close();
            if (kayitli_mi == true)
            {
                anaSayfa anaSayfa = new anaSayfa();
                anaSayfa.Show();
                this.Hide();
            }
            else MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış ");
        }
    }
}
