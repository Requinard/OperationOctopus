using System;
using System.Drawing;
using System.Windows.Forms;

namespace ICT4EVENT
{
    public partial class UserPostReview : UserControl
    {
        private PostReportModel postReportModel;

        public UserPostReview(PostReportModel postReportModel)
        {
            InitializeComponent();
            this.postReportModel = postReportModel;

            //Size = new Size(970, 150);
            UserPost userPost = new UserPost(postReportModel.Post);
            flowPost.Controls.Add(userPost);
            lblReason.Text += postReportModel.Reason;

            this.Size = new Size(Width,userPost.Height +3);

        }

        private void btnActionConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}