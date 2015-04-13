using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

namespace ICT4EVENT
{
    public abstract class DBModel
    {
        // Creates a new row. {0} is table name, {1} is columns and {2} is values
        protected const string INSERTSTRING = "INSERT INTO {0} ({1}) VALUES ({2})";
        // Updates a row in the database. {0} is table name, {1} is columns and values and {2} is the row id
        protected const string UPDATESTRING = "UPDATE {0} SET {1} WHERE ident={2}";
        // Reads the corresponding row from the database. {0} is table name, {1} is the row id
        protected const string READSTRING = "SELECT * FROM {0} WHERE ident={1}";
        // Destroys the corresponding row in the table. {0} is the table name, {1} is the table id
        protected const string DESTROYSTRING = "DELETE FROM {0} WHERE ident={1}";

        public int Id { get; set; }
    }

    public class EventModel : DBModel, IDataModelUpdate
    {
        private readonly List<RegistrationModel> registrationsList;
        private string description;
        private DateTime endDate;
        private string location;
        private string name;
        private DateTime startDate;

        public EventModel()
        {
            registrationsList = new List<RegistrationModel>();
        }

        public List<RegistrationModel> RegistrationsList
        {
            get { return registrationsList; }
        }

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

        public bool Create()
        {
            string columns = "EventName, EventLocation, Description, BeginTime, EndTime";
            string values = "'" + name + "','" + location + "','" + description + "','" + startDate + "','" + endDate +
                            "'";
            string finalQuery = String.Format(INSERTSTRING, "EVENT", columns, values);
            DBManager.QueryDB(finalQuery);

            return true;
        }

