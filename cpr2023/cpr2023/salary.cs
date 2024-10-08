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

namespace cpr2023
{
    public partial class salary : Form
    {
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connectder cd = new Connectder();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void sadaeng()
        {
            adt = new SqlDataAdapter("select * from salary", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].Width = 180;
            dataGridView1.Columns[3].Width = 180;
            dataGridView1.Columns[4].Width = 200;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດ";
            dataGridView1.Columns[1].HeaderText = "ວຸດທິການສຶກສາ";
            dataGridView1.Columns[2].HeaderText = "ຕຳແໜ່ງ";
            dataGridView1.Columns[3].HeaderText = "ພະແນກ";
            dataGridView1.Columns[4].HeaderText = "ຈຳນວນເງິນເດືອນ";
         
        }
        SqlDataAdapter daqua = new SqlDataAdapter();
        DataSet dsqua = new DataSet();
        Connectder cdqua = new Connectder();
        SqlCommand cmdqua = new SqlCommand();
        DataTable dtqua = new DataTable();
        public void qualificationder()
        {
            SqlDataAdapter dp = new SqlDataAdapter("select q_name from qualification", cd.conder);
            dp.Fill(dtqua);
            txtqua.DataSource = dtqua;
            txtqua.DisplayMember = "q_name";
            txtqua.ValueMember = "q_name";

        }
        SqlDataAdapter posider = new SqlDataAdapter();
        DataSet dsps = new DataSet();
        Connectder cdps = new Connectder();
        SqlCommand cmdps = new SqlCommand();
        DataTable dtps = new DataTable();
        public void positionder()
        {
            SqlDataAdapter dp = new SqlDataAdapter("select po_name from position", cd.conder);
            dp.Fill(dtps);
            txtposition.DataSource = dtps;
            txtposition.DisplayMember = "po_name";
            txtposition.ValueMember = "po_name";

        }
        SqlDataAdapter dadepart = new SqlDataAdapter();
        DataSet dsdepart = new DataSet();
        Connectder cddepart = new Connectder();
        SqlCommand cmddepart = new SqlCommand();
        DataTable dtdepart = new DataTable();
        public void departder()
        {
            SqlDataAdapter dp = new SqlDataAdapter("select dep_name from department", cd.conder);
            dp.Fill(dtdepart);
            txtdepartment.DataSource = dtdepart;
            txtdepartment.DisplayMember = "dep_name";
            txtdepartment.ValueMember = "dep_name";

        }
        public salary()
        {
            InitializeComponent();
        }

        private void salary_Load(object sender, EventArgs e)
        {
            cd.connectder();
            sadaeng();
            cdqua.connectder();
            qualificationder();
            cdps.connectder();
            positionder();
            cddepart.connectder();
            departder();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into salary values(@bs_id,@qualification,@position,@department,@amount)", cd.conder);
            cmd.Parameters.AddWithValue("@bs_id", txtid.Text);
            cmd.Parameters.AddWithValue("@qualification", txtqua.Text);
            cmd.Parameters.AddWithValue("@position", txtposition.Text);
            cmd.Parameters.AddWithValue("@department", txtdepartment.Text);
            cmd.Parameters.AddWithValue("@amount", txtamount.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not save"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update salary set qualification=@qualification, position=@position, department=@department, amount=@amount where bs_id=@bs_id", cd.conder);
            cmd.Parameters.AddWithValue("@bs_id", txtid.Text);
            cmd.Parameters.AddWithValue("@qualification", txtqua.Text);
            cmd.Parameters.AddWithValue("position", txtposition.Text);
            cmd.Parameters.AddWithValue("department", txtdepartment.Text);
            cmd.Parameters.AddWithValue("amount", txtamount.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("CAN NOT UPDATE"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtqua.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtposition.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtdepartment.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtamount.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete salary where bs_id=@bs_id", cd.conder);
            cmd.Parameters.AddWithValue("@bs_id", txtid.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("CAN NOT DELETE"); }
        }
    }
}
