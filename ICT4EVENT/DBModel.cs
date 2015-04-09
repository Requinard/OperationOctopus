using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ICT4EVENT
{
    public abstract class DBModel
    {
        // Creates a new row. {0} is table name, {1} is columns and {2} is values
        protected const string INSERTSTRING = "INSERT INTO {0} ({1}) VALUES ({2})";
        // Updates a row in the database. {0} is table name, {1} is columns and values and {2} is the row id
        private const string UPDATESTRING = "UPDATE {0} SET {1} WHERE id={2}";
        // Reads the corresponding row from the database. {0} is table name, {1} is the row id
        private const string READSTRING = "SELECT * FROM {0} WHERE id={1}";
        // Destroys the corresponding row in the table. {0} is the table name, {1} is the table id
        protected const string DESTROYSTRING = "DELETE FROM {0} WHERE id={1}";

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
            string columns = "EventName, EventLocation, Description, BeginTime, EndTime";
            string values = name + "," + location + "," + description + "," + startDate.ToString() + "," + endDate.ToString();
            string finalQuery = String.Format(INSERTSTRING, "EVENT", columns, values);
            DBManager.QueryDB(finalQuery);

            return true;
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
            string query = String.Format(DESTROYSTRING, "EVENT", Id.ToString());
            DBManager.QueryDB(query);
            return true;
        }
    }

    public class UserModel : DBModel, IDataModelUpdate
    {
        private int RFIDnumber;
        private string address;
        private string username;
        private string email;
        private string telephonenumber;
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
            set { password = value; }
        }

        public List<RegistrationModel> RegistrationList = new List<RegistrationModel>();

        public UserModel()
        {
            registrations = new List<RegistrationModel>();
        }

        public bool Create()
        {
            string columns = "RFIDnumber, Address, Username, Email, TelephoneNumber, UserPassword";
            string values = RFIDnumber.ToString() + "," + address + "," + username + "," + email + "," + telephonenumber + "," + password;
            string finalQuery = String.Format(INSERTSTRING, "USERS", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
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
            string finalQuery = String.Format(DESTROYSTRING, "USERS", Id.ToString());
            DBManager.QueryDB(finalQuery);
            return true;
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
            string columns = "UserID, EventID";
            string values = user.Id.ToString() + "," + event_item.Id.ToString();
            string finalQuery = String.Format(INSERTSTRING, "REGISTRATION", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
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
            string finalQuery = String.Format(DESTROYSTRING, "REGISTRATION", Id.ToString());
            return true;
        }
    }

    public class RFIDLogModel : DBModel, IDataModelUpdate
    {
        private UserModel user;
        private EventModel event_item;
        private string InOrOut;

        public RFIDLogModel(UserModel user, EventModel event_item)
        {
            this.user = user;
            this.event_item = event_item;
        }



        public bool Create()
        {
            string columns = "UserID,EventID,InOrOut";
            string values = user.Id.ToString() + "," + event_item.Id.ToString() + "," + InOrOut;
            string finalQuery = String.Format(INSERTSTRING, "RFIDLOG", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
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
            string finalQuery = String.Format(DESTROYSTRING, "RFIDLOG", Id.ToString());
            return true;
        }
    }

    public class RentableObjectModel : DBModel, IDataModelUpdate
    {
        private EventModel event_item;
        private string ItemType;
        private string description;
        private decimal price;
        private int amount;
        private string placeLocation;
        private string placeCategory;
        private int placeCapacity;
        private string typeOfObject;

        public EventModel EventItem
        {
            get { return event_item; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public RentableObjectModel(EventModel event_item)
        {
            this.event_item = event_item;
        }

        public bool Create()
        {
            string columns = "EventID, ItemType, Description, Price, Amount, PlaceLocation, PlaceCategory, PlaceCapacity, TypeOfObject";
            string values = event_item.Id.ToString() + "," + ItemType + "," + description + "," + price.ToString() + "," + amount.ToString() + "," + placeLocation + "," + placeCategory + "," + placeCapacity.ToString() + "," + typeOfObject;
            string finalQuery = String.Format(INSERTSTRING, "ITEM", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
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
            string finalQuery = String.Format(DESTROYSTRING, "ITEM", Id.ToString());
            return true;
        }
    }

    public class PostModel : DBModel, IDataModelUpdate
    {
        private UserModel user;
        private EventModel event_item;

        private PostModel parent;

        public PostModel Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public string PathToFile
        {
            get { return pathToFile; }
            set { pathToFile = value; }
        }

        public DateTime DatePosted
        {
            get { return datePosted; }
            set { datePosted = value; }
        }

        private string content;
        private string pathToFile;
        private DateTime datePosted;

        public UserModel User
        {
            get { return user; }
        }

        public EventModel EventItem
        {
            get { return event_item; }
        }

        public PostModel(UserModel user, EventModel event_item)
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

    public class PlaceModel : DBModel, IDataModelUpdate
    {
        private EventModel event_item;
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private decimal price;
        private int amount;
        private string location;
        private string category;
        private string capacity;

        public string Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public EventModel EventItem
        {
            get { return event_item; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public PlaceModel(EventModel event_item)
        {
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