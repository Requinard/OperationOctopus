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
        private DeleteReservationLogic deleteReservation;
        private RegisterUserLogic registerUser;
        private AcceptPaymentLogic acceptPayment;

        private RFID rfid;

        public MedewerkerForm()
        {
            InitializeComponent();
            campingLogic = new CampingLogic(this);
            createUser = new CreateUserLogic(this);
            createPlace = new CreatePlaceLogic(this);
            deleteReservation = new DeleteReservationLogic(this);
            registerUser = new RegisterUserLogic(this);
            acceptPayment = new AcceptPaymentLogic(this);

            OpenRFIDConnection();
            FillReservations();
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

        private void FillReservations()
        {
            foreach (UserModel user in UserManager.GetAllUsers())
            {
                cbReservations.Items.Add(user.Username);
            }
        }

        #region handlers

        private void RFID_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.Description);
        }

        private void RFID_Tag(object sender, TagEventArgs e)
        {
            string tag = Convert.ToString(e.Tag);
            if (tabMainTab.SelectedTab == tabCreateUser)
            {
                tbAssignRfid.Text = Convert.ToString(tag);     
            }

            if (tabMainTab.SelectedTab == tabRegisterUser)
            {
                txtRFIDCode.Text = Convert.ToString(tag);
            }

            if (tabMainTab.SelectedTab == tabAcceptPayment)
            {
                txtRFIDPayment.Text = Convert.ToString(tag);
            }
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
            PlaceModel plaats = null;
            foreach (PlaceModel pm in campingLogic.places)
            {
                if (pm.Location == nmrPlaats.Text)
                {
                    plaats = pm;
                    break;
                }
            }

            if (plaats != null)
            {
                if (campingLogic.CheckPlaceSize(Convert.ToInt32(nmrPlaats.Text), lbUser.Items.Count))
                {
                    List<UserModel> users = new List<UserModel>();
                    foreach (string user in lbUser.Items)
                    {
                        users.Add(UserManager.FindUser(user));
                    }

                    foreach (UserModel user in users)
                    {
                        //TODO: EquipmentManager.MakePlaceReservervation(user, plaats);
                    }
                    MessageBox.Show("Succesvol gereserveerd");
                    nmrPlaats.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Deze plaats is niet beschikbaar.");
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "" || tbAddress.Text == "" || tbAssignRfid.Text == "" || tbName.Text == "" ||
                tbSurName.Text == "" || tbTelNr.Text == "" || tbEmail.Text == "")
            {
                MessageBox.Show("Vul alle velden in");
            }
            else
            {
                createUser.CreateUser();
            }
            
        }

        private void tabMainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMainTab.SelectedTab == tabCreateUser || tabMainTab.SelectedTab == tabRegisterUser || tabMainTab.SelectedTab == tabAcceptPayment)
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
            if (tabMainTab.SelectedTab == tabPostReview)
            {
                postReview = new PostReviewLogic(this);
            }
        }

        private void btnCreatePlace_Click(object sender, EventArgs e)
        {
            createPlace.CreatePlace();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UserModel selectedUser = UserManager.FindUser(cbReservations.GetItemText(cbReservations.SelectedItem));
            deleteReservation.DeleteReservation(selectedUser);
        }

        private void cbReservations_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserModel selectedUser = UserManager.FindUser(cbReservations.GetItemText(cbReservations.SelectedItem));
            List<RentableReservationModel> reservations = EquipmentManager.GetUserReservations(selectedUser);
            listReservedItems.Items.Clear();
            foreach (RentableReservationModel reservation in reservations)
            {
                listReservedItems.Items.Add(reservation.Rentable.ObjectType);
            }
        }

        private void txtRFIDCode_TextChanged(object sender, EventArgs e)
        {
            if (UserManager.AuthenticateUser(txtRFIDCode.Text))
            {
                MessageBox.Show("Gebruiker gevonden.");
                UserModel rfiduser = UserManager.FindUserFromRFID(txtRFIDCode.Text);
                lblNameOfUser.Text = "Naam: " + rfiduser.Username;
                lblPaymentStatusOfUser.Text = lblPaymentStatusOfUser.Text;
                lblAtEventStatus.Text = "At Event: " + Convert.ToString(Settings.ActiveEvent.Name);
            }
            else
            {
                txtRFIDCode.Text = "";
                MessageBox.Show("RFID-tag Niet gevonden.");
            }
        }

        private void txtRFIDPayment_TextChanged(object sender, EventArgs e)
        {
            if (txtRFIDPayment.Text != null)
            {
                if (UserManager.AuthenticateUser(txtRFIDPayment.Text))
                {
                    MessageBox.Show("Gebruiker gevonden.");
                    UserModel rfiduser = UserManager.FindUserFromRFID(txtRFIDPayment.Text);
                    lblNamePayment.Text = rfiduser.Username;
                    List<RegistrationModel> events = UserManager.GetUserRegistrations(rfiduser);

                    foreach (RegistrationModel _event in events)
                    {
                        listEvents.Items.Add(_event.EventItem.Name);
                    }
                }
                else
                {
                    txtRFIDPayment.Text = "";
                    MessageBox.Show("RFID-tag Niet gevonden.");
                }  
            } 
        }

        private void btnConformUser_Click(object sender, EventArgs e)
        {
            registerUser.RegisterUser();
            lblNameOfUser.Text = "Naam: ";
            lblPaymentStatusOfUser.Text = "Payment status: ";
            lblAtEventStatus.Text = "At event: ";
            txtRFIDCode.Text = "";
        }

        private void btnAcceptPayment_Click(object sender, EventArgs e)
        {
            acceptPayment.AcceptPayment();
        }

        private void btnMakeMaterial_Click(object sender, EventArgs e)
        {
            if (txtObjectName.Text != null && txtDescriptionMaterial.Text != null)
            {
                EquipmentManager.CreateNewRentable(txtDescriptionMaterial.Text, numMaterialPrice.Value, Convert.ToInt32(numMaterialAmount.Value), txtObjectName.Text);
                MessageBox.Show("Materiaal aangemaakt!");
                txtDescription.Text = "";
                txtObjectName.Text = "";
                numMaterialAmount.Value = 1;
                numMaterialPrice.Value = 0;
            }
            else
            {
                MessageBox.Show("Vul alle velden in!");
            }
        }

        #endregion

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

            public List<string> UserList { get; private set; }
            public List<PlaceModel> places { get; private set; }

            public CampingLogic(MedewerkerForm form)
            {
                parent = form;

                UserList = new List<string>();
                places = EquipmentManager.GetAllPlaces();

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

            public void AddUserToList()
            {
                parent.lbUser.Items.Add(parent.txtGebruikers.Text);
                UserList.Add(parent.txtGebruikers.Text);
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
                FillList();
            }

            private void FillList()
            {
                List<PostReportModel> reportModels = PostManager.GetAllReports();
                foreach (PostReportModel postReportModel in reportModels)
                {
                    parent.flowPostReview.Controls.Add(new UserPostReview(postReportModel));
                }
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
                string FullName = parent.tbName.Text + " " + parent.tbSurName.Text;
                string Password = GeneratePassword();
                string userName = parent.tbUsername.Text;
                string Address = parent.tbAddress.Text;
                string TelNr = parent.tbTelNr.Text;
                string Email = parent.tbEmail.Text;
                string Rfid = parent.tbAssignRfid.Text;
                UserManager.CreateUser(userName, Password, FullName, Address, TelNr, Email, Rfid);
                Clipboard.SetText(Password);
                MessageBox.Show("Gebruiker aangemaakt." + Environment.NewLine + "Gebruikersnaam: " + userName +
                                Environment.NewLine + "Wachtwoord: " + Password + Environment.NewLine + "Je wachtwoord is gekopieerd naar je klembord");
                
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

        public class DeleteReservationLogic
        {
            private readonly MedewerkerForm parent;
            public DeleteReservationLogic(MedewerkerForm form)
            {
                parent = form;
            }

            public void DeleteReservation(UserModel user)
            {
                string selecteditem = parent.listReservedItems.GetItemText(parent.listReservedItems.SelectedItem);
                List<RentableObjectModel> products = EquipmentManager.GetAllRentables();
                RentableObjectModel rented = null;
                foreach (RentableObjectModel rentable in products)
                {
                    
                    if (rentable.ObjectType == selecteditem)
                    {
                        rented = rentable;
                        break;
                    }
                }
                EquipmentManager.DeleteObjectReservation(user, rented, 1);
                MessageBox.Show("Reservatie verwijdert");
                parent.cbReservations.SelectedIndex = 0;
            }
        }

        public class RegisterUserLogic
        {
            private readonly MedewerkerForm parent;
            public RegisterUserLogic(MedewerkerForm form)
            {
                parent = form;
            }

            public void RegisterUser()
            {
                UserModel rfiduser = UserManager.FindUserFromRFID(parent.txtRFIDCode.Text);
                UserManager.RegisterUserForEvent(rfiduser, Settings.ActiveEvent);
                MessageBox.Show("Gebruiker succesvol geregistreerd op het event.");
            }
        }

        public class AcceptPaymentLogic
        {
            private readonly MedewerkerForm parent;

            public AcceptPaymentLogic(MedewerkerForm form)
            {
                parent = form;
            }

            public void AcceptPayment()
            {
                if (parent.txtRFIDPayment.Text == null)
                {
                    MessageBox.Show("Scan eerst een rfid-tag");
                    return;
                }
                if (parent.listEvents.SelectedIndex < 0)
                {
                    MessageBox.Show("Selecteer eerst een event");
                    return;
                }
                if (parent.txtPaymentType.Text == null || parent.numPriceAmount.Value == 0)
                {
                    MessageBox.Show("Voer alle velden in");
                    return;
                }

                UserModel rfiduser = UserManager.FindUserFromRFID(parent.txtRFIDPayment.Text);
                RegistrationModel registrationevent = null;
                List<RegistrationModel> events = UserManager.GetUserRegistrations(rfiduser);
                string selectedevent = parent.listEvents.GetItemText(parent.listEvents.SelectedItem);

                foreach (RegistrationModel registration in events)
                {
                    if (registration.EventItem.Name == selectedevent)
                    {
                        registrationevent = registration;
                        break;
                    }
                }

                if (registrationevent == null)
                {
                    MessageBox.Show("Error");
                    return;
                }

                UserManager.RegistrationMarkPaid(registrationevent, parent.numPriceAmount.Value,
                    parent.txtPaymentType.Text);

                MessageBox.Show("Betaling geaccepteerd");

                parent.txtRFIDPayment.Text = "";
                parent.lblNamePayment.Text = "";
                parent.listEvents.Items.Clear();
                parent.txtPaymentType.Text = "";
                parent.numPriceAmount.Value = 0;
            }
        }
    }
}