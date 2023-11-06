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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HastaneProjesi
{
    public partial class Hastalar : Form
    {
        public Hastalar()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("server=AHMET\\SQLKODLAB ; Database=Hastane ;Integrated Security=true;");
        public void HListe()
        {
            SqlCommand hasta = new SqlCommand();
            hasta.Connection = coon;
            hasta.CommandType = CommandType.StoredProcedure;
            hasta.CommandText = "Hasta1";
            SqlDataAdapter H1 = new SqlDataAdapter(hasta);
            DataTable filldata = new DataTable();
            H1.Fill(filldata);
            dataGridView1.DataSource = filldata;
            coon.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Hastalar_Load(object sender, EventArgs e)
        {
            HListe();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand hasta = new SqlCommand();
            hasta.Connection = coon;
            hasta.CommandType = CommandType.StoredProcedure;
            hasta.CommandText = "Hasta";
            hasta.Parameters.AddWithValue("HastaAdSoyad", textBox1.Text);
            hasta.ExecuteNonQuery();
            coon.Close();
            HListe();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow columns = dataGridView1.CurrentRow;
            textBox1.Tag = columns.Cells["HastaNo"].Value.ToString();
            textBox1.Text = columns.Cells["HastaAdSoyad"].Value.ToString();
            textBox2.Text = columns.Cells["HastaKanGrubu"].Value.ToString();
            textBox3.Text = columns.Cells["HastaYas"].Value.ToString();
            textBox4.Text = columns.Cells["HastaBoy"].Value.ToString();
            textBox5.Text = columns.Cells["HastaKilo"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand hasta = new SqlCommand();
            hasta.Connection = coon;
            hasta.CommandType = CommandType.StoredProcedure;
            hasta.CommandText = "Hasta";
            hasta.Parameters.AddWithValue("@HastaAdSoyad", textBox1.Text);
            hasta.Parameters.AddWithValue("@HastaKanGrubu", textBox2.Text);
            hasta.Parameters.AddWithValue("@HastaYas", textBox3.Text);
            hasta.Parameters.AddWithValue("@HastaBoy", textBox4.Text);
            hasta.Parameters.AddWithValue("@HastaKilo", textBox5.Text);
            hasta.ExecuteNonQuery();
            coon.Close();
            HListe();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand hasta = new SqlCommand();
            hasta.Connection = coon;
            hasta.CommandType = CommandType.StoredProcedure;
            hasta.CommandText = "HastaUp";
            hasta.Parameters.AddWithValue("@HastaNo", textBox1.Tag);
            hasta.Parameters.AddWithValue("@HastaAdSoyad", textBox1.Text);
            hasta.Parameters.AddWithValue("@HastaKanGrubu", textBox2.Text);
            hasta.Parameters.AddWithValue("@HastaYas", textBox3.Text);
            hasta.Parameters.AddWithValue("@HastaBoy", textBox4.Text);
            hasta.Parameters.AddWithValue("@HastaKilo", textBox5.Text);
            hasta.ExecuteNonQuery();
            coon.Close();
            HListe();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand hasta = new SqlCommand();
            hasta.Connection = coon;
            hasta.CommandType = CommandType.StoredProcedure;
            hasta.CommandText = "HastaDel";
            hasta.Parameters.AddWithValue("@HastaNo", textBox1.Tag);
            hasta.ExecuteNonQuery();
            coon.Close();
            HListe();
        }
    }
}
