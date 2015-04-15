using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICT4EVENT;

namespace ICT4EVENTUnitTest.Managers
{
    [TestClass]
    public class EquimentManagerUnitTest
    {
        [TestInitialize]
        public void Initialize()
        {
            Init.Initialize();
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
            RentableObjectModel rent = EquipmentManager.CreateNewRentable("A hammer", Decimal.MinusOne, 1);

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
    }
}
