using System;
using Oracle.DataAccess.Client;

namespace ICT4EVENT
{
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

        public LikeModel()
        {
            this.post = new PostModel();
            this.user = new UserModel();
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
            string values = string.Format("'{0}','{1}'", this.user.Id, this.post.Id);
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
            string finalQuery = string.Format(DESTROYSTRING, "LIKES", "'" + this.Id + "'");
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
            string query = string.Format(READSTRING, "LIKES", this.Id);
            OracleDataReader reader = DBManager.QueryDB(query);
            if (reader == null)
            {
                return false;
            }

            reader.Read();
            this.Id = Convert.ToInt32(reader["Ident"].ToString());
            this.user.Id = Convert.ToInt32(reader["UserID"].ToString());
            this.post.Id = Convert.ToInt32(reader["PostID"].ToString());

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
            string columnvalues = "UserID='" + this.user.Id + "', PostID='" + this.post.Id + "'";
            string finalQuery = string.Format(UPDATESTRING, "LIKES", columnvalues, "'" + this.Id + "'");
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