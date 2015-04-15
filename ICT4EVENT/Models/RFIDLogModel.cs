using System;

namespace ICT4EVENT
{
    /// <summary>
    ///     The rfid log model.
    /// </summary>
    public class RFIDLogModel : DBModel, IDataModelUpdate
    {
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
            var columns = "UserID,EventID,InOrOut";
            var values = "'" + user.Id + "','" + event_item.Id + "','" + InOrOut + "'";
            var finalQuery = string.Format(INSERTSTRING, "RFIDLOG", columns, values);
            var reader = DBManager.QueryDB(finalQuery);

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
            var finalQuery = string.Format(DESTROYSTRING, "RFIDLOG", "'" + Id + "'");
            var reader = DBManager.QueryDB(finalQuery);

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
            var query = string.Format(READSTRING, "RFIDLOG", Id);
            var reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return false;
            }

            reader.Read();
            Id = Convert.ToInt32(reader["Ident"].ToString());
            user.Id = Convert.ToInt32(reader["UserID"].ToString());
            event_item.Id = Convert.ToInt32(reader["EventID"].ToString());
            InOrOut = reader["InOrOut"].ToString();

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
            var columnvalues = string.Format("UserID='{0}', EventID='{1}', InOrOut='{2}'", user.Id, event_item.Id,
                InOrOut);
            var finalQuery = string.Format(UPDATESTRING, "RFIDLOG", columnvalues, "'" + Id + "'");
            var reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }
}