namespace ICT4EVENT
{
    using System;

    using Oracle.DataAccess.Client;

    /// <summary>
    ///     The post model.
    /// </summary>
    public class PostModel : DBModel, IDataModelUpdate
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
        ///     The content.
        /// </summary>
        private string content;

        /// <summary>
        ///     The date posted.
        /// </summary>
        private DateTime datePosted;

        /// <summary>
        ///     The parent.
        /// </summary>
        private PostModel parent;

        /// <summary>
        ///     The path to file.
        /// </summary>
        private string pathToFile;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PostModel" /> class.
        /// </summary>
        /// <param name="user">
        ///     The user.
        /// </param>
        /// <param name="event_item">
        ///     The event_item.
        /// </param>
        public PostModel(UserModel user, EventModel event_item)
        {
            this.user = user;
            this.event_item = event_item;
        }

        public PostModel()
        {
            this.user = new UserModel();
            this.event_item = new EventModel();
        }

        public PostModel(int ID)
        {
            this.Id = ID;
            this.user = new UserModel();
            this.event_item = new EventModel();
            this.Read();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the content.
        /// </summary>
        public string Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;
            }
        }

        /// <summary>
        ///     Gets or sets the date posted.
        /// </summary>
        public DateTime DatePosted
        {
            get
            {
                return this.datePosted;
            }

            set
            {
                this.datePosted = value;
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
        ///     Gets or sets the parent.
        /// </summary>
        public PostModel Parent
        {
            get
            {
                return this.parent;
            }

            set
            {
                this.parent = value;
            }
        }

        /// <summary>
        ///     Gets or sets the path to file.
        /// </summary>
        public string PathToFile
        {
            get
            {
                return this.pathToFile;
            }

            set
            {
                this.pathToFile = value;
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
            var columns = "";
            var values = "";
            if (this.parent != null)
            {
                columns = "UserID, EventID, ReplyID, PostContent, PathToFile, DATETIME";

                values = string.Format(
                    "'{0}','{1}','{2}','{3}','{4}',,to_date('{5}', 'fmmm-fmdd-yyyy hh:mi:ss')'",
                    this.user.Id,
                    this.event_item.Id,
                    this.parent.Id,
                    this.content,
                    this.pathToFile,
                    this.datePosted.ToString(this.dateFormat));
            }
            else
            {
                columns = "UserID, EventID, PostContent, PathToFile, DATETIME";

                values = string.Format(
                    "'{0}','{1}','{2}','{3}',to_date('{4}', 'fmmm-fmdd-yyyy hh:mi:ss')",
                    this.user.Id,
                    this.event_item.Id,
                    this.content,
                    this.pathToFile,
                    this.datePosted.ToString(this.dateFormat));
            }

            var finalQuery = string.Format(INSERTSTRING, "POST", columns, values);
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
            var finalQuery = string.Format(DESTROYSTRING, "POST", "'" + this.Id + "'");
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
            var query = string.Format(READSTRING, "POST", this.Id);
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
            this.User.Id = Convert.ToInt32(reader["UserID"].ToString());
            user.Read();
            this.event_item.Id = Convert.ToInt32(reader["EventID"].ToString());
            EventItem.Read();
            try
            {
                this.parent.Id = Convert.ToInt32(reader["ReplyID"].ToString());
                parent.Read();
            }
            catch (Exception)
            {
                this.parent = null;
            }
            this.content = reader["PostContent"].ToString();
            this.pathToFile = reader["PathToFile"].ToString();
            this.datePosted = Convert.ToDateTime(reader["DATETIME"].ToString());
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Update()
        {
            var columnvalues = "";
            if (this.parent != null)
            {
                columnvalues =
                    string.Format(
                        "UserID='{0}', EventID='{1}', ReplyID='{2}', PostContent='{3}', PathToFile='{4}', DATETIME=to_date('{5}', 'fmmm-fmdd-yyyy hh:mi:ss')",
                        this.user.Id,
                        this.event_item.Id,
                        this.parent.Id,
                        this.content,
                        this.pathToFile,
                        this.datePosted.ToString(this.dateFormat));
            }
            else
            {
                columnvalues =
                    string.Format(
                        "UserID='{0}', EventID='{1}', PostContent='{2}', PathToFile='{3}', DATETIME=to_date('{4}', 'fmmm-fmdd-yyyy hh:mi:ss')",
                        this.user.Id,
                        this.event_item.Id,
                        this.content,
                        this.pathToFile,
                        this.datePosted.ToString(this.dateFormat));
            }
            var finalQuery = string.Format(UPDATESTRING, "POST", columnvalues, "'" + this.Id + "'");
            var reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }
}