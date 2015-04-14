using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4EVENT
{
    public partial class UserPostReview : UserControl
    {
        private UserPost userPost;
        public UserPostReview(UserPost userPost)
        {
            InitializeComponent();
            this.userPost = userPost;
            flowLayoutPanel1.Controls.Add(userPost);
            //this.Size = new Size(this.Width,(userPost.Height+3));
            this.BackColor = (Color) userPost.BackColor;
        }
    }
}
