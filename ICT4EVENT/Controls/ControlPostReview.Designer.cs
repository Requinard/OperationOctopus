namespace ICT4EVENT
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblReason = new System.Windows.Forms.Label();
            this.btnActionConfirm = new System.Windows.Forms.Button();
            this.gbReviewAction = new System.Windows.Forms.GroupBox();
            this.rbPostIgnore = new System.Windows.Forms.RadioButton();
            this.rbPostEdit = new System.Windows.Forms.RadioButton();
            this.rbPostRemove = new System.Windows.Forms.RadioButton();
            this.gbReviewAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(791, 250);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(791, 250);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Agency FB", 15.75F);
            this.lblReason.Location = new System.Drawing.Point(841, 0);
            this.lblReason.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReason.MinimumSize = new System.Drawing.Size(465, 31);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(465, 32);
            this.lblReason.TabIndex = 9;
            this.lblReason.Text = "Reason: <Reason>";
            // 
            // btnActionConfirm
            // 
            this.btnActionConfirm.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActionConfirm.Location = new System.Drawing.Point(1139, 91);
            this.btnActionConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btnActionConfirm.Name = "btnActionConfirm";
            this.btnActionConfirm.Size = new System.Drawing.Size(156, 53);
            this.btnActionConfirm.TabIndex = 12;
            this.btnActionConfirm.Text = "Bevestig";
            this.btnActionConfirm.UseVisualStyleBackColor = true;
            this.btnActionConfirm.Click += new System.EventHandler(this.btnActionConfirm_Click);
            // 
            // gbReviewAction
            // 
            this.gbReviewAction.Controls.Add(this.rbPostIgnore);
            this.gbReviewAction.Controls.Add(this.rbPostEdit);
            this.gbReviewAction.Controls.Add(this.rbPostRemove);
            this.gbReviewAction.Font = new System.Drawing.Font("Agency FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReviewAction.Location = new System.Drawing.Point(848, 34);
            this.gbReviewAction.Margin = new System.Windows.Forms.Padding(4);
            this.gbReviewAction.Name = "gbReviewAction";
            this.gbReviewAction.Padding = new System.Windows.Forms.Padding(4);
            this.gbReviewAction.Size = new System.Drawing.Size(267, 110);
            this.gbReviewAction.TabIndex = 13;
            this.gbReviewAction.TabStop = false;
            this.gbReviewAction.Text = "Actie";
            // 
            // rbPostIgnore
            // 
            this.rbPostIgnore.AutoSize = true;
            this.rbPostIgnore.Location = new System.Drawing.Point(9, 75);
            this.rbPostIgnore.Margin = new System.Windows.Forms.Padding(4);
            this.rbPostIgnore.Name = "rbPostIgnore";
            this.rbPostIgnore.Size = new System.Drawing.Size(73, 28);
            this.rbPostIgnore.TabIndex = 2;
            this.rbPostIgnore.TabStop = true;
            this.rbPostIgnore.Text = "Negeer";
            this.rbPostIgnore.UseVisualStyleBackColor = true;
            // 
            // rbPostEdit
            // 
            this.rbPostEdit.AutoSize = true;
            this.rbPostEdit.Location = new System.Drawing.Point(9, 47);
            this.rbPostEdit.Margin = new System.Windows.Forms.Padding(4);
            this.rbPostEdit.Name = "rbPostEdit";
            this.rbPostEdit.Size = new System.Drawing.Size(115, 28);
            this.rbPostEdit.TabIndex = 1;
            this.rbPostEdit.TabStop = true;
            this.rbPostEdit.Text = "Verander Post";
            this.rbPostEdit.UseVisualStyleBackColor = true;
            // 
            // rbPostRemove
            // 
            this.rbPostRemove.AutoSize = true;
            this.rbPostRemove.Location = new System.Drawing.Point(9, 18);
            this.rbPostRemove.Margin = new System.Windows.Forms.Padding(4);
            this.rbPostRemove.Name = "rbPostRemove";
            this.rbPostRemove.Size = new System.Drawing.Size(116, 28);
            this.rbPostRemove.TabIndex = 0;
            this.rbPostRemove.TabStop = true;
            this.rbPostRemove.Text = "Verwijder Post";
            this.rbPostRemove.UseVisualStyleBackColor = true;
            // 
            // UserPostReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbReviewAction);
            this.Controls.Add(this.btnActionConfirm);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1305, 250);
            this.Name = "UserPostReview";
            this.Size = new System.Drawing.Size(1305, 250);
            this.gbReviewAction.ResumeLayout(false);
            this.gbReviewAction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Button btnActionConfirm;
        private System.Windows.Forms.GroupBox gbReviewAction;
        private System.Windows.Forms.RadioButton rbPostIgnore;
        private System.Windows.Forms.RadioButton rbPostEdit;
        private System.Windows.Forms.RadioButton rbPostRemove;
    }
}
