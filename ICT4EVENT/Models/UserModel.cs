using System;
using System.Collections.Generic;

namespace ICT4EVENT
{
    using Oracle.DataAccess.Client;

    /// <summary>
    ///     The user model.
    /// </summary>
    public class UserModel : DBModel, IDataModelUpdate
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserModel" /> class.
        /// </summary>
        public UserModel()
        {
            level = 1;
            RegistrationList = new List<RegistrationModel>();
        }

        public UserModel(int ID)
        {
            this.Id = ID;

            this.Read();
        }

        #endregion

        #region Fields

        /// <summary>
        ///     The registration list.
        /// </summary>
        public List<RegistrationModel> RegistrationList;

        /// <summary>
        ///     The rfi dnumber.
        /// </summary>
        private string RFIDnumber;

        /// <summary>
        ///     The address.
        /// </summary>
        private string address;

        /// <summary>
        ///     The email.
        /// </summary>
        private string email;

        /// <summary>
        ///     The level.
        /// </summary>
        private int level;

        /// <summary>
        ///     The password.
        /// </summary>
        private string password;

        /// <summary>
        ///     The registrations.
        /// </summary>
        private List<RegistrationModel> registrations;

        /// <summary>
        ///     The telephonenumber.
        /// </summary>
        private string telephonenumber;

        /// <summary>
        ///     The username.
        /// </summary>
        private string username;

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        public string Address
        {
            get { return address; }

            set { address = value; }
        }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        public string Email
        {
            get { return email; }

            set { email = value; }
        }

        /// <summary>
        ///     Gets or sets the level.
        /// </summary>
        public int Level
        {
            get { return level; }

            set { level = value; }
        }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        public string Password
        {
            get { return password; }

            // Automatically hashes a new string when it's set
            set { password = value; }
        }

        /// <summary>
        ///     Gets or sets the rfi dnumber.
        /// </summary>
        public string RfiDnumber
        {
            get { return RFIDnumber; }

            set { RFIDnumber = value; }
        }

        /// <summary>
        ///     Gets or sets the telephonenumber.
        /// </summary>
        public string Telephonenumber
        {
            get { return telephonenumber; }

            set { telephonenumber = value; }
        }

        /// <summary>
        ///     Gets or sets the username.
        /// </summary>
        public string Username
        {
            get { return username; }

            set { username = value; }
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
            string columns = "RFIDnumber, Address, Username, Email, TelephoneNumber, UserPassword, UserLevel";
            string values = string.Format(
                "'{0}','{1}','{2}','{3}','{4}','{5}','{6}'",
                RFIDnumber,
                address,
                username,
                email,
                telephonenumber,
                password,
                level);
            string finalQuery = string.Format(INSERTSTRING, "USERS", columns, values);
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
            string finalQuery = string.Format(DESTROYSTRING, "USERS", "'" + Id + "'");
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
            string query = string.Format(READSTRING, "USERS", Id);
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
            this.RFIDnumber = reader["RFIDnumber"].ToString();
            this.address = reader["Address"].ToString();
            this.username = reader["Username"].ToString();
            this.email = reader["Email"].ToString();
            this.telephonenumber = reader["TelephoneNumber"].ToString();
            this.password = reader["UserPassword"].ToString();
            this.level = Convert.ToInt32(reader["UserLevel"].ToString());
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
                    "RFIDnumber='{0}', Address='{1}', Username='{2}', Email='{3}', TelephoneNumber='{4}', UserPassword='{5}'",
                    RFIDnumber,
                    address,
                    username,
                    email,
                    telephonenumber,
                    password);
            string finalQuery = string.Format(UPDATESTRING, "USERS", columnvalues, "'" + Id + "'");
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