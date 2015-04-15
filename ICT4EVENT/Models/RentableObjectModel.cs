using System;

namespace ICT4EVENT
{
    using Oracle.DataAccess.Client;

    /// <summary>
    ///     The rentable object model.
    /// </summary>
    public class RentableObjectModel : DBModel, IDataModelUpdate
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RentableObjectModel" /> class.
        /// </summary>
        /// <param name="event_item">
        ///     The event_item.
        /// </param>
        public RentableObjectModel(EventModel event_item)
        {
            this.event_item = event_item;
        }

        #endregion

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

        #region Public Properties

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        public int Amount
        {
            get { return amount; }

            set { amount = value; }
        }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description
        {
            get { return description; }

            set { description = value; }
        }

        /// <summary>
        ///     Gets or sets the kind of object.
        /// </summary>
        public string ObjectType
        {
            get { return objectType; }

            set { objectType = value; }
        }

        /// <summary>
        ///     Gets the event item.
        /// </summary>
        public EventModel EventItem
        {
            get { return event_item; }
        }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        public decimal Price
        {
            get { return price; }

            set { price = value; }
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
            var columns = "EventID, Description, Price, Amount, TypeOfObject, ItemType";
            var values = string.Format("'{0}','{1}','{2}','{3}','{4}', 'RentableObject'", event_item.Id, description,
                price, amount, objectType);
            var finalQuery = string.Format(INSERTSTRING, "ITEM", columns, values);
            var reader = DBManager.QueryDB(finalQuery);

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
            var finalQuery = string.Format(DESTROYSTRING, "ITEM", "'" + Id + "'");
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
            var query = string.Format(READSTRING, "ITEM", Id);
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
            this.event_item.Id = Convert.ToInt32(reader["EventID"].ToString());
            this.description = reader["Description"].ToString();
            this.objectType = reader["TypeOfObject"].ToString();
            this.price = Convert.ToDecimal(reader["Price"].ToString());
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
                "EventID='{0}', Description='{1}', Price='{2}', Amount='{3}', TypeOfObject='{4}'",
                event_item.Id,
                description,
                price,
                amount,
                objectType);
            var finalQuery = string.Format(UPDATESTRING, "ITEM", columnvalues, "'" + Id + "'");
            var reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }
}