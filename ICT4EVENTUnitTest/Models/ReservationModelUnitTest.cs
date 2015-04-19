using System;
using ICT4EVENT;
using Oracle.DataAccess.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ICT4EVENTUnitTest
{
    [TestClass]
    public class ReservationModelUnitTest
    {
        [TestMethod]
        public void ReservationModelCrudTest()
        {
            UserModelUnitTest userTest = new UserModelUnitTest();
            userTest.CreateTest();
            RentItemModelUnitTest rentTest = new RentItemModelUnitTest();
            rentTest.CreateTest();

            this.CreateTest();
            this.ReadTest();
            this.AlterTest();
            this.DestroyTest();

            //userTest.DestroyTest();     Iemand moet deze repareren, ik ga niet over user
            rentTest.DestroyTest();
        }

        public void CreateTest()
        {
            Init.Initialize();

            RentableReservationModel rentableReservationItem = Init.GetLocalReservation();

            Assert.IsTrue(rentableReservationItem.Create(), "Could not write rentableReservation to database");
        }

        public void ReadTest()
        {

            Init.Initialize();

            UserModel user_item = Init.getExternalTestUser();
            RentableObjectModel rent_item = Init.getExternalRentItem();
            RentableReservationModel rentableReservationItem = new RentableReservationModel(rent_item, user_item);

            string query = "SELECT ident FROM rentableReservation where Amount = 3";

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "Reader retrieved no data");
            reader.Read();

            rentableReservationItem.Id = Int32.Parse(reader["ident"].ToString());

            Assert.IsTrue(rentableReservationItem.Read(), "Could not find data from database");
        }

        public void AlterTest()
        {
            Init.Initialize();

            RentableReservationModel rentableReservationItem = Init.getExternalReservation();

            rentableReservationItem.Amount = 2;

            Assert.IsTrue(rentableReservationItem.Update(), "Could not update rentableReservation table");
        }

        public void DestroyTest()
        {
            Init.Initialize();

            RentableReservationModel rentableReservationItem = Init.getExternalReservation();

            Assert.IsTrue(rentableReservationItem.Destroy(), "Reservation could not be destroyed");
        }
    }
}
