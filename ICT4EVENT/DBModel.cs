// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DBModel.cs" company="">
//   
// </copyright>
// <summary>
//   The db model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using ICT4EVENT;

namespace ICT4EVENT
{
using System;
using System.Collections.Generic;

using Oracle.DataAccess.Client;

    /// <summary>
    ///     The db model.
    /// </summary>
    public abstract class DBModel
    {
        // Creates a new row. {0} is table name, {1} is columns and {2} is values
        #region Constants

        protected string dateFormat = "MM-dd-yyyy hh:mm:ss";
        /// <summary>
        ///     The destroystring.
        /// </summary>
        protected const string DESTROYSTRING = "DELETE FROM {0} WHERE ident={1}";

        /// <summary>
        ///     The insertstring.
        /// </summary>
        protected const string INSERTSTRING = "INSERT INTO {0} ({1}) VALUES ({2})";

        // Updates a row in the database. {0} is table name, {1} is columns and values and {2} is the row id

        // Reads the corresponding row from the database. {0} is table name, {1} is the row id
        /// <summary>
        ///     The readstring.
        /// </summary>
        protected const string READSTRING = "SELECT * FROM {0} WHERE ident={1}";

        /// <summary>
        ///     The updatestring.
        /// </summary>
        protected const string UPDATESTRING = "UPDATE {0} SET {1} WHERE ident={2}";

        #endregion

        // Destroys the corresponding row in the table. {0} is the table name, {1} is the table id
        #region Public Properties

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        #endregion
    }

    /// <summary>
    ///     The event model.
    /// </summary>
    public class EventModel : DBModel, IDataModelUpdate
    {
        #region Fields

        /// <summary>
        ///     The registrations list.
        /// </summary>
        private readonly List<RegistrationModel> registrationsList;

        /// <summary>
        ///     The description.
        /// </summary>
        private string description;

        /// <summary>
        ///     The end date.
        /// </summary>
        private DateTime endDate;

        /// <summary>
        ///     The location.
        /// </summary>
        private string location;

        /// <summary>
        ///     The name.
        /// </summary>
        private string name;

        /// <summary>
        ///     The start date.
        /// </summary>
        private DateTime startDate;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="EventModel" /> class.
        /// </summary>
        public EventModel()
        {
            this.registrationsList = new List<RegistrationModel>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
        }

            set
        {
                this.description = value;
        }
        }

