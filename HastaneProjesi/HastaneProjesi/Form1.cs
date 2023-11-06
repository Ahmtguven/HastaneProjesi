using Microsoft.Win32.SafeHandles;
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


namespace HastaneProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection coon = new SqlConnection("server=AHMET\\SQLKODLAB ; Database=Hastane ;Integrated Security=true;");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KullanıcıGiris1";
            cmd.Parameters.AddWithValue("KullanıcıAdı", textBox1.Text);
            cmd.Parameters.AddWithValue("KullanıcıSifre", textBox2.Text);
            coon.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Kullanıcılar giris = new Kullanıcılar();
                giris.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Tekrar Deneyiniz");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand yonetim = new SqlCommand();
            yonetim.Connection = coon;
            yonetim.CommandType = CommandType.StoredProcedure;
            yonetim.CommandText = "YoneticiGiris";
            yonetim.Parameters.AddWithValue("AdıSoyadı", textBox3.Text);
            yonetim.Parameters.AddWithValue("Sifre", textBox4.Text);
            coon.Open();
            SqlDataReader reader;
            reader = yonetim.ExecuteReader();

            if (reader.Read())
            {
                Yoneticiler giris = new Yoneticiler();
                giris.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Tekrar Deneyiniz");
            }
        }
    }
}
