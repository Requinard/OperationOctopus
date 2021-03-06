using System;

namespace ICT4EVENT
{
    using System.Windows.Forms.VisualStyles;

    using Oracle.DataAccess.Client;

    /// <summary>
    ///     The registration model.
    /// </summary>
    public class RegistrationModel : DBModel, IDataModelUpdate
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RegistrationModel" /> class.
        /// </summary>
        /// <param name="user">
        ///     The user.
        /// </param>
        /// <param name="event_item">
        ///     The event_item.
        /// </param>
        public RegistrationModel(UserModel user, EventModel event_item)
        {
            this.user = user;
            this.event_item = event_item;
        }

        #endregion

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

        #region Public Properties

        public RegistrationModel()
        {
            event_item = new EventModel();
            user = new UserModel();
        }

        public RegistrationModel(int ID)
        {
            event_item = new EventModel();
            user = new UserModel();
            this.Id = ID;

            this.Read();
        }

        /// <summary>
        ///     Gets the event item.
        /// </summary>
        public EventModel EventItem
        {
            get { return event_item; }
        }

        /// <summary>
        ///     Gets the user.
        /// </summary>
        public UserModel User
        {
            get { return user; }
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
            string values = string.Format("'{0}','{1}'", user.Id, event_item.Id);
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
            string finalQuery = string.Format(DESTROYSTRING, "REGISTRATION", "'" + Id + "'");
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
            string query = string.Format(READSTRING, "REGISTRATION", Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            if (reader == null)
            {
                return false;
            }

            reader.Read();
            this.ReadFromReader(reader);

            return true;
        }

        public void ReadFromReader(OracleDataReader reader)
        {
            this.Id = Convert.ToInt32(reader["Ident"].ToString());
            this.user.Id = Convert.ToInt32(reader["UserID"].ToString());
            user.Read();
            this.event_item.Id = Convert.ToInt32(reader["EventID"].ToString());
            event_item.Read();
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Update()
        {
            string columnvalues = "UserID='" + User.Id + "', EventID='" + event_item.Id + "'";
            string finalQuery = string.Format(UPDATESTRING, "REGISTRATION", columnvalues, "'" + Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }
}