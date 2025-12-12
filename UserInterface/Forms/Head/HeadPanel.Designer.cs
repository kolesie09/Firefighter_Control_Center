
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
            this.BtnEquivalent = new System.Windows.Forms.Button();
            this.BtnEmailManagement = new System.Windows.Forms.Button();
            this.BtnRateManagement = new System.Windows.Forms.Button();
            this.btn_vehicle = new System.Windows.Forms.Button();
            this.EditUser = new System.Windows.Forms.Button();
            this.AddUser = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.HP.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // HP
            // 
            this.HP.AutoScroll = true;
            this.HP.AutoSize = true;
            this.HP.Controls.Add(this.groupBox3);
            this.HP.Controls.Add(this.groupBox2);
            this.HP.Controls.Add(this.groupBox1);
            this.HP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HP.Location = new System.Drawing.Point(0, 0);
            this.HP.Name = "HP";
            this.HP.Size = new System.Drawing.Size(1284, 734);
            this.HP.TabIndex = 1;
            // 
            // BtnEquivalent
            // 
            this.BtnEquivalent.Location = new System.Drawing.Point(422, 31);
            this.BtnEquivalent.Name = "BtnEquivalent";
            this.BtnEquivalent.Size = new System.Drawing.Size(154, 49);
            this.BtnEquivalent.TabIndex = 7;
            this.BtnEquivalent.Text = "Generuj raport ekwiwalentu";
            this.BtnEquivalent.UseVisualStyleBackColor = true;
            this.BtnEquivalent.Click += new System.EventHandler(this.BtnEquivalent_Click);
            // 
            // BtnEmailManagement
            // 
            this.BtnEmailManagement.Location = new System.Drawing.Point(248, 31);
            this.BtnEmailManagement.Name = "BtnEmailManagement";
            this.BtnEmailManagement.Size = new System.Drawing.Size(154, 49);
            this.BtnEmailManagement.TabIndex = 6;
            this.BtnEmailManagement.Text = "Zarządzanie mailami";
            this.BtnEmailManagement.UseVisualStyleBackColor = true;
            this.BtnEmailManagement.Click += new System.EventHandler(this.BtnEmailManagement_Click);
            // 
            // BtnRateManagement
            // 
            this.BtnRateManagement.Location = new System.Drawing.Point(73, 31);
            this.BtnRateManagement.Name = "BtnRateManagement";
            this.BtnRateManagement.Size = new System.Drawing.Size(154, 49);
            this.BtnRateManagement.TabIndex = 5;
            this.BtnRateManagement.Text = "Zarządzanie ekwiwalentem";
            this.BtnRateManagement.UseVisualStyleBackColor = true;
            this.BtnRateManagement.Click += new System.EventHandler(this.BtnRateManagement_Click);
            // 
            // btn_vehicle
            // 
            this.btn_vehicle.Location = new System.Drawing.Point(248, 28);
            this.btn_vehicle.Name = "btn_vehicle";
            this.btn_vehicle.Size = new System.Drawing.Size(154, 49);
            this.btn_vehicle.TabIndex = 4;
            this.btn_vehicle.Text = "Zarządzanie autami";
            this.btn_vehicle.UseVisualStyleBackColor = true;
            this.btn_vehicle.Click += new System.EventHandler(this.btn_vehicle_Click);
            // 
            // EditUser
            // 
            this.EditUser.Location = new System.Drawing.Point(338, 29);
            this.EditUser.Name = "EditUser";
            this.EditUser.Size = new System.Drawing.Size(154, 49);
            this.EditUser.TabIndex = 1;
            this.EditUser.Text = "Edytuj strażaka";
            this.EditUser.UseVisualStyleBackColor = true;
            this.EditUser.Click += new System.EventHandler(this.EditUser_Click);
            // 
            // AddUser
            // 
            this.AddUser.Location = new System.Drawing.Point(159, 29);
            this.AddUser.Name = "AddUser";
            this.AddUser.Size = new System.Drawing.Size(154, 49);
            this.AddUser.TabIndex = 0;
            this.AddUser.Text = "Dodaj strażaka";
            this.AddUser.UseVisualStyleBackColor = true;
            this.AddUser.Click += new System.EventHandler(this.AddUser_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.AddUser);
            this.groupBox1.Controls.Add(this.EditUser);
            this.groupBox1.Location = new System.Drawing.Point(321, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Strażacy";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.btn_vehicle);
            this.groupBox2.Location = new System.Drawing.Point(321, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remiza";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.BtnRateManagement);
            this.groupBox3.Controls.Add(this.BtnEmailManagement);
            this.groupBox3.Controls.Add(this.BtnEquivalent);
            this.groupBox3.Location = new System.Drawing.Point(321, 309);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(630, 100);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Oganizacja";
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel HP;
        private System.Windows.Forms.Button AddUser;
        private System.Windows.Forms.Button EditUser;
        private System.Windows.Forms.Button btn_vehicle;
        private System.Windows.Forms.Button BtnRateManagement;
        private System.Windows.Forms.Button BtnEmailManagement;
        private System.Windows.Forms.Button BtnEquivalent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}