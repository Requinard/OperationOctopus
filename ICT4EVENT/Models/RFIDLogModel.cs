using System;
using Oracle.DataAccess.Client;

namespace ICT4EVENT
{
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
}