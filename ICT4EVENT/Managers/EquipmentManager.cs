using System.Collections.Generic;

namespace ICT4EVENT
{
    using System;
    using System.Configuration;

    using Oracle.DataAccess.Client;

    public static class EquipmentManager
    {
        /// <summary>
        /// Gets all available place models
        /// </summary>
        /// <returns></returns>
        public static List<PlaceModel> GetAllPlaces()
        {
            List<PlaceModel> places = new List<PlaceModel>();

            string query = string.Format(
                "SELECT * FROM Item WHERE itemtype = 'Place' AND eventid = '{0}'",
                Settings.ActiveEvent.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
            {
                return null;
            }

            while (reader.Read())
            {
                PlaceModel place = new PlaceModel();

                place.ReadFromReader(reader);

                places.Add(place);
            }

            return places;
        }

        /// <summary>
        /// Gets all objects that can be rented
        /// </summary>
        /// <returns></returns>
        public static List<RentableObjectModel> GetAllRentables()
        {
            List<RentableObjectModel> rentables = new List<RentableObjectModel>();

            string query = string.Format(
                "SELECT * FROM Item WHERE itemtype = 'RentableObject' AND eventid = '{0}'",
                Settings.ActiveEvent.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
            {
                return null;
            }

            while (reader.Read())
            {
                RentableObjectModel rent = new RentableObjectModel();

                rent.ReadFromReader(reader);

                rentables.Add(rent);
            }

            return rentables;
        }

        /// <summary>
        /// Creates a new rentable item
        /// </summary>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static RentableObjectModel CreateNewRentable(string description, decimal price, int amount, string name)
        {
            RentableObjectModel rent = new RentableObjectModel(Settings.ActiveEvent);

            rent.ObjectType = name;
            rent.Description = description;
            rent.Amount = amount;
            rent.Price = price;

            if (rent.Create())
            {
                return rent;
            }
            return null;
        }

        /// <summary>
        /// Creates a new place item
        /// </summary>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <param name="location"></param>
        /// <param name="category"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public static PlaceModel CreateNewPlace(
            string description,
            decimal price,
            int amount,
            string location,
            string category,
            int capacity)
        {
            PlaceModel place = new PlaceModel(Settings.ActiveEvent);

            place.ObjectType = "Place";
            place.Description = description;
            place.Price = price;
            place.Amount = amount;
            place.Location = location;
            place.Category = category;
            place.Capacity = capacity;

            if (place.Create())
            {
                return place;
            }
            return null;
        }

        /// <summary>
        /// Gets all user reservations that were made (and thus outstanding reservations)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static List<RentableReservationModel> GetUserReservations(UserModel user)
        {
            List<RentableReservationModel> reservations = new List<RentableReservationModel>();
            string query = String.Format("SELECT * FROM RESERVATION WHERE USERID = '{0}'", user.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return null;
            }

            while (reader.Read())
            {
                RentableReservationModel rentableReservation = new RentableReservationModel();

                rentableReservation.ReadFromReader(reader);

                reservations.Add(rentableReservation);
            }

            return reservations;
        }

        public static List<PlaceReservationModel> GetUserPlaceReservations(UserModel user)
        {
            List<PlaceReservationModel> reservations = new List<PlaceReservationModel>();
            string query = String.Format("SELECT * FROM RESERVATION R, ITEM I WHERE R.ITEMID = I.IDENT AND I.ITEMTYPE = 'Place' AND USERID = '{0}'", user.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return null;
            }

            while (reader.Read())
            {
                PlaceReservationModel placeReservation = new PlaceReservationModel();

                placeReservation.ReadFromReader(reader);

                reservations.Add(placeReservation);
            }

            return reservations;
        }

        /// <summary>
        /// Reserves a rentable object for a user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="rent"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static RentableReservationModel MakeObjectReservervation(
            UserModel user,
            RentableObjectModel rent,
            int amount)
        {
            RentableReservationModel res = new RentableReservationModel(rent, user, amount);

            res.ReturnDate = Settings.ActiveEvent.EndDate;

            if (res.Create())
            {
                return res;
            }
            return null;
        }

        /// <summary>
        /// Reserves a place for a user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="place"></param>
        /// <returns></returns>
        public static PlaceReservationModel MakePlaceReservationModel(UserModel user, PlaceModel place)
        {
            PlaceReservationModel model = new PlaceReservationModel();

            model.Place = place;
            model.ReturnDate = Settings.ActiveEvent.EndDate;

            model.User = user;

            model.Amount = 1;

            if (model.Create())
            {
                return model;
            }

            return null;
        }

        public static bool CheckIfPlaceIsAvailable(PlaceModel place)
        {
            string query = String.Format("SELECT * FROM RESERVATION R, ITEM I WHERE R.ITEMID = I.IDENT AND I.ITEMTYPE = 'Place' AND I.PLACELOCATION= '{0}'", place.Location);
            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return false;
            }
            if (!reader.HasRows)
            {
                return false;
            }

            return true;
        }
    }
}