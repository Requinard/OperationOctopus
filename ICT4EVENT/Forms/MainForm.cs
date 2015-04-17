using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ICT4EVENT.Controls;

namespace ICT4EVENT
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // TODO: Repair initializations from social media manager
            //socialManager = new SocialMediaEventManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Settings.DEBUG)
            {
                CreateTestPosts();
            }
            DynamicButtonLogic(false);
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
                flowPostsFromUser.Controls.Add(new UserPost(postModel));
            }
        }

        private void FillMaterials()
        {
            List<RentableObjectModel> Rentables = EquipmentManager.GetAllRentables();
            foreach (RentableObjectModel rentModel in Rentables)
            {
                flowMaterials.Controls.Add(new Materials(rentModel.ObjectType, rentModel.Description));
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            if (cbProfileSelector.Text.Length >= 3)
            {
                //Add the results of the search query here
                cbProfileSelector.Items.Add(null);
            }
        }

        private void tabMainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            DynamicButtonLogic(false);
        }

        private void btnDynamicButton_Click(object sender, EventArgs e)
        {
            DynamicButtonLogic(false);
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
                btnDynamicButton.Text = "Bevestig";

                // button actions happen here
            }
            if (tabMainTab.SelectedTab.Name == "tabSettings")
            {
                btnDynamicButton.Text = "Bevestig";

                // button actions happen here
            }
        }

        public bool PostingLogic(string PostContent)
        {
            if (PostManager.CreateNewPost(PostContent) != null)
            {
                return true;
            }

            return false;
        }

       
    }
}