using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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


            lblPoster.Text = "@" + postModel.User.Username + ", " + postModel.DatePosted;

            if (postModel.PathToFile == "")
            {
                Size = new Size(Size.Width, (lblText.Size.Height));
            }
            else
            {
                if (!File.Exists(postModel.PathToFile))
                    FTPManager.DownloadFile(postModel.PathToFile);
                pbMedia.Enabled = true;
                
                pbMedia.Image = Image.FromFile(postModel.PathToFile);

                pbMedia.Location = new Point(pbMedia.Location.X, (lblText.Location.Y + lblText.Height + 3));
                Size = new Size(Size.Width, (pbMedia.Location.Y + pbMedia.Size.Height + 3));
            }

            Random r = new Random();
            BackColor = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
            pictureBox1.BackColor = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));

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
            List<LikeModel> likes = PostManager.GetPostLikes(postModel);
            if (likes != null)
            {
                btnLike.Text = likes.Count.ToString() + " Likes";
            }
            else
            {
                btnLike.Text = "0 Likes";
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
            /*
             if (tbReport.Visible == false)
            {
                tbReport.Visible = true;
            }

            if (tbReport.Visible == true)
            {
                if (string.IsNullOrWhiteSpace(tbReport.Text))
                {
                    PostManager.ReportPost(postModel, " ");
                }
                else
                {
                    PostManager.ReportPost(postModel, tbReport.Text);
                }
                tbReport.Visible = false;
            }*/
            if (gbReport.Enabled == false)
            {
                gbReport.Enabled = true;
                gbReport.Visible = true;
                gbReport.Location = new Point(3, this.Height + 3);
                this.Size = new Size(this.Width, gbReport.Location.Y + gbReport.Size.Height + 1);
            }
            else
            {
                gbReport.Enabled = false;
                gbReport.Visible = false;
                this.Size = new Size(this.Width, (gbReport.Location.Y + 1));
            }
        }



        private void btnLike_Click(object sender, EventArgs e)
        {
            if (PostManager.CreateNewLike(this.postModel) != null)
            {
                this.btnLike.Text = "Liked!";
                btnLike.Enabled = false;
            }
        }

        private void btnReportConfirm_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(("Weet je zeker dat je deze post van " + postModel.User.Username + " wil reporten ?"),
                    "Weet je het zeker", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PostReportModel postReportModel = PostManager.ReportPost(postModel, tbReport.Text);
                if (postReportModel != null)
                {
                    MessageBox.Show("Post Succesvol Gereport");
                    gbReport.Enabled = false;
                    gbReport.Visible = false;
                    this.Size = new Size(this.Width, (gbReport.Location.Y + 1));
                    btnReport.ForeColor = Color.Blue;
                }
            }
           

        }
    }
}