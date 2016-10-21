using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace Spends.Connection
{
    public class ConnectionParameters
    {
        MySqlConnection conn;
        MySqlCommand cmm;
        MySqlDataReader dr;

        public ConnectionParameters()
        {
            conn = new MySqlConnection(strConnection);
        }

        private string strConnection
        {
            get
            {
                return "Server=localhost" +
                       ";Port=3306" +
                       ";Database=spendsdb" +
                       ";Uid=root" +
                       ";Pwd=root";
            }
        }

        private void connect()
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }

        private void close()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        public void executeCommand(MySqlCommand pCmd)
        {
            connect();
            pCmd.Connection = conn;
            pCmd.ExecuteNonQuery();
            close();
        }

        public MySqlDataReader getDataReader(MySqlCommand pCmd)
        {
            connect();
            pCmd.Connection = conn;
            dr = pCmd.ExecuteReader();

            return dr;
        }

    }
}