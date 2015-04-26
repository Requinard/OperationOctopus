using System;
using System.Collections.Generic;
using System.Security.Authentication;

namespace ICT4EVENT
{
    using System.Reflection.Emit;

    using Oracle.DataAccess.Client;

    public static class EventManager
    {
        /// <summary>
        /// Finds an event by it's database id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static EventModel FindEvent(int id)
        {
            EventModel eventModel = new EventModel();
            eventModel.Id = id;

            if (eventModel.Read())
                return eventModel;
            return null;
        }

        /// <summary>
        /// finds an event with a specific name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static EventModel FindEvent(string name)
        {
            string query = string.Format("SELECT * FROM event WHERE eventname = '{0}'", name);

            EventModel eventModel = new EventModel();

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
                return null;

            reader.Read();
            eventModel.Id = Int32.Parse(reader["ident"].ToString());

            eventModel.Read();

            return eventModel;
        }

        /// <summary>
        /// Finds all events in the database
        /// </summary>
        /// <returns></returns>
        public static List<EventModel> FindAllEvents()
        {
            string query = "SELECT * FROM event ";

            List<EventModel> eventModels = new List<EventModel>();

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
                return null;

            while (reader.Read())
            {
                EventModel eventModel = new EventModel();

                eventModel.ReadFromReader(reader);

                eventModels.Add(eventModel);
            }

            return eventModels;
        }

        /// <summary>
        /// Finds events that match a name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<EventModel> FindEvents(string name)
        {
            string query = string.Format("SELECT * FROM event WHERE eventname LIKE '%{0}%'", name);

            List<EventModel> eventModels = new List<EventModel>();

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null || !reader.HasRows)
                return null;

            while (reader.Read())
            {
                EventModel eventModel = new EventModel();

                eventModel.ReadFromReader(reader);

                eventModels.Add(eventModel); 
            }

            return eventModels;
        }

        /// <summary>
        /// Starts a new event in the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="description"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a log entry for access with RFID
        /// </summary>
        /// <param name="user"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static RFIDLogModel LogRFID(UserModel user, RFIDAccessType accessType)
        {
            RFIDLogModel rfid = new RFIDLogModel();

            rfid.User = user;
            rfid.EventItem = Settings.ActiveEvent;
            rfid.Status = accessType;
            rfid.Date = DateTime.Now;

            if (rfid.Create()) return rfid;
            return null;
        }

        public static List<RFIDLogModel> GetUserLog(UserModel user)
        {
            List<RFIDLogModel> logs = new List<RFIDLogModel>();
            string query = string.Format("SELECT * FROM rfidlog where userid = {0}", user.Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null) return null;

            while (reader.Read())
            {
                RFIDLogModel log = new RFIDLogModel(Int32.Parse(reader["ident"].ToString()));
                logs.Add(log);
            }

            return logs;
        }

        /// <summary>
        /// This will return a list of users still on the premises
        /// </summary>
        /// <returns></returns>
        public static List<UserModel> GetUsersStillOnPremises()
        {
            List<UserModel> users = new List<UserModel>();
            string query =
                string.Format("SELECT * FROM RFIDLOG r1 where r1.inorout = '0' AND r1.userid not in ( select r2.userid from RFIDLOG r2   WHERE r2.inorout = '1') AND eventid = '{0}'", Settings.ActiveEvent);

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null) return users;

            while (reader.Read())
            {
                users.Add(new UserModel(Int32.Parse(reader["r1.userid"].ToString())));
            }

            return users;
        }
    }
}