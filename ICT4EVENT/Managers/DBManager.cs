using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace ICT4EVENT
{
    public static class DBManager
    {
        private static OracleConnection oracleConnection;

        /// <summary>
        ///     Connects to our database
        /// </summary>
        public static void Initalize()
        {
            // make sure the dbmanager can't reinitialise
            if (oracleConnection != null &&
                (oracleConnection.State != ConnectionState.Broken || oracleConnection.State != ConnectionState.Closed))
                return;

            // If the file exist, we deserialize our configs
            if (File.Exists(Settings.DBCONFIGFILENAME))
            {
                Settings.DeserializeDatabase();
            }
            // Else we get new configs and we serialize them
            else if (!File.Exists(Settings.DBCONFIGFILENAME))
            {
                if (Settings.DbConfig == null)
                {
                    DBConfigForm dbConfigForm = new DBConfigForm();
                    dbConfigForm.ShowDialog();
                    Settings.SerializeDatabase();
                }
            }

            oracleConnection = new OracleConnection();
            oracleConnection.ConnectionString = string.Format("User Id={0};Password={1};Data Source=//{2}:{3}/{4}",
                Settings.DbConfig.user, Settings.DbConfig.pw, Settings.DbConfig.host,
                Settings.DbConfig.port, Settings.DbConfig.database);

            try
            {
                //Logger.Info("Attempting connection to Database.");
                oracleConnection.Open();
                //Logger.Success("Database connection succesfully opened.");
            }
            catch (OracleException)
            {
                //Logger.Error("Database connection could not be opened.");
                if (
                    MessageBox.Show(
                        "There seems to be an error connecting to the Database. Would you like to remove the existing database configuration?",
                        "Database error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Logger.Warning("Deleting database config name");
                    File.Delete(Settings.DBCONFIGFILENAME);
                }
                //Logger.Info("Exiting application due to broken database config");
                //Logger.Destruct(Settings.LOGFILENAME);
                Environment.Exit(1);
                return;
            }


        }

        public static void Destruct()
        {
            oracleConnection.Close();
        }

        /// <summary>
        ///     Sends a query to the database and returns the result
        /// </summary>
        /// <param name="query">Query for the database</param>
        /// <returns>Object containing the result</returns>
        public static OracleDataReader QueryDB(string query)
        {
            OracleDataReader queryResult;

            OracleCommand oracleCommand = oracleConnection.CreateCommand();

            // Replace ; with EOS, so that this won't ever be a problem again
            oracleCommand.CommandText = query.Replace(';', '\0');

            // Prepare for docking
            oracleCommand.Prepare();

            try
            {
                //Logger.Info("Querying Database");
                //Logger.Debug("Query: " + query);
                queryResult = oracleCommand.ExecuteReader();
                oracleCommand.CommandText = "commit";
                oracleCommand.ExecuteReader();
                //Logger.Success("Query Successfully executed");
            }
            catch (OracleException exception)
            {
                //Logger.Error("Error querying datbase: " + exception.ToString());
                Console.WriteLine(exception.ToString());

                MessageBox.Show(exception.ToString());

                return null;
            }


            return queryResult;
        }
    }
}