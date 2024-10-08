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
    public partial class frmReportBillBuy : Form
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        DbConnect db = new DbConnect();
        string codes = null;
        public frmReportBillBuy(string code)
        {
            InitializeComponent();
            textBox1.Text = code;
        }

        private void frmReportBillBuy_Load(object sender, EventArgs e)
        {
            getdata();
            getDetaildata();
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void getdata()
        {
            try
            {
                string sql = "select supplier.supplier_name from buy join supplier on buy.supplier_id = supplier.supplier_id where buy.code = " + textBox1.Text;
                cmd = new SqlCommand(sql, db.Connect());
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    ReportParameter parameters = new ReportParameter("code", textBox1.Text);
                    ReportParameter parameters1 = new ReportParameter("supplier_name", row["supplier_name"].ToString());
                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    this.reportViewer1.LocalReport.SetParameters(parameters1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ກະລຸນາປ້ອນລະຫັດບິນ!");
            }
        }

        private void getDetaildata()
        {
            if (textBox1.Text != "")
            {
                string sql = "select b.code, c.cate_name, d.brand_name, b.pro_name, e.unit_name, a.qty from buy_detail as a join product as b on a.product_id = b.product_id join category as c on b.cate_id = c.cate_id join brand as d on b.brand_id = d.brand_id join unit as e on b.unit_id = e.unit_id where a.buy_code = '" + textBox1.Text + "'";
                cmd = new SqlCommand(sql, db.Connect());
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                ReportDataSource rpds = new ReportDataSource("DataSet10", dt);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rpds);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            codes = textBox1.Text;
            getdata();
            getDetaildata();
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
