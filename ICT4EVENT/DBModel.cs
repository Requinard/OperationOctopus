using System;
using System.Collections.Generic;

namespace ICT4EVENT
{
    internal abstract class DBModel
    {
        // Creates a new row. {0} is table name, {1} is columns and {2} is values
        private const string INSERTSTRING = "INSERT INTO {0} {1} VALUES {2}";
        // Updates a row in the database. {0} is table name, {1} is columns and values and {2} is the row id
        private const string UPDATESTRING = "UPDATE {0} SET {1} WHERE id={2}";
        // Reads the corresponding row from the database. {0} is table name, {1} is the row id
        private const string READSTRING = "SELECT * FROM {0} WHERE id={1}";
        // Destroys the corresponding row in the table. {0} is the table name, {1} is the table id
        private const string DESTROYSTRING = "DELETE FROM {0} WHERE id={1}";
        private int ID;
        private DBManager dbManager;

        public DBModel(DBManager dbManager)
        {
            this.dbManager = dbManager;
        }

        public int Id
        {
            get { return ID; }
        }
    }

    internal class EventModel : DBModel, IDataModelUpdate
    {
        public EventModel(DBManager dbManager) : base(dbManager)
        {
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    internal class UserModel : DBModel, IDataModelUpdate
    {
        public List<RegistrationModel> RegistrationList = new List<RegistrationModel>();

        public UserModel(DBManager dbManager) : base(dbManager)
        {
        }

        public int ID { get; set; }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    internal class RegistrationModel : DBModel, IDataModelUpdate
    {
        public RegistrationModel(DBManager dbManager) : base(dbManager)
        {
        }

        public int ID { get; set; }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    internal class RFIDLogModel : DBModel, IDataModelUpdate
    {
        public RFIDLogModel(DBManager dbManager) : base(dbManager)
        {
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    internal class RentableObjectModel : DBModel, IDataModelUpdate
    {
        public RentableObjectModel(DBManager dbManager) : base(dbManager)
        {
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    internal class PostModel : DBModel, IDataModelUpdate
    {
        public PostModel(DBManager dbManager) : base(dbManager)
        {
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    internal class PlaceModel : DBModel, IDataModelUpdate
    {
        public PlaceModel(DBManager dbManager) : base(dbManager)
        {
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    internal class LikeModel : DBModel, IDataModelUpdate
    {
        public LikeModel(DBManager dbManager) : base(dbManager)
        {
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    internal class PostReportModel : DBModel, IDataModelUpdate
    {
        public PostReportModel(DBManager dbManager) : base(dbManager)
        {
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    internal class PaymentModel : DBModel, IDataModelUpdate
    {
        public PaymentModel(DBManager dbManager) : base(dbManager)
        {
        }

        public int ID { get; set; }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }

    internal class ReservationModel : DBModel, IDataModelUpdate
    {
        public ReservationModel(DBManager dbManager) : base(dbManager)
        {
        }

        private DateTime ReturnDate { get; set; }
        private int Amount { get; set; }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }
    }
}