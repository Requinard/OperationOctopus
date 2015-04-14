using System;

namespace ICT4EVENT
{
    /// <summary>
    ///     The payment model.
    /// </summary>
    public class PaymentModel : DBModel, IDataModelUpdate
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int ID { get; set; }

        #endregion

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
            var columns = "RegistrationID, Amount, PaymentType";
            var values = string.Format("'{0}','{1}','{2}'", registration.Id, amount, paymentType);
            var finalQuery = string.Format(INSERTSTRING, "PAYMENT", columns, values);
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
            var finalQuery = string.Format(DESTROYSTRING, "PAYMENT", "'" + Id + "'");
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
            var query = string.Format(READSTRING, "PAYMENT", Id);
            var reader = DBManager.QueryDB(query);
            if (reader == null)
            {
                return false;
            }

            reader.Read();
            Id = Convert.ToInt32(reader["Ident"].ToString());
            registration.Id = Convert.ToInt32(reader["RegistrationID"].ToString());
            amount = Convert.ToInt32(reader["Amount"].ToString());
            paymentType = reader["PaymentType"].ToString();

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
                "RegistrationID='{0}', Amount='{1}', PaymentType='{2}'",
                registration.Id,
                amount,
                paymentType);
            var finalQuery = string.Format(UPDATESTRING, "PAYMENT", columnvalues, "'" + Id + "'");
            var reader = DBManager.QueryDB(finalQuery);

            return reader != null;
        }

        #endregion
    }
}