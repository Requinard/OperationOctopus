namespace ICT4EVENT
{
    partial class UserPost
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblText = new System.Windows.Forms.Label();
            this.lblPoster = new System.Windows.Forms.LinkLabel();
            this.pbMedia = new System.Windows.Forms.PictureBox();
            this.btnLike = new System.Windows.Forms.Button();
            this.flowComment = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReport = new System.Windows.Forms.Button();
            this.tbAction = new System.Windows.Forms.TextBox();
            this.btnReportConfirm = new System.Windows.Forms.Button();
            this.gbAction = new System.Windows.Forms.GroupBox();
            this.btnComment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMedia)).BeginInit();
            this.gbAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblText.Location = new System.Drawing.Point(113, 24);
            this.lblText.MaximumSize = new System.Drawing.Size(500, 1000);
            this.lblText.MinimumSize = new System.Drawing.Size(500, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(500, 24);
            this.lblText.TabIndex = 1;
            this.lblText.Tag = "UserControl";
            this.lblText.Text = "<TEXT>";
            // 
            // lblPoster
            // 
            this.lblPoster.AutoSize = true;
            this.lblPoster.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoster.Location = new System.Drawing.Point(109, 0);
            this.lblPoster.Name = "lblPoster";
            this.lblPoster.Size = new System.Drawing.Size(109, 24);
            this.lblPoster.TabIndex = 2;
            this.lblPoster.TabStop = true;
            this.lblPoster.Tag = "UserControl";
            this.lblPoster.Text = "@<Displayname>";
            // 
            // pbMedia
            // 
            this.pbMedia.BackColor = System.Drawing.Color.Transparent;
            this.pbMedia.Enabled = false;
            this.pbMedia.Location = new System.Drawing.Point(109, 96);
            this.pbMedia.MaximumSize = new System.Drawing.Size(450, 450);
            this.pbMedia.MinimumSize = new System.Drawing.Size(100, 100);
            this.pbMedia.Name = "pbMedia";
            this.pbMedia.Size = new System.Drawing.Size(450, 450);
            this.pbMedia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMedia.TabIndex = 3;
            this.pbMedia.TabStop = false;
            // 
            // btnLike
            // 
            this.btnLike.Font = new System.Drawing.Font("Agency FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLike.Location = new System.Drawing.Point(3, 109);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(76, 23);
            this.btnLike.TabIndex = 4;
            this.btnLike.Text = "Like";
            this.btnLike.UseVisualStyleBackColor = true;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // flowComment
            // 
            this.flowComment.AutoSize = true;
            this.flowComment.BackColor = System.Drawing.Color.Transparent;
            this.flowComment.Enabled = false;
            this.flowComment.Location = new System.Drawing.Point(-3, 328);
            this.flowComment.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.flowComment.MaximumSize = new System.Drawing.Size(5000, 106);
            this.flowComment.Name = "flowComment";
            this.flowComment.Size = new System.Drawing.Size(595, 106);
            this.flowComment.TabIndex = 5;
            this.flowComment.Visible = false;
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Agency FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.Red;
            this.btnReport.Location = new System.Drawing.Point(85, 109);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(18, 23);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "!";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // tbAction
            // 
            this.tbAction.Location = new System.Drawing.Point(4, 18);
            this.tbAction.Margin = new System.Windows.Forms.Padding(2);
            this.tbAction.Multiline = true;
            this.tbAction.Name = "tbAction";
            this.tbAction.Size = new System.Drawing.Size(496, 54);
            this.tbAction.TabIndex = 7;
            // 
            // btnReportConfirm
            // 
            this.btnReportConfirm.Font = new System.Drawing.Font("Agency FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportConfirm.Location = new System.Drawing.Point(505, 15);
            this.btnReportConfirm.Name = "btnReportConfirm";
            this.btnReportConfirm.Size = new System.Drawing.Size(76, 27);
            this.btnReportConfirm.TabIndex = 8;
            this.btnReportConfirm.Text = "Confirm";
            this.btnReportConfirm.UseVisualStyleBackColor = true;
            this.btnReportConfirm.Click += new System.EventHandler(this.btnReportConfirm_Click);
            // 
            // gbAction
            // 
            this.gbAction.Controls.Add(this.tbAction);
            this.gbAction.Controls.Add(this.btnReportConfirm);
            this.gbAction.Enabled = false;
            this.gbAction.Location = new System.Drawing.Point(6, 167);
            this.gbAction.Name = "gbAction";
            this.gbAction.Size = new System.Drawing.Size(587, 77);
            this.gbAction.TabIndex = 10;
            this.gbAction.TabStop = false;
            this.gbAction.Text = "Report";
            this.gbAction.Visible = false;
            // 
            // btnComment
            // 
            this.btnComment.Font = new System.Drawing.Font("Agency FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComment.Location = new System.Drawing.Point(3, 138);
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(100, 23);
            this.btnComment.TabIndex = 11;
            this.btnComment.Text = "Comment";
            this.btnComment.UseVisualStyleBackColor = true;
            this.btnComment.Click += new System.EventHandler(this.btnComment_Click);
            // 
            // UserPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.Controls.Add(this.btnComment);
            this.Controls.Add(this.gbAction);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.flowComment);
            this.Controls.Add(this.btnLike);
            this.Controls.Add(this.pbMedia);
            this.Controls.Add(this.lblPoster);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(593, 3000);
            this.MinimumSize = new System.Drawing.Size(593, 164);
            this.Name = "UserPost";
            this.Size = new System.Drawing.Size(593, 347);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMedia)).EndInit();
            this.gbAction.ResumeLayout(false);
            this.gbAction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.LinkLabel lblPoster;
        private System.Windows.Forms.PictureBox pbMedia;
        private System.Windows.Forms.Button btnLike;
        private System.Windows.Forms.FlowLayoutPanel flowComment;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.TextBox tbAction;
        private System.Windows.Forms.Button btnReportConfirm;
        private System.Windows.Forms.GroupBox gbAction;
        private System.Windows.Forms.Button btnComment;
    }
}
