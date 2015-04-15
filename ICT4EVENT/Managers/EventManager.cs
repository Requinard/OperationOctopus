using System;
using System.Collections.Generic;
using System.Security.Authentication;

namespace ICT4EVENT
{
    using Oracle.DataAccess.Client;

    public static class EventManager
    {
        public static EventModel FindEvent(int id)
        {
            EventModel eventModel = new EventModel();
            eventModel.Id = id;

            if (eventModel.Read())
                return eventModel;
            return null;
        }

        public static EventModel FindEvent(string name)
        {
            string query = string.Format("SELECT * FROM event WHERE eventname = '{0}'", name);

            EventModel eventModel = new EventModel();

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null)
                return null;

            reader.Read();
            eventModel.Id = Int32.Parse(reader["ident"].ToString());

            eventModel.Read();

            return eventModel;
        }

        public static List<EventModel> FindAllEvents()
        {
            string query = "SELECT * FROM event ";

            List<EventModel> eventModels = new List<EventModel>();

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null)
                return null;

            while (reader.Read())
            {
                EventModel eventModel = new EventModel();

                eventModel.ReadFromReader(reader);

                eventModels.Add(eventModel);
            }

            return eventModels;
        }

        public static List<EventModel> FindEvents(string name)
        {
            string query = string.Format("SELECT * FROM event WHERE eventname IS LIKE '%{0}%'", name);

            List<EventModel> eventModels = new List<EventModel>();

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null)
                return null;

            while (reader.Read())
            {
                EventModel eventModel = new EventModel();

                eventModel.ReadFromReader(reader);

                eventModels.Add(eventModel); 
            }

            return eventModels;
        }

        public static EventModel CreateNewEvent(string name, string location, string description, DateTime startDate,
            DateTime endDate)
        {            EventModel eventModel = new EventModel();


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