﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    public class DbConnect
    {
        private SqlConnection con;
        public SqlDataReader dr;
        public SqlDataAdapter da;
        public string userid;
        public string User_id {
            get { return userid; }
            set { userid = value; } 
        }

        public SqlConnection Connect() 
        {
            con = new SqlConnection(@"Data Source=DESKTOP-U2B1AN9\BOYZ2019;Initial Catalog=pos_dshop;User ID=sa;Password=123456");
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            else
            {
                con.Open();
            }

            return con;
        }

        public void ConClose()
        {
            if(con != null)
            {
                con.Close();
            }
        }
    }
}
