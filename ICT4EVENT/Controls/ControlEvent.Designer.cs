namespace ICT4EVENT
{
    partial class UserEvent
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
            this.pbEventLogo = new System.Windows.Forms.PictureBox();
            this.lblEventName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbEventLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbEventLogo
            // 
            this.pbEventLogo.Location = new System.Drawing.Point(3, 6);
            this.pbEventLogo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.pbEventLogo.Name = "pbEventLogo";
            this.pbEventLogo.Size = new System.Drawing.Size(157, 190);
            this.pbEventLogo.TabIndex = 0;
            this.pbEventLogo.TabStop = false;
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventName.Location = new System.Drawing.Point(164, 6);
            this.lblEventName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(109, 28);
            this.lblEventName.TabIndex = 1;
            this.lblEventName.Text = "<EventName>";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(165, 71);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(88, 24);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "<Description>";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(238, 34);
            this.lblStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(81, 24);
            this.lblStartDate.TabIndex = 3;
            this.lblStartDate.Text = "<Start Date>";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(165, 34);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(69, 24);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "<Location>";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(481, 34);
            this.lblEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(73, 24);
            this.lblEndDate.TabIndex = 5;
            this.lblEndDate.Text = "<End Date>";
            // 
            // UserEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblEventName);
            this.Controls.Add(this.pbEventLogo);
            this.Font = new System.Drawing.Font("Agency FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "UserEvent";
            this.Size = new System.Drawing.Size(982, 200);
            ((System.ComponentModel.ISupportInitialize)(this.pbEventLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbEventLogo;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblEndDate;
    }
}
