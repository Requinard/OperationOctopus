using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ICT4EVENTUnitTest.Managers
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    using ICT4EVENT;

    [TestClass]
    public class PostManagerUnitTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Init.Initialize();
            UserManager.CreateUser(
                "PostManagerTest",
                "test",
                "test",
                "adadres",
                "wdaadw",
                "dwwaddaw",
                "dwadawdaw");
            EventManager.CreateNewEvent("PostTestingEvent", "test", "test", DateTime.Now, DateTime.Now);

            Settings.ActiveUser = UserManager.FindUser("PostManagerTest");
            Settings.ActiveEvent = EventManager.FindEvent("PostTestingEvent");
        }

        [ClassCleanup]
        public static void ClassDestruct()
        {
            Settings.ActiveEvent.Destroy();
            Settings.ActiveUser.Destroy();

        }

        [TestMethod]
        [Priority(0)]
        public void CreateNewPost()
        {
            PostModel post = PostManager.CreateNewPost("I <3 bees");

            Assert.IsNotNull(post);
        }

        [TestMethod]
        [Priority(1)]
        public void FindPost()
        {
            List<PostModel> posts = PostManager.FindPost("<3");

            Assert.IsNotNull(posts);

            Assert.IsTrue(posts.Count > 0);
        }

        [TestMethod]
        [Priority(2)]
        public void LikePost()
        {
            LikeModel like = PostManager.CreateNewLike(PostManager.FindPost("<3").First());

            Assert.IsNotNull(like);
        }

        [TestMethod]
        [Priority(2)]
        public void ReportPost()
        {
            PostReportModel report = PostManager.ReportPost(PostManager.FindPost("<3").First(), "This post sux");

            Assert.IsNotNull(report);
        }

        [TestMethod]
        [Priority(3)]
        public void GetAllReports()
        {
            List<PostReportModel> reports = PostManager.GetAllReports();

            Assert.IsNotNull(reports);
        }

        [TestMethod]
        [Priority(3)]
        public void GetReportOnPost()
        {
            List<PostReportModel> reports = PostManager.GetPostReports(PostManager.FindPost("<3").First());

            Assert.IsNotNull(reports);
        }

        [TestMethod]
        [Priority(2)]
        public void GetPostByPage()
        {
            List<PostModel> posts = PostManager.GetPostsByPage();

            Assert.IsNotNull(posts);
        }
    }
}
