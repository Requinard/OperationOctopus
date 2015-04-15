using System;

namespace ICT4EVENT
{
    /// <summary>
    ///     The place model.
    /// </summary>
    public class PlaceModel : DBModel, IDataModelUpdate
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PlaceModel" /> class.
        /// </summary>
        /// <param name="event_item">
        ///     The event_item.
        /// </param>
        public PlaceModel(EventModel event_item)
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
        ///     Gets or sets the capacity.
        /// </summary>
        public int Capacity
        {
            get { return capacity; }

            set { capacity = value; }
        }

        /// <summary>
        ///     Gets or sets the category.
        /// </summary>
        public string Category
        {
            get { return category; }

            set { category = value; }
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
        ///     Gets the event item.
        /// </summary>
        public EventModel EventItem
        {
            get { return event_item; }
        }

        /// <summary>
        ///     Gets or sets the location.
        /// </summary>
        public string Location
        {
            get { return location; }

            set { location = value; }
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
            var columns = "EventID, Description, Price, Amount, PlaceLocation, PlaceCategory, PlaceCapacity, ItemType";
            var values = string.Format(
                "'{0}','{1}','{2}','{3}','{4}','{5}','{6}', 'Place'",
                event_item.Id,
                description,
                price,
                amount,
                location,
                category,
                capacity);
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
            Id = Convert.ToInt32(reader["Ident"].ToString());
            event_item.Id = Convert.ToInt32(reader["EventID"].ToString());
            description = reader["Description"].ToString();
            price = Convert.ToDecimal(reader["Price"].ToString());
            amount = Convert.ToInt32(reader["Amount"].ToString());
            location = reader["PlaceLocation"].ToString();
            category = reader["PlaceCategory"].ToString();
            capacity = Convert.ToInt32(reader["PlaceCapacity"].ToString());

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
            var columnvalues =
                string.Format(
                    "EventID='{0}', Description='{1}', Price='{2}', Amount='{3}', PlaceLocation='{4}', PlaceCategory='{5}', PlaceCapacity='{6}'",
                    event_item.Id,
                    description,
                    price,
                    amount,
                    location,
                    category,
                    capacity);
            var finalQuery = string.Format(UPDATESTRING, "ITEM", columnvalues, "'" + Id + "'");
            var reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }
}