using System;
using System.Drawing;
using System.Windows.Forms;

namespace ICT4EVENT
{
    public partial class UserPostReview : UserControl
    {
        private PostModel postmodel;
        private string reason;

        public UserPostReview(PostModel postmodel, string reason)
        {
            InitializeComponent();
            this.postmodel = postmodel;
            this.reason = reason;

            Size = new Size(970, 150);

            flowLayoutPanel1.Controls.Add(new UserPost(postmodel));
            lblReason.Text = "Reason: " + reason;

            Random r = new Random();
            BackColor = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
        }
    }
}