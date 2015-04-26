#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;

#endregion

namespace ICT4EVENT
{
    public partial class EmployeeForm : Form
    {
        private readonly CampingLogic campingLogic;
        private readonly CreateUserLogic createUser;
        private AcceptPaymentLogic acceptPayment;
        private CreatePlaceLogic createPlace;
        private DeleteReservationLogic deleteReservation;
        private PostReviewLogic postReview;
        private RegisterUserLogic registerUser;
        private RFID rfid;
        private RFIDLogAddLogic rfidLogAdd;
        private UserManagement userManagement;

        public EmployeeForm()
        {
            InitializeComponent();
            campingLogic = new CampingLogic(this);
            createUser = new CreateUserLogic(this);
            createPlace = new CreatePlaceLogic(this);
            deleteReservation = new DeleteReservationLogic(this);
            registerUser = new RegisterUserLogic(this);
            acceptPayment = new AcceptPaymentLogic(this);
            rfidLogAdd = new RFIDLogAddLogic(this);

            
                
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

        private void EmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            rfid.close();
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            UserModel userModel = UserManager.FindUser(tbSearchUser.Text);

            if (userModel != null)
            {
                if (userManagement == null)
                {
                    userManagement = new UserManagement(this);
                }
                userManagement.SelectedUser = userModel;
                MessageBox.Show("Gebruiker gevonden");
            }
            else
            {
                MessageBox.Show("Geen gebruiker gevonden");
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            userManagement.EditUserInformation();
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                ("Weet je zeker dat je het profiel van " + userManagement.SelectedUser.Username + " wil verwijderen ?"),
                "Weet je het zeker", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                userManagement.SelectedUser.Destroy();
            }
        }

        public class CampingLogic
        {
            //private readonly int[] Blokhutten;
            //private readonly int[] Bungalinos;
            //private readonly int[] Bungalows;
            //private readonly int[] ComfortPlaatsen;
            //private readonly int[] EigenTenten;
            //private readonly int[] Huurtentjes;
            //private readonly int[] Invalidenaccomodatie;
            private readonly EmployeeForm parent;
            //private readonly int[] StaCaravan;
            //private int[] AllPlaces;
            private decimal amount;

            public CampingLogic(EmployeeForm form)
            {
                parent = form;

                UserList = new List<string>();
                places = EquipmentManager.GetAllPlaces();

                //EigenTenten = EigenTentenArray();
                //Bungalows = BungalowArray();
                //Blokhutten = BlokHuttenArray();
                //Bungalinos = BungalinosArray();
                //ComfortPlaatsen = ComfortPlaatsenArray();
                //StaCaravan = StaCaravanArray();

                //Invalidenaccomodatie = Enumerable.Range(85, 6).ToArray();
                //Huurtentjes = Enumerable.Range(643, 36).ToArray();

                //AllPlaces = AllPlacesArray();
                FillAllPlaces();
            }

            public List<string> UserList { get; private set; }
            public List<PlaceModel> places { get; private set; }

            public void AddUserToList()
            {
                parent.lbUser.Items.Add(parent.txtGebruikers.Text);
                UserList.Add(parent.txtGebruikers.Text);
                parent.txtGebruikers.Text = "";
            }

            public bool CheckPlaceSize(int place, int amountofusers)
            {
                if (amountofusers == 0)
                {
                    MessageBox.Show("Vul minstens een persoon in bij gebruikers");
                    return false;
                }
                if (place == 0)
                {
                    MessageBox.Show("Vul een geldige plaats in bij plaats");
                    return false;
                }
                return true;
            }

            private void FillAllPlaces()
            {
                try
                {
                    parent.nmrPlaats.Items.Clear();
                    foreach (PlaceModel place in EquipmentManager.GetAllPlaces())
                    {
                        parent.nmrPlaats.Items.Add(place.Location);
                    }
                }
                catch
                {
                }
            }
        }

        public class PostReviewLogic
        {
            private readonly EmployeeForm parent;

            public PostReviewLogic(EmployeeForm form)
            {
                parent = form;
                parent.flowPostReview.Visible = false;
                FillList();

                parent.flowPostReview.Enabled = true;
                parent.flowPostReview.Visible = true;
            }

