using System;

namespace ICT4EVENT
{
    using Oracle.DataAccess.Client;

    /// <summary>
    ///     The reservation model.
    /// </summary>
    public class RentableReservationModel : DBModel, IDataModelUpdate
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RentableObjectModel" /> class.
        /// </summary>
        /// <param name="rentRentable">
        ///     The rentRentable.
        /// </param>
        /// <param name="user_item">
        ///     The user_item.
        /// </param>
        public RentableReservationModel(RentableObjectModel rentRentable, UserModel user_item, int amount)
        {
            this.Rentable = rentRentable;
            User = user_item;
            Amount = amount;
        }

        public RentableReservationModel()
        {
            this.rentable = new RentableObjectModel();
            user = new UserModel();
        }

        public RentableReservationModel(int ID)
        {
            this.Id = ID;

            this.rentable = new RentableObjectModel();
            user = new UserModel();

            this.Read();
        }
        #endregion

        #region Fields

        /// <summary>
        ///     The amount.
        /// </summary>
        private int amount;

        /// <summary>
        ///     The rentable.
        /// </summary>
        private PlaceModel place;

        /// <summary>
        ///     The return date.
        /// </summary>
        private DateTime returnDate;

        /// <summary>
        ///     The user.
        /// </summary>
        private UserModel user;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        public int Amount
        {
            get { return amount; }

            set { amount = value; }
        }

        public PlaceModel Place
        {
            get
            {
                return this.place;
            }
            set
            {
                this.place = value;
            }
        }

        /// <summary>
        ///     Gets or sets the return date.
        /// </summary>
        public DateTime ReturnDate
        {
            get { return returnDate; }

            set { returnDate = value; }
        }


        /// <summary>
        ///     Gets or sets the user.
        /// </summary>
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
            string columns = "UserID, ItemID, ReturnDate, Amount";
            string values = string.Format(
                "'{0}','{1}',to_date('{2}', 'fmmm-fmdd-yyyy hh:mi:ss'),'{3}'",
                user.Id,
                this.place.Id,
                returnDate.ToString(dateFormat),
                amount);
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
            string finalQuery = string.Format(DESTROYSTRING2, "RESERVATION", "'" + this.place.Id + "'");
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
            string query = string.Format(READSTRING, "RESERVATION", Id);
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
            this.place.Id = Convert.ToInt32(reader["ItemID"].ToString());
            this.place.Read();
            this.returnDate = Convert.ToDateTime(reader["ReturnDate"].ToString());
            this.amount = Convert.ToInt32(reader["Amount"].ToString());
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
                user.Id,
                this.place.Id,
                returnDate.ToString(dateFormat),
                amount);
            string finalQuery = string.Format(
                UPDATESTRING,
                "RESERVATION",
                columnvalues,
                string.Format("'{0}'", Id));
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }
}
