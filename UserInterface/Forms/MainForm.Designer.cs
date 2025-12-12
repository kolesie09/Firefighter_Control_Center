
namespace FirefighterControlCenter.UserInterface.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_departure_card = new System.Windows.Forms.Button();
            this.btn_ranking = new System.Windows.Forms.Button();
            this.btn_head_panel = new System.Windows.Forms.Button();
            this.btn_history = new System.Windows.Forms.Button();
            this.btn_garage = new System.Windows.Forms.Button();
            this.btn_meetings = new System.Windows.Forms.Button();
            this.btn_info_panel = new System.Windows.Forms.Button();
            this.pMain = new System.Windows.Forms.Panel();
            this.btn_cylinder = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 789);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1284, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslVersion
            // 
            this.tsslVersion.Name = "tsslVersion";
            this.tsslVersion.Size = new System.Drawing.Size(81, 17);
            this.tsslVersion.Text = "Wersja: 0.0.1.0";
            // 
            // btn_departure_card
            // 
            this.btn_departure_card.Location = new System.Drawing.Point(40, 12);
            this.btn_departure_card.Name = "btn_departure_card";
            this.btn_departure_card.Size = new System.Drawing.Size(146, 37);
            this.btn_departure_card.TabIndex = 1;
            this.btn_departure_card.Text = "Karta wyjazdu";
            this.btn_departure_card.UseVisualStyleBackColor = true;
            this.btn_departure_card.Click += new System.EventHandler(this.btn_departure_card_Click);
            // 
            // btn_ranking
            // 
            this.btn_ranking.Location = new System.Drawing.Point(192, 12);
            this.btn_ranking.Name = "btn_ranking";
            this.btn_ranking.Size = new System.Drawing.Size(146, 37);
            this.btn_ranking.TabIndex = 2;
            this.btn_ranking.Text = "Ranking";
            this.btn_ranking.UseVisualStyleBackColor = true;
            this.btn_ranking.Click += new System.EventHandler(this.btn_ranking_Click);
            // 
            // btn_head_panel
            // 
            this.btn_head_panel.Location = new System.Drawing.Point(800, 12);
            this.btn_head_panel.Name = "btn_head_panel";
            this.btn_head_panel.Size = new System.Drawing.Size(146, 37);
            this.btn_head_panel.TabIndex = 3;
            this.btn_head_panel.Text = "Panel naczelnika";
            this.btn_head_panel.UseVisualStyleBackColor = true;
            this.btn_head_panel.Click += new System.EventHandler(this.btn_head_panel_Click);
            // 
            // btn_history
            // 
            this.btn_history.Location = new System.Drawing.Point(344, 12);
            this.btn_history.Name = "btn_history";
            this.btn_history.Size = new System.Drawing.Size(146, 37);
            this.btn_history.TabIndex = 4;
            this.btn_history.Text = "Historia";
            this.btn_history.UseVisualStyleBackColor = true;
            this.btn_history.Click += new System.EventHandler(this.btn_history_Click);
            // 
            // btn_garage
            // 
            this.btn_garage.Enabled = false;
            this.btn_garage.Location = new System.Drawing.Point(496, 12);
            this.btn_garage.Name = "btn_garage";
            this.btn_garage.Size = new System.Drawing.Size(146, 37);
            this.btn_garage.TabIndex = 5;
            this.btn_garage.Text = "Garaż";
            this.btn_garage.UseVisualStyleBackColor = true;
            this.btn_garage.Click += new System.EventHandler(this.btn_garage_Click);
            // 
            // btn_meetings
            // 
            this.btn_meetings.Enabled = false;
            this.btn_meetings.Location = new System.Drawing.Point(952, 12);
            this.btn_meetings.Name = "btn_meetings";
            this.btn_meetings.Size = new System.Drawing.Size(146, 37);
            this.btn_meetings.TabIndex = 6;
            this.btn_meetings.Text = "Zebrania";
            this.btn_meetings.UseVisualStyleBackColor = true;
            this.btn_meetings.Click += new System.EventHandler(this.btn_meetings_Click);
            // 
            // btn_info_panel
            // 
            this.btn_info_panel.Enabled = false;
            this.btn_info_panel.Location = new System.Drawing.Point(1104, 12);
            this.btn_info_panel.Name = "btn_info_panel";
            this.btn_info_panel.Size = new System.Drawing.Size(146, 37);
            this.btn_info_panel.TabIndex = 7;
            this.btn_info_panel.Text = "Panel informacyjny";
            this.btn_info_panel.UseVisualStyleBackColor = true;
            this.btn_info_panel.Click += new System.EventHandler(this.btn_info_panel_Click);
            // 
            // pMain
            // 
            this.pMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pMain.Location = new System.Drawing.Point(0, 55);
            this.pMain.Margin = new System.Windows.Forms.Padding(0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(1284, 734);
            this.pMain.TabIndex = 8;
            // 
            // btn_cylinder
            // 
            this.btn_cylinder.Enabled = false;
            this.btn_cylinder.Location = new System.Drawing.Point(648, 12);
            this.btn_cylinder.Name = "btn_cylinder";
            this.btn_cylinder.Size = new System.Drawing.Size(146, 37);
            this.btn_cylinder.TabIndex = 9;
            this.btn_cylinder.Text = "Butle";
            this.btn_cylinder.UseVisualStyleBackColor = true;
            this.btn_cylinder.Click += new System.EventHandler(this.btn_cylinder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 811);
            this.Controls.Add(this.btn_cylinder);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.btn_info_panel);
            this.Controls.Add(this.btn_meetings);
            this.Controls.Add(this.btn_garage);
            this.Controls.Add(this.btn_history);
            this.Controls.Add(this.btn_head_panel);
            this.Controls.Add(this.btn_ranking);
            this.Controls.Add(this.btn_departure_card);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Firefighter Control Center";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslVersion;
        private System.Windows.Forms.Button btn_departure_card;
        private System.Windows.Forms.Button btn_ranking;
        private System.Windows.Forms.Button btn_head_panel;
        private System.Windows.Forms.Button btn_history;
        private System.Windows.Forms.Button btn_garage;
        private System.Windows.Forms.Button btn_meetings;
        private System.Windows.Forms.Button btn_info_panel;
        private System.Windows.Forms.Button btn_cylinder;
        public System.Windows.Forms.Panel pMain;
    }
}