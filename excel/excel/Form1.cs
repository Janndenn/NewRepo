using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace excel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Excel.Application xlApp;
        Excel.Workbook wb;
        Excel.Worksheet ws;
        object misValue = System.Reflection.Missing.Value;
        OleDbConnection conn;
        DataSet ds;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        string path = "", sql = "";
        public void read()
        {
            conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=='"+path+";MyExcel.xls;Extended Properties=\"Excel 8.0;HDR = Yes;IMEX=1\";");
            da = new OleDbDataAdapter("select * from [Sheet1$] where ID is not null", conn);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.DefaultExt = "xls";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                }
                if(path != "")
                {
                    read();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != ""&& textBox2.Text !="" && path != "")
            {
                try
                {
                    cmd = new OleDbCommand();
                    conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=='" + path + ";MyExcel.xls;Extended Properties=\"Excel 8.0;HDR = Yes;IMEX=1\";");
                    conn.Open ();
                    sql = "insert into [Sheet1$](ID,Name) values('" + textBox1.Text + "', '" + textBox2.Text + "')";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    read();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && path != "")
            {
                try
                {
                    cmd = new OleDbCommand();
                    conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=='" + path + ";MyExcel.xls;Extended Properties=\"Excel 8.0;HDR = Yes;IMEX=1\";");
                    conn.Open();
                    sql = "Update [sheet1$] set Name= '"+ textBox1.Text +"' where ID = '"+ textBox2.Text+ "'";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    read();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                xlApp = new Excel.Application();    
                if(xlApp == null)
                {
                    MessageBox.Show("Excel not installed");
                    return;
                }
                wb = xlApp.Workbooks.Add(misValue);
                ws = (Excel.Worksheet)wb.Worksheets.get_Item(1);

                ws.Cells[1, 1] = "ID";
                ws.Cells[1, 2] = "Name";
                
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.DefaultExt = "xls";
                sfd.AddExtension = true;
                string savePath = "";
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    savePath = sfd.FileName;
                    MessageBox.Show(savePath);
                }
                wb.SaveAs(savePath, Excel.XlFileFormat.xlWorkbookNormal);
                wb.Close();
                xlApp.Quit();
                Marshal.ReleaseComObject(wb);
                Marshal.ReleaseComObject(ws);
                Marshal.ReleaseComObject(xlApp);


            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
