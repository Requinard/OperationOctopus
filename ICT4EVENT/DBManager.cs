using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace ICT4EVENT
{
    class DBManager
    {

        private OracleConnection oracleConnection;

        private const string user = "SYSTEM";
        private const string pw = "test";
        private const bool RUNTESTS = true;



        public DBManager()
        {
           oracleConnection = new OracleConnection();
           oracleConnection.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + "//192.168.250.130:1521/xe" + ";"; 

            oracleConnection.Open();

            if (RUNTESTS)
            {
                RunOracleDatabaseTest();
            }
        }

        private bool RunOracleDatabaseTest()
        {
            const string create_table = @"CREATE TABLE test_db (number_thing NUMBER);";
            const string insert_into_table = "INSERT INTO test_db (number_thing) VALUES (1);";
            const string select_from_table = "SELECT * FROM test_db;";
            const string drop_table = "DROP TABLE test_db;";

            Console.Write(QueryDDL(create_table));
            Console.WriteLine(QueryDB(insert_into_table));
            Console.WriteLine(QueryDB(select_from_table));
            Console.WriteLine(QueryDB(drop_table));

            return true;
        }

        ~DBManager()
        {

            oracleConnection.Close();
            oracleConnection.Dispose();
        }

        private int QueryDDL(string query)
        {
            OracleCommand oracleCommand = oracleConnection.CreateCommand();

            oracleCommand.CommandText = query;

            int dr = oracleCommand.ExecuteNonQuery();

            return dr;
        }
        private OracleDataReader QueryDB(string query)
        {
            OracleCommand oracleCommand = oracleConnection.CreateCommand();

            oracleCommand.CommandText = query;

            OracleDataReader dr = oracleCommand.ExecuteReader();

            return dr;
        }
    }
}
