namespace ICT4EVENT.Models
{
    using Oracle.DataAccess.Client;

    public class TagModel : DBModel, IDataModelUpdate
    {
        public TagModel()
        {
            this.Name = "";
        }

        public TagModel(int id)
        {
            this.Id = id;

            this.Read();
        }

        public string Name { get; set; }

        public bool Create()
        {
            var query = string.Format("INSERT INTO TAG (name) VALUES ('{0}')", this.Id);

            if (DBManager.QueryDB(query) == null)
            {
                return false;
            }
            return true;
        }

        public bool Read()
        {
            var query = string.Format(READSTRING, "Tag", this.Id);

            var reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return false;
            }

            reader.Read();

            this.ReadFromReader(reader);

            return true;
        }

        public bool Update()
        {
            var query = string.Format(UPDATESTRING, "Tag", this.Id);

            var reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return false;
            }

            reader.Read();

            this.ReadFromReader(reader);

            return true;
        }

        public bool Destroy()
        {
            var query = string.Format(DESTROYSTRING, "Tag", this.Id);

            var reader = DBManager.QueryDB(query);

            if (reader == null)
            {
                return false;
            }
            return true;
        }

        public void ReadFromReader(OracleDataReader reader)
        {
            this.Id = int.Parse(reader["ident"].ToString());
            this.Name = reader["tagname"].ToString();
        }
    }
}