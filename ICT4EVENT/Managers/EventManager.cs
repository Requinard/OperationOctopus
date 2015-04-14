using System;
using System.Collections.Generic;
using System.Security.Authentication;

namespace ICT4EVENT
{
    public static class EventManager
    {
        public static EventModel FindEvent(int id)
        {
            var eventModel = new EventModel();
            eventModel.Id = id;

            if (eventModel.Read())
                return eventModel;
            return null;
        }

        public static EventModel FindEvent(string name)
        {
            var query = string.Format("SELECT * FROM event WHERE eventname = '{0}'", name);

            var eventModel = new EventModel();

            var reader = DBManager.QueryDB(query);

            if (reader == null)
                return null;

            reader.Read();
            eventModel.Id = int.Parse(reader["ident"].ToString());

            eventModel.Read();

            return eventModel;
        }

        public static List<EventModel> FindAllEvents()
        {
            var query = "SELECT * FROM event ";

            var eventModels = new List<EventModel>();

            var reader = DBManager.QueryDB(query);

            if (reader == null)
                return null;

            while (reader.Read())
            {
                var eventModel = new EventModel();

                eventModel.Id = int.Parse(reader["ident"].ToString());

                eventModel.Read();

                eventModels.Add(eventModel);
            }

            return eventModels;
        }

        public static List<EventModel> FindEvents(string name)
        {
            var query = string.Format("SELECT * FROM event WHERE eventname IS LIKE '%{0}%'", name);

            var eventModels = new List<EventModel>();

            var reader = DBManager.QueryDB(query);

            if (reader == null)
                return null;

            while (reader.Read())
            {
                var eventModel = new EventModel();

                eventModel.Id = int.Parse(reader["ident"].ToString());

                eventModel.Read();

                eventModels.Add(eventModel);
            }

            return eventModels;
        }

        public static EventModel CreateNewEvent(string name, string location, string description, DateTime startDate,
            DateTime endDate)
        {
            if (Settings.ActiveUser.Level != 3)
                throw new AuthenticationException();

            var eventModel = new EventModel();

            eventModel.Name = name;
            eventModel.Location = location;
            eventModel.Description = description.Replace("'", "");
            eventModel.StartDate = startDate;
            eventModel.EndDate = endDate;

            eventModel.Create();

            return eventModel;
        }
    }
}