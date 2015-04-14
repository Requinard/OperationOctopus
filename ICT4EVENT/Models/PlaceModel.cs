using System;
using Oracle.DataAccess.Client;

namespace ICT4EVENT
{
    /// <summary>
    ///     The place model.
    /// </summary>
    public class PlaceModel : DBModel, IDataModelUpdate
    {
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

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaceModel"/> class.
        /// </summary>
        /// <param name="event_item">
        /// The event_item.
        /// </param>
        public PlaceModel(EventModel event_item)
        {
            this.event_item = event_item;
        }

        #endregion

        #region Public Properties

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
        ///     Gets or sets the capacity.
        /// </summary>
        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                this.capacity = value;
            }
        }

        /// <summary>
        ///     Gets or sets the category.
        /// </summary>
        public string Category
        {
            get
            {
                return this.category;
            }

            set
            {
                this.category = value;
            }
        }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                this.description = value;
            }
        }

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
        ///     Gets or sets the location.
        /// </summary>
        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                this.location = value;
            }
        }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
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
            string columns = "EventID, Description, Price, Amount, PlaceLocation, PlaceCategory, PlaceCapacity, ItemType";
            string values = string.Format(
                "'{0}','{1}','{2}','{3}','{4}','{5}','{6}', 'Place'", 
                this.event_item.Id, 
                this.description, 
                this.price, 
                this.amount, 
                this.location, 
                this.category, 
                this.capacity);
            string finalQuery = string.Format(INSERTSTRING, "ITEM", columns, values);
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

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
            string finalQuery = string.Format(DESTROYSTRING, "ITEM", "'" + this.Id + "'");
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
            string query = string.Format(READSTRING, "ITEM", this.Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            if (reader == null)
            {
                return false;
            }

            reader.Read();
            this.Id = Convert.ToInt32(reader["Ident"].ToString());
            this.event_item.Id = Convert.ToInt32(reader["EventID"].ToString());
            this.description = reader["Description"].ToString();
            this.price = Convert.ToDecimal(reader["Price"].ToString());
            this.amount = Convert.ToInt32(reader["Amount"].ToString());
            this.location = reader["PlaceLocation"].ToString();
            this.category = reader["PlaceCategory"].ToString();
            this.capacity = Convert.ToInt32(reader["PlaceCapacity"].ToString());

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
            string columnvalues =
                string.Format(
                    "EventID='{0}', Description='{1}', Price='{2}', Amount='{3}', PlaceLocation='{4}', PlaceCategory='{5}', PlaceCapacity='{6}'", 
                    this.event_item.Id, 
                    this.description, 
                    this.price, 
                    this.amount, 
                    this.location, 
                    this.category, 
                    this.capacity);
            string finalQuery = string.Format(UPDATESTRING, "ITEM", columnvalues, "'" + this.Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }
}