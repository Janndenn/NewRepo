using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace postgreSql
{
    public partial class Form1 : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;port=5432;Database=chanden;User Id=postgres;Password=12345");
        NpgsqlCommand cmd = new NpgsqlCommand();
        DataTable dt = new DataTable();
        NpgsqlDataAdapter adt = new NpgsqlDataAdapter();

        public void show()
        {
            adt = new NpgsqlDataAdapter("SELECT * FROM chanden", conn);
            DataSet ds = new DataSet();
            adt.Fill(ds, "chanden");
            dataGridView1.DataSource = ds.Tables["chanden"];
        }
            public Form1()
        {
            InitializeComponent();
        }
        public void cleartext()
        {
            txtID.Clear();
            txtName.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            show();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO chanden(p_id,p_name)VALUES(@p_id,@p_name)", conn);
            cmd.Parameters.AddWithValue("@p_id", txtID.Text);
            cmd.Parameters.AddWithValue("@p_name", txtName.Text);

            dt.Clear();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("save dai leo!!!");
                show();
            }
            else
            {
                MessageBox.Show("save br dai!!");
            }
            conn.Close();
            cleartext();
            dataGridView1.Refresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("UPDATE chanden SET p_id = @p_id, p_name = @p_name ", conn);
            cmd.Parameters.AddWithValue("@p_id", txtID.Text);
            cmd.Parameters.AddWithValue("@p_name", txtName.Text);

            dt.Clear();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Update dai leo!!!!");
                show();
            }
            else
            {
                MessageBox.Show("Update br dai!!! ");
            }
            conn.Close();
            cleartext();
            dataGridView1.Refresh();

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM chanden WHERE p_id=@p_id", conn);
            cmd.Parameters.AddWithValue("@p_id", txtID.Text);
            cmd.Parameters.AddWithValue("@p_name", txtName.Text);

            dt.Clear();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("delete dai leo I sus");
                show();
            }
            else
            {
                MessageBox.Show("delete br dai I sus");

            }
            conn.Close();
            cleartext();
            dataGridView1.Refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            conn.Open();
            adt = new NpgsqlDataAdapter("select * from chanden where p_name like'" + txtSearch.Text + "%' ", conn);
            dt = new DataTable();
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
