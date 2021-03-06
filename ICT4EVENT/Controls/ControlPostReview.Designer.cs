﻿namespace ICT4EVENT
{
    partial class UserPostReview
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
            this.flowPost = new System.Windows.Forms.FlowLayoutPanel();
            this.lblReason = new System.Windows.Forms.Label();
            this.btnActionConfirm = new System.Windows.Forms.Button();
            this.gbReviewAction = new System.Windows.Forms.GroupBox();
            this.rbPostIgnore = new System.Windows.Forms.RadioButton();
            this.rbPostRemove = new System.Windows.Forms.RadioButton();
            this.lblReportedBy = new System.Windows.Forms.Label();
            this.gbReviewAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowPost
            // 
            this.flowPost.AutoScroll = true;
            this.flowPost.AutoSize = true;
            this.flowPost.Location = new System.Drawing.Point(0, 0);
            this.flowPost.MinimumSize = new System.Drawing.Size(593, 164);
            this.flowPost.Name = "flowPost";
            this.flowPost.Size = new System.Drawing.Size(593, 164);
            this.flowPost.TabIndex = 0;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Agency FB", 15.75F);
            this.lblReason.Location = new System.Drawing.Point(599, 25);
            this.lblReason.MinimumSize = new System.Drawing.Size(349, 25);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(349, 25);
            this.lblReason.TabIndex = 9;
            this.lblReason.Text = "Reden : ";
            // 
            // btnActionConfirm
            // 
            this.btnActionConfirm.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActionConfirm.Location = new System.Drawing.Point(831, 114);
            this.btnActionConfirm.Name = "btnActionConfirm";
            this.btnActionConfirm.Size = new System.Drawing.Size(158, 43);
            this.btnActionConfirm.TabIndex = 12;
            this.btnActionConfirm.Text = "Bevestig";
            this.btnActionConfirm.UseVisualStyleBackColor = true;
            this.btnActionConfirm.Click += new System.EventHandler(this.btnActionConfirm_Click);
            // 
            // gbReviewAction
            // 
            this.gbReviewAction.Controls.Add(this.rbPostIgnore);
            this.gbReviewAction.Controls.Add(this.rbPostRemove);
            this.gbReviewAction.Font = new System.Drawing.Font("Agency FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReviewAction.Location = new System.Drawing.Point(604, 85);
            this.gbReviewAction.Name = "gbReviewAction";
            this.gbReviewAction.Size = new System.Drawing.Size(200, 72);
            this.gbReviewAction.TabIndex = 13;
            this.gbReviewAction.TabStop = false;
            this.gbReviewAction.Text = "Actie";
            // 
            // rbPostIgnore
            // 
            this.rbPostIgnore.AutoSize = true;
            this.rbPostIgnore.Location = new System.Drawing.Point(7, 43);
            this.rbPostIgnore.MaximumSize = new System.Drawing.Size(64, 24);
            this.rbPostIgnore.Name = "rbPostIgnore";
            this.rbPostIgnore.Size = new System.Drawing.Size(64, 22);
            this.rbPostIgnore.TabIndex = 2;
            this.rbPostIgnore.TabStop = true;
            this.rbPostIgnore.Text = "Negeer Post";
            this.rbPostIgnore.UseVisualStyleBackColor = true;
            // 
            // rbPostRemove
            // 
            this.rbPostRemove.AutoSize = true;
            this.rbPostRemove.Location = new System.Drawing.Point(7, 19);
            this.rbPostRemove.Name = "rbPostRemove";
            this.rbPostRemove.Size = new System.Drawing.Size(93, 22);
            this.rbPostRemove.TabIndex = 0;
            this.rbPostRemove.TabStop = true;
            this.rbPostRemove.Text = "Verwijder Post";
            this.rbPostRemove.UseVisualStyleBackColor = true;
            // 
            // lblReportedBy
            // 
            this.lblReportedBy.AutoSize = true;
            this.lblReportedBy.Font = new System.Drawing.Font("Agency FB", 15.75F);
            this.lblReportedBy.Location = new System.Drawing.Point(599, 0);
            this.lblReportedBy.MinimumSize = new System.Drawing.Size(349, 25);
            this.lblReportedBy.Name = "lblReportedBy";
            this.lblReportedBy.Size = new System.Drawing.Size(349, 25);
            this.lblReportedBy.TabIndex = 14;
            this.lblReportedBy.Text = "Reported door:  ";
            // 
            // UserPostReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblReportedBy);
            this.Controls.Add(this.gbReviewAction);
            this.Controls.Add(this.btnActionConfirm);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.flowPost);
            this.MinimumSize = new System.Drawing.Size(992, 164);
            this.Name = "UserPostReview";
            this.Size = new System.Drawing.Size(992, 164);
            this.gbReviewAction.ResumeLayout(false);
            this.gbReviewAction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowPost;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Button btnActionConfirm;
        private System.Windows.Forms.GroupBox gbReviewAction;
        private System.Windows.Forms.RadioButton rbPostIgnore;
        private System.Windows.Forms.RadioButton rbPostRemove;
        private System.Windows.Forms.Label lblReportedBy;
    }
}
