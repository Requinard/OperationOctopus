using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ICT4EVENT
{
    public static class Settings
    {
        public const bool DEBUG = false;
        public const string DBCONFIGFILE = "db.cnf";

        public static DatabaseConfig DatabaseConfig = new DatabaseConfig();

        public static void SerializeDatabase()
        {
            Stream s = new FileStream(DBCONFIGFILE, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(s, DatabaseConfig);

            s.Close();
        }

        public static void DeserializeDatabase()
        {
            Stream s = new FileStream(DBCONFIGFILE, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            DatabaseConfig = (DatabaseConfig) binaryFormatter.Deserialize(s);

            s.Close();
        }
    }
}
