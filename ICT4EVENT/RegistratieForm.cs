using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        void GenerateRandomPassword()
        {
            Security.Membership.GeneratePassword();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            GenerateRandomPassword();
        }
    }
}
