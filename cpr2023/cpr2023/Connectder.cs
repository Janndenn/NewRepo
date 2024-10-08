using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace cpr2023
{
    internal class Connectder
    {
        public string con = @"Data Source=DESKTOP-3B6JIUK; initial Catalog = salary_cpr2023; integrated security = True";
        public SqlConnection conder=new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public void connectder()
        {
            conder.ConnectionString = con;
            conder.Open();
        }
    }
}
