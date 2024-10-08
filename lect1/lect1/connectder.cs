using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using Microsoft.SqlServer;
using System.Security;

namespace lect1
{
    internal class connectder
    {
        public string con = @"Data Source=DESKTOP-3B6JIUK; initial Catalog = class_mini; integrated security = True";
        public SqlConnection conder = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public void Connectder()
        {
            conder.ConnectionString = con;
            conder.Open();
        }
    }
}
