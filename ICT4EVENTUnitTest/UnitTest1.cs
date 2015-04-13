using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICT4EVENT;

namespace ICT4EVENTUnitTest
{
    [TestClass]
    public class UserModelUnitTest
    {
        public UserModelUnitTest()
        {
            Init.Initialize();
        }
        [TestMethod]
        public void CreateTest()
        {
            // set up
            UserModel user = new UserModel();

            user.Address = "Testing Street 1";
            user.Email = "Testing@test.com";
            user.Level = 2;
            user.Password = "test";
            user.RfiDnumber = "00d0wad0aw";
            user.Telephonenumber = "0638212327";
            user.Username = "Requinard";

            Assert.IsTrue(user.Create(), "Cannot write user to database");
        }
    }
}
