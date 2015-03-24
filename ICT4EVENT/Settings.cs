using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ICT4EVENT
{
    public static class Settings
    {
        public const bool DEBUG = false;
        public const string DBCONFIGFILE = "db.cnf";

        public static DBConfig DbConfig = new DBConfig();

        public static void SerializeDatabase()
        {
            Stream s = new FileStream(DBCONFIGFILE, FileMode.Create);
            var binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(s, DbConfig);

            s.Close();
        }

        public static void DeserializeDatabase()
        {
            Stream s = new FileStream(DBCONFIGFILE, FileMode.Open);
            var binaryFormatter = new BinaryFormatter();

            DbConfig = (DBConfig) binaryFormatter.Deserialize(s);

            s.Close();
        }
    }
}
