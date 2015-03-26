﻿using System;
using System.IO;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace ICT4EVENT
{
    internal class DBManager : IDisposable
    {
        private readonly OracleConnection oracleConnection;
        private bool disposed;

        /// <summary>
        ///     Connects to our database
        /// </summary>
        public DBManager()
        {
            // If the file exist, we deserialize our configs
            if (File.Exists(Settings.DBCONFIGFILENAME))
            {
                Settings.DeserializeDatabase();
            }
                // Else we get new configs and we serialize them
            else if (!File.Exists(Settings.DBCONFIGFILENAME))
            {
                var dbConfigForm = new DBConfigForm();
                dbConfigForm.ShowDialog();
                Settings.SerializeDatabase();
            }

            oracleConnection = new OracleConnection();
            oracleConnection.ConnectionString = String.Format("User Id={0};Password={1};Data Source=//{2}:{3}/{4}",
                Settings.DbConfig.user, Settings.DbConfig.pw, Settings.DbConfig.host,
                Settings.DbConfig.port, Settings.DbConfig.database);

            try
            {
                Logger.Info("Attempting connection to Database.");
                oracleConnection.Open();
                Logger.Success("Database connection succesfully opened.");
            }
            catch (OracleException)
            {
                Logger.Error("Database connection could not be opened.");
                if (
                    MessageBox.Show(
                        "There seems to be an error connecting to the Database. Would you like to remove the existing database configuration?",
                        "Database error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Logger.Warning("Deleting database config name");
                    File.Delete(Settings.DBCONFIGFILENAME);
                }
                Logger.Info("Exiting application due to broken database config");
                Logger.Destruct();
                Environment.Exit(1);
                return;
            }


            if (Settings.DEBUG)
            {
                RunOracleDatabaseTest();
            }

            //TODO: Add method of checking whether database already contains our data
            ConstructDatabaseSchema();
        }

        public void Dispose()
        {
            Logger.Debug("Disposing of DBManager");
            Dispose(true);
        }

        /// <summary>
        ///     Constructs new database. Drops all old tables
        /// </summary>
        public void ConstructDatabaseSchema()
        {
            //TODO: Add construction queries for all tables
            ConstructDatabaseEventTable();
        }

        private void ConstructDatabaseEventTable()
        {
            const string drop = "DROP TABLE event";
            const string create =
                "CREATE TABLE event (eventName varchar2(20),location varchar2(20),description CLOB,beginTime TIMESTAMP,endTime TIMESTAMP);";

            //TODO: Add constraints for event table

            QueryDB(drop);
            QueryDB(create);
        }

        /// <summary>
        ///     Tests the oracle database to see if we can IO to it
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

        /// <summary>
        ///     Destructs DBManager
        /// </summary>
        ~DBManager()
        {
            Dispose(true);
        }

        /// <summary>
        ///     Sends a query to the database and returns the result
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
                Logger.Info("Querying Database");
                Logger.Debug("Query: " + query);
                queryResult = oracleCommand.ExecuteReader();
                Logger.Success("Query Successfully executed");
            }
            catch (OracleException exception)
            {
                Logger.Error("Error querying datbase: " + exception.ToString());
                Console.WriteLine(exception.ToString());

                return null;
            }


            return queryResult;
        }

        /// <summary>
        ///     Disposes of the DBManager object
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