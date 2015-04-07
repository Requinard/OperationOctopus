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
            this.gbStaticUpdates = new System.Windows.Forms.GroupBox();
            this.lblTrending = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Posts = new System.Windows.Forms.TabPage();
            this.lbTrendingPosts = new System.Windows.Forms.ListBox();
            this.Media = new System.Windows.Forms.TabPage();
            this.Organisation = new System.Windows.Forms.TabPage();
            this.btnDynamicButton = new System.Windows.Forms.Button();
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.gbDynamic = new System.Windows.Forms.GroupBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnMediaFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Profiel = new System.Windows.Forms.TabPage();
            this.gbProfielen = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.gbAdminOptions = new System.Windows.Forms.GroupBox();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.gbStaticUpdates.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Posts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.gbDynamic.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Profiel.SuspendLayout();
            this.gbProfielen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.gbAdminOptions.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbStaticUpdates
            // 
            this.gbStaticUpdates.BackColor = System.Drawing.Color.RoyalBlue;
            this.gbStaticUpdates.Controls.Add(this.lblTrending);
            this.gbStaticUpdates.Controls.Add(this.tabControl1);
            this.gbStaticUpdates.Controls.Add(this.btnDynamicButton);
            this.gbStaticUpdates.Location = new System.Drawing.Point(823, 12);
            this.gbStaticUpdates.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gbStaticUpdates.Name = "gbStaticUpdates";
            this.gbStaticUpdates.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gbStaticUpdates.Size = new System.Drawing.Size(166, 584);
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
            this.lblTrending.Size = new System.Drawing.Size(120, 24);
            this.lblTrending.TabIndex = 5;
            this.lblTrending.Tag = "Static";
            this.lblTrending.Text = "Trending right now:";
            this.lblTrending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Posts);
            this.tabControl1.Controls.Add(this.Media);
            this.tabControl1.Controls.Add(this.Organisation);
            this.tabControl1.Location = new System.Drawing.Point(4, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(156, 481);
            this.tabControl1.TabIndex = 0;
            // 
            // Posts
            // 
            this.Posts.Controls.Add(this.lbTrendingPosts);
            this.Posts.Location = new System.Drawing.Point(4, 27);
            this.Posts.Name = "Posts";
            this.Posts.Padding = new System.Windows.Forms.Padding(3);
            this.Posts.Size = new System.Drawing.Size(148, 450);
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
            this.lbTrendingPosts.ItemHeight = 24;
            this.lbTrendingPosts.Location = new System.Drawing.Point(6, 6);
            this.lbTrendingPosts.Name = "lbTrendingPosts";
            this.lbTrendingPosts.Size = new System.Drawing.Size(136, 436);
            this.lbTrendingPosts.TabIndex = 0;
            this.lbTrendingPosts.Tag = "Static";
            // 
            // Media
            // 
            this.Media.Location = new System.Drawing.Point(4, 27);
            this.Media.Name = "Media";
            this.Media.Padding = new System.Windows.Forms.Padding(3);
            this.Media.Size = new System.Drawing.Size(148, 450);
            this.Media.TabIndex = 1;
            this.Media.Text = "Media";
            this.Media.UseVisualStyleBackColor = true;
            // 
            // Organisation
            // 
            this.Organisation.Location = new System.Drawing.Point(4, 27);
            this.Organisation.Name = "Organisation";
            this.Organisation.Size = new System.Drawing.Size(148, 450);
            this.Organisation.TabIndex = 2;
            this.Organisation.Text = "Organisation";
            this.Organisation.UseVisualStyleBackColor = true;
            // 
            // btnDynamicButton
            // 
            this.btnDynamicButton.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDynamicButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDynamicButton.Location = new System.Drawing.Point(4, 13);
            this.btnDynamicButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnDynamicButton.Name = "btnDynamicButton";
            this.btnDynamicButton.Size = new System.Drawing.Size(156, 50);
            this.btnDynamicButton.TabIndex = 4;
            this.btnDynamicButton.Tag = "Static";
            this.btnDynamicButton.Text = "DynamicButton";
            this.btnDynamicButton.UseVisualStyleBackColor = true;
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
            this.gbDynamic.BackColor = System.Drawing.Color.DodgerBlue;
            this.gbDynamic.Controls.Add(this.tabControl2);
            this.gbDynamic.Location = new System.Drawing.Point(11, 13);
            this.gbDynamic.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gbDynamic.Name = "gbDynamic";
            this.gbDynamic.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gbDynamic.Size = new System.Drawing.Size(808, 583);
            this.gbDynamic.TabIndex = 6;
            this.gbDynamic.TabStop = false;
            this.gbDynamic.Tag = "Static";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.Profiel);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(5, 12);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(798, 562);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnMediaFile);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(790, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Social Media Sharing System";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnMediaFile
            // 
            this.btnMediaFile.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMediaFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMediaFile.Location = new System.Drawing.Point(628, 9);
            this.btnMediaFile.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnMediaFile.Name = "btnMediaFile";
            this.btnMediaFile.Size = new System.Drawing.Size(156, 65);
            this.btnMediaFile.TabIndex = 6;
            this.btnMediaFile.Tag = "Static";
            this.btnMediaFile.Text = "Add File(s)";
            this.btnMediaFile.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 9);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(617, 65);
            this.textBox1.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listBox1.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(6, 89);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(778, 436);
            this.listBox1.TabIndex = 0;
            this.listBox1.Tag = "Static";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(790, 531);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Materiaal Verhuur";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Profiel
            // 
            this.Profiel.Controls.Add(this.gbProfielen);
            this.Profiel.Location = new System.Drawing.Point(4, 27);
            this.Profiel.Name = "Profiel";
            this.Profiel.Size = new System.Drawing.Size(790, 531);
            this.Profiel.TabIndex = 4;
            this.Profiel.Text = "Profiel";
            this.Profiel.UseVisualStyleBackColor = true;
            // 
            // gbProfielen
            // 
            this.gbProfielen.Controls.Add(this.pictureBox1);
            this.gbProfielen.Controls.Add(this.pictureBox2);
            this.gbProfielen.Controls.Add(this.lblDisplayName);
            this.gbProfielen.Controls.Add(this.lblPassword);
            this.gbProfielen.Controls.Add(this.textBox3);
            this.gbProfielen.Controls.Add(this.textBox2);
            this.gbProfielen.Location = new System.Drawing.Point(3, 3);
            this.gbProfielen.Name = "gbProfielen";
            this.gbProfielen.Size = new System.Drawing.Size(784, 525);
            this.gbProfielen.TabIndex = 13;
            this.gbProfielen.TabStop = false;
            this.gbProfielen.Text = "Profiel";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.OrangeRed;
            this.pictureBox1.Location = new System.Drawing.Point(6, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(154, 184);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.BackColor = System.Drawing.Color.OrangeRed;
            this.lblDisplayName.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayName.Location = new System.Drawing.Point(166, 24);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(90, 24);
            this.lblDisplayName.TabIndex = 9;
            this.lblDisplayName.Tag = "Settings";
            this.lblDisplayName.Text = "Display Name:";
            this.lblDisplayName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.OrangeRed;
            this.lblPassword.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(166, 68);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(71, 24);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Tag = "Profiel";
            this.lblPassword.Text = "Password:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(262, 70);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(516, 24);
            this.textBox3.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(262, 26);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(516, 24);
            this.textBox2.TabIndex = 8;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.gbSettings);
            this.tabPage4.Location = new System.Drawing.Point(4, 27);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(790, 531);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Settings";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.gbAdminOptions);
            this.gbSettings.Controls.Add(this.btnLogOut);
            this.gbSettings.Location = new System.Drawing.Point(3, 3);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(787, 532);
            this.gbSettings.TabIndex = 10;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogOut.Location = new System.Drawing.Point(616, 459);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(156, 50);
            this.btnLogOut.TabIndex = 6;
            this.btnLogOut.Tag = "Settings";
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            // 
            // gbAdminOptions
            // 
            this.gbAdminOptions.Controls.Add(this.tabControl4);
            this.gbAdminOptions.Controls.Add(this.button1);
            this.gbAdminOptions.Location = new System.Drawing.Point(8, 219);
            this.gbAdminOptions.Name = "gbAdminOptions";
            this.gbAdminOptions.Size = new System.Drawing.Size(779, 321);
            this.gbAdminOptions.TabIndex = 11;
            this.gbAdminOptions.TabStop = false;
            this.gbAdminOptions.Text = "Admin Options";
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage6);
            this.tabControl4.Controls.Add(this.tabPage7);
            this.tabControl4.Location = new System.Drawing.Point(6, 24);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(770, 282);
            this.tabControl4.TabIndex = 9;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 27);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(762, 251);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "Materiaal Verhuur";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 27);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(192, 69);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Event Beheer";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(616, 459);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 50);
            this.button1.TabIndex = 6;
            this.button1.Tag = "Settings";
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.gbStaticUpdates);
            this.Controls.Add(this.gbDynamic);
            this.Controls.Add(this.pbBanner);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Agency FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbStaticUpdates.ResumeLayout(false);
            this.gbStaticUpdates.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Posts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.gbDynamic.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.Profiel.ResumeLayout(false);
            this.gbProfielen.ResumeLayout(false);
            this.gbProfielen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.gbSettings.ResumeLayout(false);
            this.gbAdminOptions.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbStaticUpdates;
        private System.Windows.Forms.Label lblTrending;
        private System.Windows.Forms.Button btnDynamicButton;
        private System.Windows.Forms.ListBox lbTrendingPosts;
        private System.Windows.Forms.PictureBox pbBanner;
        private System.Windows.Forms.GroupBox gbDynamic;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Posts;
        private System.Windows.Forms.TabPage Media;
        private System.Windows.Forms.TabPage Organisation;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnMediaFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage Profiel;
        private System.Windows.Forms.GroupBox gbProfielen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.GroupBox gbAdminOptions;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Button button1;
    }
}

