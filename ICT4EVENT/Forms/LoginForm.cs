using System;
using System.Windows.Forms;
using ApplicationLogger;
using Phidget21COM;
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

        private void rfid_TagLost(object sender, TagEventArgs e)
        {
            txtRFID.Text = "";
        }

        private void RFID_Error(object sender, ErrorEventArgs e)
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
                TagEventHandler tag = this.btnLogin_Click;

                this.Invoke(tag, new object[]{sender, e});
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


                rfid.open(-1);

                rfid.waitForAttachment(1000);
                rfid.LED = true;
                rfid.Antenna = true;
            }
            catch (PhidgetException ex)
            {
                MessageBox.Show(ex.Description);
            }
        }

        private void FillActionList()
        {
            // Fill active events
            foreach (RegistrationModel registrationModel in UserManager.GetUserRegistrations(Settings.ActiveUser))
            {
                comboBox1.Items.Add(registrationModel.EventItem.Name);
            }
            comboOptions.Items.Add("Social Media Sharing");
            if (Settings.ActiveUser.Level == 2)
            {
                comboOptions.Items.Add("Registraties");
                comboOptions.Items.Add("Toegangscontrole");
            }
            if (Settings.ActiveUser.Level == 3)
            {
                comboOptions.Items.Add("Medewerker Form");
                comboOptions.Items.Add("Ultra mega holocaust nigger 9000");
            }

            comboOptions.Enabled = true;
            comboBox1.Enabled = true;
            comboOptions.SelectedIndex = 0;
            btnGO.Enabled = true;
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

            FillActionList();
        }

        private void openForm(Form form)
        {
            Hide();

            form.Closed += (s, args) => Close();
            form.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            Settings.ActiveEvent = EventManager.FindEvent(comboBox1.SelectedItem.ToString());

            switch (comboOptions.SelectedIndex)
            {
                case 0:
                    if (Settings.ActiveUser == null || Settings.ActiveEvent == null)
                    {
                        Logger.Error("No user or event were set to active on form initialization");
                        Environment.Exit(2);
                    }
                    openForm(new MainForm());
                    break;
                case 1:
                    // TODO: Open registrations
                    if (Settings.ActiveUser == null || Settings.ActiveEvent == null)
                    {
                        Logger.Error("No user or event were set to active on form initialization");
                        Environment.Exit(2);
                    }
                    openForm(new MedewerkerForm());
                    break;
                case 2:
                    // TODO: Open access control
                    if (Settings.ActiveUser == null)
                    {
                        Logger.Error("No user or event were set to active on form initialization");
                        Environment.Exit(2);
                    }
                    openForm(new AdminForm());
                    break;
                case 3:
                    // TODO: Open administrator panel
                    
                    break;
                default:
                    openForm(new MainForm());
                    break;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r' || e.KeyChar == '\n')
                btnLogin_Click(this, e);
        }
    }
}