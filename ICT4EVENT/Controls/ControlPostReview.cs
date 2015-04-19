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

            Size = new Size(970, 150);

            flowLayoutPanel1.Controls.Add(new UserPost(postReportModel.Post));
            lblReason.Text += postReportModel.Reason;

        }

        private void btnActionConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}