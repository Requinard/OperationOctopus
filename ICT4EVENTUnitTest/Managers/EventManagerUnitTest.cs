using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ICT4EVENTUnitTest.Managers
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Security.Cryptography.X509Certificates;

    using ICT4EVENT;

    [TestClass]
    public class EventManagerUnitTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Init.Initialize();

        }
        [ClassCleanup]
        public static void ClassDestruct()
        {
            EventManager.FindEvent("Unit Testing Event").Destroy();
        }

        [TestMethod]
        [Priority(0)]
        public void CreateEvent()
        {
            EventModel eventModel = EventManager.CreateNewEvent(
                "Unit Testing Event",
                "Eindhoven",
                "een beschrijving",
                DateTime.Now,
                DateTime.Now);

            Assert.IsNotNull(eventModel);
        }
        [TestMethod]
        [Priority(1)]
        public void FindEventByName()
        {
            EventModel model = EventManager.FindEvent("Unit Testing Event");

            Assert.IsNotNull(model);
        }

        [TestMethod]
        [Priority(1)]
        public void FailFindEventByName()
        {
            Assert.IsNull(EventManager.FindEvent("DAWDWADAWNesgvd hvabneb u"));
        }

        [TestMethod]
        [Priority(2)]
        public void FindEventByID()
        {
            EventModel protomodel = EventManager.FindEvent("Unit Testing Event");

            EventModel eventModel = EventManager.FindEvent(protomodel.Id);

            Assert.IsNotNull(eventModel);
        }

        [TestMethod]
        [Priority(2)]
        public void FailFindEventsByID()
        {
           Assert.IsNull(EventManager.FindEvent(312903127));
        }
        [TestMethod]
        [Priority(1)]
        public void FindAllEvents()
        {
            List<EventModel> events = EventManager.FindAllEvents();

            Assert.IsTrue(events.Count > 0);
        }
[TestMethod]
        [Priority(1)]
        public void FindEvents()
        {
            List<EventModel> events = EventManager.FindEvents("e");
            Assert.IsNotNull(events);
            Assert.IsTrue(events.Count > 0);
        }
    }
}
