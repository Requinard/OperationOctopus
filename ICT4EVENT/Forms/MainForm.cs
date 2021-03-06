﻿#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ICT4EVENT.Models;
using Microsoft.VisualBasic;

#endregion

namespace ICT4EVENT
{
    public partial class MainForm : Form
    {
        private int currentPage = 0;
        private string filePath = "";

        public MainForm()
        {
            InitializeComponent();

            FillPostList();
            //FillMaterials();
            FillReservedMaterials();
            FillReservedPlaces();
            FillAllPlaces();
            treeTags();
            //UpdateProfile(Settings.ActiveUser);
            ControlPost.ControlLinkClicked += PostLinkClicked;
        }

        public ComboBox cbProfileSelector { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Settings.DEBUG)
            {
               
            }
            DynamicButtonLogic(false);
        }

        private void FillAllPlaces()
        {
            lbUser.Items.Clear();
            lbUser.Items.Add(Settings.ActiveUser.Username);
            try
            {
                nmrPlaats.Items.Clear();
                foreach (PlaceModel place in EquipmentManager.GetAllPlaces())
                {
                    if (!EquipmentManager.CheckIfPlaceIsAvailable(place))
                    {
                        nmrPlaats.Items.Add(place.Location);
                    }
                }
            }
            catch
            {
            }
        }

        private void FillReservedMaterials()
        {
            try
            {
                listReservedMaterials.Items.Clear();
                List<RentableReservationModel> rentables = EquipmentManager.GetUserReservations(Settings.ActiveUser);
                foreach (RentableReservationModel rentable in rentables)
                {
                    if (rentable.Rentable.ObjectType != "")
                    {
                        listReservedMaterials.Items.Add(rentable.Rentable.ObjectType);
                    }
                }
            }
            catch
            {
            }
        }

        private void FillReservedPlaces()
        {
            try
            {
                listReservedPlaces.Items.Clear();
                List<PlaceReservationModel> places = EquipmentManager.GetUserPlaceReservations(Settings.ActiveUser);
                foreach (PlaceReservationModel place in places)
                {
                    listReservedPlaces.Items.Add(place.Place.Location);
                }
            }
            catch
            {
            }
        }

        private void PostLinkClicked(UserModel userModel)
        {
            tabMainTab.SelectTab(tabProfile);
            tbSearchUser.Text = userModel.Username;
            DynamicButtonLogic(true);
        }

        private void FillPostList()
        {
            flowPosts.Controls.Clear();
            var postModels = PostManager.GetPostsByPage(null,currentPage,10);
            if (postModels == null) return;
            if (postModels.Count == 0) return;
            foreach (var postModel in postModels)
            {
                if (postModel.Parent == null)
                {
                    flowPosts.Controls.Add(new ControlPost(postModel));
                }
            }
        }

        private void FillMaterials()
        {
            listMaterials.Items.Clear();
            var rentables = EquipmentManager.GetAllRentables();
            if (rentables == null) return;
            foreach (var rentModel in rentables)
            {
                listMaterials.Items.Add(rentModel.ObjectType).SubItems.Add(rentModel.Description);
            }
        }

