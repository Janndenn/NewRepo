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
    public partial class frmReportUser : Form
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        string strConn = "Data Source=DESKTOP-U2B1AN9\\BOYZ2019;Initial Catalog=pos_cafe;User ID=sa;Password=123456";

        public frmReportUser()
        {
            InitializeComponent();
        }

        private void frmReportUser_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strConn);
            conn.Open();

            getdata();
        }

        private void getdata()
        {
            string sql = "select username_id, user_password,user_name, user_lastname, tel, email, bod, address, card, img from users";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            ReportDataSource rpds = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rpds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
