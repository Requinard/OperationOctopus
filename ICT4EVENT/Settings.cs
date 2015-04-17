using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ICT4EVENT
{
    public static class Settings
    {
        public const bool DEBUG = false;
        public const string DBCONFIGFILENAME = "db.cnf";
        public const string LOGFILENAME = "log.log";
        public static UserModel ActiveUser = null;
        public static EventModel ActiveEvent = null;
        public static DBConfig DbConfig;

        public static void SerializeDatabase()
        {
            //Logger.Info("Serializing Database");
            Stream s = new FileStream(DBCONFIGFILENAME, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(s, DbConfig);
            //Logger.Success("Successfully serialized database");
            s.Close();
        }

        public static void DeserializeDatabase()
        {
            //Logger.Info("Deserializing Database");
            Stream s = new FileStream(DBCONFIGFILENAME, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            DbConfig = (DBConfig) binaryFormatter.Deserialize(s);
            //Logger.Success("Successfully deserialized database");

            s.Close();
        }
    }
}