        private void tabMainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabProfile.Enabled = false;
            tabSocialMediaSharingSystem.Enabled = false;
            DynamicButtonLogic(false);
            
        }

        private void btnDynamicButton_Click(object sender, EventArgs e)
        {
            DynamicButtonLogic(true);
        }

        public void DynamicButtonLogic(bool action)
        {
            if (tabMainTab.SelectedTab == tabSocialMediaSharingSystem)
            {
                
                tabSocialMediaSharingSystem.Enabled = true;
                // button actions happen here
                if (action)
                {
                    btnDynamicButton.Text = "Uploading...";
                    CreatePost();
                    tbPostContent.Text = "";
                    btnDynamicButton.Text = "Post";
                    return;
                }
                else
                {
                    btnDynamicButton.Text = "Post";
                }
            }
            else if (tabMainTab.SelectedTab == tabMaterialrent)
            {
                btnDynamicButton.Text = "Huur";
                FillMaterials();

                // button actions happen here
                if (action)
                {
                    ReserveMaterial();
                    return;
                }
            }

            else if (tabMainTab.SelectedTab == tabReservePlace)
            {
                btnDynamicButton.Text = "Reserveer";

                if (action)
                {
                    ReservePlace();
                    return;
                }
            }
            else if (tabMainTab.SelectedTab == tabPaymentStat)
            {
                btnDynamicButton.Text = "Ververs";

                PaymentInfo();

                if (action)
                {
                    tabMainTab.SelectedTab.Refresh();
                }

            }
            else if (tabMainTab.SelectedTab == tabReserved)
            {
                btnDynamicButton.Text = "Ververs";

                FillReservedMaterials();
                FillReservedPlaces();

                if (action)
                {
                    tabMainTab.SelectedTab.Refresh();
                }

            }
            else if (tabMainTab.SelectedTab == tabProfile)
            {
                btnDynamicButton.Text = "Search User";
                tabProfile.Enabled = true;
                // button actions happen here
                if (action)
                {
                    SearchUser();
                    return;
                }
            }
            else if (tabMainTab.SelectedTab == tabSettings)
            {
                btnDynamicButton.Text = "Bevestig";

                // button actions happen here
                if (action)
                {
                    changeUserInformation();
                    return;
                }
            }
        }
        #region dynamicButtonActions

        private void CreatePost()
        {
            if (tbPostContent.Text != "")
            {
                var postModel = PostManager.CreateNewPost(tbPostContent.Text, filePath);

                if (postModel != null)
                {
                    Control[] oldControls = new Control[flowPosts.Controls.Count];
                    flowPosts.Controls.CopyTo(oldControls, 0);
                    flowPosts.Controls.Clear();


                    flowPosts.Controls.Add(new ControlPost(postModel));

                    flowPosts.Controls.AddRange(oldControls);

                    filePath = "";

                    btnMediaFile.Size = new Size(156, 57);
                    btnMediaFile.ForeColor = Color.Black;
                    lblSelectedFile.Enabled = false;
                    lblSelectedFile.Visible = false;
                }
                treeTags();
            }
            else
            {
                MessageBox.Show("Type een bericht of voeg een mediabestand toe");
            }
        }

        private void changeUserInformation()
        {
            bool changed = false;
            if (tbNewUserName.Text != "")
            {
                Settings.ActiveUser.Username = tbNewUserName.Text;
                changed = true;
            }
            if (tbNewEmail.Text != "")
            {
                Settings.ActiveUser.Email = tbNewEmail.Text;
                changed = true;
            }
            if (tbNewTelephoneNumber.Text != "")
            {
                Settings.ActiveUser.Telephonenumber = tbNewTelephoneNumber.Text;
                changed = true;
            }
            if (tbNewPassword.Text != "" || tbNewPassword2.Text != "")
            {
                if (tbNewPassword.Text == tbNewPassword2.Text)
                {
                    if (UserManager.ChangeUserPassword(Settings.ActiveUser, tbNewPassword.Text))
                    {
                        MessageBox.Show("Wachtwoord Succesvol Gewijzigd");
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
                if (Settings.ActiveUser.Update())
                {
                    MessageBox.Show("Succesvol aangepast");
                }
                else
                {
                    MessageBox.Show("Oeps er is iets mis gegaan");
                }
            }
        }
        private void UpdateProfile(UserModel user)
        {
            gbPostsOfUser.Text = string.Format("Posts van {0}", user.Username);
            gbProfileOfUser.Text = string.Format("Profiel van {0}", user.Username);

            lblUserDisplayName.Text = string.Format("Weergave naam : {0}", user.Username);
            lblRFIDFromProfile.Text = string.Format("RFID : {0}", user.RfiDnumber);
            lblEmailFromUser.Text = string.Format("Email : {0}", user.Email);
            lblTelefoonNummer.Text = string.Format("Telefoonnummer: {0}", user.Telephonenumber);

            List<PostModel> posts = PostManager.GetUserPosts(user);

            flowPostsFromUser.Controls.Clear();

            if (posts != null)
            {
                foreach (PostModel post in posts)
                {
                    flowPostsFromUser.Controls.Add(new ControlPost(post));
                }
            }
        }

        private void PaymentInfo()
        {
            lblPaidUsername.Text = string.Format("Gebruikersnaam : {0}", Settings.ActiveUser.Username);
            lblPaidEvent.Text = string.Format("Evenementnaam : {0}", Settings.ActiveEvent.Name); ;
            List<RegistrationModel> registrations = UserManager.GetUserRegistrations(Settings.ActiveUser);
            bool haspaid = false;
            foreach (RegistrationModel registration in registrations)
            {
                if (registration.EventItem.Id == Settings.ActiveEvent.Id)
                {
                    if (UserManager.SeeIfRegistrationIsPaid(registration))
                    {
                        haspaid = true;
                        break;
                    }
                }
            }
            if (haspaid)
            {
                gbPaymentStatus.Text = string.Format("Betalings status : {0}", "Betaald");
                pbPaidCheck.BackColor = Color.GreenYellow;
            }
            else
            {
                gbPaymentStatus.Text = string.Format("Betalings status : {0}", "Nog niet betaald");
                pbPaidCheck.BackColor = Color.Red;
            }
        }
        private void SearchUser()
        {
            UserModel user = UserManager.FindUser(tbSearchUser.Text);

            if (user != null)
            {
                UpdateProfile(user);
            }

            else
            {
                if (lblUserDisplayName.Text != Settings.ActiveUser.Username)
                    UpdateProfile(Settings.ActiveUser);
            }
        }
        private void ReserveMaterial()
        {
            if (listCart.Items.Count > 0)
            {
                List<RentableObjectModel> rentables = EquipmentManager.GetAllRentables();
                foreach (ListViewItem rentable in listCart.Items)
                {
                    int j = 1;
                    for (int i = 0; i < rentable.SubItems.Count; i++)
                    {
                        foreach (RentableObjectModel rentableobject in rentables)
                            {  
                                if (rentableobject.ObjectType == rentable.SubItems[i].Text)
                                {
                                    EquipmentManager.MakeObjectReservervation(Settings.ActiveUser, rentableobject,
                                        Convert.ToInt32(rentable.SubItems[j].Text));
                                    j++;
                                }
                            }
                        }
                }
                MessageBox.Show("Artikelen besteld");
                listCart.Items.Clear();
                FillReservedMaterials();
            }
            else
            {
                MessageBox.Show("Winkelmandje is leeg");
            }
        }
        private void ReservePlace()
        {
            PlaceModel plaats = null;
            List<PlaceModel> places = EquipmentManager.GetAllPlaces();
            if (places != null)
            {
                foreach (PlaceModel pm in places)
                {
                    if (pm.Location == nmrPlaats.Text)
                    {
                        plaats = pm;
                        break;
                    }
                }

                if (plaats != null)
                {
                    if (CheckPlaceSize(Convert.ToInt32(nmrPlaats.Text), lbUser.Items.Count))
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
                        lbUser.Items.Clear();
                        FillAllPlaces();
                    }
                }
                else
                {
                    MessageBox.Show("Deze plaats is niet beschikbaar.");
                }
                
            }
           
            FillReservedPlaces();
        }

        #endregion

        private void treeTags()
        {
            var tags = new List<TagModel>();
            tags = PostManager.GetAllTags();

            treeCategorie.Nodes.Clear();

            treeCategorie.Nodes.Add("All Posts");

            foreach (var tag in tags)
            {
                treeCategorie.Nodes.Add(tag.Name);
            }
        }
       
        private void btnMediaFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                filePath = openFileDialog1.FileName;
                btnMediaFile.ForeColor = Color.LawnGreen;
                btnMediaFile.Size = new Size(156, 32);
                lblSelectedFile.Enabled = true;
                lblSelectedFile.Visible = true;
                lblSelectedFile.Text = openFileDialog1.SafeFileNames[0];
            }
        }

        private void btnHireMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = listMaterials.SelectedItems[0];
                var selectedString = selectedItem.SubItems[0].Text;
                listCart.Items.Add(selectedString).SubItems.Add(Convert.ToString(numAmount.Value)); ;
            }
            catch
            {
                MessageBox.Show("Selecteer eerst een product");
            }
        }

        private void listMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMaterials.SelectedIndices.Count <= 0)
            {
                lblDetails.Text = "Selecteer een product.";
                return;
            }
            var intselectedindex = listMaterials.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                //var selectedItem = listMaterials.SelectedItems[intselectedindex];
                var selectedItem = listMaterials.SelectedItems[0];
                var selectedString = selectedItem.SubItems[1].Text;
                lblDetails.Text = selectedString;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                listCart.Items.RemoveAt(listCart.SelectedIndices[0]);
            }
            catch
            {
                MessageBox.Show("Selecteer een item dat u wilt verwijderen!");
            }
        }

        private void treeCategorie_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var tag = e.Node.Text;

            if (tag == "All Posts")
            {
                flowPosts.Controls.Clear();
                FillPostList();
                return;
            }

            var posts = PostManager.GetPostByTags(tag);

            if (posts == null)
                return;

            flowPosts.Controls.Clear();

            foreach (var postModel in posts)
            {
                flowPosts.Controls.Add(new ControlPost(postModel));
            }
        }

        

        private void tbSearchUser_TextChanged(object sender, EventArgs e)
        {
        }

        



        private void btnNextPage_Click(object sender, EventArgs e)
        {
            pageModifier(1);
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            pageModifier(-1);
        }

        private void pageModifier(int direction)
        {
            currentPage += direction;
            numPage.Value = currentPage;
            FillPostList();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //Als we dit form sluiten gaan we automatisch terug naar inlog
            Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            int num;
            bool isRfid = int.TryParse(txtGebruikers.Text, out num);

            if (isRfid)
            {
                if (UserManager.FindUser(Convert.ToInt32(txtGebruikers.Text)) != null)
                {
                    lbUser.Items.Add(txtGebruikers.Text);
                    txtGebruikers.Text = "";
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
                    lbUser.Items.Add(txtGebruikers.Text);
                    txtGebruikers.Text = "";
                }
                else
                {
                    MessageBox.Show("Gebruiker niet gevonden");
                    txtGebruikers.Text = "";
                }
            }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Zoek");

            if (input != "")
            {
                List<PostModel> postModels = PostManager.FindPost(input);
                if (postModels != null)
                {
                    flowPosts.Controls.Clear();
                    foreach (PostModel postModel in postModels)
                    {
                        flowPosts.Controls.Add(new ControlPost(postModel));
                    }
                    MessageBox.Show(string.Format("Er zijn {0} resultaten gevonden", postModels.Count));
                    return;
                }
                else
                {
                    MessageBox.Show("Geen posts gevonden");
                }
            }
        }

        private void numPage_ValueChanged(object sender, EventArgs e)
        {
            if (numPage.Value != currentPage)
            {
                currentPage = (int)numPage.Value;
                pageModifier(0);
            }

        }
    }
}