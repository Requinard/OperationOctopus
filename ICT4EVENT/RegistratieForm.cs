using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;
using System.Web;

namespace ICT4EVENT
{
    public partial class RegistratieForm : Form
    {
        private RFID rfid = new RFID();
        private string GeneratedPassword;
        public RegistratieForm()
        {
            InitializeComponent();

            rfid.Error += RFID_Error;
            rfid.Tag += RFID_Tag;

            OpenRFIDConnection();
        }

        private void RFID_Error(object sender, Phidgets.Events.ErrorEventArgs e)
        {
            MessageBox.Show(e.Description);
        }

        private void RFID_Tag(object sender, TagEventArgs e)
        {
            txtRFID.Text = Convert.ToString(e.Tag);

            btnAddUser.Enabled = true;
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

        private string GenerateRandomPassword()
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[8];
            Random r = new Random();

            for (int i = 0; i < 8; i++)
            {
                chars[i] = allowedChars[r.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (txtAdress.Text != null && txtEmail.Text != null && txtTel.Text != null && txtUsername.Text != null)
            {
                GeneratedPassword = GenerateRandomPassword();
                Aangemaakt();
            }
        }

        private void Aangemaakt()
        {
            txtAdress.Text = txtEmail.Text = txtRFID.Text = txtTel.Text = txtUsername.Text = "";
            lblPassword.Text = "Gebruiker toegevoegd. Wachtwoord is: " + GeneratedPassword;
        }
    }
}
