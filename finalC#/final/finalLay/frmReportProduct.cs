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
    public partial class frmReportProduct : Form
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        DbConnect db = new DbConnect();
        public frmReportProduct()
        {
            InitializeComponent();
        }

        private void frmReportProduct_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void getdata()
        {
            string sql = "select a.code, b.cate_name, c.brand_name, a.pro_name, d.unit_name, a.qty, a.price from product as a join category as b on a.cate_id = b.cate_id join brand as c on a.brand_id = c.brand_id join unit as d on a.unit_id = d.unit_id";
            cmd = new SqlCommand(sql, db.Connect());
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            ReportDataSource rpds = new ReportDataSource("DataSet2", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rpds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
        }
    }
}
