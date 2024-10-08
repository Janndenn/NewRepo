using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace lab3
{
    internal class connectder
    {
        public string con = @"Data Source=DESKTOP-3B6JIUK; initial catalog = lab3; integrated security= true";
        public SqlConnection conder= new SqlConnection();
        public SqlCommand cmd= new SqlCommand();
        public void Connectder()
        {
            conder.ConnectionString = con;
            conder.Open();
        }

    }
}
