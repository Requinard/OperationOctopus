using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICT4EVENT;

namespace ICT4EVENTUnitTest 
{
    [TestClass]
    public class UserManagerTest 
    {
        [TestMethod]
        public void CreateNewUserFromUser()
        {
            UserModel user = new UserModel();

            user.Level = 1;
            user.Username = "TestUser";
            user.Password = "test";

            user.RfiDnumber = "9e02130312";
            user.Telephonenumber = "561551";

            Assert.IsTrue(user.Create());
        }

        public void ReadUserFromDatabase
    }
}
