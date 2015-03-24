using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
            var binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(s, DatabaseConfig);

            s.Close();
        }

        public static void DeserializeDatabase()
        {
            Stream s = new FileStream(DBCONFIGFILE, FileMode.Open);
            var binaryFormatter = new BinaryFormatter();

            DatabaseConfig = (DatabaseConfig) binaryFormatter.Deserialize(s);

            s.Close();
        }
    }
}