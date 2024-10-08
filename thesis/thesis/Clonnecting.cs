using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace thesis
{
    internal class Clonnecting
    {
        public string con = @"Data Source=JANNDENN\SQLEXPRESS; initial Catalog = databasethesis; integrated security = True";
        public SqlConnection conder = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public void connectjah()
        {
            conder.ConnectionString = con;
            conder.Open();
        }
    }
}
