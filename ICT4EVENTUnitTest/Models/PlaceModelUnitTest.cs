using System;
using ICT4EVENT;
using Oracle.DataAccess.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ICT4EVENTUnitTest
{
    [TestClass]
    public class PlaceModelUnitTest
    {
        [TestMethod]
        public void PlaceModelCrudTest()
        {
            EventModelUnitTEst eventTest = new EventModelUnitTEst();
            eventTest.CreateTest();

            this.CreateTest();
            this.ReadTest();
            this.AlterTest();
            this.DestroyTest();

            eventTest.DestroyEvent();
        }

        public void CreateTest()
        {
            Init.Initialize();

            PlaceModel place_item = Init.getLocalPlace();

            Assert.IsTrue(place_item.Create(), "Could not write place to database");
        }

        public void ReadTest()
        {

            Init.Initialize();

            EventModel event_item = Init.getExternalEvent();
            PlaceModel place_item = new PlaceModel(event_item);

            string query = string.Format("SELECT ident FROM item where EventID = '{0}'", event_item.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "Reader retrieved no data");
            reader.Read();

            place_item.Id = Int32.Parse(reader["ident"].ToString());

            Assert.IsTrue(place_item.Read(), "Could not find data from database");
        }
        public void AlterTest()
        {
            Init.Initialize();

            PlaceModel place_item = Init.getExternalPlace();

            place_item.Category = "Camping";

            Assert.IsTrue(place_item.Update(), "Could not update place table");
        }
        public void DestroyTest()
        {
            Init.Initialize();

            EventModel event_item = Init.getExternalEvent();
            PlaceModel place_item = new PlaceModel(event_item);

            Assert.IsTrue(place_item.Destroy(), "Event could not be destroyed");
        }
    }
}
