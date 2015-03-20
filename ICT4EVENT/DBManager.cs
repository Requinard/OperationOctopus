using System;
using Oracle.DataAccess.Client;

namespace ICT4EVENT
{
    internal class DBManager : IDisposable
    {
        private const string user = "SYSTEM";
        private const string pw = "test";
        private const string server = "192.168.250.130";
        private const string port = "1521";
        private const string database = "xe";

        private const bool RUNTESTS = true;
        private readonly OracleConnection oracleConnection;
        private bool disposed;

        /// <summary>
        /// Connects to our database
        /// </summary>
        public DBManager()
        {
            oracleConnection = new OracleConnection();
            oracleConnection.ConnectionString = String.Format("User Id={0};Password={1};Data Source=//{2}:{3}/{4}", user,
                pw, server, port, database);

            oracleConnection.Open();

            if (RUNTESTS)
            {
                RunOracleDatabaseTest();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Tests the oracle database to see if we can IO to it
        /// </summary>
        /// <returns>success</returns>
        private bool RunOracleDatabaseTest()
        {
            const string create_table = "CREATE TABLE test_db (number_thing NUMBER)";
            const string insert_into_table = "INSERT INTO test_db (number_thing) VALUES (1)";
            const string select_from_table = "SELECT * FROM test_db";
            const string drop_table = "DROP TABLE test_db";

            Console.WriteLine(QueryDB(create_table));
            Console.WriteLine(QueryDB(insert_into_table));
            Console.WriteLine(QueryDB(select_from_table));
            Console.WriteLine(QueryDB(drop_table));

            return true;
        }

        ~DBManager()
        {
            Dispose(true);
        }

        /// <summary>
        /// Sends a query to the database and returns the result
        /// </summary>
        /// <param name="query">Query for the database</param>
        /// <returns>Object containing the result</returns>
        private OracleDataReader QueryDB(string query)
        {
            OracleDataReader queryResult;

            OracleCommand oracleCommand = oracleConnection.CreateCommand();

            // Replace ; with EOS, so that this won't ever be a problem again
            oracleCommand.CommandText = query.Replace(';', '\0');

            // Prepare for docking
            oracleCommand.Prepare();

            try
            {
               queryResult = oracleCommand.ExecuteReader();
            }
            catch (OracleException exception)
            {
                Console.WriteLine(exception.ToString());

                return null;
            }
           

            return queryResult;
        }

        /// <summary>
        /// Disposes of the DBManager object
        /// </summary>
        /// <param name="disposing">Are you disposing?</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                oracleConnection.Close();
                oracleConnection.Dispose();
            }


            disposed = true;
        }
    }
}