using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;
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

        public static void Initialize()
        {
            const string select_query = "SELECT * FROM USERS";

            //TODO: query db for all users
            OracleDataReader reader = DBManager.QueryDB(select_query);

            while (reader.Read())
            {
                UserModel user = new UserModel();

                user.Username = (string)reader["username"];
                user.Password = (string)reader["userpassword"];
                user.Id = (int) reader["ident"];

                users.Add(user);
            }

            //TODO: for all users we add the reservations

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
            user.Password = password;

            user.Create();

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

            return AuthenticateUser(user, password);
        }

        /// <summary>
        /// Authenticates a user.
        /// </summary>
        /// <param name="user">UserModel of the user to be authenticated</param>
        /// <param name="password">Password that the user inputted</param>
        /// <returns>Success of the operation</returns>
        public static bool AuthenticateUser(UserModel user, string password)
        {
            if (user.Password == (Settings.salt + password))
                return true;

            return false;
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

            return s.ToList()[0] ?? null;
        }
    }
}