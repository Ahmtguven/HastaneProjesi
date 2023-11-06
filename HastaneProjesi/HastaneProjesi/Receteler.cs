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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HastaneProjesi
{
    public partial class Receteler : Form
    {
        public Receteler()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("server=AHMET\\SQLKODLAB ; Database=Hastane ;Integrated Security=true;");
        public void HListe()
        {
            SqlCommand hasta = new SqlCommand();
            hasta.Connection = coon;
            hasta.CommandType = CommandType.StoredProcedure;
            hasta.CommandText = "Recete1";
            SqlDataAdapter H1 = new SqlDataAdapter(hasta);
            DataTable filldata = new DataTable();
            H1.Fill(filldata);
            dataGridView1.DataSource = filldata;
            coon.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow columns = dataGridView1.CurrentRow;
            textBox1.Tag = columns.Cells["ReceteNo"].Value.ToString();
            textBox1.Text = columns.Cells["receteAdı"].Value.ToString();
            textBox2.Text = columns.Cells["Tanımı"].Value.ToString();
            dateTimePicker1.Text = columns.Cells["Tarih"].Value.ToString();
            comboBox1.Text = columns.Cells["DoktorNo"].Value.ToString();
            comboBox2.Text = columns.Cells["HastaNo"].Value.ToString();
        }

        private void Receteler_Load(object sender, EventArgs e)
        {
            HListe();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand hasta = new SqlCommand();
            hasta.Connection = coon;
            hasta.CommandType = CommandType.StoredProcedure;
            hasta.CommandText = "Recete";
            hasta.Parameters.AddWithValue("@receteAdı", textBox1.Text);
            hasta.Parameters.AddWithValue("@Tanımı", textBox2.Text);
            hasta.Parameters.AddWithValue("@Tarihi", dateTimePicker1.Text);
            hasta.Parameters.AddWithValue("@DoktorNo", comboBox1.Text);
            hasta.Parameters.AddWithValue("@HastaNo", comboBox2.Text);
            hasta.ExecuteNonQuery();
            coon.Close();
            HListe();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand hasta = new SqlCommand();
            hasta.Connection = coon;
            hasta.CommandType = CommandType.StoredProcedure;
            hasta.CommandText = "ReceteUp";
            hasta.Parameters.AddWithValue("@receteNo", textBox1.Tag);
            hasta.Parameters.AddWithValue("@receteAdı", textBox1.Text);
            hasta.Parameters.AddWithValue("@Tanımı", textBox2.Text);
            hasta.Parameters.AddWithValue("@Tarihi", dateTimePicker1.Text);
            hasta.Parameters.AddWithValue("@DoktorNo", comboBox1.Text);
            hasta.Parameters.AddWithValue("@HastaNo", comboBox2.Text);
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
            hasta.CommandText = "ReceteDel";
            hasta.Parameters.AddWithValue("@ReceteNo", textBox1.Tag);
            hasta.ExecuteNonQuery();
            coon.Close();
            HListe();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SqlCommand doktor = new SqlCommand();
            //doktor.Connection = coon;
            //doktor.CommandType = CommandType.StoredProcedure;
            //doktor.CommandText = "Doktor1";
            //SqlDataAdapter D1 = new SqlDataAdapter(doktor);
            //DataTable filldata = new DataTable();
            //D1.Fill(filldata);
            //comboBox1.DataSource = filldata;
            //coon.Close();
        }
    }
}
