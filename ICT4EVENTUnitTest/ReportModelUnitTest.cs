using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICT4EVENT;
using Oracle.DataAccess.Client;

namespace ICT4EVENTUnitTest
{
    [TestClass]
    public class ReportModelUnitTest
    {
        [TestMethod]
        public void CreateTest()
        {
            Init.Initialize();
            PostModel post = Init.GetExternalPost();
            UserModel user = Init.getExternalTestUser();

            PostReportModel report = new PostReportModel(post, user);
            report.Status = "In behandeling";
            report.Reason = "ze zei dat mn haar lelijk is :(";
            report.Date = DateTime.Now;
            
            Assert.IsTrue(report.Create(), "Report failed to create!");
        }

        [TestMethod]
        public void ReadTest()
        {
            Init.Initialize();
            PostModel post = Init.GetExternalPost();
            UserModel user = Init.getExternalTestUser();
            PostReportModel report = new PostReportModel(post, user);

            string query = string.Format("SELECT Ident FROM report WHERE PostID = '{0}' AND UserID = '{1}'", post.Id, user.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "Could not read Report.Ident from the database.");

            reader.Read();

            report.Id = Int32.Parse(reader["Ident"].ToString());

            Assert.IsTrue(report.Read(), "Couldn't read from database.");
        }

        [TestMethod]
        public void AlterTest()
        {
            Init.Initialize();
            PostModel post = Init.GetExternalPost();
            UserModel user = Init.getExternalTestUser();
            PostReportModel report = new PostReportModel(post, user);

            string query = string.Format("SELECT Ident FROM report WHERE PostID = '{0}' AND UserID = '{1}'", post.Id, user.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "Could not read Report.Ident from the database.");

            reader.Read();

            report.Id = Int32.Parse(reader["Ident"].ToString());

            report.Read();

            report.Status = "Geweigerd";

            Assert.IsTrue(report.Update(), "Couldn't update the database.");
        }

        [TestMethod]
        public void DestroyTest()
        {
            Init.Initialize();
            PostModel post = Init.GetExternalPost();
            UserModel user = Init.getExternalTestUser();
            PostReportModel report = new PostReportModel(post, user);

            string query = string.Format("SELECT Ident FROM report WHERE PostID = '{0}' AND UserID = '{1}'", post.Id, user.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "Could not read Report.Ident from the database.");

            reader.Read();

            report.Id = Int32.Parse(reader["Ident"].ToString());

            report.Read();

            Assert.IsTrue(report.Destroy(), "Couldn't destroy the report.");
        }
    }
}
