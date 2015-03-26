using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ICT4EVENT
{
    public static class Settings
    {
        public const bool DEBUG = false;
        public const string DBCONFIGFILENAME = "db.cnf";
        public const string LOGFILENAME = "log.log";

        public static DBConfig DbConfig = new DBConfig();

        public static void SerializeDatabase()
        {
            Stream s = new FileStream(DBCONFIGFILENAME, FileMode.Create);
            var binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(s, DbConfig);

            s.Close();
        }

        public static void DeserializeDatabase()
        {
            Stream s = new FileStream(DBCONFIGFILENAME, FileMode.Open);
            var binaryFormatter = new BinaryFormatter();

            DbConfig = (DBConfig) binaryFormatter.Deserialize(s);

            s.Close();
        }
    }
}