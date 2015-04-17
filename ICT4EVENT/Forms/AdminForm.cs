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

namespace ICT4EVENT
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            FillEventList(EventManager.FindAllEvents());
        }

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            gbCreateEvent.Visible = true;
        }

        private void btnUpdateEvents_Click(object sender, EventArgs e)
        {
            flowEvent.Controls.Clear();
                FillEventList(EventManager.FindAllEvents());
            }

            public void AddEvent(UserEvent userEvent)
            {
            flowEvent.Controls.Add(userEvent);
            }

            public void FillEventList(List<EventModel> eventModels)
            {
            List<EventModel> sortedEventModels = eventModels;
            sortedEventModels.Sort();
                foreach (var eventModel in eventModels)
                {
                flowEvent.Controls.Add(new UserEvent(eventModel));
                }
            }

        private void btnCreateNewEvent_Click(object sender, EventArgs e)
        {
            EventModel eventModel = EventManager.CreateNewEvent(tbEventName.Text, tbLocation.Text, tbDescription.Text, dateTimePicker1.Value,
                    dateTimePicker2.Value);
            if (eventModel != null)
                        {
                            MessageBox.Show("Er mogen maximaal 4 personen op een comfortplaats verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                foreach (var p in Huurtentjes)
                {
                    if (p == place)
                    {
                        if (amountofusers > 4)
                        {
                            MessageBox.Show("Er mogen maximaal 4 personen in een huurtentje verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                foreach (var p in StaCaravan)
                {
                    if (p == place)
                    {
                        if (amountofusers > 6)
                        {
                            MessageBox.Show("Er mogen maximaal 4 personen in een stacaravan verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                foreach (var p in Invalidenaccomodatie)
                {
                    if (p == place)
                    {
                        if (amountofusers > 4)
                        {
                            MessageBox.Show("Er mogen maximaal 4 personen in een invalidenaccomodatie verblijven.");
                            return false;
                        }
                        return true;
                    }
                }

                MessageBox.Show("Plaats niet gevonden.");
                return false;
            }

            private void FillAllPlaces()
            {
                foreach (int place in AllPlaces)
                {
                    parent.nmrPlaats.Items.Add(place);
                }
            }

            private int[] EigenTentenArray()
            {
                var Tenten1 = Enumerable.Range(101, 23).ToArray();
                var Tenten2 = Enumerable.Range(200, 14).ToArray();
                var Tenten3 = Enumerable.Range(401, 19).ToArray();
                var Tenten4 = Enumerable.Range(314, 10).ToArray();
                int[] Tenten5 = {544, 431};
                var Tenten = Tenten1.Concat(Tenten2).Concat(Tenten3).Concat(Tenten4).Concat(Tenten5).ToArray();
                return Tenten;
            }

            private int[] BungalowArray()
            {
                var Bungalows1 = Enumerable.Range(2, 11).ToArray();
                var Bungalows2 = Enumerable.Range(14, 2).ToArray();
                var Bungalows3 = Enumerable.Range(17, 4).ToArray();
                var Bungalows4 = Enumerable.Range(23, 4).ToArray();
                var Bungalows = Bungalows1.Concat(Bungalows2).Concat(Bungalows3).Concat(Bungalows4).ToArray();
                return Bungalows;
            }

            private int[] BlokHuttenArray()
            {
                var Blokhutten1 = Enumerable.Range(72, 10).ToArray();
                var Blokhutten2 = Enumerable.Range(91, 2).ToArray();
                var Blokhutten3 = Enumerable.Range(95, 2).ToArray();
                var Blokhutten4 = Enumerable.Range(138, 5).ToArray();
                var Blokhutten5 = Enumerable.Range(143, 8).ToArray();
                int[] Blokhutten6 = {124};
                var Blokhutten =
                    Blokhutten1.Concat(Blokhutten2)
                        .Concat(Blokhutten3)
                        .Concat(Blokhutten4)
                        .Concat(Blokhutten5)
                        .Concat(Blokhutten6)
                        .ToArray();
                return Blokhutten;
            }

            private int[] BungalinosArray()
            {
                var Bungalinos1 = Enumerable.Range(50, 6).ToArray();
                var Bungalinos2 = Enumerable.Range(60, 12).ToArray();
                var Bungalinos3 = Enumerable.Range(101, 5).ToArray();
                var Bungalinos = Bungalinos1.Concat(Bungalinos2).Concat(Bungalinos3).ToArray();
                return Bungalinos;
            }

            private int[] ComfortPlaatsenArray()
            {
                var Comfortplaats1 = Enumerable.Range(601, 26).ToArray();
                var Comfortplaats2 = Enumerable.Range(432, 4).ToArray();
                var ComfortPlaats = Comfortplaats1.Concat(Comfortplaats2).ToArray();
                return ComfortPlaats;
            }

            private int[] StaCaravanArray()
            {
                var StaCaravan1 = Enumerable.Range(34, 8).ToArray();
                var StaCaravan2 = Enumerable.Range(125, 3).ToArray();
                var StaCaravan3 = Enumerable.Range(93, 2).ToArray();
                var StaCaravan4 = Enumerable.Range(97, 4).ToArray();
                var StaCaravan = StaCaravan1.Concat(StaCaravan2).Concat(StaCaravan3).Concat(StaCaravan4).ToArray();
                return StaCaravan;
            }

            private int[] AllPlacesArray()
            {
                var allplaces = Bungalows.Concat(Blokhutten)
                    .Concat(Bungalinos)
                    .Concat(ComfortPlaatsen)
                    .Concat(EigenTenten)
                    .Concat(Huurtentjes)
                    .Concat(StaCaravan)
                    .Concat(Invalidenaccomodatie)
                    .ToArray();
                Array.Sort(allplaces);
                return allplaces;
            }
        }

        public class PostReviewLogic
        {
            private readonly AdminForm parent;

            public PostReviewLogic(AdminForm form)
            {
                parent = form;
                CreateDummyData();
            }

            public void CreateDummyData()
            {

            }
        }

        public class CreateUserLogic
        {
            private readonly AdminForm parent;
            public CreateUserLogic(AdminForm gui)
            {
                parent = gui;
            }

            public void CreateUser()
            {
                string FullName = parent.txtName.Text + " " + parent.txtSurName.Text;
                string Password = GeneratePassword();
                string userName = parent.txtUsername.Text;
                string Address = parent.txtAddress.Text;
                string TelNr = parent.txtTelNr.Text;
                string Email = parent.txtEmail.Text;
                string Rfid = parent.txtAssignRfid.Text;
                UserManager.CreateUser(userName, Password, FullName, Address, TelNr, Email, Rfid);
                RemoveInput();
            }

            private string GeneratePassword()
            {
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                char[] PasswordChars = new char[8];
                Random r = new Random();

                for (int i = 0; i < PasswordChars.Length; i++)
                {
                    PasswordChars[i] = chars[r.Next(chars.Length)];
                }

                string RandomPassword = new String(PasswordChars);
                return RandomPassword;
            }

            private void RemoveInput()
            {
                parent.txtName.Text = "";
                parent.txtSurName.Text = "";
                parent.txtUsername.Text = "";
                parent.txtAddress.Text = "";
                parent.txtTelNr.Text = "";
                parent.txtEmail.Text = "";
                parent.txtAssignRfid.Text = "";
        }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (txtAssignRfid.Text != null)
            {
                createUser.CreateUser();
                MessageBox.Show("Gebruiker aangemaakt");
            }
            else
            {
                MessageBox.Show("Scan eerst een RFID");
            }
        }

        private void OpenRFIDConnection()
        {
            try
            {
                rfid = new RFID();
                rfid.Error += RFID_Error;
                rfid.Tag += RFID_Tag;

                rfid.open(-1);

                rfid.waitForAttachment(1000);
            }
            catch (PhidgetException ex)
            {
                MessageBox.Show(ex.Description);
            }
        }

        private void RFID_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.Description);
        }

        private void RFID_Tag(object sender, TagEventArgs e)
        {
            txtAssignRfid.Text = Convert.ToString(e.Tag);
        }


        private void tabMainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMainTab.SelectedTab.Name == "tabCreateUser")
            {
                try
                {
                    rfid.Antenna = true;
                    rfid.LED = true;  
                }
                catch { }
            }
            else
            {
                try
                {
                    rfid.Antenna = false;
                    rfid.LED = false;  
                }
                catch { }
            }
        }
    }
}