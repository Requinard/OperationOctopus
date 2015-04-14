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
            this.label2 = new System.Windows.Forms.Label();
            this.btnActionConfirm = new System.Windows.Forms.Button();
            this.gbReviewAction = new System.Windows.Forms.GroupBox();
            this.rbPostRemove = new System.Windows.Forms.RadioButton();
            this.rbPostEdit = new System.Windows.Forms.RadioButton();
            this.rbPostIgnore = new System.Windows.Forms.RadioButton();
            this.gbReviewAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(593, 203);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(593, 203);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 15.75F);
            this.label2.Location = new System.Drawing.Point(631, 0);
            this.label2.MinimumSize = new System.Drawing.Size(349, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Reason : <Reason>";
            // 
            // btnActionConfirm
            // 
            this.btnActionConfirm.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActionConfirm.Location = new System.Drawing.Point(854, 74);
            this.btnActionConfirm.Name = "btnActionConfirm";
            this.btnActionConfirm.Size = new System.Drawing.Size(117, 43);
            this.btnActionConfirm.TabIndex = 12;
            this.btnActionConfirm.Text = "Bevestig";
            this.btnActionConfirm.UseVisualStyleBackColor = true;
            // 
            // gbReviewAction
            // 
            this.gbReviewAction.Controls.Add(this.rbPostIgnore);
            this.gbReviewAction.Controls.Add(this.rbPostEdit);
            this.gbReviewAction.Controls.Add(this.rbPostRemove);
            this.gbReviewAction.Font = new System.Drawing.Font("Agency FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReviewAction.Location = new System.Drawing.Point(636, 28);
            this.gbReviewAction.Name = "gbReviewAction";
            this.gbReviewAction.Size = new System.Drawing.Size(200, 89);
            this.gbReviewAction.TabIndex = 13;
            this.gbReviewAction.TabStop = false;
            this.gbReviewAction.Text = "Actie";
            // 
            // rbPostRemove
            // 
            this.rbPostRemove.AutoSize = true;
            this.rbPostRemove.Location = new System.Drawing.Point(7, 15);
            this.rbPostRemove.Name = "rbPostRemove";
            this.rbPostRemove.Size = new System.Drawing.Size(93, 22);
            this.rbPostRemove.TabIndex = 0;
            this.rbPostRemove.TabStop = true;
            this.rbPostRemove.Text = "Verwijder Post";
            this.rbPostRemove.UseVisualStyleBackColor = true;
            // 
            // rbPostEdit
            // 
            this.rbPostEdit.AutoSize = true;
            this.rbPostEdit.Location = new System.Drawing.Point(7, 38);
            this.rbPostEdit.Name = "rbPostEdit";
            this.rbPostEdit.Size = new System.Drawing.Size(89, 22);
            this.rbPostEdit.TabIndex = 1;
            this.rbPostEdit.TabStop = true;
            this.rbPostEdit.Text = "Verander Post";
            this.rbPostEdit.UseVisualStyleBackColor = true;
            // 
            // rbPostIgnore
            // 
            this.rbPostIgnore.AutoSize = true;
            this.rbPostIgnore.Location = new System.Drawing.Point(7, 61);
            this.rbPostIgnore.Name = "rbPostIgnore";
            this.rbPostIgnore.Size = new System.Drawing.Size(57, 22);
            this.rbPostIgnore.TabIndex = 2;
            this.rbPostIgnore.TabStop = true;
            this.rbPostIgnore.Text = "Negeer";
            this.rbPostIgnore.UseVisualStyleBackColor = true;
            // 
            // UserPostReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbReviewAction);
            this.Controls.Add(this.btnActionConfirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(979, 203);
            this.Name = "UserPostReview";
            this.Size = new System.Drawing.Size(979, 203);
            this.gbReviewAction.ResumeLayout(false);
            this.gbReviewAction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnActionConfirm;
        private System.Windows.Forms.GroupBox gbReviewAction;
        private System.Windows.Forms.RadioButton rbPostIgnore;
        private System.Windows.Forms.RadioButton rbPostEdit;
        private System.Windows.Forms.RadioButton rbPostRemove;
    }
}
