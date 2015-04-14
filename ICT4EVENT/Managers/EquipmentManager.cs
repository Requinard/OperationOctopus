using System.Collections.Generic;

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
            var reader = DBManager.QueryDB(select_places);

            while (reader.Read())
            {
                var event_item = EventManager.FindEvent(int.Parse(reader["eventid"].ToString()));

                var model = new PlaceModel(event_item);

                model.Description = reader["description"].ToString();
                model.Price = decimal.Parse(reader["price"].ToString());
                model.Amount = int.Parse(reader["amount"].ToString());
                model.Category = reader["PlaceCategory"].ToString();
                model.Capacity = int.Parse(reader["PlaceCapacity"].ToString());
                model.Location = reader["PlaceLocation"].ToString();
                model.Id = int.Parse(reader["ident"].ToString());

                places.Add(model);
            }

            // Get rentables
            reader = DBManager.QueryDB(select_rentables);

            while (reader.Read())
            {
                var event_item = EventManager.FindEvent(int.Parse(reader["eventid"].ToString()));

                var model = new RentableObjectModel(event_item);

                model.Id = int.Parse(reader["ident"].ToString());
                model.Description = reader["description"].ToString();
                model.Price = decimal.Parse(reader["price"].ToString());
                model.Amount = int.Parse(reader["amount"].ToString());

                rentables.Add(model);
            }
        }
    }
}