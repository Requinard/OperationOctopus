using System;
using System.Drawing;
using System.Windows.Forms;

namespace ICT4EVENT
{
    public partial class UserPost : UserControl
    {
        private PostModel postModel;
        public UserPost(PostModel model)

        {
            InitializeComponent();
            postModel = model;

            Text = postModel.Content;
            Size = new Size(593, 107);


            lblPoster.Text = "@" + postModel.User;

            if (postModel.PathToFile == null)
            {
                Size = new Size(Size.Width, (lblText.Size.Height));
            }
            else
            {
                pbMedia.Enabled = true;
                pbMedia.Image = Image.FromFile(postModel.PathToFile);
                pbMedia.Location = new Point(pbMedia.Location.X, (lblText.Location.Y + lblText.Height + 3));
                Size = new Size(Size.Width, (pbMedia.Location.Y + pbMedia.Size.Height + 3));
            }

            Random r = new Random();
            BackColor = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));

            if (postModel.Parent != null)
            {
                UserPost commentUserPost = new UserPost(postModel.Parent);
                flowComment.Enabled = true;
                flowComment.Visible = true;
                commentUserPost.BackColor = BackColor;
                flowComment.Controls.Add(commentUserPost);
                flowComment.Location = new Point(Location.X, Height);
                Size = new Size(Width, flowComment.Location.Y + flowComment.Height + 3);
            }
        }

        public Image Picture
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public Image MediaImage
        {
            get { return pbMedia.Image; }
            set { pbMedia.Image = value; }
        }

        public string Text
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
    }
}