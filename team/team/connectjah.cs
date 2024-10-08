using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace team
{
    internal class connectjah
    {
        public string con = @"Data Source=DESKTOP-3B6JIUK; initial Catalog = team; integrated security = True";
        public SqlConnection conder = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public void connectja()
        {
            conder.ConnectionString = con;
            conder.Open();
        }
    }
}
