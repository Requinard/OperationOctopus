using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICT4EVENT;
using ApplicationLogger;
//https://msdn.microsoft.com/en-us/library/ms182532.aspx

namespace ICT4EVENTUnitTest 
{
    [TestClass]
    public class UserManagerTest 
    {
        public UserManagerTest()
        {
            DBConfig config = new DBConfig();

            config.database = "xe";
            config.host = "proftaak.me";
            config.user = "PTS08";
            config.pw = "PTS08";
            config.port = "1521";

            Settings.DbConfig = config;
            
            DBManager.Initalize();
        }

        [TestMethod]
        public void CreateNewUserFromUser()
        {
            UserModel user = new UserModel();

            user.Level = 1;
            user.Username = "TestUser";
            user.Password = "test";

            user.RfiDnumber = "9e02130312";
            user.Telephonenumber = "561551";

            Assert.IsTrue(user.Create(), "UserModel could not create user");
        }

        [TestMethod]
        public void CreateNewUserFromManager()
        {
            string username = "test2";
            string pass = "test";
            string address = "dwadwa";
            int level = 1;
            string rfid = "adwdw";
            string telephone = "dawdaw";
            string email = "email";

            Assert.IsInstanceOfType(UserManager.CreateUser(username, pass, "test", address, telephone, email, rfid), typeof(UserModel), "Usermanager could not create user");
        }
        public void ReadUserFromDatabase()
        {
            UserModel user = new UserModel();
            user.Id = 1;

            Assert.IsTrue(user.Read(), "User could not be read from the database");
        }
    }
}
