using System;
using System.ComponentModel.Design;
using ICT4EVENT;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oracle.DataAccess.Client;

namespace ICT4EVENTUnitTest
{
    [TestClass]
    public class LikeModelUnitTest
    {
        [TestMethod]
        public void CreateLike()
        {
            Init.Initialize();
            LikeModel like = new LikeModel();
            PostModel post = new PostModel();
            post = Init.GetExternalPost();
            post.Read();

            like.User = Init.getExternalTestUser();
            like.Post = post;
            
            Assert.IsTrue(like.Create(), "Can't write to database");
        }

        [TestMethod]
        public void ReadLike()
        {
            Init.Initialize();
            UserModel user = Init.getExternalTestUser();
            PostModel post = Init.GetExternalPost();


            LikeModel like = new LikeModel();

            string query = string.Format("SELECT Ident FROM likes WHERE UserID = '{0}' AND PostID = '{1}'", user.Id, post.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "Could not read Like.Ident from the database.");

            reader.Read();

            like.Id = Int32.Parse(reader["Ident"].ToString()); 


            Assert.IsTrue(like.Read(), "Couldn't read from database.");
        }

        [TestMethod]
        public void DestroyLike()
        {
            Init.Initialize();
            UserModel user = Init.getExternalTestUser();
            PostModel post = Init.GetExternalPost();


            LikeModel like = new LikeModel();

            string query = string.Format("SELECT Ident FROM likes WHERE UserID = '{0}' AND PostID = '{1}'", user.Id, post.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "Could not read Like.Ident from the database.");

            reader.Read();

            like.Id = Int32.Parse(reader["Ident"].ToString());


            Assert.IsTrue(like.Destroy(), "Couldn't read from database.");
        }
    }
}
