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

            ReservationModel reservation_item = Init.GetLocalReservation();

            Assert.IsTrue(reservation_item.Create(), "Could not write reservation to database");
        }

        public void ReadTest()
        {

            Init.Initialize();

            UserModel user_item = Init.getExternalTestUser();
            RentableObjectModel rent_item = Init.getExternalRentItem();
            ReservationModel reservation_item = new ReservationModel(rent_item, user_item);

            string query = "SELECT ident FROM reservation where Amount = 3";

            OracleDataReader reader = DBManager.QueryDB(query);

            Assert.IsNotNull(reader, "Reader retrieved no data");
            reader.Read();

            reservation_item.Id = Int32.Parse(reader["ident"].ToString());

            Assert.IsTrue(reservation_item.Read(), "Could not find data from database");
        }

        public void AlterTest()
        {
            Init.Initialize();

            ReservationModel reservation_item = Init.getExternalReservation();

            reservation_item.Amount = 2;

            Assert.IsTrue(reservation_item.Update(), "Could not update reservation table");
        }

        public void DestroyTest()
        {
            Init.Initialize();

            ReservationModel reservation_item = Init.getExternalReservation();

            Assert.IsTrue(reservation_item.Destroy(), "Reservation could not be destroyed");
        }
    }
}
