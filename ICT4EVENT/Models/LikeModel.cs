using System;

namespace ICT4EVENT
{
    using Oracle.DataAccess.Client;

    /// <summary>
    ///     The like model.
    /// </summary>
    public class LikeModel : DBModel, IDataModelUpdate
    {
        #region Fields

        /// <summary>
        ///     The post.
        /// </summary>
        private PostModel post;

        /// <summary>
        ///     The user.
        /// </summary>
        private UserModel user;

        public LikeModel(PostModel post, UserModel user)
        {
            this.post = post;
            this.user = user;
        }

        public LikeModel()
        {
            post = new PostModel();
            User = new UserModel();
        }

        public LikeModel(int ID)
        {
            this.Id = ID;

            post = new PostModel();
            User = new UserModel();

            this.Read();
        }

        public PostModel Post
        {
            get { return post; }
            set { post = value; }
        }

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
            string columns = "UserID, PostID";
            string values = string.Format("'{0}','{1}'", user.Id, post.Id);
            string finalQuery = string.Format(INSERTSTRING, "LIKES", columns, values);
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
            string finalQuery = string.Format(DESTROYSTRING, "LIKES", "'" + Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

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
            string query = string.Format(READSTRING, "LIKES", Id);
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
            //this.user.Read();

            this.post.Id = Convert.ToInt32(reader["PostID"].ToString());
            //this.post.Read();
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Update()
        {
            string columnvalues = "UserID='" + user.Id + "', PostID='" + post.Id + "'";
            string finalQuery = string.Format(UPDATESTRING, "LIKES", columnvalues, "'" + Id + "'");
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