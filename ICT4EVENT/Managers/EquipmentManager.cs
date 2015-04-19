using System.Collections.Generic;

namespace ICT4EVENT
{
    using System;

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

        public static List<ReservationModel> GetUserReservations(UserModel user)
        {
            List<ReservationModel> reservations = new List<ReservationModel>();
            string query = String.Format("SELECT * FROM RESERVATION WHERE USERID = '{0}'", user.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null) return null;

            while (reader.Read())
            {
                ReservationModel reservation = new ReservationModel(Int32.Parse(reader["ident"].ToString()));

                reservations.Add(reservation);
            }

            return reservations;
        }

        public static ReservationModel MakeObjectReservervation(UserModel user, RentableObjectModel rent)
        {
            ReservationModel res = new ReservationModel(rent, user);

            res.ReturnDate = Settings.ActiveEvent.EndDate;

            res.Amount = 1;

            if (res.Create())
                return res;
            return null;
        }

        public static bool DeleteObjectReservation(UserModel user, RentableObjectModel rent)
        {
            ReservationModel res = new ReservationModel(rent, user);
            if (res.Destroy())
            {
                return true;
            }
            return false;
        }
    }
}