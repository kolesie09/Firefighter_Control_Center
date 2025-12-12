namespace FirefighterControlCenter.UserInterface.Forms.Head
{
    partial class EmailManagement
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAddNewEmail = new System.Windows.Forms.Button();
            this.GPEmail = new System.Windows.Forms.GroupBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zarządzanie mailami";
            // 
            // BtnAddNewEmail
            // 
            this.BtnAddNewEmail.Location = new System.Drawing.Point(322, 65);
            this.BtnAddNewEmail.Name = "BtnAddNewEmail";
            this.BtnAddNewEmail.Size = new System.Drawing.Size(110, 23);
            this.BtnAddNewEmail.TabIndex = 1;
            this.BtnAddNewEmail.Text = "dodaj nowe pole";
            this.BtnAddNewEmail.UseVisualStyleBackColor = true;
            this.BtnAddNewEmail.Click += new System.EventHandler(this.BtnAddNewEmail_Click);
            // 
            // GPEmail
            // 
            this.GPEmail.Location = new System.Drawing.Point(12, 94);
            this.GPEmail.Name = "GPEmail";
            this.GPEmail.Size = new System.Drawing.Size(776, 304);
            this.GPEmail.TabIndex = 2;
            this.GPEmail.TabStop = false;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(678, 415);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(110, 23);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "Zapisz";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // EmailManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.GPEmail);
            this.Controls.Add(this.BtnAddNewEmail);
            this.Controls.Add(this.label1);
            this.Name = "EmailManagement";
            this.Text = "EmailManagement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAddNewEmail;
        private System.Windows.Forms.GroupBox GPEmail;
        private System.Windows.Forms.Button BtnSave;
    }
}