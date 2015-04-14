using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using Oracle.DataAccess.Client;

namespace ICT4EVENT
{
    public static class UserManager
    {
        private static RNGCryptoServiceProvider crypto;
        private static readonly RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        private static int NUM_ITERATIONS = 1000;
        private static int SALT_SIZE = 12;
        
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="username">Desired username</param>
        /// <param name="password">Desired password</param>
        /// <returns>New user that was created</returns>
        public static UserModel CreateUser(string username, string password, string realName, string address, string telephoneNumber, string email, string rfid)
        {
            UserModel user = new UserModel();

            user.Username = username;
            user.Password = CreateHashPassword(password);
            user.RfiDnumber = rfid;
            user.Address = address;
            user.Telephonenumber = telephoneNumber;
            user.Email = email;

            user.Create();

            user.Read();

            return user;
        }

        /// <summary>
        /// Authenticates a user.
        /// </summary>
        /// <param name="username">Username of user</param>
        /// <param name="password">Password that the user inputted</param>
        /// <returns>Success of the operation</returns>
        public static bool AuthenticateUser(string username, string password)
        {
            string query = String.Format("SELECT ident FROM users WHERE username = '{0}'", username);
            OracleDataReader reader = DBManager.QueryDB(query);
            reader.Read();
            UserModel user = new UserModel() { Id = Int32.Parse(reader["ident"].ToString())};

            user.Read();

            bool success = AuthenticateUser(user, password);

            if (success)
            {
                Settings.ActiveUser = user;

                GetUserRegistrations(user);
            }

            return success;
        }

        /// <summary>
        /// Authenticates a user.
        /// </summary>
        /// <param name="user">UserModel of the user to be authenticated</param>
        /// <param name="password">Password that the user inputted</param>
        /// <returns>Success of the operation</returns>
        public static bool AuthenticateUser(UserModel user, string password)
        {
            return IsPasswordValid(password, user.Password);
        }

        /// <summary>
        /// Authenticates a user over his RFID number
        /// </summary>
        /// <param name="RFIDNumber">Readable RFID number</param>
        /// <returns>Whether the operation was a success</returns>
        public static bool AuthenticateUser(string RFIDNumber)
        {
            string query = string.Format("SELECT * FROM users WHERE rfidnumber = '{0}'", RFIDNumber);

            UserModel user = new UserModel();

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader.RecordsAffected == 0)
                return false;
            
            reader.Read();

            user.Id = Int32.Parse(reader["ident"].ToString());

            user.Read();

            Settings.ActiveUser = user;

            GetUserRegistrations(user);

            return true;
        }

        public static UserModel FindUser(string username)
        {

            string query = String.Format("SELECT * FROM USERS WHERE username = '{0}'", username);

            OracleDataReader reader = DBManager.QueryDB(query);
            UserModel user = new UserModel() {Id = Int32.Parse(reader["ident"].ToString())};

            user.Read();

            return user;
        }

        public static List<UserModel> FindUsers(string username)
        {
            List<UserModel> users = new List<UserModel>();
            string query = String.Format("SELECT * FROM USERS WHERE USERNAME LIKE %'{0}'%");

            OracleDataReader reader = DBManager.QueryDB(query);

            while (reader.Read())
            {
                UserModel user = new UserModel() {Id = Int32.Parse(reader["ident"].ToString())};

                user.Read();

                users.Add(user);
            }

            return users;
        }

        public static UserModel FindUser(int id)
        {
            string query = String.Format("SELECT * FROM USERS WHERE ident = '{0}'", id);

            OracleDataReader reader = DBManager.QueryDB(query);
            UserModel user = new UserModel() { Id = Int32.Parse(reader["ident"].ToString()) };

            user.Read();
            return user; 
        }

        public static UserModel GetUserRegistrations(UserModel user)
        {
            string query = String.Format("SELECT ev.ident as evident, re.ident as regident FROM registration re, event ev WHERE re.eventid = ev.ident AND re.userid = '{0}'", user.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            while (reader.Read())
            {
                EventModel model = new EventModel();

                model.Id = Int32.Parse(reader["evident"].ToString());

                model.Read();

                RegistrationModel registration = new RegistrationModel(user, model);
                registration.Id = Int32.Parse(reader["regident"].ToString());
                registration.Read();

                user.RegistrationList.Add(registration);
            }
            return user;
        }

        private static string CreateHashPassword(string password)
        {
            byte[] buf = new byte[SALT_SIZE];
            rng.GetBytes(buf);
            string salt = Convert.ToBase64String(buf);

            Rfc2898DeriveBytes deriver2898 = new Rfc2898DeriveBytes(password.Trim(), buf, NUM_ITERATIONS);
            string hash = Convert.ToBase64String(deriver2898.GetBytes(16));
            return salt + ':' + hash;
        }

        private static bool IsPasswordValid(string password, string saltHash)
        {
            string[] parts = saltHash.Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
                return false;
            byte[] buf = Convert.FromBase64String(parts[0]);
            Rfc2898DeriveBytes deriver2898 = new Rfc2898DeriveBytes(password.Trim(), buf, NUM_ITERATIONS);
            string computedHash = Convert.ToBase64String(deriver2898.GetBytes(16));
            return parts[1].Equals(computedHash);
        }
    }

