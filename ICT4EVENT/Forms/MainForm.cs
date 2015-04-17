using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace ICT4EVENT
{
    using ICT4EVENT.Controls;

    public partial class MainForm : Form
    {
        private string filePath = "";

        public MainForm()
        {
            InitializeComponent();
            FillList();
            FillMaterials();
        }

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
            List<RentableObjectModel> Rentables = EquipmentManager.GetAllRentables();
            foreach (RentableObjectModel rentModel in Rentables)
            {
                listMaterials.Items.Add(rentModel.ObjectType, rentModel.Description);
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
