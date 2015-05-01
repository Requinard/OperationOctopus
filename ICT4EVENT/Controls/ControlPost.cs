using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ICT4EVENT
{
    public partial class ControlPost : UserControl
    {
        private PostModel postModel;
        private bool comment = false;
        private bool report = false;

        public delegate void LinkClickedInControlEventHandler(UserModel userModel);

        public static event LinkClickedInControlEventHandler ControlLinkClicked;

        public ControlPost(PostModel model)

        {
            InitializeComponent();
            postModel = model;


            Text = postModel.Content;
            Size = new Size(593, 232);

            if (postModel.DatePosted.DayOfYear == DateTime.Now.DayOfYear)
            {
                lblPoster.Text = string.Format("@{0}, {1}", postModel.User.Username, postModel.DatePosted.ToString("t"));
            }
            else
            {
                lblPoster.Text = string.Format("@{0}, {1} - {2}", postModel.User.Username,
                    postModel.DatePosted.ToString("t"), postModel.DatePosted.ToShortDateString());

            }
            
            if (postModel.PathToFile == "")
            {
                Size = new Size(Size.Width, (lblText.Size.Height));
            }
            else
            {
                string extention = Path.GetExtension(postModel.PathToFile);
                if (extention == ".avi" || extention == ".mov" || extention == ".mp4" || extention == ".wmv")
                {
                    
                    mpMedia.Enabled = false;
                    mpMedia.Visible = true;
                    
                    btnDownload.Visible = true;
                    mpMedia.Location = new Point(mpMedia.Location.X, (lblText.Location.Y + lblText.Height + 3));
                    Size = new Size(Size.Width, (mpMedia.Location.Y + mpMedia.Size.Height + 8));

                    mpMedia.Ctlcontrols.stop();
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
            }

            Random r = new Random();
            BackColor = Color.FromArgb(255,r.Next(151) + 50, r.Next(151) + 50, r.Next(151) + 50);
            pictureBox1.BackColor = Color.FromArgb(255,r.Next(151) + 50, r.Next(151) + 50, r.Next(151) + 50);


            List<PostModel> comments = PostManager.GetPostComments(postModel);

            if (comments != null)
            {
                flowComment.Enabled = true;
                flowComment.Visible = true;
                foreach (PostModel comment1 in comments)
                {
                    ControlPost commentControlPost = new ControlPost(comment1);
                    commentControlPost.BackColor = BackColor;
                    flowComment.Controls.Add(commentControlPost);
                }
                postHasComment();
                
                
                
                
                
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
            List<PostReportModel> reports = PostManager.GetPostReports(postModel);
            if(reports != null)
                btnReport.Text = string.Format("!{0}", reports.Count);
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


        private void btnReport_Click(object sender, EventArgs e)
        {
           if (gbAction.Enabled == false)
            {
                gbAction.Text = "Report";
                gbAction.Enabled = true;
                gbAction.Visible = true;
                gbAction.Location = new Point(3, this.Height + 3);
                this.Size = new Size(this.Width, gbAction.Location.Y + gbAction.Size.Height + 1);
                report = true;
            }
            else
            {
                gbAction.Enabled = false;
                gbAction.Visible = false;
                this.Size = new Size(this.Width, (gbAction.Location.Y + 1));
                report = false;
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
            if (tbAction.Text != "")
            {
            if (report)
            {
                if (
                    MessageBox.Show(
                        ("Weet je zeker dat je deze post van " + postModel.User.Username + " wil reporten ?"),
                        "Weet je het zeker", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PostReportModel postReportModel = PostManager.ReportPost(postModel, tbAction.Text);
                    if (postReportModel != null)
                    {
                        MessageBox.Show("Post Succesvol Gereport");
                        gbAction.Enabled = false;
                        gbAction.Visible = false;
                        this.Size = new Size(this.Width, (gbAction.Location.Y + 1));
                        btnReport.ForeColor = Color.Blue;
                        this.Enabled = false;

                    }
                }
            }
            else if (comment)
            {
                    PostModel commentPostModel = PostManager.CreateNewPost(tbAction.Text, "", postModel);
                if (commentPostModel != null)
                {
                    this.Size = new Size(this.Width, (gbAction.Location.Y + 1));
                    gbAction.Enabled = false;
                    gbAction.Visible = false;
                    flowComment.Enabled = true;
                    flowComment.Visible = true;

                    ControlPost commentControlPost = new ControlPost(commentPostModel);
                    commentControlPost.BackColor = BackColor;
                    flowComment.Controls.Add(commentControlPost);
                    postHasComment();
                }
            }
            }
            else
            {
                MessageBox.Show("Vul iets in");
            }
           
        }

        private void btnComment_Click(object sender, EventArgs e)
        {
            if (gbAction.Enabled == false)
            {
                gbAction.Text = "Comment on @" + postModel.User.Username;
                gbAction.Enabled = true;
                gbAction.Visible = true;
                gbAction.Location = new Point(3, this.Height + 3);
                this.Size = new Size(this.Width, gbAction.Location.Y + gbAction.Size.Height + 1);
                comment = true;
            }
            else
            {
                gbAction.Enabled = false;
                gbAction.Visible = false;
                this.Size = new Size(this.Width, (gbAction.Location.Y + 1));
                comment = false;
            }
        }

        private void postHasComment()
        {
            flowComment.Location = new Point(-3, this.Height);
            this.Size = new Size(this.Width, flowComment.Location.Y + flowComment.Size.Height + 3);

        }

        private void lblPoster_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ControlLinkClicked != null)
            {
                ControlLinkClicked(postModel.User);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            btnDownload.Visible = false;
            if (!File.Exists(postModel.PathToFile))
                FTPManager.DownloadFile(postModel.PathToFile);
            mpMedia.Enabled = true;
            mpMedia.URL = postModel.PathToFile;
        }
    }
}