using System;

namespace ICT4EVENT
{
    using Oracle.DataAccess.Client;

    /// <summary>
    ///     The payment model.
    /// </summary>
    public class PaymentModel : DBModel, IDataModelUpdate
    {
        #region Public Properties

        public PaymentModel(int id)
        {
            this.ID = id;
            Registration = new RegistrationModel();
            this.Read();
        }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int ID { get; set; }

        #endregion

        public PaymentModel(RegistrationModel registration)
        {
            this.registration = registration;
        }

        #region Fields

        /// <summary>
        ///     The amount.
        /// </summary>
        private decimal amount;

        /// <summary>
        ///     The payment type.
        /// </summary>
        private string paymentType;

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string PaymentType
        {
            get { return paymentType; }
            set { paymentType = value; }
        }

        public RegistrationModel Registration
        {
            get { return registration; }
            set { registration = value; }
        }

        /// <summary>
        ///     The registration.
        /// </summary>
        private RegistrationModel registration;

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
            string columns = "RegistrationID, DATETIME, Amount, PaymentType";
            string values = string.Format("'{0}',to_date('{1}', 'fmdd-fmmm-yyyy hh:mi:ss'),'{2}','{3}'", registration.Id, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), amount, paymentType);
            string finalQuery = string.Format(INSERTSTRING, "PAYMENT", columns, values);
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
            string finalQuery = string.Format(DESTROYSTRING, "PAYMENT", "'" + Id + "'");
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
            string query = string.Format(READSTRING, "PAYMENT", Id);
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
            this.registration.Id = Convert.ToInt32(reader["RegistrationID"].ToString());
            this.Registration.Read();
            this.amount = Convert.ToInt32(reader["Amount"].ToString());
            this.paymentType = reader["PaymentType"].ToString();
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool Update()
        {
            string columnvalues = string.Format(
                "RegistratioID='{0}', Amount='{1}', PaymentType='{2}'",
                registration.Id,
                amount,
                paymentType);
            string finalQuery = string.Format(UPDATESTRING, "PAYMENT", columnvalues, "'" + Id + "'");
            OracleDataReader reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }
}