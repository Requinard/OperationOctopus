using System;
using System.ComponentModel.Design;
using ICT4EVENT;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            post.Id = 112;
            post.Read();

            like.User = Init.getExternalTestUser();
            like.Post = post;
            
            Assert.IsTrue(like.Create(), "Kan like niet naar database schrijven.");
        }

        [TestMethod]
        public void ReadLike()
        {
            Init.Initialize();
            LikeModel like = new LikeModel();
            like.Id = 1;

            Assert.IsTrue(like.Read(), "CANT READ LIKE");
        }

    }
}
