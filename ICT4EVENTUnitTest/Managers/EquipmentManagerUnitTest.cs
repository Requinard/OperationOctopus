using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICT4EVENT;

namespace ICT4EVENTUnitTest.Managers
{
    using System.Linq;

    [TestClass]
    public class EquimentManagerUnitTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Init.Initialize();
            EventManager.CreateNewEvent("EquipmentTest", "Knowhere", "testing equipment", DateTime.Now, DateTime.Now);
            UserManager.CreateUser("EquipmentTest", "test", "test", "test", "test", "test", "test");
            Settings.ActiveUser = UserManager.FindUser("EquipmentTest");
            Settings.ActiveEvent = EventManager.FindEvent("EquipmentTest");
        }

        [ClassCleanup]
        public static void ClassDestruct()
        {
            Settings.ActiveEvent.Destroy();
            Settings.ActiveUser.Destroy();

        }

        [TestMethod]
        [Priority(0)]
        public void CreateNewPlace()
        {
            PlaceModel place = EquipmentManager.CreateNewPlace("Testing place", Decimal.One, 1, "A sauna",
                "Testing category", 5);

            Assert.IsNotNull(place);
        }

        [TestMethod]
        [Priority(0)]
        public void CreateNewRentable()
        {
            RentableObjectModel rent = EquipmentManager.CreateNewRentable("A hammer", Decimal.MinusOne, 1, "A hammer");

            Assert.IsNotNull(rent);
        }
        [TestMethod]
        [Priority(1)]
        public void GetAllPlacesSuccess()
        {
            List<PlaceModel> places = EquipmentManager.GetAllPlaces();

            Assert.IsNotNull(places, "something went wrong during the database query");

            Assert.IsTrue(places.Count > 0, "List was empty");
        }

        [TestMethod]
        [Priority(1)]
        public void GetAllRentablesSuccess()
        {
            List<RentableObjectModel> rentables = EquipmentManager.GetAllRentables();

            Assert.IsNotNull(rentables, "something went wrong during the database query");

            Assert.IsTrue(rentables.Count > 0, "List was empty");
        }
        [TestMethod]
        [Priority(1)]
        public void ReserveRentable()
        {
            List<RentableObjectModel> rent = EquipmentManager.GetAllRentables();

            RentableReservationModel res = EquipmentManager.MakeObjectReservervation(Settings.ActiveUser, rent.First(), 1);

            Assert.IsNotNull(res, "Could not create reservation");            
        }

        [TestMethod]
        [Priority(1)]
        public static void GetReservedItems()
        {
            List<RentableReservationModel> rent = EquipmentManager.GetUserReservations(Settings.ActiveUser);

            Assert.IsNotNull(rent);

            Assert.IsTrue(rent.Count > 0);
        }
        [TestMethod]
        [Priority(1)]
        public static void GetPlaceItems()
        {
            PlaceModel place = EquipmentManager.CreateNewPlace("test", Decimal.One, 10, "blabla", "te", 10);

            Assert.IsNotNull(place);
        }
    }
}
