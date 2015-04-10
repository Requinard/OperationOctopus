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
        protected const string UPDATESTRING = "UPDATE {0} SET {1} WHERE id={2}";
        // Reads the corresponding row from the database. {0} is table name, {1} is the row id
        protected const string READSTRING = "SELECT * FROM {0} WHERE id={1}";
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
            string values = "'" + name + "','" + location + "','" + description + "','" + startDate.ToString() + "','" + endDate.ToString() + "'";
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
            string columnvalues = "EventName='" + name + "', EventLocation='" + location + "', Description='" + description + "', BeginTime='" + startDate.ToString() + "', EndTime='" + endDate.ToString() + "'";
            string finalQuery = String.Format(UPDATESTRING, "EVENT", columnvalues, "'" +  Id.ToString() + "'");
            DBManager.QueryDB(finalQuery);
            return true;
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
            string values = "'" + RFIDnumber.ToString() + "','" + address + "','" + username + "','" + email + "','" + telephonenumber + "','" + password + "'";
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
            string columnvalues = "RFIDnumber='" + RFIDnumber.ToString() + "', Address='" + address + "', Username='" + username + "', Email='" + email + "', TelephoneNumber='" + telephonenumber+ "', UserPassword='" + password + "'";
            string finalQuery = String.Format(UPDATESTRING, "USERS", columnvalues, "'" + Id.ToString() + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "USERS", "'" + Id.ToString() + "'");
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
            string values = "'" + user.Id.ToString() + "','" + event_item.Id.ToString() + "'";
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
            string columnvalues = "UserID='" + User.Id.ToString() + "', EventID='" + event_item.Id.ToString() + "'";
            string finalQuery = String.Format(UPDATESTRING, "REGISTRATION", columnvalues, "'" + Id.ToString() + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "REGISTRATION", "'" + Id.ToString() + "'");
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
            string values = "'" + user.Id.ToString() + "','" + event_item.Id.ToString() + "','" + InOrOut + "'";
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
            string columnvalues = "UserID='" + user.Id.ToString() + "', EventID='" + event_item.Id.ToString() + "', InOrOut='" + InOrOut + "'";
            string finalQuery = String.Format(UPDATESTRING, "RFIDLOG", columnvalues, "'" + Id.ToString() + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "RFIDLOG", "'" + Id.ToString() + "'");
            return true;
        }
    }

    public class RentableObjectModel : DBModel, IDataModelUpdate
    {
        private EventModel event_item;
        private string description;
        private decimal price;
        private int amount;

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
            string columns = "EventID, Description, Price, Amount, TypeOfObject";
            string values = "'" + event_item.Id.ToString() + "','" + description + "','" + price.ToString() + "','" + amount.ToString() + "'";
            string finalQuery = String.Format(INSERTSTRING, "RENTABLEOBJECT", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            string columnvalues = "EventID='" + event_item.Id.ToString() + "', Description='" + description + "', Price='" + price.ToString() + "', Amount='" + amount.ToString() + "'";
            string finalQuery = String.Format(UPDATESTRING, "RENTABLEOBJECT", columnvalues, "'" + Id.ToString() + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "RENTABLEOBJECT", "'" + Id.ToString() + "'");
            return true;
        }
    }

    public class PostModel : DBModel, IDataModelUpdate
    {
        private UserModel user;
        private EventModel event_item;
        private PostModel parent;
        private string content;
        private string pathToFile;
        private DateTime datePosted;

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
            string columns = "UserID, EventID, ReplyID, PostContent, PathToFile, DATETIME";
            string values = "'" + user.Id.ToString() + "','" + event_item.Id.ToString() + "','" + parent.Id.ToString() + "','" + content + "','" + pathToFile + "','" + datePosted.ToString() + "'";
            string finalQuery = String.Format(INSERTSTRING, "POST", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            string columnvalues = "UserID='" + user.Id.ToString() + "', EventID='" + event_item.Id.ToString() + "', ReplyID='" + parent.Id.ToString() + "', PostContent='" + content + "', PathToFile='" + pathToFile + "', DATETIME='" + datePosted.ToString() + "'";
            string finalQuery = String.Format(UPDATESTRING, "POST", columnvalues, "'" + Id.ToString() + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "POST", "'" + Id.ToString() + "'");
            return true;
        }
    }

    public class PlaceModel : DBModel, IDataModelUpdate
    {
        private EventModel event_item;
        private string description;
        private decimal price;
        private int amount;
        private string location;
        private string category;
        private string capacity;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

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
            string columns = "EventID, Description, Price, Amount, PlaceLocation, PlaceCategory, PlaceCapacity";
            string values = "'" + event_item.Id.ToString() + "','" + description + "','" + price.ToString() + "','" + amount.ToString() + "','" + location + "','" + category + "','" + capacity + "'";
            string finalQuery = String.Format(INSERTSTRING, "PLACE", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            string columnvalues = "EventID='" + event_item.Id.ToString() + "', Description='" + description + "', Price='" + price.ToString() + "', Amount='" + amount.ToString() + "', PlaceLocation='" + location + "', PlaceCategory='" + category + "', PlaceCapacity='" + capacity + "'";
            string finalQuery = String.Format(UPDATESTRING, "PLACE", columnvalues, "'" + Id.ToString() + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "PLACE", "'" + Id.ToString() + "'");
            return true;
        }
    }

    public class LikeModel : DBModel, IDataModelUpdate
    {

        private UserModel user;
        private PostModel post;

        public LikeModel()
        {
        }

        public bool Create()
        {
            string columns = "UserID, PostID";
            string values = "'" + user.Id.ToString() + "','" + post.Id.ToString() + "'";
            string finalQuery = String.Format(INSERTSTRING, "LIKES", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            string columnvalues = "UserID='" + user.Id.ToString() + "', PostID='" + post.Id.ToString() + "'";
            string finalQuery = String.Format(UPDATESTRING, "LIKES", columnvalues, "'" + Id.ToString() + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "LIKES", "'" + Id.ToString() + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }
    }

    public class PostReportModel : DBModel, IDataModelUpdate
    {
        private PostModel post;
        private UserModel user;
        private string reason;
        private string status;

        public PostReportModel()
        {
        }

        public bool Create()
        {
            string columns = "PostID, UserID, Reason, Status";
            string values = "'" + post.Id.ToString() + "','" + user.Id.ToString() + "','" + reason + "','" + status + "'";
            string finalQuery = String.Format(INSERTSTRING, "REPORT", columns, values);
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
            string finalQuery = String.Format(DESTROYSTRING, "REPORT", "'" + Id.ToString() + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }
    }

    public class PaymentModel : DBModel, IDataModelUpdate
    {
        private RegistrationModel registration;
        private int amount;
        private string paymentType;

        public PaymentModel()
        {

        }

        public int ID { get; set; }

        public bool Create()
        {
            string columns = "RegistrationID, Amount, PaymentType";
            string values = "'" + registration.Id.ToString() + "','" + amount.ToString() + "','" + paymentType + "'";
            string finalQuery = String.Format(INSERTSTRING, "PAYMENT", columns, values);
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
            string finalQuery = String.Format(DESTROYSTRING, "PAYMENT", "'" + Id.ToString() + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }
    }

    public class ReservationModel : DBModel, IDataModelUpdate
    {
        private UserModel user;
        private RentableObjectModel item;
        private DateTime returnDate;
        private int amount;


        public ReservationModel()
        {
            
        }

        private DateTime ReturnDate { get; set; }
        private int Amount { get; set; }
        public bool Create()
        {
            string columns = "UserID, ItemID, ReturnDate, Amount";
            string values = "'" + user.Id.ToString() + "','" + item.Id.ToString() + "','" + returnDate.ToString() + "','" + amount.ToString() + "'";
            string finalQuery = String.Format(INSERTSTRING, "RESERVATION", columns, values);
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
            string finalQuery = String.Format(DESTROYSTRING, "RESERVATION", "'" + Id.ToString() + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }
    }
}