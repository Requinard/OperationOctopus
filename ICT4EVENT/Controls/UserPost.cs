﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4EVENT
{
    public partial class UserPost : UserControl
    {
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

       
      

        public UserPost(string text, string user, Image picture, Image mediaImage, UserPost commentUserPost = null)
           
        {
            InitializeComponent();

            
            Text = text;
            this.Size = new Size(593, 107);
            
            // if user is set
            if (user != null)
            {
                lblPoster.Text = "@" + user;
            }

             if (picture == null)
            {
                Picture = Image.FromFile(@"Picture.jpg");
            }
            else
            {
                Picture = picture;
            }

            if (mediaImage == null)
            {
                this.Size = new Size(this.Size.Width, (lblText.Size.Height));
                
            }
            else
            {
                pbMedia.Enabled = true;
                pbMedia.Location = new Point(pbMedia.Location.X, (lblText.Location.Y + lblText.Height + 3));
                this.Size = new Size(this.Size.Width, (pbMedia.Location.Y + pbMedia.Size.Height + 3));
            }


            MediaImage = mediaImage;
            Random r = new Random();
            BackColor = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));

            if (commentUserPost != null)
            {
                flowComment.Enabled = true;
                flowComment.Visible = true;
                commentUserPost.BackColor = (Color)this.BackColor;
                flowComment.Controls.Add(commentUserPost);
                flowComment.Location = new Point(this.Location.X,this.Height);
                this.Size = new Size(this.Width,flowComment.Location.Y + flowComment.Height + 3);
            }

            
           
        }

        
        private void UserControl1_Load(object sender, EventArgs e)
        {
           
            
           
        }

        
    }
}