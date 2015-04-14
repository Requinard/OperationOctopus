using System;
using Oracle.DataAccess.Client;

namespace ICT4EVENT
{
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
}