using ICT4EVENT;

namespace ICT4EVENTUnitTest
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Oracle.DataAccess.Client;

    public static class Init
    {
        public static void Initialize()
        {
            DBConfig config = new DBConfig();

            config.user = "PTS08";
            config.database = "xe";
            config.pw = "PTS08";
            config.host = "proftaak.me";
            config.port = "1521";

            Settings.DbConfig = config;

            DBManager.Initalize();
        }

        public static UserModel getExternalTestUser()
        {
            UserModel user = new UserModel();

            string query = "SELECT * FROM USERS where username = 'testcaseuser'";

            OracleDataReader reader = DBManager.QueryDB(query);

            reader.Read();

            user.Id = Int32.Parse(reader["ident"].ToString());

            user.Read();

            return user;
        }

        public static UserModel getLocalTestUser()
        {
            UserModel user = new UserModel();

            user.Address = "Testing Street 1";
            user.Email = "Testing@test.com";
            user.Level = 2;
            user.Password = "test";
            user.RfiDnumber = "00d0wad0aw";
            user.Telephonenumber = "0638212327";
            user.Username = "testcaseuser";

            return user;
        }

        public static EventModel getLocalEvent()
        {
            EventModel event_item = new EventModel();

            event_item.Location = "Eindhoven";
            event_item.Description = "We are testing our things";
            event_item.Name = "ICT Testing";
            event_item.StartDate = DateTime.Now;
            event_item.EndDate = DateTime.Now;

            return event_item;
        }

        public static EventModel getExternalEvent()
        {
            EventModel event_item = new EventModel();

            string query = "SELECT * FROM event where eventname = 'ICT Testing'";

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "Could not read from database");

            reader.Read();

            event_item.Id = Int32.Parse(reader["ident"].ToString());

            event_item.Read();

            return event_item; 
        }
    }
}