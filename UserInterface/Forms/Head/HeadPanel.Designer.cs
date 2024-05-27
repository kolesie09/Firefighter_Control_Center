
namespace FirefighterControlCenter.UserInterface.Forms.Head
{
    partial class HeadPanel
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
            this.HP = new System.Windows.Forms.Panel();
            this.EditUser = new System.Windows.Forms.Button();
            this.AddUser = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.HP.SuspendLayout();
            this.SuspendLayout();
            // 
            // HP
            // 
            this.HP.AutoScroll = true;
            this.HP.AutoSize = true;
            this.HP.Controls.Add(this.button1);
            this.HP.Controls.Add(this.EditUser);
            this.HP.Controls.Add(this.AddUser);
            this.HP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HP.Location = new System.Drawing.Point(0, 0);
            this.HP.Name = "HP";
            this.HP.Size = new System.Drawing.Size(1284, 734);
            this.HP.TabIndex = 1;
            // 
            // EditUser
            // 
            this.EditUser.Location = new System.Drawing.Point(236, 56);
            this.EditUser.Name = "EditUser";
            this.EditUser.Size = new System.Drawing.Size(154, 49);
            this.EditUser.TabIndex = 1;
            this.EditUser.Text = "Edytuj użytkownika";
            this.EditUser.UseVisualStyleBackColor = true;
            this.EditUser.Click += new System.EventHandler(this.EditUser_Click);
            // 
            // AddUser
            // 
            this.AddUser.Location = new System.Drawing.Point(57, 56);
            this.AddUser.Name = "AddUser";
            this.AddUser.Size = new System.Drawing.Size(154, 49);
            this.AddUser.TabIndex = 0;
            this.AddUser.Text = "Dodaj użytkownika";
            this.AddUser.UseVisualStyleBackColor = true;
            this.AddUser.Click += new System.EventHandler(this.AddUser_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(418, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 49);
            this.button1.TabIndex = 2;
            this.button1.Text = "Użytkownicy";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // HeadPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 734);
            this.Controls.Add(this.HP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HeadPanel";
            this.Text = "HeadPanel";
            this.HP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel HP;
        private System.Windows.Forms.Button AddUser;
        private System.Windows.Forms.Button EditUser;
        private System.Windows.Forms.Button button1;
    }
}