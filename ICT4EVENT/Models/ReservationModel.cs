using System;

namespace ICT4EVENT
{
    using Oracle.DataAccess.Client;

    /// <summary>
    ///     The reservation model.
    /// </summary>
    public class ReservationModel : DBModel, IDataModelUpdate
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RentableObjectModel" /> class.
        /// </summary>
        /// <param name="rent_item">
        ///     The rent_item.
        /// </param>
        /// <param name="user_item">
        ///     The user_item.
        /// </param>
        public ReservationModel(RentableObjectModel rent_item, UserModel user_item)
        {
            Item = rent_item;
            User = user_item;
        }

        public ReservationModel()
        {
            item = new RentableObjectModel();
            user = new UserModel();
        }

        public ReservationModel(int ID)
        {
            this.Id = ID;

            item = new RentableObjectModel();
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

        #region Properties

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        public int Amount
        {
            get { return amount; }

            set { amount = value; }
        }

        /// <summary>
        ///     Gets or sets the item.
        /// </summary>
        public RentableObjectModel Item
        {
            get { return item; }

            set { item = value; }
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
            var columns = "UserID, ItemID, ReturnDate, Amount";
            var values = string.Format(
                "'{0}','{1}',to_date('{2}', 'fmmm-fmdd-yyyy hh:mi:ss'),'{3}'",
                user.Id,
                item.Id,
                returnDate.ToString(dateFormat),
                amount);
            var finalQuery = string.Format(INSERTSTRING, "RESERVATION", columns, values);
            var reader = DBManager.QueryDB(finalQuery);

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
            var finalQuery = string.Format(DESTROYSTRING, "RESERVATION", "'" + Id + "'");
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
            var query = string.Format(READSTRING, "RESERVATION", Id);
            var reader = DBManager.QueryDB(query);
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
            this.item.Id = Convert.ToInt32(reader["ItemID"].ToString());
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
            var columnvalues = string.Format(
                "UserID='{0}', ItemID='{1}', ReturnDate=to_date('{2}', 'fmmm-fmdd-yyyy hh:mi:ss'), Amount='{3}'",
                user.Id,
                item.Id,
                returnDate.ToString(dateFormat),
                amount);
            var finalQuery = string.Format(
                UPDATESTRING,
                "RESERVATION",
                columnvalues,
                string.Format("'{0}'", Id));
            var reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }
}