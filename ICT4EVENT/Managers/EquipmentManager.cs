using System.Collections.Generic;

namespace ICT4EVENT
{
    using System;
    using System.Configuration;

    using Oracle.DataAccess.Client;

    public static class EquipmentManager
    {
        public static List<PlaceModel> GetAllPlaces()
        {
            List<PlaceModel> places = new List<PlaceModel>();

            string query = string.Format("SELECT * FROM Item WHERE itemtype = 'Place' AND eventid = '{0}'",
                Settings.ActiveEvent.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
                return null;

            while (reader.Read())
            {
                PlaceModel place = new PlaceModel();

                place.ReadFromReader(reader);

                places.Add(place);
            }

            return places;
        }

        public static List<RentableObjectModel> GetAllRentables()
        {
            List<RentableObjectModel> rentables = new List<RentableObjectModel>();

            string query = string.Format("SELECT * FROM Item WHERE itemtype = 'RentableObject' AND eventid = '{0}'",
                Settings.ActiveEvent.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
                return null;

            while (reader.Read())
            {
                RentableObjectModel rent = new RentableObjectModel();

                rent.ReadFromReader(reader);

                rentables.Add(rent);
            }

            return rentables;
        }

        public static RentableObjectModel CreateNewRentable(string description, decimal price, int amount, string name)
        {
            RentableObjectModel rent = new RentableObjectModel(Settings.ActiveEvent);

            rent.ObjectType = name;
            rent.Description = description;
            rent.Amount = amount;
            rent.Price = price;

            if (rent.Create())
                return rent;
            return null;
        }

        public static PlaceModel CreateNewPlace(string description, decimal price, int amount, string location,
            string category, int capacity)
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
                return place;
            return null;
        }

        public static List<RentableReservationModel> GetUserReservations(UserModel user)
        {
            List<RentableReservationModel> reservations = new List<RentableReservationModel>();
            string query = String.Format("SELECT * FROM RESERVATION WHERE USERID = '{0}'", user.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null) return null;

            while (reader.Read())
            {
                RentableReservationModel rentableReservation = new RentableReservationModel();

                rentableReservation.ReadFromReader(reader);

                reservations.Add(rentableReservation);
            }

            return reservations;
        }

        public static RentableReservationModel MakeObjectReservervation(UserModel user, RentableObjectModel rent, int amount)
        {
            RentableReservationModel res = new RentableReservationModel(rent, user, amount);

            res.ReturnDate = Settings.ActiveEvent.EndDate;


            if (res.Create())
                return res;
            return null;
        }

        public static PlaceReservationModel MakePlaceReservationModel(UserModel user, PlaceModel place)
        {
            PlaceReservationModel model = new PlaceReservationModel();

            model.Place = place;
            model.ReturnDate = Settings.ActiveEvent.EndDate;

            model.User = user;

            model.Amount = 1;

            if(model.Create()) return model;

            return null;
        }
    }
}