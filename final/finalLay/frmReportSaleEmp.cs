using Microsoft.Reporting.WinForms;
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

namespace final
{
    public partial class frmReportSaleEmp : Form
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        DbConnect db = new DbConnect();
        string id = null;

        public frmReportSaleEmp()
        {
            InitializeComponent();
        }

        private void frmReportSaleEmp_Load(object sender, EventArgs e)
        {
            getDataCate();
            //this.reportViewer1.RefreshReport();
        }

        public void getDataCate()
        {
            cmd = new SqlCommand("select * from employee", db.Connect());
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "emp_name";
            comboBox1.ValueMember = "emp_id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select a.code, a.valuedt, a.result, b.emp_name from sale as a join employee as b on a.emp_id = b.emp_id where a.emp_id = "+ comboBox1.SelectedValue;
            cmd = new SqlCommand(sql, db.Connect());
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            ReportDataSource rpds = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rpds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
        }
    }
}