        /// <summary>
        ///     Gets or sets the end date.
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }

            set
            {
                this.endDate = value;
            }
        }

        /// <summary>
        ///     Gets or sets the location.
        /// </summary>
        public string Location
        {
            get
            {
                return this.location;
        }

            set
        {
                this.location = value;
        }
        }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        /// <summary>
        ///     Gets the registrations list.
        /// </summary>
        public List<RegistrationModel> RegistrationsList
        {
            get
            {
                return this.registrationsList;
            }
        }

        /// <summary>
        ///     Gets or sets the start date.
        /// </summary>
        public DateTime StartDate
        {
            get
            {
                return this.startDate;
        }

            set
        {
                this.startDate = value;
        }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The create.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Create()
        {
            string columns = "EventName, EventLocation, Description, BeginTime, EndTime";
            string values = string.Format("'{0}','{1}','{2}',to_date('{3}', 'fmmm-fmdd-yyyy hh:mi:ss'),to_date('{4}', 'fmMM-fmDD-yyyy hh24:mi:ss')", this.name, this.location, this.description, this.startDate.ToString(dateFormat), this.endDate.ToString(dateFormat));
            string finalQuery = string.Format(INSERTSTRING, "EVENT", columns, values);
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            if (reader == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     The destroy.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Destroy()
        {
            string query = string.Format(DESTROYSTRING, "EVENT", this.Id);
            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     The read.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Read()
        {
            string query = string.Format(READSTRING, "EVENT", this.Id);
            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return false;
            }

            reader.Read();
            this.Id = Convert.ToInt32(reader["Ident"].ToString());
            this.name = reader["EventName"].ToString();
            this.location = reader["EventLocation"].ToString();
            this.description = reader["Description"].ToString();
            this.startDate = Convert.ToDateTime(reader["BeginTime"].ToString());
            this.endDate = Convert.ToDateTime(reader["EndTime"].ToString());

            return true;
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Update()
        {
            string columnvalues = string.Format("EventName='{0}', EventLocation='{1}', Description='{2}', BeginTime=to_date('{3}', 'fmmm-fmdd-yyyy hh:mi:ss'), EndTime=to_date('{4}', 'fmmm-fmdd-yyyy hh:mi:ss')", this.name, this.location, this.description, this.startDate.ToString(dateFormat), this.endDate.ToString(dateFormat));
            string finalQuery = string.Format(UPDATESTRING, "EVENT", columnvalues, "'" + this.Id + "'");

            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            if (reader == null)
        {
                return false;
            }

            return true;
        }

        #endregion
    }

    /// <summary>
    ///     The user model.
    /// </summary>
    public class UserModel : DBModel, IDataModelUpdate
    {
        #region Fields

        /// <summary>
        ///     The registration list.
        /// </summary>
        public List<RegistrationModel> RegistrationList;

        /// <summary>
        ///     The rfi dnumber.
        /// </summary>
        private string RFIDnumber;

        /// <summary>
        ///     The address.
        /// </summary>
        private string address;

        /// <summary>
        ///     The email.
        /// </summary>
        private string email;

        /// <summary>
        ///     The level.
        /// </summary>
        private int level;

        /// <summary>
        ///     The password.
        /// </summary>
        private string password;

        /// <summary>
        ///     The registrations.
        /// </summary>
        private List<RegistrationModel> registrations;

        /// <summary>
        ///     The telephonenumber.
        /// </summary>
        private string telephonenumber;

        /// <summary>
        ///     The username.
        /// </summary>
        private string username;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserModel" /> class.
        /// </summary>
        public UserModel()
        {
            this.level = 1;
            this.RegistrationList = new List<RegistrationModel>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.address = value;
            }
        }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        /// <summary>
        ///     Gets or sets the level.
        /// </summary>
        public int Level
        {
            get
            {
                return this.level;
        }

            set
        {
                this.level = value;
        }
        }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
        }

            // Automatically hashes a new string when it's set
            set
        {
                this.password = value;
        }
        }

        /// <summary>
        ///     Gets or sets the rfi dnumber.
        /// </summary>
        public string RfiDnumber
        {
            get
            {
                return this.RFIDnumber;
            }

            set
            {
                this.RFIDnumber = value;
            }
        }

        /// <summary>
        ///     Gets or sets the telephonenumber.
        /// </summary>
        public string Telephonenumber
        {
            get
            {
                return this.telephonenumber;
        }

            set
            {
                this.telephonenumber = value;
            }
        }

        /// <summary>
        ///     Gets or sets the username.
        /// </summary>
        public string Username
        {
            get
            {
                return this.username;
        }

            set
        {
                this.username = value;
        }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The create.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Create()
        {
            string columns = "RFIDnumber, Address, Username, Email, TelephoneNumber, UserPassword, UserLevel";
            string values = string.Format(
                "'{0}','{1}','{2}','{3}','{4}','{5}','{6}'", 
                this.RFIDnumber, 
                this.address, 
                this.username, 
                this.email, 
                this.telephonenumber, 
                this.password, 
                this.level);
            string finalQuery = string.Format(INSERTSTRING, "USERS", columns, values);
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            if (reader == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     The destroy.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Destroy()
        {
            string finalQuery = string.Format(DESTROYSTRING, "USERS", "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            if (reader == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     The read.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Read()
        {
            string query = string.Format(READSTRING, "USERS", this.Id);
            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return false;
            }

            reader.Read();
            this.Id = Convert.ToInt32(reader["Ident"].ToString());
            this.RFIDnumber = reader["RFIDnumber"].ToString();
            this.address = reader["Address"].ToString();
            this.username = reader["Username"].ToString();
            this.email = reader["Email"].ToString();
            this.telephonenumber = reader["TelephoneNumber"].ToString();
            this.password = reader["UserPassword"].ToString();
            this.level = Convert.ToInt32(reader["UserLevel"].ToString());

            return true;
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Update()
        {
            string columnvalues =
                string.Format(
                    "RFIDnumber='{0}', Address='{1}', Username='{2}', Email='{3}', TelephoneNumber='{4}', UserPassword='{5}'", 
                    this.RFIDnumber, 
                    this.address, 
                    this.username, 
                    this.email, 
                    this.telephonenumber, 
                    this.password);
            string finalQuery = string.Format(UPDATESTRING, "USERS", columnvalues, "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            if (reader == null)
        {
                return false;
            }

            return true;
        }

        #endregion
    }

    /// <summary>
    ///     The registration model.
    /// </summary>
    public class RegistrationModel : DBModel, IDataModelUpdate
    {
        #region Fields

        /// <summary>
        ///     The event_item.
        /// </summary>
        private readonly EventModel event_item;

        /// <summary>
        ///     The user.
        /// </summary>
        private readonly UserModel user;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationModel"/> class.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="event_item">
        /// The event_item.
        /// </param>
        public RegistrationModel(UserModel user, EventModel event_item)
        {
            this.user = user;
            this.event_item = event_item;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the event item.
        /// </summary>
        public EventModel EventItem
        {
            get
            {
                return this.event_item;
        }
        }

        /// <summary>
        ///     Gets the user.
        /// </summary>
        public UserModel User
        {
            get
            {
                return this.user;
        }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The create.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Create()
        {
            string columns = "UserID, EventID";
            string values = string.Format("'{0}','{1}'", this.user.Id, this.event_item.Id);
            string finalQuery = string.Format(INSERTSTRING, "REGISTRATION", columns, values);
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            if (reader == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     The destroy.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Destroy()
        {
            string finalQuery = string.Format(DESTROYSTRING, "REGISTRATION", "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            if (reader == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     The read.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Read()
        {
            string query = string.Format(READSTRING, "REGISTRATION", this.Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            if (reader == null)
            {
                return false;
            }

            reader.Read();
            this.Id = Convert.ToInt32(reader["Ident"].ToString());
            this.user.Id = Convert.ToInt32(reader["UserID"].ToString());
            this.event_item.Id = Convert.ToInt32(reader["EventID"].ToString());

            return true;
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Update()
        {
            string columnvalues = "UserID='" + this.User.Id + "', EventID='" + this.event_item.Id + "'";
            string finalQuery = string.Format(UPDATESTRING, "REGISTRATION", columnvalues, "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
        }

    /// <summary>
    ///     The rfid log model.
    /// </summary>
    public class RFIDLogModel : DBModel, IDataModelUpdate
    {
        #region Fields

        /// <summary>
        ///     The event_item.
        /// </summary>
        private readonly EventModel event_item;

        /// <summary>
        ///     The user.
        /// </summary>
        private readonly UserModel user;

        /// <summary>
        ///     The in or out.
        /// </summary>
        private string InOrOut;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RFIDLogModel"/> class.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="event_item">
        /// The event_item.
        /// </param>
        public RFIDLogModel(UserModel user, EventModel event_item)
        {
            this.user = user;
            this.event_item = event_item;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The create.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Create()
        {
            string columns = "UserID,EventID,InOrOut";
            string values = "'" + this.user.Id + "','" + this.event_item.Id + "','" + this.InOrOut + "'";
            string finalQuery = string.Format(INSERTSTRING, "RFIDLOG", columns, values);
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            if (reader == null)
            {
                return false;
            }

            ;
            return true;
        }

        /// <summary>
        ///     The destroy.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Destroy()
        {
            string finalQuery = string.Format(DESTROYSTRING, "RFIDLOG", "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        /// <summary>
        ///     The read.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Read()
        {
            string query = string.Format(READSTRING, "RFIDLOG", this.Id);
            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return false;
            }

            reader.Read();
            this.Id = Convert.ToInt32(reader["Ident"].ToString());
            this.user.Id = Convert.ToInt32(reader["UserID"].ToString());
            this.event_item.Id = Convert.ToInt32(reader["EventID"].ToString());
            this.InOrOut = reader["InOrOut"].ToString();

            return true;
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Update()
        {
            string columnvalues = string.Format("UserID='{0}', EventID='{1}', InOrOut='{2}'", this.user.Id, this.event_item.Id, this.InOrOut);
            string finalQuery = string.Format(UPDATESTRING, "RFIDLOG", columnvalues, "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
        }

    /// <summary>
    ///     The rentable object model.
    /// </summary>
    public class RentableObjectModel : DBModel, IDataModelUpdate
    {
        #region Fields

        /// <summary>
        ///     The event_item.
        /// </summary>
        private readonly EventModel event_item;

        /// <summary>
        ///     The amount.
        /// </summary>
        private int amount;

        /// <summary>
        ///     The description.
        /// </summary>
        private string description;

        /// <summary>
        ///     The price.
        /// </summary>
        private decimal price;

        /// <summary>
        ///     The price.
        /// </summary>
        private string objectType;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RentableObjectModel"/> class.
        /// </summary>
        /// <param name="event_item">
        /// The event_item.
        /// </param>
        public RentableObjectModel(EventModel event_item)
        {
            this.event_item = event_item;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        public int Amount
        {
            get
            {
                return this.amount;
        }

            set
            {
                this.amount = value;
            }
        }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
        }

            set
            {
                this.description = value;
            }
        }

        /// <summary>
        ///     Gets or sets the kind of object.
        /// </summary>
        public string ObjectType
        {
            get
            {
                return this.objectType;
            }

            set
            {
                this.objectType = value;
            }
        }

        /// <summary>
        ///     Gets the event item.
        /// </summary>
        public EventModel EventItem
        {
            get
            {
                return this.event_item;
            }
        }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.price;
        }

            set
        {
                this.price = value;
        }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The create.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Create()
        {
            string columns = "EventID, Description, Price, Amount, TypeOfObject, ItemType";
            string values = string.Format("'{0}','{1}','{2}','{3}','{4}', 'RentableObject'", this.event_item.Id, this.description, this.price, this.amount, this.objectType);
            string finalQuery = string.Format(INSERTSTRING, "ITEM", columns, values);
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        /// <summary>
        ///     The destroy.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Destroy()
        {
            string finalQuery = string.Format(DESTROYSTRING, "ITEM", "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        /// <summary>
        ///     The read.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Read()
        {
            string query = string.Format(READSTRING, "ITEM", this.Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            if (reader == null)
            {
                return false;
            }

            reader.Read();
            this.Id = Convert.ToInt32(reader["Ident"].ToString());
            this.event_item.Id = Convert.ToInt32(reader["EventID"].ToString());
            this.description = reader["Description"].ToString();
            this.objectType = reader["TypeOfObject"].ToString();
            this.price = Convert.ToDecimal(reader["Price"].ToString());
            this.amount = Convert.ToInt32(reader["Amount"].ToString());

            return true;
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Update()
        {
            string columnvalues = string.Format(
                "EventID='{0}', Description='{1}', Price='{2}', Amount='{3}', TypeOfObject='{4}'", 
                this.event_item.Id, 
                this.description, 
                this.price, 
                this.amount,
                this.objectType);
            string finalQuery = string.Format(UPDATESTRING, "ITEM", columnvalues, "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }

    /// <summary>
    ///     The post model.
    /// </summary>
    public class PostModel : DBModel, IDataModelUpdate
    {
        #region Fields

        /// <summary>
        ///     The event_item.
        /// </summary>
        private readonly EventModel event_item;

        /// <summary>
        ///     The user.
        /// </summary>
        private readonly UserModel user;

        /// <summary>
        ///     The content.
        /// </summary>
        private string content;

        /// <summary>
        ///     The date posted.
        /// </summary>
        private DateTime datePosted;

        /// <summary>
        ///     The parent.
        /// </summary>
        private PostModel parent;

        /// <summary>
        ///     The path to file.
        /// </summary>
        private string pathToFile;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PostModel"/> class.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="event_item">
        /// The event_item.
        /// </param>
        public PostModel(UserModel user, EventModel event_item)
        {
            this.user = user;
            this.event_item = event_item;
        }

        public PostModel()
        {
            user = new UserModel();
            event_item = new EventModel();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the content.
        /// </summary>
        public string Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;
            }
        }

        /// <summary>
        ///     Gets or sets the date posted.
        /// </summary>
        public DateTime DatePosted
        {
            get
            {
                return this.datePosted;
            }

            set
            {
                this.datePosted = value;
            }
        }

        /// <summary>
        ///     Gets the event item.
        /// </summary>
        public EventModel EventItem
        {
            get
            {
                return this.event_item;
            }
        }

        /// <summary>
        ///     Gets or sets the parent.
        /// </summary>
        public PostModel Parent
        {
            get
            {
                return this.parent;
        }

            set
        {
                this.parent = value;
            }
        }

        /// <summary>
        ///     Gets or sets the path to file.
        /// </summary>
        public string PathToFile
        {
            get
            {
                return this.pathToFile;
        }

            set
        {
                this.pathToFile = value;
            }
        }

        /// <summary>
        ///     Gets the user.
        /// </summary>
        public UserModel User
        {
            get
            {
                return this.user;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The create.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Create()
        {
            string columns = "";
            string values = "";
            if (parent != null)
            {
                columns = "UserID, EventID, ReplyID, PostContent, PathToFile, DATETIME";

                values = string.Format(
                    "'{0}','{1}','{2}','{3}','{4}',,to_date('{5}', 'fmmm-fmdd-yyyy hh:mi:ss')'",
                    this.user.Id,
                    this.event_item.Id,
                    this.parent.Id,
                    this.content,
                    this.pathToFile,
                    this.datePosted.ToString(dateFormat));
            }
            else
                {
                columns = "UserID, EventID, PostContent, PathToFile, DATETIME";

                values = string.Format(
                    "'{0}','{1}','{2}','{3}',to_date('{4}', 'fmmm-fmdd-yyyy hh:mi:ss')",
                    this.user.Id,
                    this.event_item.Id,
                    this.content,
                    this.pathToFile,
                    this.datePosted.ToString(dateFormat));
            }
            
            string finalQuery = string.Format(INSERTSTRING, "POST", columns, values);
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        /// <summary>
        ///     The destroy.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Destroy()
        {
            string finalQuery = string.Format(DESTROYSTRING, "POST", "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        /// <summary>
        ///     The read.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Read()
        {
            string query = string.Format(READSTRING, "POST", this.Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            if (reader == null)
            {
                return false;
            }

            reader.Read();
            this.Id = Convert.ToInt32(reader["Ident"].ToString());
            this.User.Id = Convert.ToInt32(reader["UserID"].ToString());
            this.event_item.Id = Convert.ToInt32(reader["EventID"].ToString());
            try
            {
                this.parent.Id = Convert.ToInt32(reader["ReplyID"].ToString());
            }
            catch (Exception)
            {
                this.parent = null;
            }
            this.content = reader["PostContent"].ToString();
            this.pathToFile = reader["PathToFile"].ToString();
            this.datePosted = Convert.ToDateTime(reader["DATETIME"].ToString());

            return true;
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Update()
        {
            string columnvalues = "";
            if (parent != null)
            {
                columnvalues =
                    string.Format(
                        "UserID='{0}', EventID='{1}', ReplyID='{2}', PostContent='{3}', PathToFile='{4}', DATETIME=to_date('{5}', 'fmmm-fmdd-yyyy hh:mi:ss')",
                        this.user.Id,
                        this.event_item.Id,
                        this.parent.Id,
                        this.content,
                        this.pathToFile,
                        this.datePosted.ToString(dateFormat));
            }
            else
            {
                columnvalues =
                     string.Format(
                         "UserID='{0}', EventID='{1}', PostContent='{2}', PathToFile='{3}', DATETIME=to_date('{4}', 'fmmm-fmdd-yyyy hh:mi:ss')",
                         this.user.Id,
                         this.event_item.Id,
                         this.content,
                         this.pathToFile,
                         this.datePosted.ToString(dateFormat)); 
            }
            string finalQuery = string.Format(UPDATESTRING, "POST", columnvalues, "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }

    /// <summary>
    ///     The place model.
    /// </summary>
    public class PlaceModel : DBModel, IDataModelUpdate
    {
        #region Fields

        /// <summary>
        ///     The event_item.
        /// </summary>
        private readonly EventModel event_item;

        /// <summary>
        ///     The amount.
        /// </summary>
        private int amount;

        /// <summary>
        ///     The capacity.
        /// </summary>
        private int capacity;

        /// <summary>
        ///     The category.
        /// </summary>
        private string category;

        /// <summary>
        ///     The description.
        /// </summary>
        private string description;

        /// <summary>
        ///     The location.
        /// </summary>
        private string location;

        /// <summary>
        ///     The price.
        /// </summary>
        private decimal price;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaceModel"/> class.
        /// </summary>
        /// <param name="event_item">
        /// The event_item.
        /// </param>
        public PlaceModel(EventModel event_item)
        {
            this.event_item = event_item;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        public int Amount
        {
            get
            {
                return this.amount;
            }

            set
        {
                this.amount = value;
            }
        }

        /// <summary>
        ///     Gets or sets the capacity.
        /// </summary>
        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                this.capacity = value;
            }
        }

        /// <summary>
        ///     Gets or sets the category.
        /// </summary>
        public string Category
        {
            get
            {
                return this.category;
            }

            set
            {
                this.category = value;
            }
        }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
        }

            set
        {
                this.description = value;
            }
        }

        /// <summary>
        ///     Gets the event item.
        /// </summary>
        public EventModel EventItem
        {
            get
            {
                return this.event_item;
            }
        }

        /// <summary>
        ///     Gets or sets the location.
        /// </summary>
        public string Location
        {
            get
            {
                return this.location;
        }

            set
        {
                this.location = value;
            }
        }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        public decimal Price
        {
            get
        {
                return this.price;
        }

            set
        {
                this.price = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The create.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Create()
        {
            string columns = "EventID, Description, Price, Amount, PlaceLocation, PlaceCategory, PlaceCapacity, ItemType";
            string values = string.Format(
                "'{0}','{1}','{2}','{3}','{4}','{5}','{6}', 'Place'", 
                this.event_item.Id, 
                this.description, 
                this.price, 
                this.amount, 
                this.location, 
                this.category, 
                this.capacity);
            string finalQuery = string.Format(INSERTSTRING, "ITEM", columns, values);
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        /// <summary>
        ///     The destroy.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Destroy()
        {
            string finalQuery = string.Format(DESTROYSTRING, "ITEM", "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        /// <summary>
        ///     The read.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Read()
        {
            string query = string.Format(READSTRING, "ITEM", this.Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            if (reader == null)
            {
                return false;
            }

            reader.Read();
            this.Id = Convert.ToInt32(reader["Ident"].ToString());
            this.event_item.Id = Convert.ToInt32(reader["EventID"].ToString());
            this.description = reader["Description"].ToString();
            this.price = Convert.ToDecimal(reader["Price"].ToString());
            this.amount = Convert.ToInt32(reader["Amount"].ToString());
            this.location = reader["PlaceLocation"].ToString();
            this.category = reader["PlaceCategory"].ToString();
            this.capacity = Convert.ToInt32(reader["PlaceCapacity"].ToString());

            return true;
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Update()
        {
            string columnvalues =
                string.Format(
                    "EventID='{0}', Description='{1}', Price='{2}', Amount='{3}', PlaceLocation='{4}', PlaceCategory='{5}', PlaceCapacity='{6}'", 
                    this.event_item.Id, 
                    this.description, 
                    this.price, 
                    this.amount, 
                    this.location, 
                    this.category, 
                    this.capacity);
            string finalQuery = string.Format(UPDATESTRING, "ITEM", columnvalues, "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }

    /// <summary>
    ///     The like model.
    /// </summary>
    public class LikeModel : DBModel, IDataModelUpdate
    {
        #region Fields

        /// <summary>
        ///     The post.
        /// </summary>
        private PostModel post;

        /// <summary>
        ///     The user.
        /// </summary>
        private UserModel user;

        public LikeModel()
        {
            this.post = new PostModel();
            this.user = new UserModel();
        }

        public PostModel Post
        {
            get { return post; }
            set { post = value; }
        }

        public UserModel User
        {
            get { return user; }
            set { user = value; }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The create.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Create()
        {
            string columns = "UserID, PostID";
            string values = string.Format("'{0}','{1}'", this.user.Id, this.post.Id);
            string finalQuery = string.Format(INSERTSTRING, "LIKES", columns, values);
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        /// <summary>
        ///     The destroy.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Destroy()
        {
            string finalQuery = string.Format(DESTROYSTRING, "LIKES", "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            if (reader == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     The read.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Read()
        {
            string query = string.Format(READSTRING, "LIKES", this.Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            if (reader == null)
            {
                return false;
            }

            reader.Read();
            this.Id = Convert.ToInt32(reader["Ident"].ToString());
            this.user.Id = Convert.ToInt32(reader["UserID"].ToString());
            this.post.Id = Convert.ToInt32(reader["PostID"].ToString());

            return true;
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Update()
        {
            string columnvalues = "UserID='" + this.user.Id + "', PostID='" + this.post.Id + "'";
            string finalQuery = string.Format(UPDATESTRING, "LIKES", columnvalues, "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            if (reader == null)
            {
                return false;
        }

            return true;
        }

        #endregion

    }

    /// <summary>
    ///     The post report model.
    /// </summary>
    public class PostReportModel : DBModel, IDataModelUpdate
    {
        #region Fields

        /// <summary>
        ///     The date.
        /// </summary>
        private DateTime date;

        /// <summary>
        ///     The post.
        /// </summary>
        private PostModel post;

        /// <summary>
        ///     The reason.
        /// </summary>
        private string reason;

        /// <summary>
        ///     The status.
        /// </summary>
        private string status;

        /// <summary>
        ///     The user.
        /// </summary>
        private UserModel user;

        public PostReportModel(PostModel post, UserModel user)
        {
            this.post = post;
            this.user = user;
        }

        public UserModel User
        {
            get { return user;  }
            set { user = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public PostModel Post
        {
            get { return post; }
            set { post = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The create.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Create()
        {
            string columns = "PostID, UserID, Reason, DateTime, Status";
            string values = string.Format(
                "'{0}','{1}','{2}',to_date('{3}', 'fmmm-fmdd-yyyy hh:mi:ss'),'{4}'", 
                this.post.Id, 
                this.user.Id, 
                this.reason,
                this.date.ToString(dateFormat),
                this.status);
            string finalQuery = string.Format(INSERTSTRING, "REPORT", columns, values);
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            if (reader == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     The destroy.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Destroy()
        {
            string finalQuery = string.Format(DESTROYSTRING, "REPORT", "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        /// <summary>
        ///     The read.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Read()
        {
            string query = string.Format(READSTRING, "REPORT", this.Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            if (reader == null)
            {
                return false;
            }

            reader.Read();
            this.Id = Convert.ToInt32(reader["Ident"].ToString());
            this.post.Id = Convert.ToInt32(reader["PostID"].ToString());
            this.user.Id = Convert.ToInt32(reader["UserID"].ToString());
            this.reason = reader["Reason"].ToString();
            this.status = reader["status"].ToString();

            return true;
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Update()
        {
            string columnvalues = string.Format(
                "PostID='{0}', UserID='{1}', Reason='{2}', DateTime=to_date('{3}', 'fmmm-fmdd-yyyy hh:mi:ss'), Status='{4}'", 
                this.post.Id, 
                this.user.Id, 
                this.reason,
                this.Date.ToString(dateFormat),
                this.status);
            string finalQuery = string.Format(UPDATESTRING, "REPORT", columnvalues, "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }

    /// <summary>
    ///     The payment model.
    /// </summary>
    public class PaymentModel : DBModel, IDataModelUpdate
    {
        #region Fields

        /// <summary>
        ///     The amount.
        /// </summary>
        private int amount;

        /// <summary>
        ///     The payment type.
        /// </summary>
        private string paymentType;

        /// <summary>
        ///     The registration.
        /// </summary>
        private RegistrationModel registration;

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int ID { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The create.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Create()
        {
            string columns = "RegistrationID, Amount, PaymentType";
            string values = string.Format("'{0}','{1}','{2}'", this.registration.Id, this.amount, this.paymentType);
            string finalQuery = string.Format(INSERTSTRING, "PAYMENT", columns, values);
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        /// <summary>
        ///     The destroy.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Destroy()
        {
            string finalQuery = string.Format(DESTROYSTRING, "PAYMENT", "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        /// <summary>
        ///     The read.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Read()
        {
            string query = string.Format(READSTRING, "PAYMENT", this.Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            if (reader == null)
            {
                return false;
            }

            reader.Read();
            this.Id = Convert.ToInt32(reader["Ident"].ToString());
            this.registration.Id = Convert.ToInt32(reader["RegistrationID"].ToString());
            this.amount = Convert.ToInt32(reader["Amount"].ToString());
            this.paymentType = reader["PaymentType"].ToString();

            return true;
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Update()
        {
            string columnvalues = string.Format(
                "RegistrationID='{0}', Amount='{1}', PaymentType='{2}'", 
                this.registration.Id, 
                this.amount, 
                this.paymentType);
            string finalQuery = string.Format(UPDATESTRING, "PAYMENT", columnvalues, "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }

    /// <summary>
    ///     The reservation model.
    /// </summary>
    public class ReservationModel : DBModel, IDataModelUpdate
    {
        #region Fields

        /// <summary>
        ///     The amount.
        /// </summary>
        private int amount;

        /// <summary>
        ///     The item.
        /// </summary>
        private RentableObjectModel item;

        /// <summary>
        ///     The return date.
        /// </summary>
        private DateTime returnDate;

        /// <summary>
        ///     The user.
        /// </summary>
        private UserModel user;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RentableObjectModel"/> class.
        /// </summary>
        /// <param name="rent_item">
        /// The rent_item.
        /// </param>
        /// <param name="user_item">
        /// The user_item.
        /// </param>
        public ReservationModel(RentableObjectModel rent_item, UserModel user_item)
        {
            this.Item = rent_item;
            this.User = user_item;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        public int Amount
        {
            get
            {
                return this.amount;
            }

            set
            {
                this.amount = value;
            }
        }

        /// <summary>
        ///     Gets or sets the item.
        /// </summary>
        public RentableObjectModel Item
        {
            get
            {
                return this.item;
            }

            set
            {
                this.item = value;
            }
        }

        /// <summary>
        ///     Gets or sets the return date.
        /// </summary>
        public DateTime ReturnDate
        {
            get
            {
                return this.returnDate;
            }

            set
            {
                this.returnDate = value;
            }
        }


        /// <summary>
        ///     Gets or sets the user.
        /// </summary>
        public UserModel User
        {
            get
            {
                return this.user;
            }

            set
            {
                this.user = value;
            }
        }


        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The create.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Create()
        {
            string columns = "UserID, ItemID, ReturnDate, Amount";
            string values = string.Format(
                "'{0}','{1}',to_date('{2}', 'fmmm-fmdd-yyyy hh:mi:ss'),'{3}'", 
                this.user.Id, 
                this.item.Id,
                this.returnDate.ToString(dateFormat),
                this.amount);
            string finalQuery = string.Format(INSERTSTRING, "RESERVATION", columns, values);
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            if (reader == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     The destroy.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Destroy()
        {
            string finalQuery = string.Format(DESTROYSTRING, "RESERVATION", "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        /// <summary>
        ///     The read.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Read()
        {
            string query = string.Format(READSTRING, "RESERVATION", this.Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            if (reader == null)
            {
                return false;
            }

            reader.Read();
            this.Id = Convert.ToInt32(reader["Ident"].ToString());
            this.user.Id = Convert.ToInt32(reader["UserID"].ToString());
            this.item.Id = Convert.ToInt32(reader["ItemID"].ToString());
            this.returnDate = Convert.ToDateTime(reader["ReturnDate"].ToString());
            this.amount = Convert.ToInt32(reader["Amount"].ToString());

            return true;
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Update()
        {
            string columnvalues = string.Format(
                "UserID='{0}', ItemID='{1}', ReturnDate=to_date('{2}', 'fmmm-fmdd-yyyy hh:mi:ss'), Amount='{3}'", 
                this.user.Id, 
                this.item.Id,
                this.returnDate.ToString(dateFormat), 
                this.amount);
            string finalQuery = string.Format(
                UPDATESTRING, 
                "RESERVATION", 
                columnvalues, 
                string.Format("'{0}'", this.Id));
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }
}