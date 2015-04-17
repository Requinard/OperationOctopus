﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace ICT4EVENT
{
    using ICT4EVENT.Controls;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            FillMaterials();
            DynamicButtonLogic(false);
            // TODO: Repair initializations from social media manager
            //socialManager = new SocialMediaEventManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Settings.DEBUG)
            {
                CreateTestPosts();
            }
            FillList(PostManager.GetPostsByPage());
        }

        private void CreateTestPosts()
        {
            PostManager.CreateNewPost("Wat is het social media event toch geweldig");
        }

        private void FillList(List<PostModel> postModels)
        {
            foreach (PostModel postModel in postModels)
            {
                flowPosts.Controls.Add(new UserPost(postModel));
            }
        }

        private void FillMaterials()
        {
            listMaterials.Columns.Add("Naam");
            listMaterials.Columns.Add("Beschrijving");
            List<RentableObjectModel> rentables = EquipmentManager.GetAllRentables();
            foreach (RentableObjectModel rentModel in rentables)
            {
                listMaterials.Items.Add(rentModel.ObjectType, rentModel.Description);
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
                    PostingLogic(tbPostContent.Text);
                }

            }
            if (tabMainTab.SelectedTab.Name == "tabMaterialrent")
            {
                btnDynamicButton.Text = "Huur";

                // button actions happen here
            }
            if (tabMainTab.SelectedTab.Name == "tabProfile")
            {
                btnDynamicButton.Text = "Zoek User";

                // button actions happen here

                if (action)
                {
                    UserModel userModel = UserManager.FindUser(tbUserToFind.Text);

                    if (userModel != null)
                    {
                        gbProfileOfUser.Enabled = true;
                        gbPostsOfUser.Enabled = true;
                        gbProfileOfUser.Text += userModel.Username;
                        gbPostsOfUser.Text += userModel.Username;
                        lblUserDisplayName.Text += userModel.Username;

                        List<PostModel> postsFromUserList = PostManager.RetrieveUserPosts(userModel);
                        foreach (PostModel postModel in postsFromUserList)
                        {
                            flowPostsFromUser.Controls.Add(new UserPost(postModel));
                        }
                    }
                    else
                    {
                        MessageBox.Show("User niet gevonden");
                    }
                }
            }
            if (tabMainTab.SelectedTab.Name == "tabSettings")
            {
                btnDynamicButton.Text = "Bevestig";

                // button actions happen here
            }
        }

        public bool PostingLogic(string PostContent)
        {
            PostManager.CreateNewPost(PostContent);

            return false;
        }
        

        private void btnHireMaterial_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = listMaterials.SelectedItems[0];
            string selectedString = selectedItem.SubItems[0].Text;
            listCart.Items.Add(selectedString);
        }

        private void listMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem selectedItem = listMaterials.SelectedItems[0];
            string selectedString = selectedItem.SubItems[1].Text;
            lblDetails.Text = selectedString;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            listCart.Items.RemoveAt(listCart.SelectedIndex);
        }
    }
}
