using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4EVENT.Models
{
    using System.Windows.Forms.VisualStyles;

    using Microsoft.SqlServer.Server;

    using Oracle.DataAccess.Client;

    class TagModel : DBModel, IDataModelUpdate
    {
        private string name;

        public TagModel()
        {
            name = "";
        }

        public TagModel(int id)
        {
            this.Id = id;

            this.Read();
        }

        public void ReadFromReader(OracleDataReader reader)
        {
            this.Id = Int32.Parse(reader["ident"].ToString());
            this.name = reader["name"].ToString();
        }
        public bool Create()
        {
            string query = string.Format("INSERT INTO TAG (name) VALUES ('{0}')", Id);

            if (DBManager.QueryDB(query) == null) return false;
            return true;
        }

        public bool Read()
        {
            string query = string.Format(READSTRING, "Tag", Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null) return false;

            reader.Read();

            ReadFromReader(reader);

            return true;
        }

        public bool Update()
        {
            string query = string.Format(UPDATESTRING, "Tag", Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null) return false;

            reader.Read();

            ReadFromReader(reader);

            return true;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public bool Destroy()
        {
            string query = String.Format(DESTROYSTRING, "Tag", Id);

            OracleDataReader reader = DBManager.QueryDB(query);

            if (reader == null) return false;
            return true;
        }
    }
}
