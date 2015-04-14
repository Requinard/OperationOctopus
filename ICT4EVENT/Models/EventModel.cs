using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;

namespace ICT4EVENT
{
    /// <summary>
    ///     The event model.
    /// </summary>
    public class EventModel : DBModel, IDataModelUpdate
    {
        #region Fields

        /// <summary>
        ///     The registrations list.
        /// </summary>
        private readonly List<RegistrationModel> registrationsList;

        /// <summary>
        ///     The description.
        /// </summary>
        private string description;

        /// <summary>
        ///     The end date.
        /// </summary>
        private DateTime endDate;

        /// <summary>
        ///     The location.
        /// </summary>
        private string location;

        /// <summary>
        ///     The name.
        /// </summary>
        private string name;

        /// <summary>
        ///     The start date.
        /// </summary>
        private DateTime startDate;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="EventModel" /> class.
        /// </summary>
        public EventModel()
        {
            this.registrationsList = new List<RegistrationModel>();
        }

        #endregion

        #region Public Properties

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
        ///     Gets or sets the end date.
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }

            set
            {
                this.endDate = value;
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
        ///     Gets or sets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        /// <summary>
        ///     Gets the registrations list.
        /// </summary>
        public List<RegistrationModel> RegistrationsList
        {
            get
            {
                return this.registrationsList;
            }
        }

        /// <summary>
        ///     Gets or sets the start date.
        /// </summary>
        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }

            set
            {
                this.startDate = value;
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
            string columns = "EventName, EventLocation, Description, BeginTime, EndTime";
            string values = string.Format("'{0}','{1}','{2}',to_date('{3}', 'fmmm-fmdd-yyyy hh:mi:ss'),to_date('{4}', 'fmMM-fmDD-yyyy hh24:mi:ss')", this.name, this.location, this.description, this.startDate.ToString(dateFormat), this.endDate.ToString(dateFormat));
            string finalQuery = string.Format(INSERTSTRING, "EVENT", columns, values);
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
            string query = string.Format(DESTROYSTRING, "EVENT", this.Id);
            OracleDataReader reader = DBManager.QueryDB(query);

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
            string query = string.Format(READSTRING, "EVENT", this.Id);
            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return false;
            }

            reader.Read();
            this.Id = Convert.ToInt32(reader["Ident"].ToString());
            this.name = reader["EventName"].ToString();
            this.location = reader["EventLocation"].ToString();
            this.description = reader["Description"].ToString();
            this.startDate = Convert.ToDateTime(reader["BeginTime"].ToString());
            this.endDate = Convert.ToDateTime(reader["EndTime"].ToString());

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
            string columnvalues = string.Format("EventName='{0}', EventLocation='{1}', Description='{2}', BeginTime=to_date('{3}', 'fmmm-fmdd-yyyy hh:mi:ss'), EndTime=to_date('{4}', 'fmmm-fmdd-yyyy hh:mi:ss')", this.name, this.location, this.description, this.startDate.ToString(dateFormat), this.endDate.ToString(dateFormat));
            string finalQuery = string.Format(UPDATESTRING, "EVENT", columnvalues, "'" + this.Id + "'");

            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            if (reader == null)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}