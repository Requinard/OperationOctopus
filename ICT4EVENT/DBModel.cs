using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ICT4EVENT
{
    public abstract class DBModel
    {
        // Creates a new row. {0} is table name, {1} is columns and {2} is values
        private const string INSERTSTRING = "INSERT INTO {0} {1} VALUES {2}";
        // Updates a row in the database. {0} is table name, {1} is columns and values and {2} is the row id
        private const string UPDATESTRING = "UPDATE {0} SET {1} WHERE id={2}";
        // Reads the corresponding row from the database. {0} is table name, {1} is the row id
        private const string READSTRING = "SELECT * FROM {0} WHERE id={1}";
        // Destroys the corresponding row in the table. {0} is the table name, {1} is the table id
        private const string DESTROYSTRING = "DELETE FROM {0} WHERE id={1}";
        private int ID;

        public int Id
        {
            get { return ID; }
            set { ID = value; }
        }
    }

    public class EventModel : DBModel, IDataModelUpdate
    {
        private string name;
        private string location;
        private string description;
        private DateTime startDate;
        private DateTime endDate;

        public List<RegistrationModel> RegistrationsList
        {
            get { return registrationsList; }
        }

        private List<RegistrationModel> registrationsList ;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public EventModel()
        {
            registrationsList = new List<RegistrationModel>();
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    public class UserModel : DBModel, IDataModelUpdate
    {
        private string username;
        private string password;
        private List<RegistrationModel> registrations; 

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            // Automatically hashes a new string when it's set
            set { password = (Settings.salt + value).GetHashCode().ToString(); }
        }

        public List<RegistrationModel> RegistrationList = new List<RegistrationModel>();

        public UserModel()
        {
            registrations = new List<RegistrationModel>();
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    public class RegistrationModel : DBModel, IDataModelUpdate
    {
        private UserModel user;
        private EventModel event_item;

        public UserModel User
        {
            get { return user; }
        }

        public EventModel EventItem
        {
            get { return event_item; }
        }

        public RegistrationModel(UserModel user, EventModel event_item)
        {
            this.user = user;
            this.event_item = event_item;
        }


        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    public class RFIDLogModel : DBModel, IDataModelUpdate
    {
        public RFIDLogModel()
        {
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    public class RentableObjectModel : DBModel, IDataModelUpdate
    {
        public RentableObjectModel()
        {
            
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    public class PostModel : DBModel, IDataModelUpdate
    {
        public PostModel()
        {
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    public class PlaceModel : DBModel, IDataModelUpdate
    {
        public PlaceModel()
        {
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    public class LikeModel : DBModel, IDataModelUpdate
    {
        public LikeModel()
        {
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    public class PostReportModel : DBModel, IDataModelUpdate
    {
        public PostReportModel()
        {
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    public class PaymentModel : DBModel, IDataModelUpdate
    {
        public PaymentModel()
        {

        }

        public int ID { get; set; }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    public class ReservationModel : DBModel, IDataModelUpdate
    {
        public ReservationModel()
        {
        }

        private DateTime ReturnDate { get; set; }
        private int Amount { get; set; }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }
    }
}