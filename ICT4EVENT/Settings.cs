using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ApplicationLogger;

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
            Logger.Info("Serializing Database");
            Stream s = new FileStream(DBCONFIGFILENAME, FileMode.Create);
            var binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(s, DbConfig);
            Logger.Success("Successfully serialized database");
            s.Close();
        }

        public static void DeserializeDatabase()
        {
            Logger.Info("Deserializing Database");
            Stream s = new FileStream(DBCONFIGFILENAME, FileMode.Open);
            var binaryFormatter = new BinaryFormatter();

            DbConfig = (DBConfig) binaryFormatter.Deserialize(s);
            Logger.Success("Successfully deserialized database");

            s.Close();
        }
    }
}