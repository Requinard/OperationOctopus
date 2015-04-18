using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;

namespace ICT4EVENT
{
    public partial class MedewerkerForm : Form
    {
        private readonly CampingLogic campingLogic;
        private readonly CreateUserLogic createUser;
        private PostReviewLogic postReview;
        private CreatePlaceLogic createPlace;

        private RFID rfid;

        public MedewerkerForm()
        {
            InitializeComponent();
            campingLogic = new CampingLogic(this);
            postReview = new PostReviewLogic(this);
            createUser = new CreateUserLogic(this);
            createPlace = new CreatePlaceLogic(this);

            OpenRFIDConnection();
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
                rfid.LED = true;
                rfid.Antenna = true;
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

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                UserManager.FindUser(Convert.ToInt32(txtGebruikers.Text));
            campingLogic.AddUserToList();
        }
            catch
            {
                try
                {
                    UserManager.FindUser(txtGebruikers.Text);
                    campingLogic.AddUserToList();
                }
                catch
                {
                    MessageBox.Show("Gebruiker niet gevonden");
                    txtGebruikers.Text = "";
                }
            }
        }
        
        private void btnReserve_Click(object sender, EventArgs e)
        {
            var plaats = Convert.ToInt32(nmrPlaats.Text);

            var lines = lbUser.Items.Count;

            if (campingLogic.CheckPlaceSize(plaats, lines))
            {
                //TODO: EquipmentManager.MakePlaceReservervation();
                MessageBox.Show("Succesvol gereserveerd");
                nmrPlaats.SelectedIndex = 0;
                txtGebruikers.Text = "";
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            createUser.CreateUser();
        }

        private void tabMainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMainTab.SelectedTab == tabCreateUser)
            {
                rfid.Antenna = true;
                rfid.LED = true;
            }
            else
            {
                rfid.Antenna = false;
                rfid.LED = false;
            }
        }

        private void btnCreatePlace_Click(object sender, EventArgs e)
        {
            createPlace.CreatePlace();
        }

        public class CampingLogic
        {
            private readonly int[] Blokhutten;
            private readonly int[] Bungalinos;
            private readonly int[] Bungalows;
            private readonly int[] ComfortPlaatsen;
            private readonly int[] EigenTenten;
            private readonly int[] Huurtentjes;
            private readonly int[] Invalidenaccomodatie;
            private readonly MedewerkerForm parent;
            private readonly int[] StaCaravan;
            private int[] AllPlaces;
            private decimal amount;
            private List<string> guests;

            public CampingLogic(MedewerkerForm form)
            {
                parent = form;
                UserList = new List<string>();
                EigenTenten = EigenTentenArray();
                Bungalows = BungalowArray();
                Blokhutten = BlokHuttenArray();
                Bungalinos = BungalinosArray();
                ComfortPlaatsen = ComfortPlaatsenArray();
                StaCaravan = StaCaravanArray();
                Invalidenaccomodatie = Enumerable.Range(85, 6).ToArray();
                Huurtentjes = Enumerable.Range(643, 36).ToArray();
                AllPlaces = AllPlacesArray();
                FillAllPlaces();
            }

            public List<string> UserList { get; private set; }

            public void AddUserToList()
            {
                parent.lbUser.Items.Add(parent.txtGebruikers.Text);
                parent.txtGebruikers.Text = "";
            }

            public bool CheckPlaceSize(int place, int amountofusers)
            {
                #region Check places in every array
                if (amountofusers == 0)
                {
                    MessageBox.Show("Vul minstens een persoon in bij gebruikers");
                    return true;
                }
                if (place == 0)
                {
                    MessageBox.Show("Vul een geldige plaats in bij plaats");
                    return true;
                }

                if (Bungalows.Contains(place))
                {
                    if (amountofusers > 8)
                    {
                        MessageBox.Show("Er mogen maximaal 8 personen in een bungalow verblijven.");
                        return false;
                    }
                    return true;
                }
                if (Bungalinos.Contains(place))
                {
                    if (amountofusers > 4)
                    {
                        MessageBox.Show("Er mogen maximaal 4 personen in een bungalino verblijven.");
                        return false;
                    }
                    return true;
                }

                if (EigenTenten.Contains(place))
                {
                    if (amountofusers > 5)
                    {
                        MessageBox.Show("Er mogen maximaal 5 personen in een eigen tent verblijven.");
                        return false;
                    }
                    return true;
                }

                if (Blokhutten.Contains(place))
                {
                    if (amountofusers > 4)
                    {
                        MessageBox.Show("Er mogen maximaal 4 personen in een blokhut verblijven.");
                        return false;
                    }
                    return true;
                }

                if (ComfortPlaatsen.Contains(place))
                {
                    if (amountofusers > 4)
                    {
                        MessageBox.Show("Er mogen maximaal 4 personen op een comfortplaats verblijven.");
                        return false;
                    }
                    return true;
                }


                if (Huurtentjes.Contains(place))
                {
                    if (amountofusers > 4)
                    {
                        MessageBox.Show("Er mogen maximaal 4 personen in een huurtentje verblijven.");
                        return false;
                    }
                    return true;
                }

                if (StaCaravan.Contains(place))
                {
                    if (amountofusers > 6)
                    {
                        MessageBox.Show("Er mogen maximaal 4 personen in een stacaravan verblijven.");
                        return false;
                    }
                    return true;
                }

                if (Invalidenaccomodatie.Contains(place))
                {
                    if (amountofusers > 4)
                    {
                        MessageBox.Show("Er mogen maximaal 4 personen in een invalidenaccomodatie verblijven.");
                        return false;
                    }
                    return true;
                }

                MessageBox.Show("Plaats niet gevonden.");
                return false;
                #endregion
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
                int[] Tenten5 = { 544, 431 };
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
                int[] Blokhutten6 = { 124 };
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
            private readonly MedewerkerForm parent;

            public PostReviewLogic(MedewerkerForm form)
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
            private readonly MedewerkerForm parent;
            public CreateUserLogic(MedewerkerForm gui)
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
                MessageBox.Show("Gebruiker aangemaakt." + Environment.NewLine + "Gebruikersnaam: " + userName +
                                Environment.NewLine + "Wachtwoord: " + Password);
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
        }

        public class CreatePlaceLogic
        {
            private readonly MedewerkerForm parent;
            public CreatePlaceLogic(MedewerkerForm form)
            {
                parent = form;
            }

            public void CreatePlace()
            {
                string description = parent.txtDescription.Text;
                decimal price = parent.numPrice.Value;
                int amount = 1;
                string location = Convert.ToString(parent.numPlaceNumber.Value);
                string category = parent.txtCategory.Text;
                int capacity = Convert.ToInt32(parent.numCapacity.Value);
                EquipmentManager.CreateNewPlace(description, price, amount, location, category,capacity);
                MessageBox.Show("Plaats aangemaakt");
                EmptyBoxes();
            }

            private void EmptyBoxes()
            {
                parent.txtDescription.Text = "";
                parent.numPrice.Value = 0;
                parent.numPlaceNumber.Value = 1;
                parent.txtCategory.Text = "";
                parent.numCapacity.Value = 1;
            }
        } 
    }
}