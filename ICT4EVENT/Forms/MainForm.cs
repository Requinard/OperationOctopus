using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ICT4EVENT.Models;

namespace ICT4EVENT
{
    public partial class MainForm : Form
    {
        private string filePath = "";

        public MainForm()
        {
            InitializeComponent();
            FillList();
            FillMaterials();
            treeTags();
            UpdateProfile(Settings.ActiveUser);
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

        private void CreateTestPosts()
        {
            PostManager.CreateNewPost("Wat is het social media event toch geweldig");
        }

        private void FillList()
        {
            var postModels = PostManager.GetPostsByPage();
            foreach (var postModel in postModels)
            {
                flowPosts.Controls.Add(new UserPost(postModel));
            }
        }

        private void FillMaterials()
        {
            var rentables = EquipmentManager.GetAllRentables();
            foreach (var rentModel in rentables)
            {
                listMaterials.Items.Add(rentModel.ObjectType).SubItems.Add(rentModel.Description);
            }
        }

        private void tabMainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            DynamicButtonLogic(false);
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
                    var postModel = PostManager.CreateNewPost(tbPostContent.Text, filePath);

                    if (postModel != null)
                    {
                        Control[] oldControls = new Control[flowPosts.Controls.Count];
                        flowPosts.Controls.CopyTo(oldControls, 0);
                        flowPosts.Controls.Clear();


                        flowPosts.Controls.Add(new UserPost(postModel));

                        flowPosts.Controls.AddRange(oldControls);
                    }

                    treeTags();
                }
            }
            if (tabMainTab.SelectedTab.Name == "tabMaterialrent")
            {
                btnDynamicButton.Text = "Huur";

                // button actions happen here
                if (action)
                {
                    //Make object reservation in manager.
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
            openFileDialog1.ShowDialog();
            {
                filePath = openFileDialog1.FileName;
            }
        }

        private void btnHireMaterial_Click(object sender, EventArgs e)
        {
            var selectedItem = listMaterials.SelectedItems[0];
            var selectedString = selectedItem.SubItems[0].Text;
            listCart.Items.Add(selectedString);
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
                var selectedItem = listMaterials.SelectedItems[intselectedindex];
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
            lblUserDisplayName.Text = user.Username;

            lblUserDescription.Text = user.Address;

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
    }
}