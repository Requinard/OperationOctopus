using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;

namespace ICT4EVENT
{
    public partial class LoginForm : Form
    {
        private RFID rfid = new RFID();
        public LoginForm()
        {
            InitializeComponent();
            
            rfid.Error += RFID_Error;
            rfid.Tag += RFID_Tag;
            rfid.TagLost += rfid_TagLost;

            OpenRFIDConnection();
        }

        void rfid_TagLost(object sender, TagEventArgs e)
        {
            txtRFID.Text = "";
        }

        private void RFID_Error(object sender, Phidgets.Events.ErrorEventArgs e)
        {
            MessageBox.Show(e.Description);
        }

        private void RFID_Tag(object sender, TagEventArgs e)
        {
            txtRFID.Text = Convert.ToString(e.Tag);

            if(UserManager.AuthenticateUser(e.Tag))
            txtUserName.Enabled = txtPassword.Enabled = btnLogin.Enabled = false;
        }

        private void OpenRFIDConnection()
        {
            try
            {
                rfid.open();
                rfid.waitForAttachment(1000);
                rfid.Antenna = rfid.LED = Enabled;
            }
            catch (PhidgetException ex)
            {
                MessageBox.Show(ex.Description);
            }
        }

        private void FillActionList()
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (UserManager.AuthenticateUser(txtUserName.Text, txtPassword.Text))
            {
                FillActionList();
            }
            else
            {
                MessageBox.Show("Naam of wachtwoord niet juist.");
            }
        }
    }
}
