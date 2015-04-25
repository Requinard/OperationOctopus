namespace ICT4EVENT
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Windows.Forms;

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
            string rfid,
            int privilege = 1)
        {
            var user = new UserModel();

            user.Username = username;
            user.Password = CreateHashPassword(password);
            user.RfiDnumber = rfid;
            user.Address = address;
            user.Telephonenumber = telephoneNumber;
            user.Email = email;
            user.Level = privilege;

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
            var query = string.Format("SELECT * FROM users WHERE username = '{0}'", username);

            var reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
            {
                return false;
            }

            reader.Read();

            var user = new UserModel();
            user.ReadFromReader(reader);

            var success = AuthenticateUser(user, password);

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
            var query = string.Format("SELECT * FROM users WHERE rfidnumber = '{0}'", RFIDNumber);

            var reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
            {
                return false;
            }

            reader.Read();

            var user = new UserModel();
            user.ReadFromReader(reader);

            Settings.ActiveUser = user;
            GetUserRegistrations(user);

            return true;
        }

        /// <summary>
        /// Finds a user on his username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static UserModel FindUser(string username)
        {
            var query = string.Format("SELECT * FROM USERS WHERE username = '{0}'", username);

            var reader = DBManager.QueryDB(query);
            if (reader == null || !reader.HasRows)
            {
                return null;
            }
            var user = new UserModel();

            reader.Read();

            user.ReadFromReader(reader);

            return user;
        }

        /// <summary>
        /// Finds a list of users that match the username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static List<UserModel> FindUsers(string username)
        {
            var users = new List<UserModel>();
            var query = string.Format("SELECT * FROM USERS WHERE USERNAME LIKE '%{0}%'", username);

            var reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
            {
                return null;
            }

            while (reader.Read())
            {
                var user = new UserModel { Id = int.Parse(reader["ident"].ToString()) };

                user.Read();

                users.Add(user);
            }

            return users;
        }

        /// <summary>
        /// Gets a list of all users in the database
        /// </summary>
        /// <returns></returns>
        public static List<UserModel> GetAllUsers()
        {
            var users = new List<UserModel>();
            var query = "SELECT * FROM USERS";

            var reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
            {
                return null;
            }

            while (reader.Read())
            {
                var user = new UserModel { Id = int.Parse(reader["ident"].ToString()) };

                user.Read();

                users.Add(user);
            }

            return users;
        }

        /// <summary>
        /// Finds a user based on his ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserModel FindUser(int id)
        {
            var query = string.Format("SELECT * FROM USERS WHERE ident = '{0}'", id);

            var reader = DBManager.QueryDB(query);
            if (reader == null || !reader.HasRows)
            {
                return null;
            }
            var user = new UserModel();
            reader.Read();
            user.ReadFromReader(reader);
            user.Read();
            return user;
        }

        /// <summary>
        /// Finds a user based on his RFID tag
        /// </summary>
        /// <param name="RFID"></param>
        /// <returns></returns>
        public static UserModel FindUserFromRFID(string RFID)
        {
            var query = string.Format("SELECT * FROM USERS WHERE rfidnumber = '{0}'", RFID);

            var reader = DBManager.QueryDB(query);
            if (reader == null || !reader.HasRows)
            {
                return null;
            }
            var user = new UserModel();
            reader.Read();
            user.ReadFromReader(reader);
            user.Read();
            return user;
        }

        /// <summary>
        /// Gets all registrations a user has
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static List<RegistrationModel> GetUserRegistrations(UserModel user)
        {
            var regs = new List<RegistrationModel>();
            var query = string.Format("SELECT * FROM registration WHERE userid = '{0}'", user.Id);

            var reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
            {
                return null;
            }

            while (reader.Read())
            {
                var registration = new RegistrationModel();
                registration.ReadFromReader(reader);

                regs.Add(registration);
            }

            return regs;
        }

        /// <summary>
        /// Sees if a registration has bee paid for
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        public static bool SeeIfRegistrationIsPaid(RegistrationModel registration)
        {
            var query = string.Format("SELECT * FROM payment WHERE registrationid = '{0}'", registration.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return false;
            }
            if (!reader.HasRows)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// changes a users password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool ChangeUserPassword(string password)
        {
            Settings.ActiveUser.Password = CreateHashPassword(password);
            return Settings.ActiveUser.Update();
        }

        /// <summary>
        /// Registers a user for an event
        /// </summary>
        /// <param name="user"></param>
        /// <param name="eventModel"></param>
        /// <returns></returns>
        public static RegistrationModel RegisterUserForEvent(UserModel user, EventModel eventModel)
        {
            var registration = new RegistrationModel(user, eventModel);

            if (registration.Create())
            {
                return registration;
            }

            return null;
        }

        /// <summary>
        /// Marks a registration as paid
        /// </summary>
        /// <param name="registration"></param>
        /// <param name="amount"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static PaymentModel RegistrationMarkPaid(RegistrationModel registration, decimal amount, string type)
        {
            var payment = new PaymentModel(registration);
            payment.Registration = registration;
            payment.Amount = amount;
            payment.PaymentType = type;

            if (payment.Create())
            {
                return payment;
            }
            return null;
        }

        /// <summary>
        /// Hashes a password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string CreateHashPassword(string password)
        {
            var buf = new byte[SALT_SIZE];
            rng.GetBytes(buf);
            var salt = Convert.ToBase64String(buf);

            var deriver2898 = new Rfc2898DeriveBytes(password.Trim(), buf, NUM_ITERATIONS);
            var hash = Convert.ToBase64String(deriver2898.GetBytes(16));
            return salt + ':' + hash;
        }

        /// <summary>
        /// Validates a password with it's hash
        /// </summary>
        /// <param name="password">User attempt at password</param>
        /// <param name="saltHash">The salted hashed password from the database</param>
        /// <returns></returns>
        private static bool IsPasswordValid(string password, string saltHash)
        {
            var parts = saltHash.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                return false;
            }
            var buf = Convert.FromBase64String(parts[0]);
            var deriver2898 = new Rfc2898DeriveBytes(password.Trim(), buf, NUM_ITERATIONS);
            var computedHash = Convert.ToBase64String(deriver2898.GetBytes(16));
            return parts[1].Equals(computedHash);
        }
    }
}