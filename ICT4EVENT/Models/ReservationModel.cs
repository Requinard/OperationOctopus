using System;
using Oracle.DataAccess.Client;

namespace ICT4EVENT
{
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