using System;
using ICT4EVENT;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ICT4EVENTUnitTest
{
    [TestClass]
    public class EventModelUnitTEst
    {
        [TestMethod]
        public void CreateTest()
        {
            Init.Initialize();

            EventModel event_item = new EventModel();

            event_item.Location = "Eindhoven";
            event_item.Description = "We're testing our things";
            event_item.Name = "ICT Testing";
            event_item.StartDate = DateTime.Now;
            event_item.EndDate = DateTime.Now;

            Assert.IsTrue(event_item.Create());
        }
    }
}
