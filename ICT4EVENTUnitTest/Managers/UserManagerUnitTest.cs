using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ICT4EVENTUnitTest.Managers
{
    using System.Collections.Generic;
    using System.Linq;

    using ICT4EVENT;

    [TestClass]
    public class UserManagerUnitTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Init.Initialize();
            EventModel eventModel = EventManager.CreateNewEvent(
                "User Testing Event",
                "test",
                "test",
                DateTime.Now,
                DateTime.Now);

            eventModel.Create();

            Settings.ActiveEvent = EventManager.FindEvent("User Testing Event");

        }

        [ClassCleanup]
        public static void ClassDestruct()
        {
            UserManager.FindUser("UnitTestUser").Destroy();
            EventManager.FindEvent("User Testing Event").Destroy();
        }


        [TestMethod]
        [Priority(0)]
        public void TestUserCreation()
        {
            UserModel user = UserManager.CreateUser(
                "UnitTestUser",
                "testingPassword",
                "John Doe",
                "Generaal Bentinckstraat 48",
                "0031613132909",
                "test@test.com",
                "0000doesnot");

            Assert.IsNotNull(user, "Manager did not create user");
        }

        [TestMethod]
        [Priority(1)]
        public void RetrieveUserByName()
        {
            UserModel testuser = UserManager.FindUser("UnitTestUser");

            Assert.IsNotNull(testuser, "Could not find user in database");
        }

        [TestMethod]
        [Priority(2)]
        public void RetrieveUserByID()
        {
            UserModel testuser = UserManager.FindUser("UnitTestUser");

            UserModel user = UserManager.FindUser(testuser.Id);


            Assert.IsNotNull(user, "Could not find user by ID");
        }

        [TestMethod]
        [Priority(1)]
        public void FindUsersByName()
        {
            List<UserModel> users = UserManager.FindUsers("est");

            Assert.IsTrue(users.Count > 1, "Could not find users");
        }

        [TestMethod]
        [Priority(2)]
        public void AuthenticateUserByUserModel()
        {
            UserModel testuser = UserManager.FindUser("UnitTestUser");
            Assert.IsTrue(UserManager.AuthenticateUser(testuser, "testingPassword"), "Could not authenticate user");
        }
        [TestMethod]
        [Priority(2)]
        public void AuthenticateUserByRFID()
        {
            UserModel testuser = UserManager.FindUser("UnitTestUser");
            Assert.IsTrue(UserManager.AuthenticateUser(testuser.RfiDnumber), "Could not authenticate user");
        }
        [TestMethod]
        [Priority(1)]
        public void AuthenticateUserByUsername()
        {
            Assert.IsTrue(UserManager.AuthenticateUser("UnitTestUser", "testingPassword"), "Could not validate password");
        }
        [TestMethod]
        [Priority(1)]
        public void RegisterUserForEvent()
        {
            Settings.ActiveUser = UserManager.FindUser("UnitTestUser");

            RegistrationModel reg = UserManager.RegisterUserForEvent(Settings.ActiveUser, Settings.ActiveEvent);

            Assert.IsNotNull(reg);
        }

        [TestMethod]
        [Priority(2)]
        public void GetUserRegistration()
        {
            Settings.ActiveUser = UserManager.FindUser("UnitTestUser");

            List<RegistrationModel> regs = UserManager.GetUserRegistrations(Settings.ActiveUser);

            Assert.IsNotNull(regs);

            Assert.IsTrue(regs.Count > 0);
        }

        [TestMethod]
        [Priority(2)]
        public void MarkRegistrationAsPaid()
        {
            Settings.ActiveUser = UserManager.FindUser("UnitTestUser");

            List<RegistrationModel> regs = UserManager.GetUserRegistrations(Settings.ActiveUser);

            PaymentModel pay = UserManager.RegistrationMarkPaid(regs.First(), Decimal.One, "Credit card");

            Assert.IsNotNull(pay);
        }
    }
}
