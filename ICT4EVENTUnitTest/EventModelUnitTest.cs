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

            EventModel event_item = Init.getLocalEvent(); 

            Assert.IsTrue(event_item.Create());
        }
    }
}
