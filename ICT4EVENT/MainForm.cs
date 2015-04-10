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


        public MainForm()
        {
            InitializeComponent();
            // TODO: Repair initializations from social media manager
            //socialManager = new SocialMediaEventManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random(8);
            UserPost post;
            post = new UserPost("David == fucking haat", "Guus", Image.FromFile(@"The Cage.jpg"), Image.FromFile(@"nicolas-cage-will-be-in-the-expendables-3.jpg"));
            flowLayoutPanel1.Controls.Add(post);

            for (int i = 0; i < 10; i++)
            {
                post = new UserPost("Random Text",null, null, null);
                flowLayoutPanel1.Controls.Add(post);  
            }


           

           
        }

        private void pbColour_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            if (cbProfileSelector.Text.Length >= 3)
            {
                //Add the results of the search query here
                cbProfileSelector.Items.Add(null);
            }
        }


       

        




    }
}
