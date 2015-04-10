namespace ICT4EVENT
{
    partial class RegistratieForm
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
            this.txtRfid = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtRfid
            // 
            this.txtRfid.Enabled = false;
            this.txtRfid.Location = new System.Drawing.Point(12, 12);
            this.txtRfid.Name = "txtRfid";
            this.txtRfid.Size = new System.Drawing.Size(352, 22);
            this.txtRfid.TabIndex = 0;
            // 
            // RegistratieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 428);
            this.Controls.Add(this.txtRfid);
            this.Name = "RegistratieForm";
            this.Text = "Registratie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRfid;
    }
}