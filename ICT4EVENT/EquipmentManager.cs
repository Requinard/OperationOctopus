using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

namespace ICT4EVENT
{
    public static class EquipmentManager
    {
        public static List<PlaceModel> places;
        public static List<RentableObjectModel> rentables;

        public static void Initialize()
        {
            const string select_places = "SELECT * FROM item WHERE itemtype = 'Place'";
            const string select_rentables = "SELECT * FROM item WHERE itemtype = 'RentableObject'";

            places = new List<PlaceModel>();
            rentables = new List<RentableObjectModel>();

            // Get places
            OracleDataReader reader = DBManager.QueryDB(select_places);

            while (reader.Read())
            {
                EventModel event_item = EventManager.FindEvent(Int32.Parse(reader["eventid"].ToString()));

                PlaceModel model = new PlaceModel(event_item);

                model.Description = reader["description"].ToString();
                model.Price = Decimal.Parse(reader["price"].ToString());
                model.Amount = Int32.Parse(reader["amount"].ToString());
                model.Category = reader["PlaceCategory"].ToString();
                model.Capacity = Int32.Parse(reader["PlaceCapacity"].ToString());
                model.Location = reader["PlaceLocation"].ToString();
                model.Id = Int32.Parse(reader["ident"].ToString());

                places.Add(model);
            }

            // Get rentables
            reader = DBManager.QueryDB(select_rentables);

            while (reader.Read())
            {
                EventModel event_item = EventManager.FindEvent(Int32.Parse(reader["eventid"].ToString()));

                RentableObjectModel model = new RentableObjectModel(event_item);

                model.Id = Int32.Parse(reader["ident"].ToString());
                model.Description = reader["description"].ToString();
                model.Price = Decimal.Parse(reader["price"].ToString());
                model.Amount = Int32.Parse(reader["amount"].ToString());

                rentables.Add(model);
            }
        }
    }
}