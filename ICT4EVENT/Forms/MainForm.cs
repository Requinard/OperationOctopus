using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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
            List<PostModel> postModels = PostManager.GetPostsByPage();
            foreach (PostModel postModel in postModels)
            {
                flowPosts.Controls.Add(new UserPost(postModel));
            }
        }

        private void FillMaterials()
        {
            List<RentableObjectModel> rentables = EquipmentManager.GetAllRentables();
            foreach (RentableObjectModel rentModel in rentables)
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
                    
                    PostModel postModel = PostManager.CreateNewPost(tbPostContent.Text, filePath);
                    if (postModel != null)
                    {
                        flowPosts.Controls.Add(new UserPost(postModel));
                    }
                }

            }
            if (tabMainTab.SelectedTab.Name == "tabMaterialrent")
                {
                btnDynamicButton.Text = "Huur";

                    // button actions happen here
                if (action)
                {
                    List<string> Reserved = new List<string>();
                    foreach (string item in listCart.Items)
                    {
                        Reserved.Add(item);
                    }
                    //Make object reservation in manager.
                }
            }
            if (tabMainTab.SelectedTab.Name == "tabProfile")
                {
                btnDynamicButton.Text = "Search User";

                    // button actions happen here
                    if (action)
                    {
                        UserModel userModel = UserManager.FindUser(tbSearchUser.Text);
                        if (userModel != null)
                        {
                            gbProfileOfUser.Text += userModel.Username;
                            gbPostsOfUser.Text += userModel.Username;
                            lblUserDisplayName.Text += userModel.Username;

                            List<PostModel> postModels = PostManager.RetrieveUserPosts(userModel);
                            foreach (PostModel postModel in postModels)
                            {
                                flowPostsFromUser.Controls.Add(new UserPost(postModel));
                            }
                        }
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
            List<TagModel> tags = new List<TagModel>();
            tags = PostManager.GetAllTags();
            foreach (TagModel tag in tags)
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
            ListViewItem selectedItem = listMaterials.SelectedItems[0];
            string selectedString = selectedItem.SubItems[0].Text;
            listCart.Items.Add(selectedString);
        }

        private void listMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMaterials.SelectedIndices.Count <= 0)
            {
                lblDetails.Text = "Selecteer een product.";
                return;
            }
            int intselectedindex = listMaterials.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                ListViewItem selectedItem = listMaterials.SelectedItems[intselectedindex];
            string selectedString = selectedItem.SubItems[1].Text;
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
    }
    }
