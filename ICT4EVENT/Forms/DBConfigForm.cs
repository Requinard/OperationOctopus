using System;
using System.Windows.Forms;

namespace ICT4EVENT
{
    public partial class DBConfigForm : Form
    {
        public DBConfigForm()
        {
            InitializeComponent();
            Settings.DbConfig = new DBConfig();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool FieldsAreOk = true;

            if (tbUser.Text.Length > 0)
                Settings.DbConfig.user = tbUser.Text;
            else
                FieldsAreOk = false;

            if (tbPassword.Text.Length > 0)
                Settings.DbConfig.pw = tbPassword.Text;
            else
                FieldsAreOk = false;

            if (tbHost.Text.Length > 0)
                Settings.DbConfig.host = tbHost.Text;
            else
                FieldsAreOk = false;

            if (tbPort.Text.Length > 0)
                Settings.DbConfig.port = tbPort.Text;
            else
                FieldsAreOk = false;

            if (tbDatabase.Text.Length > 0)
                Settings.DbConfig.database = tbDatabase.Text;
            else
                FieldsAreOk = false;

            if (FieldsAreOk)
            {
                Close();
            }
            else
            {
                //TODO: ZEt een mooie text neer
                MessageBox.Show("Je doet het fout.");
            }
        }
    }

    [Serializable]
    public class DBConfig
    {
        public string database;
        public string host;
        public string port;
        public string pw;
        public string user;
    }
}