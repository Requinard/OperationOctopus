using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace ICT4EVENT
{
    class DBManager
    {
        private MySqlConnection dbConnection;
        private OracleConnection oracleConnection;

        private const string user = "SYSTEM";
        private const string pw = "test";



        public DBManager()
        {
            dbConnection = new MySqlConnection();
            dbConnection.ConnectionString = "SERVER=terarion.com;DATABASE=proftaak2;UID=proftaak2;PASSWORD=FCUGBmvCFJfyGNv6;";
            dbConnection.Open();

           oracleConnection = new OracleConnection();
           oracleConnection.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + "//192.168.250.130:1521/xe" + ";"; 

            oracleConnection.Open();
        }

        public ~DBManager()
        {
            dbConnection.Close();
            oracleConnection.Close();
        }

        private void QueryDB(string query)
        {
            throw new NotImplementedException();
        }
    }
}
