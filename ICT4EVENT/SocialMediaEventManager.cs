using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Oracle.DataAccess.Client;

namespace ICT4EVENT
{
    public static class UserManager
    {
        private static RNGCryptoServiceProvider crypto;
        private static List<UserModel> users;

        private static readonly RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        private static int NUM_ITERATIONS = 1000;
        private static int SALT_SIZE = 12;

        public static void Initialize()
        {
            const string select_query = "SELECT * FROM USERS";
            const string select_registration = "SELECT * FROM REGISTRATION WHERE USERID = {0}";

            users = new List<UserModel>();

            // Construct users
            OracleDataReader reader = DBManager.QueryDB(select_query);

            while (reader.Read())
            {
                UserModel user = new UserModel();

                user.Username = (string)reader["username"];
                user.Password = (string)reader["userpassword"];
                user.Id = Int32.Parse(reader["ident"].ToString());

                users.Add(user);
            }

            // If there are 0 users we will add an administrator
            if (false)
            {
                UserModel user = new UserModel();

                user.Username = "admin";
                user.Password = CreateHashPassword("admin");
                user.Telephonenumber = "dwad";
                user.RfiDnumber = "";
                user.Address = "dasdaw";
                user.Email = "eadwdwa";

                user.Create();

                users.Add(user);
            }

            // Construct reservations
            foreach (UserModel model in users)
            {
                string select = String.Format(select_registration, model.Id);

                reader = DBManager.QueryDB(@select);

                while (reader.Read())
                {
                    EventModel event_item = EventManager.FindEvent(Int32.Parse(reader["eventid"].ToString()));

                    RegistrationModel registration = new RegistrationModel(model, event_item);

                    registration.Id = Int32.Parse(reader["ident"].ToString());

                    model.RegistrationList.Add(registration);

                    event_item.RegistrationsList.Add(registration);
                }
            }
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="username">Desired username</param>
        /// <param name="password">Desired password</param>
        /// <returns>New user that was created</returns>
        public static UserModel CreateUser(string username, string password)
        {
            UserModel user = new UserModel();

            user.Username = username;
            user.Password = CreateHashPassword(password);

            user.Create();

            users.Add(user);
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
            UserModel user = FindUser(username);

            bool success = AuthenticateUser(user, password);

            if (success)
            {
                Settings.ActiveUser = user;
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

        public static bool AuthenticateUser(string RFIDNumber)
        {
            UserModel userModel = null;

            foreach (UserModel user in users)
            {
                if (user.RfiDnumber == RFIDNumber)
                {
                    userModel = user;
                    break;
                }
            }

            if (userModel == null)
            {
                return false;
            }
            else
            {
                Settings.ActiveUser = userModel;
                return true;
            }
        }

        public static UserModel FindUser(string username)
        {
            IEnumerable<UserModel> s = from user in users
                where user.Username == username
                select user;

            return s.ToList()[0] ?? null;
        }

        public static UserModel FindUser(int id)
        {
            var s = from user in users
                where user.Id == id
                select user;

            return s.ToList().First()?? null;
        }

        private static string CreateHashPassword(string password)
        {
            byte[] buf = new byte[SALT_SIZE];
            rng.GetBytes(buf);
            string salt = Convert.ToBase64String(buf);

            Rfc2898DeriveBytes deriver2898 = new Rfc2898DeriveBytes(password.Trim(), buf, NUM_ITERATIONS);
            string hash = Convert.ToBase64String(deriver2898.GetBytes(16));
            return salt + ':' + hash; ;
        }

        private static bool IsPasswordValid(string password, string saltHash)
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

    public static class EventManager
    {
        public static List<EventModel> events;

        public static void Initialize()
        {
            const string select_events = "SELECT * FROM EVENT";
            events = new List<EventModel>();

            // Construct all events

            OracleDataReader reader = DBManager.QueryDB(select_events);

            while (reader.Read())
            {
                EventModel event_item = new EventModel();

                event_item.Id = Int32.Parse(reader["ident"].ToString());
                event_item.Name = reader["eventname"].ToString();
                event_item.Location = reader["eventlocation"].ToString();
                event_item.Description = reader["description"].ToString();
                event_item.StartDate = DateTime.Parse(reader["beginTime"].ToString());
                event_item.EndDate = DateTime.Parse(reader["endtime"].ToString());

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

            return s.ToList()[0] ?? null;
        }
    }

    public static class PostManager
    {
        private static List<PostModel> posts;

        public static void Initialize()
        {
            const string select_posts = "SELECT * FROM POST WHERE EVENTID = {0}";
            posts = new List<PostModel>();

            List<EventModel> events = EventManager.events;

            foreach (EventModel event_item in events)
            {
                OracleDataReader reader = DBManager.QueryDB(String.Format(select_posts, event_item.Id));

                while (reader.Read())
                {
                    UserModel user = UserManager.FindUser(Int32.Parse(reader["userid"].ToString()));

                    PostModel post = new PostModel(user, event_item);

                    post.Id = Int32.Parse(reader["ident"].ToString());
                    post.PathToFile = reader["pathtofile"].ToString();
                    post.Content = reader["PostContent"].ToString();

                    posts.Add(post);

                    //TODO: Add tags
                    //TODO: add likes
                    //TODO: add reports

                }
            }
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
                model.Capacity = reader["PlaceCapacity"].ToString();
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