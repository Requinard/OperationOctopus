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
        private RFID rfid;
        public LoginForm()
        {
            InitializeComponent();
            

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
            rfid.Antenna = false;
            rfid.LED = false;
            txtRFID.Text = Convert.ToString(e.Tag);

            if (UserManager.AuthenticateUser(e.Tag))
            {
                txtPassword.Enabled = txtUserName.Enabled = false;
                rfid.Error -= RFID_Error;
                rfid.Tag -= RFID_Tag;
                rfid.TagLost -= rfid_TagLost;
            }

            rfid.Antenna = true;
        }

        private void OpenRFIDConnection()
        {
            try
            {
                rfid = new RFID();
                rfid.Error += RFID_Error;
                rfid.Tag += RFID_Tag;
                rfid.TagLost += rfid_TagLost;
          
                rfid.open();
             
            }
            catch (PhidgetException ex)
            {
                MessageBox.Show(ex.Description);
            }
        }



        private void FillActionList()
        {
            //if()
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Settings.ActiveUser != null)
            {
                isAuthenticated();
            }
            else if (UserManager.AuthenticateUser(txtUserName.Text, txtPassword.Text))
            {
                isAuthenticated();
            }
            else
            {
                MessageBox.Show("Naam of wachtwoord niet juist.");
            }
        }

        private void isAuthenticated()
        {
            
            Application.DoEvents();

            rfid.close();



            if (Settings.ActiveUser.Level == 1)
            {
                openForm(new MainForm());
            }
            else
            {
                FillActionList();
            }

            
        }

        private void openForm(Form form)
        {
            this.Hide();

            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}
