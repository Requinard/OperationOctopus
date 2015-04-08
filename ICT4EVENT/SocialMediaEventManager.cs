﻿using System;
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

            // Construct reservations
            foreach (UserModel model in users)
            {
                string select = String.Format(select_registration, model.Id);

                reader = DBManager.QueryDB(select);

                while (reader.Read())
                {
                    RegistrationModel registration = new RegistrationModel();

                    registration.Id = Int32.Parse(reader["ident"].ToString());

                    // TODO: further initialize registration
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
}