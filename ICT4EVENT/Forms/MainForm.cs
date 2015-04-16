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
        private MainGuiLogic mainGuiLogic;
        public MainForm()
        {
            InitializeComponent();
            mainGuiLogic = new MainGuiLogic(this);
            // TODO: Repair initializations from social media manager
            //socialManager = new SocialMediaEventManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Settings.DEBUG)
            {
                CreateTestPosts();
            }
            mainGuiLogic.DynamicButtonLogic();
            //FillList();
        }

        private void CreateTestPosts()
        {
            
        }

        private void FillList(List<PostModel> postModels)
        {
            foreach (PostModel postModel in postModels)
            {
                flowPostsFromUser.Controls.Add(new UserPost(postModel));
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
            mainGuiLogic.DynamicButtonLogic();
        }

        private void btnDynamicButton_Click(object sender, EventArgs e)
        {

        }

        public class MainGuiLogic
        {
            private MainForm parent;

            public MainGuiLogic(MainForm mainform)
            {
                parent = mainform;
            }

            public void DynamicButtonLogic()
            {
                if (parent.tabMainTab.SelectedTab.Name == "tabSocialMediaSharingSystem")
                {
                    parent.btnDynamicButton.Text = "Post";

                    // button actions happen here
                    PostingLogic(parent.tbPostContent.Text);
                }
                if (parent.tabMainTab.SelectedTab.Name == "tabMaterialrent")
                {
                    parent.btnDynamicButton.Text = "Huur";

                    // button actions happen here
                }
                if (parent.tabMainTab.SelectedTab.Name == "tabProfile")
                {
                    parent.btnDynamicButton.Text = "Bevestig";

                    // button actions happen here
                }
                if (parent.tabMainTab.SelectedTab.Name == "tabSettings")
                {
                    parent.btnDynamicButton.Text = "Bevestig";

                    // button actions happen here
                }
            }

            public bool PostingLogic(string PostContent)
            {
                PostManager.CreateNewPost(PostContent);

                return false;
            }

            
        }

        private void tabMainTab_Selected(object sender, TabControlEventArgs e)
        {
            Image test = new Bitmap(161, 161);
            EquipmentManager.Initialize();
            foreach (RentableObjectModel ROM in EquipmentManager.rentables)
            {
                flowMaterials.Controls.Add(new Materials(test, ROM.ObjectType, ROM.Description));
            }
        }
    }
}