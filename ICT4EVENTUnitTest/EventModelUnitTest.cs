using System;
using ICT4EVENT;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ICT4EVENTUnitTest
{
    using System.Threading;

    using Oracle.DataAccess.Client;

    [TestClass]
    public class EventModelUnitTEst
    {
        [TestMethod]
        public void EventTest()
        {
            this.CreateTest();
            this.ReadEvent();
            this.AlterEvent();
            this.DestroyEvent();
        }

        public void CreateTest()
        {
            Init.Initialize();

            EventModel event_item = Init.getLocalEvent(); 

            Assert.IsTrue(event_item.Create());
        }

        public void ReadEvent()
        {
            Init.Initialize();

            EventModel event_item = new EventModel();

            string query = "SELECT ident FROM event where eventname = 'ICT Testing'";

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "Reader retrieved no data");
            reader.Read();

            event_item.Id = Int32.Parse(reader["ident"].ToString());

            Assert.IsTrue(event_item.Read(), "Could not find data from database");
        }

        public void AlterEvent()
        {
            Init.Initialize();

            EventModel eventModel = Init.getExternalEvent();

            eventModel.Location = "Amsterdam";

            Assert.IsTrue(eventModel.Update(), "Could not update event table");
        }

        public void DestroyEvent()
        {
            Init.Initialize();
     
            EventModel eventModel = new EventModel();

            Assert.IsTrue(eventModel.Destroy(), "Event could not be destroyed");
                
        }
    }
}
