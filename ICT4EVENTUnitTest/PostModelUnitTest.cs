using System;
using ICT4EVENT;
using Oracle.DataAccess.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ICT4EVENTUnitTest
{
    [TestClass]
    public class PostModelUnitTest 
    {
        [TestMethod]
        public void PostModelCrudTest()
        {
            UserModelUnitTest userTest = new UserModelUnitTest();
            userTest.CreateTest();

            EventModelUnitTEst eventTest = new EventModelUnitTEst();
            eventTest.CreateTest();

            this.CreateTest();
            this.ReadTest();
            this.AlterTest();
            this.DestroyTest();
        }

        public void CreateTest()
        {
            Init.Initialize();

            UserModel user = Init.getExternalTestUser();
            EventModel event_item = Init.getExternalEvent();

            PostModel post = new PostModel(user, event_item);

            post.Content = "Testing post";
            post.DatePosted = DateTime.Now;
            post.PathToFile = "";
            post.Parent = null;

            Assert.IsTrue(post.Create(), "Could not write post to database");
        }

        public void ReadTest()
        {
            Init.Initialize();

            UserModel user = Init.getExternalTestUser();
            EventModel event_item = Init.getExternalEvent();

            PostModel post = new PostModel(user, event_item);

            string query = "SELECT ident FROM post WHERE TO_CHAR(Postcontent) ='Testing post'";

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "could not read post ident from database");

            reader.Read(); 

            post.Id = Int32.Parse(reader["ident"].ToString());

            Assert.IsTrue(reader.Read(), "Could not read from database");
        }

        public void AlterTest()
        {
            Init.Initialize();

            UserModel user = Init.getExternalTestUser();
            EventModel event_item = Init.getExternalEvent();

            PostModel post = new PostModel(user, event_item);

            string query = "SELECT ident FROM post WHERE TO_CHAR(Postcontent) ='Testing post'";

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "could not read post ident from database");

            reader.Read();

            post.Id = Int32.Parse(reader["ident"].ToString());

            post.Read();

            post.DatePosted = DateTime.UtcNow;

            Assert.IsTrue(post.Update(), "Could not update post");
        }

        public void DestroyTest()
        {
            Init.Initialize();

            UserModel user = Init.getExternalTestUser();
            EventModel event_item = Init.getExternalEvent();

            PostModel post = new PostModel(user, event_item);

            string query = "SELECT ident FROM post WHERE TO_CHAR(Postcontent) ='Testing post'";

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "could not read post ident from database");

            reader.Read();

            post.Id = Int32.Parse(reader["ident"].ToString());

            post.Read();
            
            Assert.IsTrue(post.Destroy(), "could not destroy post");
        }

    }
}
