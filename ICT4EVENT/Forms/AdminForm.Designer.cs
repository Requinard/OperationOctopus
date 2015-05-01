namespace ICT4EVENT
{
    partial class AdminForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbEventManagment = new System.Windows.Forms.GroupBox();
            this.gbCreateNewEvent = new System.Windows.Forms.GroupBox();
            this.btnConfirmEvent = new System.Windows.Forms.Button();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblEventName = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbEventName = new System.Windows.Forms.TextBox();
            this.btnUpdateEvents = new System.Windows.Forms.Button();
            this.flowEvent = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreateEvent = new System.Windows.Forms.Button();
            this.gbEventManagment.SuspendLayout();
            this.gbCreateNewEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEventManagment
            // 
            this.gbEventManagment.Controls.Add(this.gbCreateNewEvent);
            this.gbEventManagment.Controls.Add(this.btnUpdateEvents);
            this.gbEventManagment.Controls.Add(this.flowEvent);
            this.gbEventManagment.Controls.Add(this.btnCreateEvent);
            this.gbEventManagment.Location = new System.Drawing.Point(3, 3);
            this.gbEventManagment.Name = "gbEventManagment";
            this.gbEventManagment.Size = new System.Drawing.Size(989, 626);
            this.gbEventManagment.TabIndex = 15;
            this.gbEventManagment.TabStop = false;
            this.gbEventManagment.Text = "Evenment Beheer";
            // 
            // gbCreateNewEvent
            // 
            this.gbCreateNewEvent.Controls.Add(this.btnConfirmEvent);
            this.gbCreateNewEvent.Controls.Add(this.lblEndDate);
            this.gbCreateNewEvent.Controls.Add(this.dtpEndDate);
            this.gbCreateNewEvent.Controls.Add(this.dtpStartDate);
            this.gbCreateNewEvent.Controls.Add(this.lblStartDate);
            this.gbCreateNewEvent.Controls.Add(this.tbLocation);
            this.gbCreateNewEvent.Controls.Add(this.lblDescription);
            this.gbCreateNewEvent.Controls.Add(this.lblLocation);
            this.gbCreateNewEvent.Controls.Add(this.lblEventName);
            this.gbCreateNewEvent.Controls.Add(this.tbDescription);
            this.gbCreateNewEvent.Controls.Add(this.tbEventName);
            this.gbCreateNewEvent.Location = new System.Drawing.Point(655, 25);
            this.gbCreateNewEvent.Name = "gbCreateNewEvent";
            this.gbCreateNewEvent.Size = new System.Drawing.Size(334, 237);
            this.gbCreateNewEvent.TabIndex = 6;
            this.gbCreateNewEvent.TabStop = false;
            this.gbCreateNewEvent.Text = "Creëer een evenement";
            this.gbCreateNewEvent.Visible = false;
            // 
            // btnConfirmEvent
            // 
            this.btnConfirmEvent.Location = new System.Drawing.Point(9, 189);
            this.btnConfirmEvent.Name = "btnConfirmEvent";
            this.btnConfirmEvent.Size = new System.Drawing.Size(306, 32);
            this.btnConfirmEvent.TabIndex = 21;
            this.btnConfirmEvent.Text = "Creëer evenement";
            this.btnConfirmEvent.UseVisualStyleBackColor = true;
            this.btnConfirmEvent.Click += new System.EventHandler(this.btnConfirmEvent_Click);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(6, 148);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(62, 13);
            this.lblEndDate.TabIndex = 20;
            this.lblEndDate.Text = "Eind Datum";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(107, 143);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpEndDate.Size = new System.Drawing.Size(208, 20);
            this.dtpEndDate.TabIndex = 19;
            this.dtpEndDate.Value = new System.DateTime(2015, 7, 8, 0, 0, 0, 0);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(107, 112);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(208, 20);
            this.dtpStartDate.TabIndex = 22;
            this.dtpStartDate.Value = new System.DateTime(2015, 7, 1, 0, 0, 0, 0);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(6, 112);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(61, 13);
            this.lblStartDate.TabIndex = 17;
            this.lblStartDate.Text = "Start datum";
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(107, 49);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(208, 20);
            this.tbLocation.TabIndex = 16;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 83);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(64, 13);
            this.lblDescription.TabIndex = 15;
            this.lblDescription.Text = "Beschrijving";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(6, 52);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(42, 13);
            this.lblLocation.TabIndex = 14;
            this.lblLocation.Text = "Locatie";
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Location = new System.Drawing.Point(6, 21);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(95, 13);
            this.lblEventName.TabIndex = 13;
            this.lblEventName.Text = "Evenement Naam:";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(107, 80);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(208, 20);
            this.tbDescription.TabIndex = 12;
            // 
            // tbEventName
            // 
            this.tbEventName.Location = new System.Drawing.Point(107, 18);
            this.tbEventName.Name = "tbEventName";
            this.tbEventName.Size = new System.Drawing.Size(208, 20);
            this.tbEventName.TabIndex = 11;
            // 
            // btnUpdateEvents
            // 
            this.btnUpdateEvents.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateEvents.Location = new System.Drawing.Point(729, 566);
            this.btnUpdateEvents.Name = "btnUpdateEvents";
            this.btnUpdateEvents.Size = new System.Drawing.Size(241, 54);
            this.btnUpdateEvents.TabIndex = 4;
            this.btnUpdateEvents.Text = "Update Events";
            this.btnUpdateEvents.UseVisualStyleBackColor = true;
            this.btnUpdateEvents.Click += new System.EventHandler(this.btnUpdateEvents_Click_1);
            // 
            // flowEvent
            // 
            this.flowEvent.AutoScroll = true;
            this.flowEvent.Location = new System.Drawing.Point(6, 19);
            this.flowEvent.Name = "flowEvent";
            this.flowEvent.Size = new System.Drawing.Size(643, 535);
            this.flowEvent.TabIndex = 3;
            // 
            // btnCreateEvent
            // 
            this.btnCreateEvent.ForeColor = System.Drawing.Color.Black;
            this.btnCreateEvent.Location = new System.Drawing.Point(6, 566);
            this.btnCreateEvent.Name = "btnCreateEvent";
            this.btnCreateEvent.Size = new System.Drawing.Size(241, 54);
            this.btnCreateEvent.TabIndex = 0;
            this.btnCreateEvent.Text = "Nieuw Evenement";
            this.btnCreateEvent.UseVisualStyleBackColor = true;
            this.btnCreateEvent.Click += new System.EventHandler(this.btnCreateEvent_Click_1);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 629);
            this.Controls.Add(this.gbEventManagment);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.gbEventManagment.ResumeLayout(false);
            this.gbCreateNewEvent.ResumeLayout(false);
            this.gbCreateNewEvent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEventManagment;
        private System.Windows.Forms.GroupBox gbCreateNewEvent;
        private System.Windows.Forms.Button btnConfirmEvent;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbEventName;
        private System.Windows.Forms.Button btnUpdateEvents;
        private System.Windows.Forms.FlowLayoutPanel flowEvent;
        private System.Windows.Forms.Button btnCreateEvent;
    }
}