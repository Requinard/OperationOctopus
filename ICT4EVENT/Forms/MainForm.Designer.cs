using System.Windows.Forms;

namespace ICT4EVENT
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("All Posts");
            this.gbStaticUpdates = new System.Windows.Forms.GroupBox();
            this.lblTrending = new System.Windows.Forms.Label();
            this.tabTrending = new System.Windows.Forms.TabControl();
            this.Posts = new System.Windows.Forms.TabPage();
            this.lbTrendingPosts = new System.Windows.Forms.ListBox();
            this.Media = new System.Windows.Forms.TabPage();
            this.Organisation = new System.Windows.Forms.TabPage();
            this.btnDynamicButton = new System.Windows.Forms.Button();
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.gbDynamic = new System.Windows.Forms.GroupBox();
            this.tabMainTab = new System.Windows.Forms.TabControl();
            this.tabSocialMediaSharingSystem = new System.Windows.Forms.TabPage();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.flowPosts = new System.Windows.Forms.FlowLayoutPanel();
            this.treeCategorie = new System.Windows.Forms.TreeView();
            this.btnMediaFile = new System.Windows.Forms.Button();
            this.tbPostContent = new System.Windows.Forms.TextBox();
            this.tabMaterialrent = new System.Windows.Forms.TabPage();
            this.listMaterials = new System.Windows.Forms.ListView();
            this.Naam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemove = new System.Windows.Forms.Button();
            this.listCart = new System.Windows.Forms.ListBox();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.btnHireMaterial = new System.Windows.Forms.Button();
            this.lblDetails = new System.Windows.Forms.Label();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.gbProfielen = new System.Windows.Forms.GroupBox();
            this.tbSearchUser = new System.Windows.Forms.TextBox();
            this.gbPostsOfUser = new System.Windows.Forms.GroupBox();
            this.flowPostsFromUser = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.gbProfileOfUser = new System.Windows.Forms.GroupBox();
            this.lblUserDescription = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblUserDisplayName = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.gbMyProfile = new System.Windows.Forms.GroupBox();
            this.gbSocialMedia = new System.Windows.Forms.GroupBox();
            this.btnSocialMedia4 = new System.Windows.Forms.Button();
            this.btnSocialMedia3 = new System.Windows.Forms.Button();
            this.btnSocialMedia2 = new System.Windows.Forms.Button();
            this.btnSocialMedia1 = new System.Windows.Forms.Button();
            this.pbMyBanner = new System.Windows.Forms.PictureBox();
            this.tbMyBio = new System.Windows.Forms.TextBox();
            this.lblBiografie = new System.Windows.Forms.Label();
            this.pbMyProfileImage = new System.Windows.Forms.PictureBox();
            this.tbMyPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMyDisplayName = new System.Windows.Forms.TextBox();
            this.lblDisplayUser = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.gbStaticUpdates.SuspendLayout();
            this.tabTrending.SuspendLayout();
            this.Posts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.gbDynamic.SuspendLayout();
            this.tabMainTab.SuspendLayout();
            this.tabSocialMediaSharingSystem.SuspendLayout();
            this.tabMaterialrent.SuspendLayout();
            this.groupDetails.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.gbProfielen.SuspendLayout();
            this.gbPostsOfUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbProfileOfUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.gbMyProfile.SuspendLayout();
            this.gbSocialMedia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyProfileImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // gbStaticUpdates
            // 
            this.gbStaticUpdates.BackColor = System.Drawing.Color.RoyalBlue;
            this.gbStaticUpdates.Controls.Add(this.lblTrending);
            this.gbStaticUpdates.Controls.Add(this.tabTrending);
            this.gbStaticUpdates.Controls.Add(this.btnDynamicButton);
            this.gbStaticUpdates.Location = new System.Drawing.Point(823, 0);
            this.gbStaticUpdates.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gbStaticUpdates.Name = "gbStaticUpdates";
            this.gbStaticUpdates.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gbStaticUpdates.Size = new System.Drawing.Size(182, 672);
            this.gbStaticUpdates.TabIndex = 4;
            this.gbStaticUpdates.TabStop = false;
            this.gbStaticUpdates.Tag = "Static";
            // 
            // lblTrending
            // 
            this.lblTrending.AutoSize = true;
            this.lblTrending.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblTrending.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrending.Location = new System.Drawing.Point(4, 67);
            this.lblTrending.Name = "lblTrending";
            this.lblTrending.Size = new System.Drawing.Size(154, 28);
            this.lblTrending.TabIndex = 5;
            this.lblTrending.Tag = "Static";
            this.lblTrending.Text = "Trending right now:";
            this.lblTrending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabTrending
            // 
            this.tabTrending.Controls.Add(this.Posts);
            this.tabTrending.Controls.Add(this.Media);
            this.tabTrending.Controls.Add(this.Organisation);
            this.tabTrending.Location = new System.Drawing.Point(4, 94);
            this.tabTrending.Name = "tabTrending";
            this.tabTrending.SelectedIndex = 0;
            this.tabTrending.Size = new System.Drawing.Size(173, 571);
            this.tabTrending.TabIndex = 0;
            // 
            // Posts
            // 
            this.Posts.Controls.Add(this.lbTrendingPosts);
            this.Posts.Location = new System.Drawing.Point(4, 33);
            this.Posts.Name = "Posts";
            this.Posts.Padding = new System.Windows.Forms.Padding(3);
            this.Posts.Size = new System.Drawing.Size(165, 534);
            this.Posts.TabIndex = 0;
            this.Posts.Text = "Posts";
            this.Posts.UseVisualStyleBackColor = true;
            // 
            // lbTrendingPosts
            // 
            this.lbTrendingPosts.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbTrendingPosts.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTrendingPosts.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbTrendingPosts.FormattingEnabled = true;
            this.lbTrendingPosts.ItemHeight = 28;
            this.lbTrendingPosts.Location = new System.Drawing.Point(-3, 6);
            this.lbTrendingPosts.Name = "lbTrendingPosts";
            this.lbTrendingPosts.Size = new System.Drawing.Size(172, 508);
            this.lbTrendingPosts.TabIndex = 0;
            this.lbTrendingPosts.Tag = "Static";
            // 
            // Media
            // 
            this.Media.Location = new System.Drawing.Point(4, 33);
            this.Media.Name = "Media";
            this.Media.Padding = new System.Windows.Forms.Padding(3);
            this.Media.Size = new System.Drawing.Size(165, 534);
            this.Media.TabIndex = 1;
            this.Media.Text = "Media";
            this.Media.UseVisualStyleBackColor = true;
            // 
            // Organisation
            // 
            this.Organisation.Location = new System.Drawing.Point(4, 33);
            this.Organisation.Name = "Organisation";
            this.Organisation.Size = new System.Drawing.Size(165, 534);
            this.Organisation.TabIndex = 2;
            this.Organisation.Text = "Organisation";
            this.Organisation.UseVisualStyleBackColor = true;
            // 
            // btnDynamicButton
            // 
            this.btnDynamicButton.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDynamicButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDynamicButton.Location = new System.Drawing.Point(4, 12);
            this.btnDynamicButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnDynamicButton.Name = "btnDynamicButton";
            this.btnDynamicButton.Size = new System.Drawing.Size(169, 50);
            this.btnDynamicButton.TabIndex = 4;
            this.btnDynamicButton.Tag = "Static";
            this.btnDynamicButton.Text = "DynamicButton";
            this.btnDynamicButton.UseVisualStyleBackColor = true;
            this.btnDynamicButton.Click += new System.EventHandler(this.btnDynamicButton_Click);
            // 
            // pbBanner
            // 
            this.pbBanner.BackColor = System.Drawing.Color.RoyalBlue;
            this.pbBanner.Location = new System.Drawing.Point(183, 930);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(1539, 96);
            this.pbBanner.TabIndex = 5;
            this.pbBanner.TabStop = false;
            this.pbBanner.Tag = "Static";
            // 
            // gbDynamic
            // 
            this.gbDynamic.BackColor = System.Drawing.Color.Transparent;
            this.gbDynamic.Controls.Add(this.tabMainTab);
            this.gbDynamic.Location = new System.Drawing.Point(-1, 0);
            this.gbDynamic.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gbDynamic.Name = "gbDynamic";
            this.gbDynamic.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gbDynamic.Size = new System.Drawing.Size(820, 661);
            this.gbDynamic.TabIndex = 6;
            this.gbDynamic.TabStop = false;
            this.gbDynamic.Tag = "Static";
            // 
            // tabMainTab
            // 
            this.tabMainTab.Controls.Add(this.tabSocialMediaSharingSystem);
            this.tabMainTab.Controls.Add(this.tabMaterialrent);
            this.tabMainTab.Controls.Add(this.tabProfile);
            this.tabMainTab.Controls.Add(this.tabSettings);
            this.tabMainTab.Location = new System.Drawing.Point(5, 12);
            this.tabMainTab.Name = "tabMainTab";
            this.tabMainTab.SelectedIndex = 0;
            this.tabMainTab.Size = new System.Drawing.Size(810, 653);
            this.tabMainTab.TabIndex = 1;
            this.tabMainTab.SelectedIndexChanged += new System.EventHandler(this.tabMainTab_SelectedIndexChanged);
            // 
            // tabSocialMediaSharingSystem
            // 
            this.tabSocialMediaSharingSystem.Controls.Add(this.btnPreviousPage);
            this.tabSocialMediaSharingSystem.Controls.Add(this.btnNextPage);
            this.tabSocialMediaSharingSystem.Controls.Add(this.flowPosts);
            this.tabSocialMediaSharingSystem.Controls.Add(this.treeCategorie);
            this.tabSocialMediaSharingSystem.Controls.Add(this.btnMediaFile);
            this.tabSocialMediaSharingSystem.Controls.Add(this.tbPostContent);
            this.tabSocialMediaSharingSystem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabSocialMediaSharingSystem.Location = new System.Drawing.Point(4, 33);
            this.tabSocialMediaSharingSystem.Name = "tabSocialMediaSharingSystem";
            this.tabSocialMediaSharingSystem.Padding = new System.Windows.Forms.Padding(3);
            this.tabSocialMediaSharingSystem.Size = new System.Drawing.Size(802, 616);
            this.tabSocialMediaSharingSystem.TabIndex = 0;
            this.tabSocialMediaSharingSystem.Text = "Social Media Sharing System";
            this.tabSocialMediaSharingSystem.UseVisualStyleBackColor = true;
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Font = new System.Drawing.Font("Agency FB", 21.75F);
            this.btnPreviousPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPreviousPage.Location = new System.Drawing.Point(628, 559);
            this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(74, 55);
            this.btnPreviousPage.TabIndex = 14;
            this.btnPreviousPage.Tag = "SMSS";
            this.btnPreviousPage.Text = "<";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Font = new System.Drawing.Font("Agency FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNextPage.Location = new System.Drawing.Point(710, 559);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(74, 55);
            this.btnNextPage.TabIndex = 13;
            this.btnNextPage.Tag = "SMSS";
            this.btnNextPage.Text = ">";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // flowPosts
            // 
            this.flowPosts.AutoScroll = true;
            this.flowPosts.Location = new System.Drawing.Point(7, 73);
            this.flowPosts.Name = "flowPosts";
            this.flowPosts.Size = new System.Drawing.Size(616, 543);
            this.flowPosts.TabIndex = 12;
            // 
            // treeCategorie
            // 
            this.treeCategorie.Location = new System.Drawing.Point(629, 73);
            this.treeCategorie.Name = "treeCategorie";
            treeNode1.Name = "All Posts";
            treeNode1.Text = "All Posts";
            this.treeCategorie.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeCategorie.Size = new System.Drawing.Size(155, 479);
            this.treeCategorie.TabIndex = 7;
            this.treeCategorie.Tag = "SMSS";
            this.treeCategorie.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeCategorie_AfterSelect);
            // 
            // btnMediaFile
            // 
            this.btnMediaFile.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMediaFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMediaFile.Location = new System.Drawing.Point(628, 9);
            this.btnMediaFile.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnMediaFile.Name = "btnMediaFile";
            this.btnMediaFile.Size = new System.Drawing.Size(156, 57);
            this.btnMediaFile.TabIndex = 6;
            this.btnMediaFile.Tag = "SMSS";
            this.btnMediaFile.Text = "Add File(s)";
            this.btnMediaFile.UseVisualStyleBackColor = true;
            this.btnMediaFile.Click += new System.EventHandler(this.btnMediaFile_Click);
            // 
            // tbPostContent
            // 
            this.tbPostContent.Location = new System.Drawing.Point(6, 9);
            this.tbPostContent.Multiline = true;
            this.tbPostContent.Name = "tbPostContent";
            this.tbPostContent.Size = new System.Drawing.Size(617, 57);
            this.tbPostContent.TabIndex = 1;
            // 
            // tabMaterialrent
            // 
            this.tabMaterialrent.Controls.Add(this.listMaterials);
            this.tabMaterialrent.Controls.Add(this.btnRemove);
            this.tabMaterialrent.Controls.Add(this.listCart);
            this.tabMaterialrent.Controls.Add(this.groupDetails);
            this.tabMaterialrent.Location = new System.Drawing.Point(4, 33);
            this.tabMaterialrent.Name = "tabMaterialrent";
            this.tabMaterialrent.Padding = new System.Windows.Forms.Padding(3);
            this.tabMaterialrent.Size = new System.Drawing.Size(802, 616);
            this.tabMaterialrent.TabIndex = 1;
            this.tabMaterialrent.Text = "Materiaalverhuur";
            this.tabMaterialrent.UseVisualStyleBackColor = true;
            // 
            // listMaterials
            // 
            this.listMaterials.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Naam,
            this.Description});
            this.listMaterials.Location = new System.Drawing.Point(6, 3);
            this.listMaterials.Name = "listMaterials";
            this.listMaterials.Size = new System.Drawing.Size(624, 447);
            this.listMaterials.TabIndex = 6;
            this.listMaterials.UseCompatibleStateImageBehavior = false;
            this.listMaterials.View = System.Windows.Forms.View.Details;
            this.listMaterials.SelectedIndexChanged += new System.EventHandler(this.listMaterials_SelectedIndexChanged);
            // 
            // Naam
            // 
            this.Naam.Text = "Naam";
            this.Naam.Width = 120;
            // 
            // Description
            // 
            this.Description.Text = "Beschrijving";
            this.Description.Width = 500;
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRemove.Location = new System.Drawing.Point(642, 558);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(145, 50);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Tag = "Static";
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // listCart
            // 
            this.listCart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listCart.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listCart.FormattingEnabled = true;
            this.listCart.ItemHeight = 24;
            this.listCart.Location = new System.Drawing.Point(642, 6);
            this.listCart.Name = "listCart";
            this.listCart.Size = new System.Drawing.Size(145, 508);
            this.listCart.TabIndex = 2;
            // 
            // groupDetails
            // 
            this.groupDetails.Controls.Add(this.numAmount);
            this.groupDetails.Controls.Add(this.label1);
            this.groupDetails.Controls.Add(this.btnHireMaterial);
            this.groupDetails.Controls.Add(this.lblDetails);
            this.groupDetails.Location = new System.Drawing.Point(6, 456);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(630, 166);
            this.groupDetails.TabIndex = 1;
            this.groupDetails.TabStop = false;
            this.groupDetails.Text = "Details";
            // 
            // btnHireMaterial
            // 
            this.btnHireMaterial.BackColor = System.Drawing.Color.Transparent;
            this.btnHireMaterial.Font = new System.Drawing.Font("Agency FB", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHireMaterial.Location = new System.Drawing.Point(447, 22);
            this.btnHireMaterial.Name = "btnHireMaterial";
            this.btnHireMaterial.Size = new System.Drawing.Size(177, 131);
            this.btnHireMaterial.TabIndex = 2;
            this.btnHireMaterial.Text = "Voeg toe aan winkelwagen";
            this.btnHireMaterial.UseVisualStyleBackColor = false;
            this.btnHireMaterial.Click += new System.EventHandler(this.btnHireMaterial_Click);
            // 
            // lblDetails
            // 
            this.lblDetails.Location = new System.Drawing.Point(6, 29);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(323, 131);
            this.lblDetails.TabIndex = 1;
            this.lblDetails.Text = "Details";
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.gbProfielen);
            this.tabProfile.Location = new System.Drawing.Point(4, 33);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Size = new System.Drawing.Size(802, 616);
            this.tabProfile.TabIndex = 4;
            this.tabProfile.Text = "Profiel";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // gbProfielen
            // 
            this.gbProfielen.Controls.Add(this.tbSearchUser);
            this.gbProfielen.Controls.Add(this.gbPostsOfUser);
            this.gbProfielen.Controls.Add(this.gbProfileOfUser);
            this.gbProfielen.Location = new System.Drawing.Point(3, 3);
            this.gbProfielen.Name = "gbProfielen";
            this.gbProfielen.Size = new System.Drawing.Size(784, 616);
            this.gbProfielen.TabIndex = 13;
            this.gbProfielen.TabStop = false;
            this.gbProfielen.Text = "Profielen:";
            // 
            // tbSearchUser
            // 
            this.tbSearchUser.Location = new System.Drawing.Point(9, 25);
            this.tbSearchUser.Name = "tbSearchUser";
            this.tbSearchUser.Size = new System.Drawing.Size(769, 30);
            this.tbSearchUser.TabIndex = 16;
            this.tbSearchUser.TextChanged += new System.EventHandler(this.tbSearchUser_TextChanged);
            // 
            // gbPostsOfUser
            // 
            this.gbPostsOfUser.Controls.Add(this.flowPostsFromUser);
            this.gbPostsOfUser.Controls.Add(this.pictureBox2);
            this.gbPostsOfUser.Location = new System.Drawing.Point(3, 236);
            this.gbPostsOfUser.Name = "gbPostsOfUser";
            this.gbPostsOfUser.Size = new System.Drawing.Size(781, 376);
            this.gbPostsOfUser.TabIndex = 15;
            this.gbPostsOfUser.TabStop = false;
            this.gbPostsOfUser.Text = "Posts van ";
            // 
            // flowPostsFromUser
            // 
            this.flowPostsFromUser.AutoScroll = true;
            this.flowPostsFromUser.Location = new System.Drawing.Point(6, 24);
            this.flowPostsFromUser.Name = "flowPostsFromUser";
            this.flowPostsFromUser.Size = new System.Drawing.Size(616, 346);
            this.flowPostsFromUser.TabIndex = 13;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.OrangeRed;
            this.pictureBox2.Location = new System.Drawing.Point(6, 402);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(772, 117);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // gbProfileOfUser
            // 
            this.gbProfileOfUser.Controls.Add(this.lblUserDescription);
            this.gbProfileOfUser.Controls.Add(this.pictureBox3);
            this.gbProfileOfUser.Controls.Add(this.pictureBox4);
            this.gbProfileOfUser.Controls.Add(this.lblUserDisplayName);
            this.gbProfileOfUser.Location = new System.Drawing.Point(0, 56);
            this.gbProfileOfUser.Name = "gbProfileOfUser";
            this.gbProfileOfUser.Size = new System.Drawing.Size(784, 225);
            this.gbProfileOfUser.TabIndex = 14;
            this.gbProfileOfUser.TabStop = false;
            this.gbProfileOfUser.Text = "profiel van ";
            // 
            // lblUserDescription
            // 
            this.lblUserDescription.BackColor = System.Drawing.Color.OrangeRed;
            this.lblUserDescription.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserDescription.Location = new System.Drawing.Point(165, 56);
            this.lblUserDescription.Name = "lblUserDescription";
            this.lblUserDescription.Size = new System.Drawing.Size(613, 116);
            this.lblUserDescription.TabIndex = 16;
            this.lblUserDescription.Tag = "Profiel";
            this.lblUserDescription.Text = "Biografie:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.OrangeRed;
            this.pictureBox3.Location = new System.Drawing.Point(9, 22);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(150, 150);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.OrangeRed;
            this.pictureBox4.Location = new System.Drawing.Point(6, 402);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(772, 117);
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // lblUserDisplayName
            // 
            this.lblUserDisplayName.BackColor = System.Drawing.Color.OrangeRed;
            this.lblUserDisplayName.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserDisplayName.Location = new System.Drawing.Point(165, 22);
            this.lblUserDisplayName.Name = "lblUserDisplayName";
            this.lblUserDisplayName.Size = new System.Drawing.Size(613, 24);
            this.lblUserDisplayName.TabIndex = 9;
            this.lblUserDisplayName.Tag = "Settings";
            this.lblUserDisplayName.Text = "Display Name:";
            this.lblUserDisplayName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.gbSettings);
            this.tabSettings.Location = new System.Drawing.Point(4, 33);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(802, 616);
            this.tabSettings.TabIndex = 3;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.gbMyProfile);
            this.gbSettings.Controls.Add(this.btnLogOut);
            this.gbSettings.Location = new System.Drawing.Point(3, 3);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(787, 619);
            this.gbSettings.TabIndex = 10;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // gbMyProfile
            // 
            this.gbMyProfile.Controls.Add(this.gbSocialMedia);
            this.gbMyProfile.Controls.Add(this.pbMyBanner);
            this.gbMyProfile.Controls.Add(this.tbMyBio);
            this.gbMyProfile.Controls.Add(this.lblBiografie);
            this.gbMyProfile.Controls.Add(this.pbMyProfileImage);
            this.gbMyProfile.Controls.Add(this.tbMyPassword);
            this.gbMyProfile.Controls.Add(this.label4);
            this.gbMyProfile.Controls.Add(this.tbMyDisplayName);
            this.gbMyProfile.Controls.Add(this.lblDisplayUser);
            this.gbMyProfile.Location = new System.Drawing.Point(8, 24);
            this.gbMyProfile.Name = "gbMyProfile";
            this.gbMyProfile.Size = new System.Drawing.Size(779, 530);
            this.gbMyProfile.TabIndex = 12;
            this.gbMyProfile.TabStop = false;
            this.gbMyProfile.Text = "Mijn Profiel";
            // 
            // gbSocialMedia
            // 
            this.gbSocialMedia.Controls.Add(this.btnSocialMedia4);
            this.gbSocialMedia.Controls.Add(this.btnSocialMedia3);
            this.gbSocialMedia.Controls.Add(this.btnSocialMedia2);
            this.gbSocialMedia.Controls.Add(this.btnSocialMedia1);
            this.gbSocialMedia.Location = new System.Drawing.Point(102, 292);
            this.gbSocialMedia.Name = "gbSocialMedia";
            this.gbSocialMedia.Size = new System.Drawing.Size(516, 100);
            this.gbSocialMedia.TabIndex = 19;
            this.gbSocialMedia.TabStop = false;
            // 
            // btnSocialMedia4
            // 
            this.btnSocialMedia4.Location = new System.Drawing.Point(384, 24);
            this.btnSocialMedia4.Name = "btnSocialMedia4";
            this.btnSocialMedia4.Size = new System.Drawing.Size(120, 61);
            this.btnSocialMedia4.TabIndex = 21;
            this.btnSocialMedia4.Text = "Reddit";
            this.btnSocialMedia4.UseVisualStyleBackColor = true;
            // 
            // btnSocialMedia3
            // 
            this.btnSocialMedia3.Location = new System.Drawing.Point(258, 24);
            this.btnSocialMedia3.Name = "btnSocialMedia3";
            this.btnSocialMedia3.Size = new System.Drawing.Size(120, 61);
            this.btnSocialMedia3.TabIndex = 20;
            this.btnSocialMedia3.Text = "Google + ";
            this.btnSocialMedia3.UseVisualStyleBackColor = true;
            // 
            // btnSocialMedia2
            // 
            this.btnSocialMedia2.Location = new System.Drawing.Point(132, 24);
            this.btnSocialMedia2.Name = "btnSocialMedia2";
            this.btnSocialMedia2.Size = new System.Drawing.Size(120, 61);
            this.btnSocialMedia2.TabIndex = 19;
            this.btnSocialMedia2.Text = "Twitter";
            this.btnSocialMedia2.UseVisualStyleBackColor = true;
            // 
            // btnSocialMedia1
            // 
            this.btnSocialMedia1.Location = new System.Drawing.Point(6, 24);
            this.btnSocialMedia1.Name = "btnSocialMedia1";
            this.btnSocialMedia1.Size = new System.Drawing.Size(120, 61);
            this.btnSocialMedia1.TabIndex = 18;
            this.btnSocialMedia1.Text = "Facebook";
            this.btnSocialMedia1.UseVisualStyleBackColor = true;
            // 
            // pbMyBanner
            // 
            this.pbMyBanner.BackColor = System.Drawing.Color.OrangeRed;
            this.pbMyBanner.Location = new System.Drawing.Point(10, 413);
            this.pbMyBanner.Name = "pbMyBanner";
            this.pbMyBanner.Size = new System.Drawing.Size(754, 99);
            this.pbMyBanner.TabIndex = 17;
            this.pbMyBanner.TabStop = false;
            this.pbMyBanner.Tag = "Settings";
            // 
            // tbMyBio
            // 
            this.tbMyBio.Location = new System.Drawing.Point(102, 90);
            this.tbMyBio.Multiline = true;
            this.tbMyBio.Name = "tbMyBio";
            this.tbMyBio.Size = new System.Drawing.Size(516, 187);
            this.tbMyBio.TabIndex = 16;
            // 
            // lblBiografie
            // 
            this.lblBiografie.AutoSize = true;
            this.lblBiografie.BackColor = System.Drawing.Color.OrangeRed;
            this.lblBiografie.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiografie.Location = new System.Drawing.Point(6, 90);
            this.lblBiografie.Name = "lblBiografie";
            this.lblBiografie.Size = new System.Drawing.Size(82, 28);
            this.lblBiografie.TabIndex = 15;
            this.lblBiografie.Tag = "Profiel";
            this.lblBiografie.Text = "Biografie:";
            this.lblBiografie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbMyProfileImage
            // 
            this.pbMyProfileImage.BackColor = System.Drawing.Color.OrangeRed;
            this.pbMyProfileImage.Location = new System.Drawing.Point(624, 24);
            this.pbMyProfileImage.Name = "pbMyProfileImage";
            this.pbMyProfileImage.Size = new System.Drawing.Size(150, 150);
            this.pbMyProfileImage.TabIndex = 14;
            this.pbMyProfileImage.TabStop = false;
            // 
            // tbMyPassword
            // 
            this.tbMyPassword.Location = new System.Drawing.Point(102, 62);
            this.tbMyPassword.Multiline = true;
            this.tbMyPassword.Name = "tbMyPassword";
            this.tbMyPassword.Size = new System.Drawing.Size(516, 22);
            this.tbMyPassword.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.OrangeRed;
            this.label4.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 28);
            this.label4.TabIndex = 12;
            this.label4.Tag = "Profiel";
            this.label4.Text = "Wachtwoord:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbMyDisplayName
            // 
            this.tbMyDisplayName.Location = new System.Drawing.Point(102, 27);
            this.tbMyDisplayName.Multiline = true;
            this.tbMyDisplayName.Name = "tbMyDisplayName";
            this.tbMyDisplayName.Size = new System.Drawing.Size(516, 24);
            this.tbMyDisplayName.TabIndex = 11;
            // 
            // lblDisplayUser
            // 
            this.lblDisplayUser.AutoSize = true;
            this.lblDisplayUser.BackColor = System.Drawing.Color.OrangeRed;
            this.lblDisplayUser.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayUser.Location = new System.Drawing.Point(6, 27);
            this.lblDisplayUser.Name = "lblDisplayUser";
            this.lblDisplayUser.Size = new System.Drawing.Size(116, 28);
            this.lblDisplayUser.TabIndex = 10;
            this.lblDisplayUser.Tag = "Settings";
            this.lblDisplayUser.Text = "Display Name:";
            this.lblDisplayUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogOut.Location = new System.Drawing.Point(616, 561);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(156, 50);
            this.btnLogOut.TabIndex = 6;
            this.btnLogOut.Tag = "Settings";
            this.btnLogOut.Text = "Uitloggen";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Aantal:";
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(339, 61);
            this.numAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(92, 30);
            this.numAmount.TabIndex = 4;
            this.numAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 666);
            this.Controls.Add(this.gbStaticUpdates);
            this.Controls.Add(this.gbDynamic);
            this.Controls.Add(this.pbBanner);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Agency FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "MainForm";
            this.Text = "Social Media Sharing System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbStaticUpdates.ResumeLayout(false);
            this.gbStaticUpdates.PerformLayout();
            this.tabTrending.ResumeLayout(false);
            this.Posts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.gbDynamic.ResumeLayout(false);
            this.tabMainTab.ResumeLayout(false);
            this.tabSocialMediaSharingSystem.ResumeLayout(false);
            this.tabSocialMediaSharingSystem.PerformLayout();
            this.tabMaterialrent.ResumeLayout(false);
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            this.tabProfile.ResumeLayout(false);
            this.gbProfielen.ResumeLayout(false);
            this.gbProfielen.PerformLayout();
            this.gbPostsOfUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbProfileOfUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.gbSettings.ResumeLayout(false);
            this.gbMyProfile.ResumeLayout(false);
            this.gbMyProfile.PerformLayout();
            this.gbSocialMedia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMyBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyProfileImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbStaticUpdates;
        private System.Windows.Forms.Label lblTrending;
        private System.Windows.Forms.Button btnDynamicButton;
        private System.Windows.Forms.ListBox lbTrendingPosts;
        private System.Windows.Forms.PictureBox pbBanner;
        private System.Windows.Forms.GroupBox gbDynamic;
        private System.Windows.Forms.TabControl tabTrending;
        private System.Windows.Forms.TabPage Posts;
        private System.Windows.Forms.TabPage Media;
        private System.Windows.Forms.TabPage Organisation;
        private System.Windows.Forms.TabControl tabMainTab;
        private System.Windows.Forms.TabPage tabSocialMediaSharingSystem;
        private System.Windows.Forms.Button btnMediaFile;
        private System.Windows.Forms.TextBox tbPostContent;
        private System.Windows.Forms.TabPage tabMaterialrent;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.GroupBox gbProfielen;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.TreeView treeCategorie;
        private System.Windows.Forms.GroupBox gbProfileOfUser;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblUserDisplayName;
        private System.Windows.Forms.GroupBox gbMyProfile;
        private System.Windows.Forms.TextBox tbMyBio;
        private System.Windows.Forms.Label lblBiografie;
        private System.Windows.Forms.PictureBox pbMyProfileImage;
        private System.Windows.Forms.TextBox tbMyPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMyDisplayName;
        private System.Windows.Forms.Label lblDisplayUser;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.Button btnHireMaterial;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.ListBox listCart;
        private System.Windows.Forms.GroupBox gbSocialMedia;
        private System.Windows.Forms.Button btnSocialMedia3;
        private System.Windows.Forms.Button btnSocialMedia2;
        private System.Windows.Forms.Button btnSocialMedia1;
        private System.Windows.Forms.PictureBox pbMyBanner;
        private System.Windows.Forms.GroupBox gbPostsOfUser;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.FlowLayoutPanel flowPosts;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblUserDescription;
        private System.Windows.Forms.Button btnSocialMedia4;
        private System.Windows.Forms.FlowLayoutPanel flowPostsFromUser;
        private System.Windows.Forms.ListView listMaterials;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbSearchUser;
        private System.Windows.Forms.ColumnHeader Naam;
        private System.Windows.Forms.ColumnHeader Description;
        private Button btnNextPage;
        private Button btnPreviousPage;
        private NumericUpDown numAmount;
        private Label label1;
    }
}

