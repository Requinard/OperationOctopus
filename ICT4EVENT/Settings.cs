using System;
using System.Drawing.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using ApplicationLogger;

namespace ICT4EVENT
{
    public static class Settings
    {
        public const bool DEBUG = false;
        public const string DBCONFIGFILENAME = "db.cnf";
        public const string LOGFILENAME = "log.log";
        private static readonly RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        private static int NUM_ITERATIONS = 1000;
        private static int SALT_SIZE = 12;

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

        public static string CreateHashPassword(string password)
        {
            byte[] buf = new byte[SALT_SIZE]; 
            rng.GetBytes(buf);
            string salt = Convert.ToBase64String(buf);

            Rfc2898DeriveBytes deriver2898 = new Rfc2898DeriveBytes(password.Trim(), buf, NUM_ITERATIONS);
            string hash = Convert.ToBase64String(deriver2898.GetBytes(16));
            return salt + ':' + hash; ;
        }

        public static bool IsPasswordValid(string password, string saltHash)
        {
            string[] parts = saltHash.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
                return false;
            byte[] buf = Convert.FromBase64String(parts[0]);
            Rfc2898DeriveBytes deriver2898 = new Rfc2898DeriveBytes(password.Trim(), buf, NUM_ITERATIONS);
            string computedHash = Convert.ToBase64String(deriver2898.GetBytes(16));
            return parts[1].Equals(computedHash);
        }
    }
}