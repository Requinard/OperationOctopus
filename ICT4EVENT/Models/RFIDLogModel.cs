namespace ICT4EVENT
{
    using System;

    using Oracle.DataAccess.Client;

    /// <summary>
    ///     The rfid log model.
    /// </summary>
    public class RFIDLogModel : DBModel, IDataModelUpdate
    {
        public EventModel EventItem
        {
            get
            {
                return this.event_item;
            }
            set
            {
                this.event_item = value;
            }
        }

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

        public string InOrOut1
        {
            get
            {
                return this.InOrOut;
            }
            set
            {
                this.InOrOut = value;
            }
        }

        public string DateFormat
        {
            get
            {
                return this.dateFormat;
            }
            set
            {
                this.dateFormat = value;
            }
        }

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RFIDLogModel" /> class.
        /// </summary>
        /// <param name="user">
        ///     The user.
        /// </param>
        /// <param name="event_item">
        ///     The event_item.
        /// </param>
        public RFIDLogModel(UserModel user, EventModel event_item)
        {
            this.user = user;
            this.event_item = event_item;
        }

        public RFIDLogModel()
        {
            this.user = new UserModel();
            this.event_item = new EventModel();
        }

        public RFIDLogModel(int ID)
        {
            this.Id = ID;
            this.user = new UserModel();
            this.event_item = new EventModel();

            this.Read();
        }

        #endregion

        #region Fields

        /// <summary>
        ///     The event_item.
        /// </summary>
        private  EventModel event_item;

        /// <summary>
        ///     The user.
        /// </summary>
        private  UserModel user;


        /// <summary>
        ///     The in or out.
        /// </summary>
        private string InOrOut;

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
            this.InOrOut = reader["InOrOut"].ToString();
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
                "UserID='{0}', EventID='{1}', InOrOut='{2}'",
                this.user.Id,
                this.event_item.Id,
                this.InOrOut);
            string finalQuery = string.Format(UPDATESTRING, "RFIDLOG", columnvalues, "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }
}