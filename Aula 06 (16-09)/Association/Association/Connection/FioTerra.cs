using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association.Connection
{
    public class FioTerra
    {
        MySqlConnection conn;
        MySqlCommand cmm;
        MySqlDataReader dr;

        public FioTerra()
        {
            conn = new MySqlConnection(strConnection);
        }

        private string strConnection
        {
            get
            {
                return "Server=localhost" +
                       ";Port=3306" +
                       ";Database=associationsdb" +
                       ";Uid=root" +
                       ";Pwd=root";
            }
        }

        private void Connect()
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

        }

        private void Close()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        public void ExecuteCommand(MySqlCommand pCmd)
        {
            Connect();
            pCmd.Connection = conn;
            pCmd.ExecuteNonQuery();
            Close();
        }

        public MySqlDataReader getDataReader(MySqlCommand pCmd)
        {
            Connect();
            pCmd.Connection = conn;
            dr = pCmd.ExecuteReader();

            return dr;
        }

    }

}