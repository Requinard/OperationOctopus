﻿namespace ICT4EVENT
{
    partial class AdminGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminGUI));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Test1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Test2");
            this.tabMainTab = new System.Windows.Forms.TabControl();
            this.tabCampingPlace = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGebruikers = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nmrPlaats = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupDetail = new System.Windows.Forms.GroupBox();
            this.pictureDetail = new System.Windows.Forms.PictureBox();
            this.txtRFIDCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPostReview = new System.Windows.Forms.TabPage();
            this.tabMaterialRental = new System.Windows.Forms.TabPage();
            this.tabEventManagment = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cbReservations = new System.Windows.Forms.ComboBox();
            this.listView3 = new System.Windows.Forms.ListView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.lblSelectReservation = new System.Windows.Forms.Label();
            this.tabMainTab.SuspendLayout();
            this.tabCampingPlace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPlaats)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabMaterialRental.SuspendLayout();
            this.tabEventManagment.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMainTab
            // 
            this.tabMainTab.Controls.Add(this.tabCampingPlace);
            this.tabMainTab.Controls.Add(this.tabPage1);
            this.tabMainTab.Controls.Add(this.tabPostReview);
            this.tabMainTab.Controls.Add(this.tabMaterialRental);
            this.tabMainTab.Controls.Add(this.tabEventManagment);
            this.tabMainTab.Location = new System.Drawing.Point(-1, 0);
            this.tabMainTab.Name = "tabMainTab";
            this.tabMainTab.SelectedIndex = 0;
            this.tabMainTab.Size = new System.Drawing.Size(1000, 660);
            this.tabMainTab.TabIndex = 2;
            // 
            // tabCampingPlace
            // 
            this.tabCampingPlace.BackColor = System.Drawing.Color.White;
            this.tabCampingPlace.Controls.Add(this.button1);
            this.tabCampingPlace.Controls.Add(this.label1);
            this.tabCampingPlace.Controls.Add(this.txtGebruikers);
            this.tabCampingPlace.Controls.Add(this.pictureBox1);
            this.tabCampingPlace.Controls.Add(this.label3);
            this.tabCampingPlace.Controls.Add(this.nmrPlaats);
            this.tabCampingPlace.Controls.Add(this.label2);
            this.tabCampingPlace.Location = new System.Drawing.Point(4, 27);
            this.tabCampingPlace.Name = "tabCampingPlace";
            this.tabCampingPlace.Size = new System.Drawing.Size(992, 629);
            this.tabCampingPlace.TabIndex = 0;
            this.tabCampingPlace.Text = "Kampeerplaats";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(762, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 43);
            this.button1.TabIndex = 11;
            this.button1.Text = "Reserveer";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(650, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Campingplaats verhuur";
            // 
            // txtGebruikers
            // 
            this.txtGebruikers.Location = new System.Drawing.Point(762, 69);
            this.txtGebruikers.Multiline = true;
            this.txtGebruikers.Name = "txtGebruikers";
            this.txtGebruikers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGebruikers.Size = new System.Drawing.Size(169, 146);
            this.txtGebruikers.TabIndex = 10;
            this.txtGebruikers.Text = "Elke ID op een nieuwe regel...";
            this.txtGebruikers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(641, 623);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Agency FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(653, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Gebruikers:";
            // 
            // nmrPlaats
            // 
            this.nmrPlaats.Location = new System.Drawing.Point(762, 35);
            this.nmrPlaats.Maximum = new decimal(new int[] {
            678,
            0,
            0,
            0});
            this.nmrPlaats.Name = "nmrPlaats";
            this.nmrPlaats.Size = new System.Drawing.Size(169, 25);
            this.nmrPlaats.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 15.75F);
            this.label2.Location = new System.Drawing.Point(653, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "CampingPlaats:";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(992, 629);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Gasten Inschrijven";
            // 
            // groupDetail
            // 
            this.groupDetail.Controls.Add(this.pictureDetail);
            this.groupDetail.Location = new System.Drawing.Point(27, 135);
            this.groupDetail.Name = "groupDetail";
            this.groupDetail.Size = new System.Drawing.Size(730, 411);
            this.groupDetail.TabIndex = 1;
            this.groupDetail.TabStop = false;
            this.groupDetail.Text = "Details";
            // 
            // pictureDetail
            // 
            this.pictureDetail.Location = new System.Drawing.Point(533, 15);
            this.pictureDetail.Name = "pictureDetail";
            this.pictureDetail.Size = new System.Drawing.Size(190, 190);
            this.pictureDetail.TabIndex = 0;
            this.pictureDetail.TabStop = false;
            // 
            // txtRFIDCode
            // 
            this.txtRFIDCode.Enabled = false;
            this.txtRFIDCode.Location = new System.Drawing.Point(6, 19);
            this.txtRFIDCode.Name = "txtRFIDCode";
            this.txtRFIDCode.Size = new System.Drawing.Size(730, 25);
            this.txtRFIDCode.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupDetail);
            this.groupBox1.Controls.Add(this.txtRFIDCode);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 629);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // tabPostReview
            // 
            this.tabPostReview.Location = new System.Drawing.Point(4, 27);
            this.tabPostReview.Name = "tabPostReview";
            this.tabPostReview.Size = new System.Drawing.Size(992, 629);
            this.tabPostReview.TabIndex = 2;
            this.tabPostReview.Text = "Post Review";
            this.tabPostReview.UseVisualStyleBackColor = true;
            // 
            // tabMaterialRental
            // 
            this.tabMaterialRental.Controls.Add(this.groupBox4);
            this.tabMaterialRental.Location = new System.Drawing.Point(4, 27);
            this.tabMaterialRental.Name = "tabMaterialRental";
            this.tabMaterialRental.Size = new System.Drawing.Size(992, 629);
            this.tabMaterialRental.TabIndex = 3;
            this.tabMaterialRental.Text = "Materiaal Uitgifte";
            this.tabMaterialRental.UseVisualStyleBackColor = true;
            // 
            // tabEventManagment
            // 
            this.tabEventManagment.Controls.Add(this.groupBox5);
            this.tabEventManagment.Location = new System.Drawing.Point(4, 27);
            this.tabEventManagment.Name = "tabEventManagment";
            this.tabEventManagment.Size = new System.Drawing.Size(992, 629);
            this.tabEventManagment.TabIndex = 4;
            this.tabEventManagment.Text = "Event Beheer";
            this.tabEventManagment.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblSelectReservation);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.cbReservations);
            this.groupBox4.Controls.Add(this.listView3);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(989, 630);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(304, 434);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "Verwijder";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cbReservations
            // 
            this.cbReservations.FormattingEnabled = true;
            this.cbReservations.Location = new System.Drawing.Point(142, 24);
            this.cbReservations.Name = "cbReservations";
            this.cbReservations.Size = new System.Drawing.Size(256, 26);
            this.cbReservations.TabIndex = 1;
            // 
            // listView3
            // 
            this.listView3.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView3.Location = new System.Drawing.Point(6, 56);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(741, 372);
            this.listView3.TabIndex = 2;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listView2);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(989, 626);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(7, 54);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(750, 398);
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(559, 458);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(198, 54);
            this.button3.TabIndex = 2;
            this.button3.Text = "Evenement Bewerken";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(7, 458);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(198, 54);
            this.button4.TabIndex = 0;
            this.button4.Text = "Nieuw Evenement";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(286, 458);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(198, 54);
            this.button5.TabIndex = 1;
            this.button5.Text = "Evenement Verwijderen";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // lblSelectReservation
            // 
            this.lblSelectReservation.AutoSize = true;
            this.lblSelectReservation.Location = new System.Drawing.Point(13, 27);
            this.lblSelectReservation.Name = "lblSelectReservation";
            this.lblSelectReservation.Size = new System.Drawing.Size(123, 18);
            this.lblSelectReservation.TabIndex = 4;
            this.lblSelectReservation.Text = "Selecteer een reservering";
            // 
            // AdminGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 666);
            this.Controls.Add(this.tabMainTab);
            this.Font = new System.Drawing.Font("Agency FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "AdminGUI";
            this.Text = "AdminGUI";
            this.tabMainTab.ResumeLayout(false);
            this.tabCampingPlace.ResumeLayout(false);
            this.tabCampingPlace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPlaats)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureDetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabMaterialRental.ResumeLayout(false);
            this.tabEventManagment.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMainTab;
        private System.Windows.Forms.TabPage tabCampingPlace;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtGebruikers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmrPlaats;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupDetail;
        private System.Windows.Forms.PictureBox pictureDetail;
        private System.Windows.Forms.TextBox txtRFIDCode;
        private System.Windows.Forms.TabPage tabPostReview;
        private System.Windows.Forms.TabPage tabMaterialRental;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblSelectReservation;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbReservations;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.TabPage tabEventManagment;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}