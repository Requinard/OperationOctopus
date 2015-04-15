﻿using System;
using System.Drawing;
using System.Windows.Forms;

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
        }

        private void CreateTestPosts()
        {
            var r = new Random(8);
            UserPost post;
            post = new UserPost("David == fucking haat", "Guus", Image.FromFile(@"The Cage.jpg"),
                Image.FromFile(@"nicolas-cage-will-be-in-the-expendables-3.jpg"),
                new UserPost("@Guus, Random Text", null, null, null));
            flowUserPosts.Controls.Add(post);

            for (var i = 0; i < 10; i++)
            {
                post = new UserPost("Random Text", null, null, null);
                flowUserPosts.Controls.Add(post);
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
            }
        }
    }
}