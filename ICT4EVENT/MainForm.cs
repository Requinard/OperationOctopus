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
            Random r = new Random(8);

            int postion = 0;
            
            UserPost post = new UserPost();
            post.Text = r.Next().ToString();
            postion ++;
            flowLayoutPanel1.Controls.Add(post); 

            post = new UserPost();
            post.Text = r.Next().ToString();
            Image image = Image.FromFile("Picture.jpg");
            post.MediaImage = image;
            postion++;
            flowLayoutPanel1.Controls.Add(post);

            post = new UserPost();
            post.Text = r.Next().ToString();
            postion++;
            flowLayoutPanel1.Controls.Add(post);

            post = new UserPost();
            post.Text = r.Next().ToString();
            postion++;
            flowLayoutPanel1.Controls.Add(post); 
            
            post = new UserPost();
            post.Text = r.Next().ToString();
            postion++;
            flowLayoutPanel1.Controls.Add(post); 

            post = new UserPost();
            post.Text = r.Next().ToString();
            postion++;
            flowLayoutPanel1.Controls.Add(post);
        }

        private void pbColour_Click(object sender, EventArgs e)
        {

        }


       

        




    }
}
