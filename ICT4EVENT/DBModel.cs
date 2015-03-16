using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4EVENT
{
    abstract class DBModel
    {
        private DBManager dbManager;
        private int ID;

        public int Id
        {
            get { return ID; }
        }

        public DBModel(DBManager dbManager)
        {
            this.dbManager = dbManager;
        }
    }

    class EventModel : DBModel, IDataModelUpdate
    {
        public EventModel(DBManager dbManager) :base (dbManager)
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

    class UserModel : DBModel, IDataModelUpdate
    {

        public int ID { get; set; }
        public List<RegistrationModel> RegistrationList = new List<RegistrationModel>();

        public UserModel(DBManager dbManager) :base (dbManager)
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

    class RegistrationModel : DBModel, IDataModelUpdate
    {

        public int ID { get; set; }

        public RegistrationModel(DBManager dbManager) :base (dbManager)
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

    class RFIDLogModel : DBModel, IDataModelUpdate
    {
        public RFIDLogModel(DBManager dbManager) :base (dbManager)
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

    class RentableObjectModel : DBModel, IDataModelUpdate
    {
        public RentableObjectModel(DBManager dbManager) :base (dbManager)
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

    class PostModel : DBModel, IDataModelUpdate
    {
        public PostModel(DBManager dbManager) :base (dbManager)
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

    class PlaceModel : DBModel, IDataModelUpdate
    {
        public PlaceModel(DBManager dbManager) :base (dbManager)
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

    class LikeModel : DBModel, IDataModelUpdate
    {
        public LikeModel(DBManager dbManager) :base (dbManager)
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

    class PostReportModel : DBModel, IDataModelUpdate
    {
        public PostReportModel(DBManager dbManager) :base (dbManager)
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

    class PaymentModel : DBModel, IDataModelUpdate
    {

        public int ID { get; set; }

        public PaymentModel(DBManager dbManager) :base (dbManager)
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

    

}
