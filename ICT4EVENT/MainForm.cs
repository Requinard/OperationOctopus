using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4EVENT
{
    public partial class MainForm : Form
    {
        private SocialMediaEventManager socialManager;

        public MainForm()
        {
            InitializeComponent();

            socialManager = new SocialMediaEventManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            testData();

           

           
        }

        private void testData()
        {
            UserPost post;

            post = new UserPost("David != fucking haat", "Guus", Image.FromFile(@"The Cage.jpg"), Image.FromFile(@"nicolas-cage-will-be-in-the-expendables-3.jpg"), new UserPost("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi eu ipsum vitae magna feugiat vulputate. Nullam hendrerit nec erat non ullamcorper. Quisque ornare pulvinar lorem eget dictum. Ut fermentum molestie faucibus. Curabitur pulvinar lorem at ultrices vehicula. Nullam quis leo pellentesque, consequat dui malesuada, dignissim orci. Aliquam vehicula sodales libero sit amet molestie. Praesent egestas sodales viverra. Quisque porttitor lorem nisl, eget eleifend lacus mattis id. Vivamus nec pharetra orci.", null, null, null));
            flowUserPosts.Controls.Add(post);

            post = new UserPost("David != fucking haat", "Guus", Image.FromFile(@"The Cage.jpg"), Image.FromFile(@"nicolas-cage-will-be-in-the-expendables-3.jpg"), new UserPost("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi eu ipsum vitae magna feugiat vulputate. Nullam hendrerit nec erat non ullamcorper. Quisque ornare pulvinar lorem eget dictum. Ut fermentum molestie faucibus. Curabitur pulvinar lorem at ultrices vehicula. Nullam quis leo pellentesque, consequat dui malesuada, dignissim orci. Aliquam vehicula sodales libero sit amet molestie. Praesent egestas sodales viverra. Quisque porttitor lorem nisl, eget eleifend lacus mattis id. Vivamus nec pharetra orci.", null, null, null));
            flowPostsFromUser.Controls.Add(post);

            for (int i = 0; i < 10; i++)
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

        private void tabMainTab_TabIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void tabMainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMainTab.SelectedTab.Name == "tabSocialMediaSharingSystem")
            {
                btnDynamicButton.Text = "Post";

                // button actions happen here

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


       

        




    }
}
