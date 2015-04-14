using System;

namespace ICT4EVENT
{
    /// <summary>
    ///     The post report model.
    /// </summary>
    public class PostReportModel : DBModel, IDataModelUpdate
    {
        #region Fields

        /// <summary>
        ///     The date.
        /// </summary>
        private DateTime date;

        /// <summary>
        ///     The post.
        /// </summary>
        private PostModel post;

        /// <summary>
        ///     The reason.
        /// </summary>
        private string reason;

        /// <summary>
        ///     The status.
        /// </summary>
        private string status;

        /// <summary>
        ///     The user.
        /// </summary>
        private UserModel user;

        public PostReportModel(PostModel post, UserModel user)
        {
            this.post = post;
            this.user = user;
        }

        public UserModel User
        {
            get { return user; }
            set { user = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public PostModel Post
        {
            get { return post; }
            set { post = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
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
            var columns = "PostID, UserID, Reason, DateTime, Status";
            var values = string.Format(
                "'{0}','{1}','{2}',to_date('{3}', 'fmmm-fmdd-yyyy hh:mi:ss'),'{4}'",
                post.Id,
                user.Id,
                reason,
                date.ToString(dateFormat),
                status);
            var finalQuery = string.Format(INSERTSTRING, "REPORT", columns, values);
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
            var finalQuery = string.Format(DESTROYSTRING, "REPORT", "'" + Id + "'");
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
            var query = string.Format(READSTRING, "REPORT", Id);
            var reader = DBManager.QueryDB(query);
            if (reader == null)
            {
                return false;
            }

            reader.Read();
            Id = Convert.ToInt32(reader["Ident"].ToString());
            post.Id = Convert.ToInt32(reader["PostID"].ToString());
            user.Id = Convert.ToInt32(reader["UserID"].ToString());
            reason = reader["Reason"].ToString();
            status = reader["status"].ToString();

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
            var columnvalues = string.Format(
                "PostID='{0}', UserID='{1}', Reason='{2}', DateTime=to_date('{3}', 'fmmm-fmdd-yyyy hh:mi:ss'), Status='{4}'",
                post.Id,
                user.Id,
                reason,
                Date.ToString(dateFormat),
                status);
            var finalQuery = string.Format(UPDATESTRING, "REPORT", columnvalues, "'" + Id + "'");
            var reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }
}