            private void FillList()
            {
                parent.flowPostReview.Controls.Clear();
                List<PostReportModel> reportModels = PostManager.GetAllReports();
                if (reportModels != null)
                {
                    foreach (PostReportModel postReportModel in reportModels)
                    {
                        parent.flowPostReview.Controls.Add(new UserPostReview(postReportModel));
                    }
                }
            }

            public void CreateDummyData()
            {
            }
        }

        public class CreateUserLogic
        {
            private readonly EmployeeForm parent;

            public CreateUserLogic(EmployeeForm gui)
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
                                Environment.NewLine + "Wachtwoord: " + Password + Environment.NewLine +
                                "Je wachtwoord is gekopieerd naar je klembord");
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
            private readonly EmployeeForm parent;

            public CreatePlaceLogic(EmployeeForm form)
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
                EquipmentManager.CreateNewPlace(description, price, amount, location, category, capacity);
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
            private readonly EmployeeForm parent;

            public DeleteReservationLogic(EmployeeForm form)
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
                rented.Destroy();
                MessageBox.Show("Reservatie verwijdert");
                parent.cbReservations.SelectedIndex = 0;
            }
        }

        public class RegisterUserLogic
        {
            private readonly EmployeeForm parent;

            public RegisterUserLogic(EmployeeForm form)
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

        public class RFIDLogAddLogic
        {
            private readonly EmployeeForm parent;

            public RFIDLogAddLogic(EmployeeForm form)
            {
                parent = form;
            }

            public void LogAddIn()
            {
                UserModel rfiduser = UserManager.FindUserFromRFID(parent.txtRFIDCode.Text);
                EventManager.LogRFID(rfiduser, RFIDAccessType.EnterTerrain);
                MessageBox.Show("Gebruiker succesvol het terrein binnen gelaten.");
            }

            public void LogAddOut()
            {
                UserModel rfiduser = UserManager.FindUserFromRFID(parent.txtRFIDCode.Text);
                EventManager.LogRFID(rfiduser, RFIDAccessType.ExitTerrain);
                MessageBox.Show("Gebruiker succesvol het terrein verlaten.");
            }
        }

        public class AcceptPaymentLogic
        {
            private readonly EmployeeForm parent;

            public AcceptPaymentLogic(EmployeeForm form)
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
                parent.lblEventPaid.Text = "";
            }
        }

        public class UserManagement
        {
            private readonly EmployeeForm parent;
            private UserModel selectedUser = null;

            public UserManagement(EmployeeForm form)
            {
                parent = form;
            }

            public UserModel SelectedUser
            {
                get { return selectedUser; }
                set { selectedUser = value; }
            }

            public bool EditUserInformation()
            {
                bool changed = false;
                if (parent.tbNewUserName.Text != "")
                {
                    selectedUser.Username = parent.tbNewUserName.Text;
                    changed = true;
                }
                if (parent.tbNewEmail.Text != "")
                {
                    selectedUser.Email = parent.tbNewEmail.Text;
                    changed = true;
                }
                if (parent.tbNewTelephoneNumber.Text != "")
                {
                    selectedUser.Telephonenumber = parent.tbNewTelephoneNumber.Text;
                    changed = true;
                }
                if (parent.tbNewPassword.Text != "" || parent.tbNewPassword2.Text != "")
                {
                    if (parent.tbNewPassword.Text == parent.tbNewPassword2.Text)
                    {
                        if (UserManager.ChangeUserPassword(selectedUser, parent.tbNewPassword.Text))
                        {
                            changed = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("De wachtwoorden komen niet overeen");
                    }
                }
                if (changed)
                {
                    if (selectedUser.Update())
                    {
                        MessageBox.Show("Succesvol aangepast");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Oeps er is iets mis gegaan");
                    }
                }
                return false;
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
            int num;
            bool isRfid = int.TryParse(txtGebruikers.Text, out num);

            if (isRfid)
            {
                if (UserManager.FindUser(Convert.ToInt32(txtGebruikers.Text)) != null)
                {
                    campingLogic.AddUserToList();
                }
                else
                {
                    MessageBox.Show("Gebruiker niet gevonden");
                    txtGebruikers.Text = "";
                }
            }
            else
            {
                if (UserManager.FindUser(txtGebruikers.Text) != null)
                {
                    campingLogic.AddUserToList();
                }
                else
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
                        EquipmentManager.MakePlaceReservationModel(user, plaats);
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
            tabPostReview.Enabled = false;
            if (tabMainTab.SelectedTab == tabCreateUser || tabMainTab.SelectedTab == tabRegisterUser ||
                tabMainTab.SelectedTab == tabAcceptPayment)
            {
                try
                {
                    rfid.Antenna = true;
                    rfid.LED = true;
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    rfid.Antenna = false;
                    rfid.LED = false;
                }
                catch
                {
                }
            }
            if (tabMainTab.SelectedTab == tabPostReview)
            {
                if (postReview == null)
                {
                    postReview = new PostReviewLogic(this);
                }
                tabPostReview.Enabled = true;
            }
            if (tabMainTab.SelectedTab == tabCheckUsersAtEvent)
            {
                listMaterials.Items.Clear();
                List<UserModel> usersOnTerrain = EventManager.GetUsersStillOnPremises();

                if (usersOnTerrain != null)
                {
                    foreach (var user in usersOnTerrain)
                    {
                        listMaterials.Items.Add(user.Username);
                    }
                }
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
            if (txtRFIDCode.Text != "")
            {
                if (UserManager.AuthenticateUser(txtRFIDCode.Text))
                {
                    MessageBox.Show("Gebruiker gevonden.");
                    UserModel rfiduser = UserManager.FindUserFromRFID(txtRFIDCode.Text);
                    lblNameOfUser.Text = "Naam: " + rfiduser.Username;
                    //lblPaymentStatusOfUser.Text = "Payment status:" + UserManager.SeeIfRegistrationIsPaid();
                    lblAtEventStatus.Text = "At Event: " + Convert.ToString(Settings.ActiveEvent.Name);
                }
                else
                {
                    txtRFIDCode.Text = "";
                    MessageBox.Show("RFID-tag Niet gevonden.");
                }
            }
        }

        private void txtRFIDPayment_TextChanged(object sender, EventArgs e)
        {
            if (txtRFIDPayment.Text != "")
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
            LogButtons(true);
        }

        private void btnLeaveUser_Click(object sender, EventArgs e)
        {
            LogButtons(false);
        }

        private void LogButtons(bool goesIn)
        {
            if (txtRFIDCode.Text != "")
            {
                if (goesIn)
                {
                    rfidLogAdd.LogAddIn();
                }
                else
                {
                    rfidLogAdd.LogAddOut();
                }
                lblNameOfUser.Text = "Naam: ";
                lblAtEventStatus.Text = "At event: ";
                txtRFIDCode.Text = "";
            }
            else
            {
                MessageBox.Show("Er is geen gebruiker aanwezig.");
            }
        }

        private void btnAcceptPayment_Click(object sender, EventArgs e)
        {
            acceptPayment.AcceptPayment();
        }

        private void btnMakeMaterial_Click(object sender, EventArgs e)
        {
            if (txtObjectName.Text != "" && txtDescriptionMaterial.Text != "")
            {
                EquipmentManager.CreateNewRentable(txtDescriptionMaterial.Text, numMaterialPrice.Value,
                    Convert.ToInt32(numMaterialAmount.Value), txtObjectName.Text);
                MessageBox.Show("Materiaal aangemaakt!");
                txtDescriptionMaterial.Text = "";
                txtObjectName.Text = "";
                numMaterialAmount.Value = 1;
                numMaterialPrice.Value = 0;
            }
            else
            {
                MessageBox.Show("Vul alle velden in!");
            }
        }

        private void listEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserModel user = UserManager.FindUserFromRFID(txtRFIDPayment.Text);
            List<RegistrationModel> events = UserManager.GetUserRegistrations(user);
            bool ispaid = false;
            string text = listEvents.GetItemText(listEvents.SelectedItem);
            foreach (RegistrationModel _event in events)
            {
                if (_event.EventItem.Name == text)
                {
                    if (UserManager.SeeIfRegistrationIsPaid(_event) == true)
                    {
                        ispaid = true;
                        break;
                    }
                }
            }
            if (ispaid)
            {
                lblEventPaid.Text = "Betaald";
            }
            else
            {
                lblEventPaid.Text = "Niet betaald";
            }
        }

        #endregion

    }
}