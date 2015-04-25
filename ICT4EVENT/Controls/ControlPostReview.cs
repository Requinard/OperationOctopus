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
            ControlPost controlPost = new ControlPost(postReportModel.Post);
            flowPost.Controls.Add(controlPost);
            lblReason.Text += postReportModel.Reason;
            lblReportedBy.Text += postReportModel.User.Username;

            this.Size = new Size(Width,controlPost.Height +3);

        }

        private void btnActionConfirm_Click(object sender, EventArgs e)
        {
            if (rbPostRemove.Checked) postReportModel.Post.Destroy();

            postReportModel.Destroy();

            this.Dispose();
        }
    }
}