    public static class EventManager
    {
        public static List<EventModel> events;

        public static void Initialize()
        {
            const string select_events = "SELECT ident FROM EVENT";
            events = new List<EventModel>();

            // Construct all events

            OracleDataReader reader = DBManager.QueryDB(select_events);

            while (reader.Read())
            {
                EventModel event_item = new EventModel();

                event_item.Id = Int32.Parse(reader["ident"].ToString());

                event_item.Read();

                events.Add(event_item);
            }
        }

        public static EventModel FindEvent(int id)
        {
            var s = from event_item in events
                where event_item.Id == id
                select event_item;

            return s.ToList()[0] ?? null;
        }

        public static EventModel FindEvent(string name)
        {
            var s = from event_item in events
                where event_item.Name.Contains(name)
                select event_item;

            return s.ToList().First() ?? null;
        }
    }

    public static class PostManager
    {
        public static void Initialize()
        {
            
        }

        public static PostModel CreateNewPost(string body, string filepath)
        {
            PostModel post = new PostModel(Settings.ActiveUser, Settings.ActiveEvent);

            // Set up post details
            post.Content = body;
            DateTime datePosted = DateTime.Now;
            post.DatePosted = datePosted;

            //Upload file to FTP

            // First we copy it to a local directory
            //Extract filename
            string fileName = Path.GetFileName(filepath);
            string localDirectory = String.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}", "test", datePosted.Year, datePosted.Month, datePosted.Day,
                datePosted.Hour, datePosted.Minute, datePosted.Second, fileName);

            Directory.CreateDirectory(localDirectory.Replace(fileName, ""));
            File.Copy(filepath, localDirectory);

            FTPManager.UploadFile(localDirectory);

            post.PathToFile = localDirectory;

            post.Create();

            post.Read();

            return post;
        }

        public static LikeModel CreateNewLike(PostModel post)
        {
            LikeModel like = new LikeModel();

            like.User = Settings.ActiveUser;
            like.Post = post;

            like.Create();

            return like;
        }

        public static PostModel RetrievePostFile(PostModel post)
        {
            FTPManager.DownloadFile(post.PathToFile);

            return post;
        }
    }

    public static class EquipmentManager
    {
        public static List<PlaceModel> places;
        public static List<RentableObjectModel> rentables;

        public static void Initialize()
        {
            const string select_places = "SELECT * FROM item WHERE itemtype = 'Place'";
            const string select_rentables = "SELECT * FROM item WHERE itemtype = 'RentableObject'";

            places = new List<PlaceModel>();
            rentables = new List<RentableObjectModel>();

            // Get places
            OracleDataReader reader = DBManager.QueryDB(select_places);

            while (reader.Read())
            {
                EventModel event_item = EventManager.FindEvent(Int32.Parse(reader["eventid"].ToString()));

                PlaceModel model = new PlaceModel(event_item);

                model.Description = reader["description"].ToString();
                model.Price = Decimal.Parse(reader["price"].ToString());
                model.Amount = Int32.Parse(reader["amount"].ToString());
                model.Category = reader["PlaceCategory"].ToString();
                model.Capacity = Int32.Parse(reader["PlaceCapacity"].ToString());
                model.Location = reader["PlaceLocation"].ToString();
                model.Id = Int32.Parse(reader["ident"].ToString());

                places.Add(model);
            }

            // Get rentables
            reader = DBManager.QueryDB(select_rentables);

            while (reader.Read())
            {
                EventModel event_item = EventManager.FindEvent(Int32.Parse(reader["eventid"].ToString()));

                RentableObjectModel model = new RentableObjectModel(event_item);

                model.Id = Int32.Parse(reader["ident"].ToString());
                model.Description = reader["description"].ToString();
                model.Price = Decimal.Parse(reader["price"].ToString());
                model.Amount = Int32.Parse(reader["amount"].ToString());

                rentables.Add(model);
            }
        }
    }
}