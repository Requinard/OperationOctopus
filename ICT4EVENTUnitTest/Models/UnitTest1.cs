using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ICT4EVENTUnitTest.Models
{
    using ICT4EVENT;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Init.Initialize();
            EventManager.CreateNewEvent("test", "test", "test", DateTime.Now, DateTime.Now);

            EventModel evetn = EventManager.FindEvent("test");
            UserModel user = UserManager.FindUser("admin");

            RFIDLogModel log = new RFIDLogModel(user, evetn);

            log.Status = RFIDAccessType.EnterTerrain;
            log.Date = DateTime.Now;
            log.Create();
        }
    }
}
