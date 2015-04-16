namespace ICT4EVENT
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;

    using Oracle.DataAccess.Client;

    public static class UserManager
    {
        private static readonly RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        private static readonly int NUM_ITERATIONS = 1000;

        private static readonly int SALT_SIZE = 12;

        /// <summary>
        ///     Creates a new user
        /// </summary>
        /// <param name="username">Desired username</param>
        /// <param name="password">Desired password</param>
        /// <returns>New user that was created</returns>
        public static UserModel CreateUser(
            string username,
            string password,
            string realName,
            string address,
            string telephoneNumber,
            string email,
            string rfid)
        {
            UserModel user = new UserModel();

            user.Username = username;
            user.Password = CreateHashPassword(password);
            user.RfiDnumber = rfid;
            user.Address = address;
            user.Telephonenumber = telephoneNumber;
            user.Email = email;

            user.Create();

            return user;
        }

        /// <summary>
        ///     Authenticates a user.
        /// </summary>
        /// <param name="username">Username of user</param>
        /// <param name="password">Password that the user inputted</param>
        /// <returns>Success of the operation</returns>
        public static bool AuthenticateUser(string username, string password)
        {
            string query = string.Format("SELECT * FROM users WHERE username = '{0}'", username);

            OracleDataReader reader = DBManager.QueryDB(query);

            reader.Read();

            UserModel user = new UserModel();
            user.ReadFromReader(reader);

            bool success = AuthenticateUser(user, password);

            if (success)
            {
                Settings.ActiveUser = user;

                GetUserRegistrations(user);
            }

            return success;
        }

        /// <summary>
        ///     Authenticates a user.
        /// </summary>
        /// <param name="user">UserModel of the user to be authenticated</param>
        /// <param name="password">Password that the user inputted</param>
        /// <returns>Success of the operation</returns>
        public static bool AuthenticateUser(UserModel user, string password)
        {
            return IsPasswordValid(password, user.Password);
        }

        /// <summary>
        ///     Authenticates a user over his RFID number
        /// </summary>
        /// <param name="RFIDNumber">Readable RFID number</param>
        /// <returns>Whether the operation was a success</returns>
        public static bool AuthenticateUser(string RFIDNumber)
        {
            string query = string.Format("SELECT * FROM users WHERE rfidnumber = '{0}'", RFIDNumber);

            UserModel user = new UserModel();

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader.RecordsAffected == 0)
            {
                return false;
            }

            reader.Read();

            user.ReadFromReader(reader);

            GetUserRegistrations(user);

            return true;
        }

        public static UserModel FindUser(string username)
        {
            string query = string.Format("SELECT * FROM USERS WHERE username = '{0}'", username);

            OracleDataReader reader = DBManager.QueryDB(query);
            UserModel user = new UserModel();

            reader.Read();

            user.ReadFromReader(reader);

            return user;
        }

        public static List<UserModel> FindUsers(string username)
        {
            List<UserModel> users = new List<UserModel>();
            string query = string.Format("SELECT * FROM USERS WHERE USERNAME LIKE '%{0}%'", username);

            OracleDataReader reader = DBManager.QueryDB(query);

            while (reader.Read())
            {
                UserModel user = new UserModel { Id = int.Parse(reader["ident"].ToString()) };

                user.Read();

                users.Add(user);
            }

            return users;
        }

        public static UserModel FindUser(int id)
        {
            string query = string.Format("SELECT * FROM USERS WHERE ident = '{0}'", id);

            OracleDataReader reader = DBManager.QueryDB(query);
            UserModel user = new UserModel();
            reader.Read();
            user.ReadFromReader(reader);
            user.Read();
            return user;
        }

        public static List<RegistrationModel> GetUserRegistrations(UserModel user)
        {
            List<RegistrationModel> regs = new List<RegistrationModel>();
            string query =
                string.Format(
                    "SELECT * FROM registration WHERE userid = '{0}'",
                    user.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            if(reader == null)
                return null;    

            while (reader.Read())
            {
                RegistrationModel registration = new RegistrationModel();
                registration.ReadFromReader(reader);

                regs.Add(registration);
            }

            return regs;
        }

        public static RegistrationModel RegisterUserForEvent(UserModel user, EventModel eventModel)
        {
            RegistrationModel registration = new RegistrationModel(user, eventModel);

            if (registration.Create())
            {
                return registration;
            }

            return null;
        }

        public static PaymentModel RegistrationMarkPaid(RegistrationModel registration, decimal amount, string type)
        {
            PaymentModel payment = new PaymentModel(registration);
            payment.Registration = registration;
            payment.Amount = amount;
            payment.PaymentType = type;

            if (payment.Create())
            {
                return payment;
            }
            return null;
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
            string[] parts = saltHash.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                return false;
            }
            byte[] buf = Convert.FromBase64String(parts[0]);
            Rfc2898DeriveBytes deriver2898 = new Rfc2898DeriveBytes(password.Trim(), buf, NUM_ITERATIONS);
            string computedHash = Convert.ToBase64String(deriver2898.GetBytes(16));
            return parts[1].Equals(computedHash);
        }
    }
}