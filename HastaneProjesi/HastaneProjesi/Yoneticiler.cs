using HastaneProjesi;
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
    public partial class Yoneticiler : Form
    {
        public Yoneticiler()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("server=AHMET\\SQLKODLAB ; Database=Hastane ;Integrated Security=true;");

        private void label1_Click(object sender, EventArgs e)
        {
            SqlCommand hasta = new SqlCommand();
            hasta.Connection = coon;
            hasta.CommandType = CommandType.StoredProcedure;
            hasta.CommandText = "Hasta1";
            Hastalar hastalar = new Hastalar();
            hastalar.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SqlCommand recete = new SqlCommand();
            recete.Connection = coon;
            recete.CommandType = CommandType.StoredProcedure;
            recete.CommandText = "Recete1";
            Receteler recete1 = new Receteler();
            recete1.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SqlCommand doktor = new SqlCommand();
            doktor.Connection = coon;
            doktor.CommandType = CommandType.StoredProcedure;
            doktor.CommandText = "Doktor1";
            Doktorlar doktorlar = new Doktorlar();
            doktorlar.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Raporlar go = new Raporlar();
            go.Show(); this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Raporlar go = new Raporlar(); go.Show(); this.Hide(); 
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1(); go.Show(); this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
