﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testthesis
{
    internal class ConnectionString
    {
        public string con = @"Data Source=JANNDENN\SQLEXPRESS; initial Catalog = testthesis; integrated security = True";
        public SqlConnection conder = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public void connect()
        {
            conder.ConnectionString = con;
            conder.Open();
        }
    }
}