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
    public partial class Doktorlar : Form
    {
        public Doktorlar()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("server=AHMET\\SQLKODLAB ; Database=Hastane ;Integrated Security=true;");

        public void DListe()
        {
            SqlCommand doktor = new SqlCommand();
            doktor.Connection = coon;
            doktor.CommandType = CommandType.StoredProcedure;
            doktor.CommandText = "Doktor1";
            SqlDataAdapter D1 = new SqlDataAdapter(doktor);
            DataTable filldata = new DataTable();
            D1.Fill(filldata);
            dataGridView1.DataSource = filldata;
            coon.Close();
        }


        private void Doktorlar_Load(object sender, EventArgs e)
        {
            DListe();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow columns = dataGridView1.CurrentRow;
            textBox1.Tag = columns.Cells["DoktorNo"].Value.ToString();
            textBox1.Text = columns.Cells["DoktorAdSoyad"].Value.ToString();
            textBox2.Text = columns.Cells["Brans"].Value.ToString();
            textBox3.Text = columns.Cells["Unvan"].Value.ToString();
            textBox4.Text = columns.Cells["Maas"].Value.ToString();
            textBox5.Text = columns.Cells["prim"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand doktor = new SqlCommand();
            doktor.Connection = coon;
            doktor.CommandType = CommandType.StoredProcedure;
            doktor.CommandText = "Doktor";
            doktor.Parameters.AddWithValue("@DoktorAdSoyad", textBox1.Text);
            doktor.Parameters.AddWithValue("@Brans", textBox2.Text);
            doktor.Parameters.AddWithValue("@Unvan", textBox3.Text);
            doktor.Parameters.AddWithValue("@Maas", textBox4.Text);
            doktor.Parameters.AddWithValue("@Prim", textBox5.Text);
            doktor.ExecuteNonQuery();
            coon.Close();
            DListe();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand doktor = new SqlCommand();
            doktor.Connection = coon;
            doktor.CommandType = CommandType.StoredProcedure;
            doktor.CommandText = "DoktorUp";
            doktor.Parameters.AddWithValue("@DoktorNo", textBox1.Tag);
            doktor.Parameters.AddWithValue("@DoktorAdSoyad", textBox1.Text);
            doktor.Parameters.AddWithValue("@Brans", textBox2.Text);
            doktor.Parameters.AddWithValue("@Unvan", textBox3.Text);
            doktor.Parameters.AddWithValue("@Maas", textBox4.Text);
            doktor.Parameters.AddWithValue("@Prim", textBox5.Text);
            doktor.ExecuteNonQuery();
            coon.Close();
            DListe();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand doktor = new SqlCommand();
            doktor.Connection = coon;
            doktor.CommandType = CommandType.StoredProcedure;
            doktor.CommandText = "DoktorDel";
            doktor.Parameters.AddWithValue("@DoktorNo", textBox1.Tag);
            doktor.ExecuteNonQuery();
            coon.Close();
            DListe();
        }
    }
}
