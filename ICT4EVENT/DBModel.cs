using System;
using System.Collections.Generic;

namespace ICT4EVENT
{
    internal abstract class DBModel
    {
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