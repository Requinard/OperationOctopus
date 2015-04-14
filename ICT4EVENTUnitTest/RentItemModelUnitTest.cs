using System;
using ICT4EVENT;
using Oracle.DataAccess.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ICT4EVENTUnitTest
{
    [TestClass]
    public class RentItemModelUnitTest
    {
        [TestMethod]
        public void RentItemModelCrudTest()
        {
            EventModelUnitTEst eventTest = new EventModelUnitTEst();
            eventTest.CreateTest();

            this.CreateTest();
            this.ReadTest();
            //this.AlterTest();
            //this.DestroyTest();

            eventTest.DestroyEvent();
        }
        public void CreateTest()
        {
            Init.Initialize();

            RentableObjectModel rent_item = Init.getLocalRentItem();

            Assert.IsTrue(rent_item.Create(), "Could not write place to database");
        }

        public void ReadTest()
        {

            Init.Initialize();

            EventModel event_item = Init.getExternalEvent();
            RentableObjectModel rent_item = new RentableObjectModel(event_item);

            string query = "SELECT ident FROM item where eventname = 'ICT Testing'";

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "Reader retrieved no data");
            reader.Read();

            rent_item.Id = Int32.Parse(reader["ident"].ToString());

            Assert.IsTrue(rent_item.Read(), "Could not find data from database");
        }
    }
}
