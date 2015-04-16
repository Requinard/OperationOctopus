namespace ICT4EVENTUnitTest
{
    using ICT4EVENT;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Oracle.DataAccess.Client;

    [TestClass]
    public class EventModelUnitTEst
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Init.Initialize();
        }

        [TestMethod]
        [Priority(0)]
        public void CreateTest()
        {
            Init.Initialize();

            EventModel event_item = Init.getLocalEvent();

            Assert.IsTrue(event_item.Create());
        }

        [TestMethod]
        [Priority(1)]
        public void ReadEvent()
        {
            EventModel event_item = new EventModel();

            string query = "SELECT * FROM event where eventname = 'ICT Testing'";

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "Reader retrieved no data");

            reader.Read();

            event_item.ReadFromReader(reader);

            Assert.IsTrue(event_item.Read(), "Could not find data from database");
        }

        [TestMethod]
        [Priority(2)]
        public void AlterEvent()
        {
            EventModel eventModel = Init.getExternalEvent();

            eventModel.Location = "Amsterdam";

            Assert.IsTrue(eventModel.Update(), "Could not update event table");
        }

        [TestMethod]
        [Priority(3)]
        public void DestroyEvent()
        {
            Init.Initialize();

            EventModel eventModel = new EventModel();

            Assert.IsTrue(eventModel.Destroy(), "Event could not be destroyed");
        }
    }
}