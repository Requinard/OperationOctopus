using System;
using System.Linq;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICT4EVENT;


namespace ICT4EVENTUnitTest
{
    [TestClass]
    public class UserModelUnitTest
    {
        private UserModel test_user;
 
        

        [TestMethod]
        public void UnitCRUDTest()
        {
            this.CreateTest();
            this.ReadTest();
            this.AlterTest();
            this.DestroyTest();
        }

        public void CreateTest()
        {
            Init.Initialize();
            UserModel user = Init.getLocalTestUser();
            // set up
            

            Assert.IsTrue(user.Create(), "Cannot write user to database");

            test_user = user;
        }

        public void ReadTest()
        {
            Init.Initialize();
            // set up
            UserModel user = Init.getExternalTestUser();


            Assert.AreEqual(user.Email, Init.getLocalTestUser().Email, "Reading returned an unexpected result");

        }

        public void AlterTest()
        {
            Init.Initialize();
            UserModel user = Init.getExternalTestUser();
            UserModel exampleUser = Init.getLocalTestUser();

            user.Email = "test@testing.com";

            Assert.IsTrue(user.Update(), "Failure during updating");

            user.Read();

            Assert.AreNotEqual(user.Email, exampleUser.Email);
        }

        public void DestroyTest()
        {
            Init.Initialize();
            UserModel user = Init.getExternalTestUser();

            Assert.IsTrue(user.Destroy(), "Could not destroy user");
        }
    }
}
