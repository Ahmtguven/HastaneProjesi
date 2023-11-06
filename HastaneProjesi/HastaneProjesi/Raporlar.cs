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
    public partial class Raporlar : Form
    {
        public Raporlar()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Yoneticiler go = new Yoneticiler(); go.Show(); this.Hide();
        }

        SqlConnection coon = new SqlConnection("server=AHMET\\SQLKODLAB ; Database=Hastane ;Integrated Security=true;");

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            coon.Open();
            dataGridView1.DataSource = null;
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = coon;
            sorgu.CommandType= CommandType.StoredProcedure;
            sorgu.CommandText = "DGHL";
            SqlDataAdapter S1 = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            S1.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            coon.Open();
            dataGridView1.DataSource = null;
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = coon;
            sorgu.CommandType = CommandType.StoredProcedure;
            sorgu.CommandText = "BGHL";
            SqlDataAdapter S1 = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            S1.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            coon.Open();
            dataGridView1.DataSource = null;
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = coon;
            sorgu.CommandType = CommandType.StoredProcedure;
            sorgu.CommandText = "BGHS";
            SqlDataAdapter S1 = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            S1.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            coon.Open();
            dataGridView1.DataSource = null;
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = coon;
            sorgu.CommandType = CommandType.StoredProcedure;
            sorgu.CommandText = "UGDS";
            SqlDataAdapter S1 = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            S1.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }
    }
}
