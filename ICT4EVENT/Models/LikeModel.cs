using System;

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
            post = new PostModel();
            user = new UserModel();
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
            var columns = "UserID, PostID";
            var values = string.Format("'{0}','{1}'", user.Id, post.Id);
            var finalQuery = string.Format(INSERTSTRING, "LIKES", columns, values);
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
            var finalQuery = string.Format(DESTROYSTRING, "LIKES", "'" + Id + "'");
            var reader = DBManager.QueryDB(finalQuery);

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
            var query = string.Format(READSTRING, "LIKES", Id);
            var reader = DBManager.QueryDB(query);
            if (reader == null)
            {
                return false;
            }

            reader.Read();
            Id = Convert.ToInt32(reader["Ident"].ToString());
            user.Id = Convert.ToInt32(reader["UserID"].ToString());
            post.Id = Convert.ToInt32(reader["PostID"].ToString());

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
            var columnvalues = "UserID='" + user.Id + "', PostID='" + post.Id + "'";
            var finalQuery = string.Format(UPDATESTRING, "LIKES", columnvalues, "'" + Id + "'");
            var reader = DBManager.QueryDB(finalQuery);

            if (reader == null)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}