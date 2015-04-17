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
            this.gbCreateEvent = new System.Windows.Forms.GroupBox();
            this.btnCreateNewEvent = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbEventName = new System.Windows.Forms.TextBox();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            this.btnUpdateEvents = new System.Windows.Forms.Button();
            this.flowEvent = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreateEvent = new System.Windows.Forms.Button();
            this.gbEventManagment.SuspendLayout();
            this.gbCreateEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEventManagment
            // 
            this.gbEventManagment.Controls.Add(this.gbCreateEvent);
            this.gbEventManagment.Controls.Add(this.btnDeleteEvent);
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
            // gbCreateEvent
            // 
            this.gbCreateEvent.Controls.Add(this.btnCreateNewEvent);
            this.gbCreateEvent.Controls.Add(this.label5);
            this.gbCreateEvent.Controls.Add(this.dateTimePicker2);
            this.gbCreateEvent.Controls.Add(this.dateTimePicker1);
            this.gbCreateEvent.Controls.Add(this.label4);
            this.gbCreateEvent.Controls.Add(this.tbLocation);
            this.gbCreateEvent.Controls.Add(this.label6);
            this.gbCreateEvent.Controls.Add(this.label7);
            this.gbCreateEvent.Controls.Add(this.label8);
            this.gbCreateEvent.Controls.Add(this.tbDescription);
            this.gbCreateEvent.Controls.Add(this.tbEventName);
            this.gbCreateEvent.Location = new System.Drawing.Point(655, 25);
            this.gbCreateEvent.Name = "gbCreateEvent";
            this.gbCreateEvent.Size = new System.Drawing.Size(334, 237);
            this.gbCreateEvent.TabIndex = 6;
            this.gbCreateEvent.TabStop = false;
            this.gbCreateEvent.Text = "Create a event";
            // 
            // btnCreateNewEvent
            // 
            this.btnCreateNewEvent.Location = new System.Drawing.Point(25, 189);
            this.btnCreateNewEvent.Name = "btnCreateNewEvent";
            this.btnCreateNewEvent.Size = new System.Drawing.Size(242, 32);
            this.btnCreateNewEvent.TabIndex = 21;
            this.btnCreateNewEvent.Text = "Create Event";
            this.btnCreateNewEvent.UseVisualStyleBackColor = true;
            this.btnCreateNewEvent.Click += new System.EventHandler(this.btnCreateEvent_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "End date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(88, 143);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(227, 20);
            this.dateTimePicker2.TabIndex = 19;
            this.dateTimePicker2.Value = new System.DateTime(2015, 4, 15, 12, 57, 43, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(88, 112);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(227, 20);
            this.dateTimePicker1.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Start date";
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(88, 49);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(227, 20);
            this.tbLocation.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Description";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Location";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Event Name";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(88, 80);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(227, 20);
            this.tbDescription.TabIndex = 12;
            // 
            // tbEventName
            // 
            this.tbEventName.Location = new System.Drawing.Point(88, 18);
            this.tbEventName.Name = "tbEventName";
            this.tbEventName.Size = new System.Drawing.Size(227, 20);
            this.tbEventName.TabIndex = 11;
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteEvent.Location = new System.Drawing.Point(742, 566);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(241, 54);
            this.btnDeleteEvent.TabIndex = 5;
            this.btnDeleteEvent.Text = "Remove Evenement";
            this.btnDeleteEvent.UseVisualStyleBackColor = true;
            // 
            // btnUpdateEvents
            // 
            this.btnUpdateEvents.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateEvents.Location = new System.Drawing.Point(382, 566);
            this.btnUpdateEvents.Name = "btnUpdateEvents";
            this.btnUpdateEvents.Size = new System.Drawing.Size(241, 54);
            this.btnUpdateEvents.TabIndex = 4;
            this.btnUpdateEvents.Text = "Update Events";
            this.btnUpdateEvents.UseVisualStyleBackColor = true;
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
            this.gbCreateEvent.ResumeLayout(false);
            this.gbCreateEvent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEventManagment;
        private System.Windows.Forms.GroupBox gbCreateEvent;
        private System.Windows.Forms.Button btnCreateNewEvent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbEventName;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.Button btnUpdateEvents;
        private System.Windows.Forms.FlowLayoutPanel flowEvent;
        private System.Windows.Forms.Button btnCreateEvent;
    }
}