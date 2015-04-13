using System;
using System.Linq;
using Oracle.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICT4EVENT;
using Oracle.DataAccess.Client;

namespace ICT4EVENTUnitTest
{
    [TestClass]
    public class UserModelUnitTest
    {
        private UserModel test_user;
 
        private UserModel getTestUser()
        {
            UserModel user = new UserModel();

            string query = "SELECT * FROM USERS where usename = 'testcaseuser'";

            OracleDataReader reader = DBManager.QueryDB(query);

            reader.Read();

            user.Id = Int32.Parse(reader["ident"].ToString());

            user.Read();

            return user;
        }

        [TestMethod]
        public void CreateTest()
        {
            Init.Initialize();
            // set up
            UserModel user = new UserModel();

            user.Address = "Testing Street 1";
            user.Email = "Testing@test.com";
            user.Level = 2;
            user.Password = "test";
            user.RfiDnumber = "00d0wad0aw";
            user.Telephonenumber = "0638212327";
            user.Username = "testcaseuser";

            Assert.IsTrue(user.Create(), "Cannot write user to database");

            test_user = user;
        }

        [TestMethod]
        public void ReadTest()
        {
            Init.Initialize();
            // set up
            UserModel user = getTestUser();

            Assert.AreEqual(user.Email, test_user.Email, "Reading returned an unexpected result");
        }

        [TestMethod]
        public void AlterTest()
        {
            Init.Initialize();
            UserModel user = getTestUser();

            user.Email = "test@testing.com";

            Assert.IsTrue(user.Update(), "Failure during updating");

            user.Read();

            Assert.AreNotEqual(user.Email, test_user.Email);
        }

        [TestMethod]
        public void DestroyTest()
        {
            Init.Initialize();
            UserModel user = getTestUser();

            Assert.IsTrue(user.Destroy(), "Could not destroy user");
        }
    }
}
