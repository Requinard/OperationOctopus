﻿using ICT4EVENT;

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

        public static PlaceModel getLocalPlace()
        {
            EventModel event_item = Init.getExternalEvent();
            PlaceModel place_item = new PlaceModel(event_item);

            place_item.Amount = 3;
            place_item.Capacity = 6 ;
            place_item.Category = "Bungalow";
            place_item.Description = "The most fun you'll never have";
            place_item.Location = "Somewhere over the rainbow";
            place_item.Price = 5.70m;

            return place_item;
        }

        public static PlaceModel getExternalPlace()
        {
            EventModel event_item = Init.getExternalEvent();
            PlaceModel place_item = new PlaceModel(event_item);

            string query = "SELECT * FROM item where PlaceLocation  = 'Somewhere over the rainbow'";

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "Could not read from database");

            reader.Read();

            place_item.Id = Int32.Parse(reader["ident"].ToString());

            place_item.Read();

            return place_item;
        }

        public static PostModel GetLocalPost()
        {
            UserModel user = Init.getExternalTestUser();
            EventModel event_item = Init.getExternalEvent();

            PostModel post = new PostModel(user, event_item);

            post.Content = "Testing post";
            post.DatePosted = DateTime.Now;
            post.PathToFile = "";
            post.Parent = null;

            return post;
        }
        
        public static PostModel GetExternalPost()
        {
            PostModel post = new PostModel();
            string query = "SELECT ident FROM post WHERE TO_CHAR(Postcontent) ='Testing post'";

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "Could not read from database");

            reader.Read();

            post.Id = Int32.Parse(reader["ident"].ToString());

            post.Read();

            return post;
        }
    }
}