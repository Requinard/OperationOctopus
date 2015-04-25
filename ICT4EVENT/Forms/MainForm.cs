using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ICT4EVENT.Models;

namespace ICT4EVENT
{
    public partial class MainForm : Form
    {
        private string filePath = "";
        private int currentPage = 0;

        public MainForm()
        {
            InitializeComponent();
            FillList();
            //FillMaterials();
            FillAllPlaces();
            treeTags();
            //UpdateProfile(Settings.ActiveUser);

        }

        public ComboBox cbProfileSelector { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Settings.DEBUG)
            {
                CreateTestPosts();
            }
            DynamicButtonLogic(false);
        }

        private void FillAllPlaces()
        {
            lbUser.Items.Add(Settings.ActiveUser.Username);
            try
            {
                nmrPlaats.Items.Clear();
                foreach (PlaceModel place in EquipmentManager.GetAllPlaces())
                {
                    nmrPlaats.Items.Add(place.Location);
                }
            }
            catch { }
        }

        private void CreateTestPosts()
        {
            PostManager.CreateNewPost("Wat is het social media event toch geweldig");
        }

        private void FillList()
        {
            var postModels = PostManager.GetPostsByPage();
            if(postModels == null) return;
            foreach (var postModel in postModels)
            {
                if (postModel.Parent == null)
                {
                    flowPosts.Controls.Add(new UserPost(postModel));  
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
            DynamicButtonLogic(false);
            if (tabMainTab.SelectedTab == tabPaymentStat)
            {
                lblPaidUsername.Text = Settings.ActiveUser.Username;
                lblPaidEvent.Text = Settings.ActiveEvent.Name;
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
                    lblPaidCheck.Text = "Betaald";
                }
                else
                {
                    lblPaidCheck.Text = "Niet betaald";
                }
            }
        }

        private void btnDynamicButton_Click(object sender, EventArgs e)
        {
            DynamicButtonLogic(true);
        }

        public void DynamicButtonLogic(bool action)
        {
            if (tabMainTab.SelectedTab.Name == "tabSocialMediaSharingSystem")
            {
                btnDynamicButton.Text = "Post";

                // button actions happen here
                if (action)
                {
                    if (tbPostContent.Text != "" || filePath != "")
                    {
                      var postModel = PostManager.CreateNewPost(tbPostContent.Text, filePath);

                      if (postModel != null)
                      {
                          Control[] oldControls = new Control[flowPosts.Controls.Count];
                          flowPosts.Controls.CopyTo(oldControls, 0);
                          flowPosts.Controls.Clear();


                          flowPosts.Controls.Add(new UserPost(postModel));

                          flowPosts.Controls.AddRange(oldControls);

                          filePath = "";
                      }
                    treeTags();  
                    }
                    else
                    {
                        MessageBox.Show("Type een bericht of voeg een mediabestand toe");
                    }
                }
                
            }
            if (tabMainTab.SelectedTab.Name == "tabMaterialrent")
            {
                btnDynamicButton.Text = "Huur";
                FillMaterials();

                // button actions happen here
                if (action)
                {
                    ReserveMaterial();
                }
            }
            if (tabMainTab.SelectedTab.Name == "tabProfile")
            {
                btnDynamicButton.Text = "Search User";

                // button actions happen here
                if (action)
                {
                    SearchUser();
                }
            }
            if (tabMainTab.SelectedTab.Name == "tabSettings")
            {
                btnDynamicButton.Text = "Bevestig";

                // button actions happen here
                if (action)
                {
                    if (tbNewPassword.Text == tbNewPassword2.Text)
                    {
                        if (UserManager.ChangeUserPassword(tbNewPassword.Text))
                        {
                            MessageBox.Show("Wachtwoord Succesvol Gewijzigd");
                        }
                    }
                    else
                    {
                        MessageBox.Show("De wachtwoorden komen niet overeen");
                    }
                    
                }
            }
        }

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
            }

        }

        private void btnHireMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = listMaterials.SelectedItems[0];
                var selectedString = selectedItem.SubItems[0].Text;
                listCart.Items.Add(selectedString);
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
            if (listCart.SelectedIndex >= 0)
            {
                listCart.Items.RemoveAt(listCart.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Selecteer eerst een product.");
            }
        }

        private void treeCategorie_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var tag = e.Node.Text;

            if (tag == "All Posts")
            {
                flowPosts.Controls.Clear();
                FillList();
                return;
            }

            var posts = PostManager.GetPostByTags(tag);

            if (posts == null)
                return;

            flowPosts.Controls.Clear();

            foreach (var postModel in posts)
            {
                flowPosts.Controls.Add(new UserPost(postModel));
            }
        }

        private void UpdateProfile(UserModel user)
        {


            gbPostsOfUser.Text += user.Username;
            gbProfileOfUser.Text += user.Username;

            lblUserDisplayName.Text += user.Username;
            lblRFIDFromProfile.Text += user.RfiDnumber;
            lblEmailFromUser.Text += user.Email;
            lblTelefoonNummer.Text += user.Telephonenumber;

            List<PostModel> posts = PostManager.GetUserPosts(user);

            flowPostsFromUser.Controls.Clear();

            if (posts != null)
            {
                foreach (PostModel post in posts)
                {
                    flowPostsFromUser.Controls.Add(new UserPost(post));
                }
            }
        }

        private void tbSearchUser_TextChanged(object sender, EventArgs e)
        {

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
                foreach (string rentable in listCart.Items)
                {
                    foreach (RentableObjectModel rentableobject in rentables)
                    {
                        if (rentableobject.ObjectType == rentable)
                        {
                            EquipmentManager.MakeObjectReservervation(Settings.ActiveUser, rentableobject, Convert.ToInt32(numAmount.Value));
                        }
                    }
                }
                MessageBox.Show("Artikelen besteld");
                listCart.Items.Clear();
            }
            else
            {
                MessageBox.Show("Winkelmandje is leeg");
            }
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
            flowPosts.Controls.Clear();
            List<PostModel> postModels = PostManager.GetPostsByPage(null, currentPage + direction, 10);
            {
                foreach (PostModel postModel in postModels)
                {
                    flowPosts.Controls.Add(new UserPost(postModel));
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //Als we dit form sluiten gaan we automatisch terug naar inlog
            this.Close(); 
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

        private void btnReserve_Click(object sender, EventArgs e)
        {
            PlaceModel plaats = null;
            List<PlaceModel> places = EquipmentManager.GetAllPlaces();

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
                }
            }
            else
            {
                MessageBox.Show("Deze plaats is niet beschikbaar.");
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tabMainTab.SelectedTab.Refresh();
        }
    }
}