        public bool Read()
        {
            string query = String.Format(READSTRING, "EVENT", Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            reader.Read();
            Id = Convert.ToInt32(reader["Ident"].ToString());
            name = reader["EventName"].ToString();
            location = reader["EventLocation"].ToString();
            description = reader["Description"].ToString();
            startDate = Convert.ToDateTime(reader["BeginTime"].ToString());
            endDate = Convert.ToDateTime(reader["EndTime"].ToString());

            return true;
        }

        public bool Update()
        {
            string columnvalues = "EventName='" + name + "', EventLocation='" + location + "', Description='" +
                                  description + "', BeginTime='" + startDate + "', EndTime='" + endDate + "'";
            string finalQuery = String.Format(UPDATESTRING, "EVENT", columnvalues, "'" + Id + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string query = String.Format(DESTROYSTRING, "EVENT", Id);
            DBManager.QueryDB(query);
            return true;
        }
    }

    public class UserModel : DBModel, IDataModelUpdate
    {
        private string RFIDnumber;
        public List<RegistrationModel> RegistrationList;
        private string address;
        private string email;
        private int level;
        private string password;
        private List<RegistrationModel> registrations;
        private string telephonenumber;
        private string username;

        public UserModel()
        {
            level = 1;
            RegistrationList = new List<RegistrationModel>();
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public string RfiDnumber
        {
            get { return RFIDnumber; }
            set { RFIDnumber = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Telephonenumber
        {
            get { return telephonenumber; }
            set { telephonenumber = value; }
        }

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

        public bool Create()
        {
            string columns = "RFIDnumber, Address, Username, Email, TelephoneNumber, UserPassword, UserLevel";
            string values = "'" + RFIDnumber + "','" + address + "','" + username + "','" + email + "','" +
                            telephonenumber + "','" + password + "','" + level + "'";
            string finalQuery = String.Format(INSERTSTRING, "USERS", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Read()
        {
            string query = String.Format(READSTRING, "USERS", Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            reader.Read();
            Id = Convert.ToInt32(reader["Ident"].ToString());
            RFIDnumber = reader["RFIDnumber"].ToString();
            address = reader["Address"].ToString();
            username = reader["Username"].ToString();
            email = reader["Email"].ToString();
            telephonenumber = reader["TelephoneNumber"].ToString();
            password = reader["UserPassword"].ToString();
            level = Convert.ToInt32(reader["UserLevel"].ToString());

            return true;
        }

        public bool Update()
        {
            string columnvalues = "RFIDnumber='" + RFIDnumber + "', Address='" + address + "', Username='" + username +
                                  "', Email='" + email + "', TelephoneNumber='" + telephonenumber + "', UserPassword='" +
                                  password + "'";
            string finalQuery = String.Format(UPDATESTRING, "USERS", columnvalues, "'" + Id + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "USERS", "'" + Id + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }
    }

    public class RegistrationModel : DBModel, IDataModelUpdate
    {
        private readonly EventModel event_item;
        private readonly UserModel user;

        public RegistrationModel(UserModel user, EventModel event_item)
        {
            this.user = user;
            this.event_item = event_item;
        }

        public UserModel User
        {
            get { return user; }
        }

        public EventModel EventItem
        {
            get { return event_item; }
        }


        public bool Create()
        {
            string columns = "UserID, EventID";
            string values = "'" + user.Id + "','" + event_item.Id + "'";
            string finalQuery = String.Format(INSERTSTRING, "REGISTRATION", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Read()
        {
            string query = String.Format(READSTRING, "REGISTRATION", Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            reader.Read();
            Id = Convert.ToInt32(reader["Ident"].ToString());
            user.Id = Convert.ToInt32(reader["UserID"].ToString());
            event_item.Id = Convert.ToInt32(reader["EventID"].ToString());

            return true;
        }

        public bool Update()
        {
            string columnvalues = "UserID='" + User.Id + "', EventID='" + event_item.Id + "'";
            string finalQuery = String.Format(UPDATESTRING, "REGISTRATION", columnvalues, "'" + Id + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "REGISTRATION", "'" + Id + "'");
            return true;
        }
    }

    public class RFIDLogModel : DBModel, IDataModelUpdate
    {
        private readonly EventModel event_item;
        private readonly UserModel user;
        private string InOrOut;

        public RFIDLogModel(UserModel user, EventModel event_item)
        {
            this.user = user;
            this.event_item = event_item;
        }


        public bool Create()
        {
            string columns = "UserID,EventID,InOrOut";
            string values = "'" + user.Id + "','" + event_item.Id + "','" + InOrOut + "'";
            string finalQuery = String.Format(INSERTSTRING, "RFIDLOG", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Read()
        {
            string query = String.Format(READSTRING, "RFIDLOG", Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            reader.Read();
            Id = Convert.ToInt32(reader["Ident"].ToString());
            user.Id = Convert.ToInt32(reader["UserID"].ToString());
            event_item.Id = Convert.ToInt32(reader["EventID"].ToString());
            InOrOut = reader["InOrOut"].ToString();

            return true;
        }

        public bool Update()
        {
            string columnvalues = "UserID='" + user.Id + "', EventID='" + event_item.Id + "', InOrOut='" + InOrOut + "'";
            string finalQuery = String.Format(UPDATESTRING, "RFIDLOG", columnvalues, "'" + Id + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "RFIDLOG", "'" + Id + "'");
            return true;
        }
    }

    public class RentableObjectModel : DBModel, IDataModelUpdate
    {
        private readonly EventModel event_item;
        private int amount;
        private string description;
        private decimal price;

        public RentableObjectModel(EventModel event_item)
        {
            this.event_item = event_item;
        }

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

        public bool Create()
        {
            string columns = "EventID, Description, Price, Amount";
            string values = "'" + event_item.Id + "','" + description + "','" + price + "','" + amount + "'";
            string finalQuery = String.Format(INSERTSTRING, "RENTABLEOBJECT", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Read()
        {
            string query = String.Format(READSTRING, "RENTABLEOBJECT", Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            reader.Read();
            Id = Convert.ToInt32(reader["Ident"].ToString());
            event_item.Id = Convert.ToInt32(reader["EventID"].ToString());
            description = reader["Description"].ToString();
            price = Convert.ToDecimal(reader["Price"].ToString());
            amount = Convert.ToInt32(reader["Amount"].ToString());

            return true;
        }

        public bool Update()
        {
            string columnvalues = "EventID='" + event_item.Id + "', Description='" + description + "', Price='" + price +
                                  "', Amount='" + amount + "'";
            string finalQuery = String.Format(UPDATESTRING, "RENTABLEOBJECT", columnvalues, "'" + Id + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "RENTABLEOBJECT", "'" + Id + "'");
            return true;
        }
    }

    public class PostModel : DBModel, IDataModelUpdate
    {
        private readonly EventModel event_item;
        private readonly UserModel user;
        private string content;
        private DateTime datePosted;
        private PostModel parent;
        private string pathToFile;

        public PostModel(UserModel user, EventModel event_item)
        {
            this.user = user;
            this.event_item = event_item;
        }

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

        public bool Create()
        {
            string columns = "UserID, EventID, ReplyID, PostContent, PathToFile, DATETIME";
            string values = "'" + user.Id + "','" + event_item.Id + "','" + parent.Id + "','" + content + "','" +
                            pathToFile + "','" + datePosted + "'";
            string finalQuery = String.Format(INSERTSTRING, "POST", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Read()
        {
            string query = String.Format(READSTRING, "POST", Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            reader.Read();
            Id = Convert.ToInt32(reader["Ident"].ToString());
            User.Id = Convert.ToInt32(reader["UserID"].ToString());
            event_item.Id = Convert.ToInt32(reader["EventID"].ToString());
            parent.Id = Convert.ToInt32(reader["ReplyID"].ToString());
            content = reader["PostContent"].ToString();
            pathToFile = reader["PathToFile"].ToString();
            datePosted = Convert.ToDateTime(reader["DATETIME"].ToString());

            return true;
        }

        public bool Update()
        {
            string columnvalues = "UserID='" + user.Id + "', EventID='" + event_item.Id + "', ReplyID='" + parent.Id +
                                  "', PostContent='" + content + "', PathToFile='" + pathToFile + "', DATETIME='" +
                                  datePosted + "'";
            string finalQuery = String.Format(UPDATESTRING, "POST", columnvalues, "'" + Id + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "POST", "'" + Id + "'");
            return true;
        }
    }

    public class PlaceModel : DBModel, IDataModelUpdate
    {
        private readonly EventModel event_item;
        private int amount;
        private string capacity;
        private string category;
        private string description;
        private string location;
        private decimal price;

        public PlaceModel(EventModel event_item)
        {
            this.event_item = event_item;
        }

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

        public bool Create()
        {
            string columns = "EventID, Description, Price, Amount, PlaceLocation, PlaceCategory, PlaceCapacity";
            string values = "'" + event_item.Id + "','" + description + "','" + price + "','" + amount + "','" +
                            location + "','" + category + "','" + capacity + "'";
            string finalQuery = String.Format(INSERTSTRING, "PLACE", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Read()
        {
            string query = String.Format(READSTRING, "PLACE", Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            reader.Read();
            Id = Convert.ToInt32(reader["Ident"].ToString());
            event_item.Id = Convert.ToInt32(reader["EventID"].ToString());
            description = reader["Description"].ToString();
            price = Convert.ToDecimal(reader["Price"].ToString());
            amount = Convert.ToInt32(reader["Amount"].ToString());
            location = reader["PlaceLocation"].ToString();
            category = reader["PlaceCategory"].ToString();
            capacity = reader["PlaceCapacity"].ToString();

            return true;
        }

        public bool Update()
        {
            string columnvalues = "EventID='" + event_item.Id + "', Description='" + description + "', Price='" + price +
                                  "', Amount='" + amount + "', PlaceLocation='" + location + "', PlaceCategory='" +
                                  category + "', PlaceCapacity='" + capacity + "'";
            string finalQuery = String.Format(UPDATESTRING, "PLACE", columnvalues, "'" + Id + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "PLACE", "'" + Id + "'");
            return true;
        }
    }

    public class LikeModel : DBModel, IDataModelUpdate
    {
        private PostModel post;
        private UserModel user;

        public bool Create()
        {
            string columns = "UserID, PostID";
            string values = "'" + user.Id + "','" + post.Id + "'";
            string finalQuery = String.Format(INSERTSTRING, "LIKES", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Read()
        {
            string query = String.Format(READSTRING, "LIKES", Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            reader.Read();
            Id = Convert.ToInt32(reader["Ident"].ToString());
            user.Id = Convert.ToInt32(reader["UserID"].ToString());
            post.Id = Convert.ToInt32(reader["PostID"].ToString());

            return true;
        }

        public bool Update()
        {
            string columnvalues = "UserID='" + user.Id + "', PostID='" + post.Id + "'";
            string finalQuery = String.Format(UPDATESTRING, "LIKES", columnvalues, "'" + Id + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "LIKES", "'" + Id + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }
    }

    public class PostReportModel : DBModel, IDataModelUpdate
    {
        private PostModel post;
        private string reason;
        private string status;
        private UserModel user;

        public bool Create()
        {
            string columns = "PostID, UserID, Reason, Status";
            string values = "'" + post.Id + "','" + user.Id + "','" + reason + "','" + status + "'";
            string finalQuery = String.Format(INSERTSTRING, "REPORT", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Read()
        {
            string query = String.Format(READSTRING, "REPORT", Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            reader.Read();
            Id = Convert.ToInt32(reader["Ident"].ToString());
            post.Id = Convert.ToInt32(reader["PostID"].ToString());
            user.Id = Convert.ToInt32(reader["UserID"].ToString());
            reason = reader["Reason"].ToString();
            status = reader["status"].ToString();

            return true;
        }

        public bool Update()
        {
            string columnvalues = "PostID='" + post.Id + "', UserID='" + user.Id + "', Reason='" + reason +
                                  "', Status='" + status + "'";
            string finalQuery = String.Format(UPDATESTRING, "REPORT", columnvalues, "'" + Id + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "REPORT", "'" + Id + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }
    }

    public class PaymentModel : DBModel, IDataModelUpdate
    {
        private int amount;
        private string paymentType;
        private RegistrationModel registration;

        public int ID { get; set; }

        public bool Create()
        {
            string columns = "RegistrationID, Amount, PaymentType";
            string values = "'" + registration.Id + "','" + amount + "','" + paymentType + "'";
            string finalQuery = String.Format(INSERTSTRING, "PAYMENT", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Read()
        {
            string query = String.Format(READSTRING, "PAYMENT", Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            reader.Read();
            Id = Convert.ToInt32(reader["Ident"].ToString());
            registration.Id = Convert.ToInt32(reader["RegistrationID"].ToString());
            amount = Convert.ToInt32(reader["Amount"].ToString());
            paymentType = reader["PaymentType"].ToString();

            return true;
        }

        public bool Update()
        {
            string columnvalues = "RegistrationID='" + registration.Id + "', Amount='" + amount + "', PaymentType='" +
                                  paymentType + "'";
            string finalQuery = String.Format(UPDATESTRING, "PAYMENT", columnvalues, "'" + Id + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "PAYMENT", "'" + Id + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }
    }

    public class ReservationModel : DBModel, IDataModelUpdate
    {
        private int amount;
        private RentableObjectModel item;
        private DateTime returnDate;
        private UserModel user;


        private DateTime ReturnDate { get; set; }
        private int Amount { get; set; }

        public bool Create()
        {
            string columns = "UserID, ItemID, ReturnDate, Amount";
            string values = "'" + user.Id + "','" + item.Id + "','" + returnDate + "','" + amount + "'";
            string finalQuery = String.Format(INSERTSTRING, "RESERVATION", columns, values);
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Read()
        {
            string query = String.Format(READSTRING, "RESERVATION", Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            reader.Read();
            Id = Convert.ToInt32(reader["Ident"].ToString());
            user.Id = Convert.ToInt32(reader["UserID"].ToString());
            item.Id = Convert.ToInt32(reader["ItemID"].ToString());
            returnDate = Convert.ToDateTime(reader["ReturnDate"].ToString());
            amount = Convert.ToInt32(reader["Amount"].ToString());

            return true;
        }

        public bool Update()
        {
            string columnvalues = "UserID='" + user.Id + "', ItemID='" + item.Id + "', ReturnDate='" + returnDate +
                                  "', Amount='" + amount + "'";
            string finalQuery = String.Format(UPDATESTRING, "RESERVATION", columnvalues, "'" + Id + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }

        public bool Destroy()
        {
            string finalQuery = String.Format(DESTROYSTRING, "RESERVATION", "'" + Id + "'");
            DBManager.QueryDB(finalQuery);
            return true;
        }
    }
}