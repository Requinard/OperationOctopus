using System;
using System.Drawing;
using System.Windows.Forms;

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
        }

        private void CreateTestPosts()
        {
            var r = new Random(8);
            UserPost post;

            DynamicButtonLogic(false);

            Image image = (DrawFilledRectangle(400, 400));
        
            
       

            post = new UserPost("David != fucking haat", "Guus", Image.FromFile(@"The Cage.jpg"),
                image,
                new UserPost("@Guus, Random Text", null, null, null));
            flowUserPosts.Controls.Add(post);

            for (var i = 0; i < 10; i++)
            {
                post = new UserPost("Random Text", null, null, null);
                flowUserPosts.Controls.Add(post);
            }
        }

        private Bitmap DrawFilledRectangle(int x, int y)
        {
            Bitmap bmp = new Bitmap(x, y);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, x, y);
                graph.FillRectangle(Brushes.White, ImageSize);
            }
            return bmp;
        }

        public void DynamicButtonLogic(bool action)
        {
            if (tabMainTab.SelectedTab.Name == "tabSocialMediaSharingSystem")
            {
                btnDynamicButton.Text = "Post";

                // button actions happen here

                if (action)
                {
                    PostManager.CreateNewPost(tbPostContent.Text,null);
                }
            }
            if (tabMainTab.SelectedTab.Name == "tabMaterialrent")
            {
                btnDynamicButton.Text = "Huur";
                
                // button actions happen here
                // TODO Wire
            }
            if (tabMainTab.SelectedTab.Name == "tabProfile")
            {
                btnDynamicButton.Text = "Bevestig";
                
                // button actions happen here
                // TODO Wire
            }
            if (tabMainTab.SelectedTab.Name == "tabSettings")
            {
                btnDynamicButton.Text = "Bevestig";
                
                // button actions happen here
                // TODO Wire
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
            DynamicButtonLogic(true);    
        }
        
    }
}