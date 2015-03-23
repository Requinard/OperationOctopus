using System;
using System.Windows.Forms;

namespace ICT4EVENT
{
    public partial class DatabaseConfigForm : Form
    {
        public DatabaseConfigForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool FieldsAreOk = true;

            if (tbUser.Text.Length > 0)
                Settings.DatabaseConfig.user = tbUser.Text;
            else
                FieldsAreOk = false;

            if (tbPassword.Text.Length > 0)
                Settings.DatabaseConfig.pw = tbPassword.Text;
            else
                FieldsAreOk = false;

            if (tbHost.Text.Length > 0)
                Settings.DatabaseConfig.host = tbHost.Text;
            else
                FieldsAreOk = false;

            if (tbPort.Text.Length > 0)
                Settings.DatabaseConfig.port = tbPort.Text;
            else
                FieldsAreOk = false;

            if (tbDatabase.Text.Length > 0)
                Settings.DatabaseConfig.database = tbDatabase.Text;
            else
                FieldsAreOk = false;

            if (FieldsAreOk)
            {
                this.Close();
            }
            else
            {
                //TODO: ZEt een mooie text neer
                MessageBox.Show("Je doet het fout.");
            }
        }
    }

    [Serializable]
    public class DatabaseConfig
    {
        public string database;
        public string host;
        public string port;
        public string pw;
        public string user;
    }
}