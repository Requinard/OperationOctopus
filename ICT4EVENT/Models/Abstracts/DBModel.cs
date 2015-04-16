// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DBModel.cs" company="">
//   
// </copyright>
// <summary>
//   The db model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ICT4EVENT
{
    using System;
    using System.Collections;

    /// <summary>
    ///     The db model.
    /// </summary>
    public abstract class DBModel :IEqualityComparer
    {
        // Destroys the corresponding row in the table. {0} is the table name, {1} is the table id

        #region Public Properties

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        #endregion

        // Creates a new row. {0} is table name, {1} is columns and {2} is values

        #region Constants

        protected string dateFormat = "MM-dd-yyyy hh:mm:ss";

        /// <summary>
        ///     The destroystring.
        /// </summary>
        protected const string DESTROYSTRING = "DELETE FROM {0} WHERE ident={1}";

        /// <summary>
        ///     The insertstring.
        /// </summary>
        protected const string INSERTSTRING = "INSERT INTO {0} ({1}) VALUES ({2})";

        // Updates a row in the database. {0} is table name, {1} is columns and values and {2} is the row id

        // Reads the corresponding row from the database. {0} is table name, {1} is the row id
        /// <summary>
        ///     The readstring.
        /// </summary>
        protected const string READSTRING = "SELECT * FROM {0} WHERE ident={1}";

        /// <summary>
        ///     The updatestring.
        /// </summary>
        protected const string UPDATESTRING = "UPDATE {0} SET {1} WHERE ident={2}";

        #endregion

        public bool Equals(object x, object y)
        {
            DBModel xModel = (DBModel)x;
            DBModel yModel = (DBModel)y;

            Type xType = x.GetType();
            Type yType = y.GetType();

            if (xType != yType) return false;

            return xModel.Id == yModel.Id;
        }

        public int GetHashCode(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}