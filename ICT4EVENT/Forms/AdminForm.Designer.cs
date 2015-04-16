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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Test1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Test2");
            this.tabMainTab = new System.Windows.Forms.TabControl();
            this.tabCampingPlace = new System.Windows.Forms.TabPage();
            this.nmrPlaats = new System.Windows.Forms.ComboBox();
            this.lbUser = new System.Windows.Forms.ListBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnReserve = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGebruikers = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbRecent = new System.Windows.Forms.ListBox();
            this.gbCheckIn = new System.Windows.Forms.GroupBox();
            this.btnFindUser = new System.Windows.Forms.Button();
            this.gbUserDetails = new System.Windows.Forms.GroupBox();
            this.btnConformUser = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblAtEventStatus = new System.Windows.Forms.Label();
            this.lblPaymentStatusOfUser = new System.Windows.Forms.Label();
            this.lblNameOfUser = new System.Windows.Forms.Label();
            this.txtRFIDCode = new System.Windows.Forms.TextBox();
            this.tabPostReview = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowPostReview = new System.Windows.Forms.FlowLayoutPanel();
            this.tabMaterialRental = new System.Windows.Forms.TabPage();
            this.gbMaterialControl = new System.Windows.Forms.GroupBox();
            this.lblSelectReservation = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cbReservations = new System.Windows.Forms.ComboBox();
            this.listView3 = new System.Windows.Forms.ListView();
            this.tabEventManagment = new System.Windows.Forms.TabPage();
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
            this.tabCreateUser = new System.Windows.Forms.TabPage();
            this.groupCreateUser = new System.Windows.Forms.GroupBox();
            this.txtSurName = new System.Windows.Forms.TextBox();
            this.lblSurName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelNr = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblTelNr = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtAssignRfid = new System.Windows.Forms.TextBox();
            this.tabMainTab.SuspendLayout();
            this.tabCampingPlace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.gbCheckIn.SuspendLayout();
            this.gbUserDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabPostReview.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabMaterialRental.SuspendLayout();
            this.gbMaterialControl.SuspendLayout();
            this.tabEventManagment.SuspendLayout();
            this.gbEventManagment.SuspendLayout();
            this.tabCreateUser.SuspendLayout();
            this.groupCreateUser.SuspendLayout();
            this.gbCreateEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMainTab
            // 
            this.tabMainTab.Controls.Add(this.tabCampingPlace);
            this.tabMainTab.Controls.Add(this.tabPage1);
            this.tabMainTab.Controls.Add(this.tabPostReview);
            this.tabMainTab.Controls.Add(this.tabMaterialRental);
            this.tabMainTab.Controls.Add(this.tabEventManagment);
            this.tabMainTab.Controls.Add(this.tabCreateUser);
            this.tabMainTab.Location = new System.Drawing.Point(-1, 0);
            this.tabMainTab.Name = "tabMainTab";
            this.tabMainTab.SelectedIndex = 0;
            this.tabMainTab.Size = new System.Drawing.Size(1000, 660);
            this.tabMainTab.TabIndex = 2;
            // 
            // tabCampingPlace
            // 
            this.tabCampingPlace.BackColor = System.Drawing.Color.White;
            this.tabCampingPlace.Controls.Add(this.nmrPlaats);
            this.tabCampingPlace.Controls.Add(this.lbUser);
            this.tabCampingPlace.Controls.Add(this.btnAddUser);
            this.tabCampingPlace.Controls.Add(this.btnReserve);
            this.tabCampingPlace.Controls.Add(this.label1);
            this.tabCampingPlace.Controls.Add(this.txtGebruikers);
            this.tabCampingPlace.Controls.Add(this.pictureBox1);
            this.tabCampingPlace.Controls.Add(this.label3);
            this.tabCampingPlace.Controls.Add(this.label2);
            this.tabCampingPlace.Location = new System.Drawing.Point(4, 33);
            this.tabCampingPlace.Name = "tabCampingPlace";
            this.tabCampingPlace.Size = new System.Drawing.Size(992, 623);
            this.tabCampingPlace.TabIndex = 0;
            this.tabCampingPlace.Text = "Kampeerplaats";
            // 
            // nmrPlaats
            // 
            this.nmrPlaats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nmrPlaats.FormattingEnabled = true;
            this.nmrPlaats.Location = new System.Drawing.Point(755, 34);
            this.nmrPlaats.Name = "nmrPlaats";
            this.nmrPlaats.Size = new System.Drawing.Size(230, 32);
            this.nmrPlaats.TabIndex = 14;
            // 
            // lbUser
            // 
            this.lbUser.FormattingEnabled = true;
            this.lbUser.ItemHeight = 24;
            this.lbUser.Location = new System.Drawing.Point(755, 101);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(230, 148);
            this.lbUser.TabIndex = 13;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(930, 69);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(55, 25);
            this.btnAddUser.TabIndex = 12;
            this.btnAddUser.Text = "Voeg toe";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnReserve
            // 
            this.btnReserve.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReserve.Location = new System.Drawing.Point(755, 273);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(230, 43);
            this.btnReserve.TabIndex = 11;
            this.btnReserve.Text = "Reserveer";
            this.btnReserve.UseVisualStyleBackColor = true;
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(650, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 36);
            this.label1.TabIndex = 8;
            this.label1.Text = "Campingplaats verhuur";
            // 
            // txtGebruikers
            // 
            this.txtGebruikers.Location = new System.Drawing.Point(755, 69);
            this.txtGebruikers.Name = "txtGebruikers";
            this.txtGebruikers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGebruikers.Size = new System.Drawing.Size(169, 30);
            this.txtGebruikers.TabIndex = 10;
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
            this.label3.Size = new System.Drawing.Size(110, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Gebruikers:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 15.75F);
            this.label2.Location = new System.Drawing.Point(653, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "CampingPlaats:";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.lbRecent);
            this.tabPage1.Controls.Add(this.gbCheckIn);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(992, 623);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Gasten Inschrijven";
            // 
            // lbRecent
            // 
            this.lbRecent.Font = new System.Drawing.Font("Agency FB", 18F);
            this.lbRecent.FormattingEnabled = true;
            this.lbRecent.ItemHeight = 36;
            this.lbRecent.Location = new System.Drawing.Point(10, 331);
            this.lbRecent.Name = "lbRecent";
            this.lbRecent.Size = new System.Drawing.Size(973, 256);
            this.lbRecent.TabIndex = 14;
            // 
            // gbCheckIn
            // 
            this.gbCheckIn.BackColor = System.Drawing.Color.Transparent;
            this.gbCheckIn.Controls.Add(this.btnFindUser);
            this.gbCheckIn.Controls.Add(this.gbUserDetails);
            this.gbCheckIn.Controls.Add(this.txtRFIDCode);
            this.gbCheckIn.Location = new System.Drawing.Point(4, 4);
            this.gbCheckIn.Name = "gbCheckIn";
            this.gbCheckIn.Size = new System.Drawing.Size(985, 321);
            this.gbCheckIn.TabIndex = 13;
            this.gbCheckIn.TabStop = false;
            this.gbCheckIn.Text = "Schrijf bezoeker in";
            // 
            // btnFindUser
            // 
            this.btnFindUser.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFindUser.Location = new System.Drawing.Point(826, 25);
            this.btnFindUser.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.Size = new System.Drawing.Size(156, 38);
            this.btnFindUser.TabIndex = 14;
            this.btnFindUser.Tag = "SMSS";
            this.btnFindUser.Text = "Zoek gebruiker";
            this.btnFindUser.UseVisualStyleBackColor = true;
            // 
            // gbUserDetails
            // 
            this.gbUserDetails.BackColor = System.Drawing.SystemColors.Control;
            this.gbUserDetails.Controls.Add(this.btnConformUser);
            this.gbUserDetails.Controls.Add(this.pictureBox3);
            this.gbUserDetails.Controls.Add(this.lblAtEventStatus);
            this.gbUserDetails.Controls.Add(this.lblPaymentStatusOfUser);
            this.gbUserDetails.Controls.Add(this.lblNameOfUser);
            this.gbUserDetails.Location = new System.Drawing.Point(6, 81);
            this.gbUserDetails.Name = "gbUserDetails";
            this.gbUserDetails.Size = new System.Drawing.Size(979, 236);
            this.gbUserDetails.TabIndex = 1;
            this.gbUserDetails.TabStop = false;
            this.gbUserDetails.Text = "Details of <Username>";
            // 
            // btnConformUser
            // 
            this.btnConformUser.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConformUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnConformUser.Location = new System.Drawing.Point(660, 196);
            this.btnConformUser.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnConformUser.Name = "btnConformUser";
            this.btnConformUser.Size = new System.Drawing.Size(310, 40);
            this.btnConformUser.TabIndex = 15;
            this.btnConformUser.Tag = "SMSS";
            this.btnConformUser.Text = "Bevestig Gebruiker";
            this.btnConformUser.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.OrangeRed;
            this.pictureBox3.Location = new System.Drawing.Point(820, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(150, 150);
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // lblAtEventStatus
            // 
            this.lblAtEventStatus.BackColor = System.Drawing.Color.OrangeRed;
            this.lblAtEventStatus.Font = new System.Drawing.Font("Agency FB", 18F);
            this.lblAtEventStatus.Location = new System.Drawing.Point(6, 196);
            this.lblAtEventStatus.Name = "lblAtEventStatus";
            this.lblAtEventStatus.Size = new System.Drawing.Size(428, 33);
            this.lblAtEventStatus.TabIndex = 13;
            this.lblAtEventStatus.Tag = "";
            this.lblAtEventStatus.Text = "At event: <Status>";
            this.lblAtEventStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPaymentStatusOfUser
            // 
            this.lblPaymentStatusOfUser.BackColor = System.Drawing.Color.OrangeRed;
            this.lblPaymentStatusOfUser.Font = new System.Drawing.Font("Agency FB", 18F);
            this.lblPaymentStatusOfUser.Location = new System.Drawing.Point(6, 87);
            this.lblPaymentStatusOfUser.Name = "lblPaymentStatusOfUser";
            this.lblPaymentStatusOfUser.Size = new System.Drawing.Size(428, 33);
            this.lblPaymentStatusOfUser.TabIndex = 12;
            this.lblPaymentStatusOfUser.Tag = "";
            this.lblPaymentStatusOfUser.Text = "Payment status: <Status>";
            this.lblPaymentStatusOfUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNameOfUser
            // 
            this.lblNameOfUser.BackColor = System.Drawing.Color.OrangeRed;
            this.lblNameOfUser.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameOfUser.Location = new System.Drawing.Point(6, 30);
            this.lblNameOfUser.Name = "lblNameOfUser";
            this.lblNameOfUser.Size = new System.Drawing.Size(428, 34);
            this.lblNameOfUser.TabIndex = 10;
            this.lblNameOfUser.Tag = "";
            this.lblNameOfUser.Text = "Naam: <Name Of User>";
            this.lblNameOfUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRFIDCode
            // 
            this.txtRFIDCode.Font = new System.Drawing.Font("Agency FB", 14.25F);
            this.txtRFIDCode.Location = new System.Drawing.Point(6, 25);
            this.txtRFIDCode.MinimumSize = new System.Drawing.Size(815, 40);
            this.txtRFIDCode.Name = "txtRFIDCode";
            this.txtRFIDCode.Size = new System.Drawing.Size(815, 36);
            this.txtRFIDCode.TabIndex = 0;
            // 
            // tabPostReview
            // 
            this.tabPostReview.Controls.Add(this.groupBox1);
            this.tabPostReview.Location = new System.Drawing.Point(4, 33);
            this.tabPostReview.Name = "tabPostReview";
            this.tabPostReview.Size = new System.Drawing.Size(992, 623);
            this.tabPostReview.TabIndex = 2;
            this.tabPostReview.Text = "Post Review";
            this.tabPostReview.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowPostReview);
            this.groupBox1.Location = new System.Drawing.Point(2, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(989, 630);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Materiaal Beheer";
            // 
            // flowPostReview
            // 
            this.flowPostReview.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPostReview.Location = new System.Drawing.Point(-2, 25);
            this.flowPostReview.MinimumSize = new System.Drawing.Size(992, 605);
            this.flowPostReview.Name = "flowPostReview";
            this.flowPostReview.Size = new System.Drawing.Size(992, 605);
            this.flowPostReview.TabIndex = 0;
            this.flowPostReview.WrapContents = false;
            // 
            // tabMaterialRental
            // 
            this.tabMaterialRental.Controls.Add(this.gbMaterialControl);
            this.tabMaterialRental.Location = new System.Drawing.Point(4, 33);
            this.tabMaterialRental.Name = "tabMaterialRental";
            this.tabMaterialRental.Size = new System.Drawing.Size(992, 623);
            this.tabMaterialRental.TabIndex = 3;
            this.tabMaterialRental.Text = "Materiaal Uitgifte";
            this.tabMaterialRental.UseVisualStyleBackColor = true;
            // 
            // gbMaterialControl
            // 
            this.gbMaterialControl.Controls.Add(this.lblSelectReservation);
            this.gbMaterialControl.Controls.Add(this.button2);
            this.gbMaterialControl.Controls.Add(this.cbReservations);
            this.gbMaterialControl.Controls.Add(this.listView3);
            this.gbMaterialControl.Location = new System.Drawing.Point(3, 3);
            this.gbMaterialControl.Name = "gbMaterialControl";
            this.gbMaterialControl.Size = new System.Drawing.Size(989, 630);
            this.gbMaterialControl.TabIndex = 15;
            this.gbMaterialControl.TabStop = false;
            this.gbMaterialControl.Text = "Materiaal Beheer";
            // 
            // lblSelectReservation
            // 
            this.lblSelectReservation.AutoSize = true;
            this.lblSelectReservation.Location = new System.Drawing.Point(13, 27);
            this.lblSelectReservation.Name = "lblSelectReservation";
            this.lblSelectReservation.Size = new System.Drawing.Size(163, 24);
            this.lblSelectReservation.TabIndex = 4;
            this.lblSelectReservation.Text = "Selecteer een reservering";
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
            this.cbReservations.Size = new System.Drawing.Size(256, 32);
            this.cbReservations.TabIndex = 1;
            // 
            // listView3
            // 
            this.listView3.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView3.Location = new System.Drawing.Point(6, 56);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(983, 372);
            this.listView3.TabIndex = 2;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // tabEventManagment
            // 
            this.tabEventManagment.Controls.Add(this.gbEventManagment);
            this.tabEventManagment.Location = new System.Drawing.Point(4, 33);
            this.tabEventManagment.Name = "tabEventManagment";
            this.tabEventManagment.Size = new System.Drawing.Size(992, 623);
            this.tabEventManagment.TabIndex = 4;
            this.tabEventManagment.Text = "Event Beheer";
            this.tabEventManagment.UseVisualStyleBackColor = true;
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
            this.gbCreateEvent.Location = new System.Drawing.Point(648, 25);
            this.gbCreateEvent.Name = "gbCreateEvent";
            this.gbCreateEvent.Size = new System.Drawing.Size(334, 237);
            this.gbCreateEvent.TabIndex = 0;
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
            this.btnCreateNewEvent.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "End date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(88, 143);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(227, 25);
            this.dateTimePicker2.TabIndex = 19;
            this.dateTimePicker2.Value = new System.DateTime(2015, 4, 15, 12, 57, 43, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(88, 112);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(227, 25);
            this.dateTimePicker1.TabIndex = 18;
            this.dateTimePicker1.Value = new System.DateTime(2015, 4, 15, 12, 57, 43, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Start date";
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(88, 49);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(227, 25);
            this.tbLocation.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "Description";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Location";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 18);
            this.label8.TabIndex = 13;
            this.label8.Text = "Event Name";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(88, 80);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(227, 25);
            this.tbDescription.TabIndex = 12;
            // 
            // tbEventName
            // 
            this.tbEventName.Location = new System.Drawing.Point(88, 18);
            this.tbEventName.Name = "tbEventName";
            this.tbEventName.Size = new System.Drawing.Size(227, 25);
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
            this.btnUpdateEvents.Click += new System.EventHandler(this.btnUpdateEvents_Click);
            // 
            // flowEvent
            // 
            this.flowEvent.AutoScroll = true;
            this.flowEvent.Location = new System.Drawing.Point(1, 25);
            this.flowEvent.Name = "flowEvent";
            this.flowEvent.Size = new System.Drawing.Size(647, 535);
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
            // tabCreateUser
            // 
            this.tabCreateUser.Controls.Add(this.groupCreateUser);
            this.tabCreateUser.Location = new System.Drawing.Point(4, 33);
            this.tabCreateUser.Name = "tabCreateUser";
            this.tabCreateUser.Size = new System.Drawing.Size(992, 623);
            this.tabCreateUser.TabIndex = 5;
            this.tabCreateUser.Text = "Gebruiker aanmaken";
            this.tabCreateUser.UseVisualStyleBackColor = true;
            // 
            // groupCreateUser
            // 
            this.groupCreateUser.Controls.Add(this.txtSurName);
            this.groupCreateUser.Controls.Add(this.lblSurName);
            this.groupCreateUser.Controls.Add(this.txtName);
            this.groupCreateUser.Controls.Add(this.lblName);
            this.groupCreateUser.Controls.Add(this.btnCreateUser);
            this.groupCreateUser.Controls.Add(this.txtEmail);
            this.groupCreateUser.Controls.Add(this.txtTelNr);
            this.groupCreateUser.Controls.Add(this.txtAddress);
            this.groupCreateUser.Controls.Add(this.txtUsername);
            this.groupCreateUser.Controls.Add(this.lblEmail);
            this.groupCreateUser.Controls.Add(this.lblAddress);
            this.groupCreateUser.Controls.Add(this.lblTelNr);
            this.groupCreateUser.Controls.Add(this.lblUsername);
            this.groupCreateUser.Controls.Add(this.txtAssignRfid);
            this.groupCreateUser.Location = new System.Drawing.Point(7, 6);
            this.groupCreateUser.Name = "groupCreateUser";
            this.groupCreateUser.Size = new System.Drawing.Size(982, 617);
            this.groupCreateUser.TabIndex = 1;
            this.groupCreateUser.TabStop = false;
            this.groupCreateUser.Text = "Gebruiker aanmaken";
            // 
            // txtSurName
            // 
            this.txtSurName.Location = new System.Drawing.Point(399, 291);
            this.txtSurName.Name = "txtSurName";
            this.txtSurName.Size = new System.Drawing.Size(314, 30);
            this.txtSurName.TabIndex = 13;
            // 
            // lblSurName
            // 
            this.lblSurName.AutoSize = true;
            this.lblSurName.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurName.Location = new System.Drawing.Point(234, 288);
            this.lblSurName.Name = "lblSurName";
            this.lblSurName.Size = new System.Drawing.Size(119, 33);
            this.lblSurName.TabIndex = 12;
            this.lblSurName.Text = "Achternaam:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(399, 255);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(314, 30);
            this.txtName.TabIndex = 11;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(234, 252);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(104, 33);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Voornaam:";
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateUser.Location = new System.Drawing.Point(369, 524);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(212, 68);
            this.btnCreateUser.TabIndex = 9;
            this.btnCreateUser.Text = "Gebruiker aanmaken";
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(399, 399);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(314, 30);
            this.txtEmail.TabIndex = 8;
            // 
            // txtTelNr
            // 
            this.txtTelNr.Location = new System.Drawing.Point(399, 363);
            this.txtTelNr.Name = "txtTelNr";
            this.txtTelNr.Size = new System.Drawing.Size(314, 30);
            this.txtTelNr.TabIndex = 7;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(399, 327);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(314, 30);
            this.txtAddress.TabIndex = 6;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(399, 219);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(314, 30);
            this.txtUsername.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(236, 396);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(70, 33);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "E-mail:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(234, 324);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(68, 33);
            this.lblAddress.TabIndex = 3;
            this.lblAddress.Text = "Adres:";
            // 
            // lblTelNr
            // 
            this.lblTelNr.AutoSize = true;
            this.lblTelNr.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelNr.Location = new System.Drawing.Point(236, 360);
            this.lblTelNr.Name = "lblTelNr";
            this.lblTelNr.Size = new System.Drawing.Size(60, 33);
            this.lblTelNr.TabIndex = 2;
            this.lblTelNr.Text = "Telnr:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(236, 216);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(157, 33);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Gebruikersnaam:";
            // 
            // txtAssignRfid
            // 
            this.txtAssignRfid.Enabled = false;
            this.txtAssignRfid.Location = new System.Drawing.Point(240, 183);
            this.txtAssignRfid.Name = "txtAssignRfid";
            this.txtAssignRfid.Size = new System.Drawing.Size(473, 30);
            this.txtAssignRfid.TabIndex = 0;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 666);
            this.Controls.Add(this.tabMainTab);
            this.Font = new System.Drawing.Font("Agency FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.tabMainTab.ResumeLayout(false);
            this.tabCampingPlace.ResumeLayout(false);
            this.tabCampingPlace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.gbCheckIn.ResumeLayout(false);
            this.gbCheckIn.PerformLayout();
            this.gbUserDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabPostReview.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabMaterialRental.ResumeLayout(false);
            this.gbMaterialControl.ResumeLayout(false);
            this.gbMaterialControl.PerformLayout();
            this.tabEventManagment.ResumeLayout(false);
            this.gbEventManagment.ResumeLayout(false);
            this.tabCreateUser.ResumeLayout(false);
            this.groupCreateUser.ResumeLayout(false);
            this.groupCreateUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMainTab;
        private System.Windows.Forms.TabPage tabCampingPlace;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.TextBox txtGebruikers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbCheckIn;
        private System.Windows.Forms.GroupBox gbUserDetails;
        private System.Windows.Forms.TextBox txtRFIDCode;
        private System.Windows.Forms.TabPage tabPostReview;
        private System.Windows.Forms.TabPage tabMaterialRental;
        private System.Windows.Forms.GroupBox gbMaterialControl;
        private System.Windows.Forms.Label lblSelectReservation;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbReservations;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.TabPage tabEventManagment;
        private System.Windows.Forms.GroupBox gbEventManagment;
        private System.Windows.Forms.Button btnCreateEvent;
        private System.Windows.Forms.ListBox lbUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.FlowLayoutPanel flowEvent;
        private System.Windows.Forms.ComboBox nmrPlaats;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.Button btnUpdateEvents;
        private System.Windows.Forms.Button btnFindUser;
        private System.Windows.Forms.Button btnConformUser;
        private System.Windows.Forms.Label lblAtEventStatus;
        private System.Windows.Forms.Label lblPaymentStatusOfUser;
        private System.Windows.Forms.Label lblNameOfUser;
        private System.Windows.Forms.ListBox lbRecent;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowPostReview;
        private System.Windows.Forms.TabPage tabCreateUser;
        private System.Windows.Forms.GroupBox groupCreateUser;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblTelNr;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtAssignRfid;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelNr;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtSurName;
        private System.Windows.Forms.Label lblSurName;
    }
}