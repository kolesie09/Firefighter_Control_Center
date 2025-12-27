
namespace FirefighterControlCenter.UserInterface.Forms.RankingsD
{
    partial class Rankings
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
            this.btn_firefighter = new System.Windows.Forms.Button();
            this.btn_city = new System.Windows.Forms.Button();
            this.btn_street = new System.Windows.Forms.Button();
            this.btn_incident = new System.Windows.Forms.Button();
            this.btn_nonstandard = new System.Windows.Forms.Button();
            this.pRanking = new System.Windows.Forms.Panel();
            this.changeYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(469, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "RANKING";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_firefighter
            // 
            this.btn_firefighter.Location = new System.Drawing.Point(316, 59);
            this.btn_firefighter.Name = "btn_firefighter";
            this.btn_firefighter.Size = new System.Drawing.Size(75, 23);
            this.btn_firefighter.TabIndex = 1;
            this.btn_firefighter.Text = "Strażacki";
            this.btn_firefighter.UseVisualStyleBackColor = true;
            this.btn_firefighter.Click += new System.EventHandler(this.btn_firefighter_Click);
            // 
            // btn_city
            // 
            this.btn_city.Location = new System.Drawing.Point(397, 59);
            this.btn_city.Name = "btn_city";
            this.btn_city.Size = new System.Drawing.Size(99, 23);
            this.btn_city.TabIndex = 2;
            this.btn_city.Text = "Miejscowości";
            this.btn_city.UseVisualStyleBackColor = true;
            this.btn_city.Click += new System.EventHandler(this.btn_city_Click);
            // 
            // btn_street
            // 
            this.btn_street.Location = new System.Drawing.Point(502, 59);
            this.btn_street.Name = "btn_street";
            this.btn_street.Size = new System.Drawing.Size(99, 23);
            this.btn_street.TabIndex = 3;
            this.btn_street.Text = "Ulic";
            this.btn_street.UseVisualStyleBackColor = true;
            this.btn_street.Click += new System.EventHandler(this.btn_street_Click);
            // 
            // btn_incident
            // 
            this.btn_incident.Location = new System.Drawing.Point(607, 59);
            this.btn_incident.Name = "btn_incident";
            this.btn_incident.Size = new System.Drawing.Size(99, 23);
            this.btn_incident.TabIndex = 4;
            this.btn_incident.Text = "Zdarzeń";
            this.btn_incident.UseVisualStyleBackColor = true;
            this.btn_incident.Click += new System.EventHandler(this.btn_incident_Click);
            // 
            // btn_nonstandard
            // 
            this.btn_nonstandard.Enabled = false;
            this.btn_nonstandard.Location = new System.Drawing.Point(712, 59);
            this.btn_nonstandard.Name = "btn_nonstandard";
            this.btn_nonstandard.Size = new System.Drawing.Size(99, 23);
            this.btn_nonstandard.TabIndex = 5;
            this.btn_nonstandard.Text = "Niestandardowe";
            this.btn_nonstandard.UseVisualStyleBackColor = true;
            this.btn_nonstandard.Click += new System.EventHandler(this.btn_nonstandard_Click);
            // 
            // pRanking
            // 
            this.pRanking.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pRanking.Location = new System.Drawing.Point(0, 88);
            this.pRanking.Name = "pRanking";
            this.pRanking.Size = new System.Drawing.Size(1284, 646);
            this.pRanking.TabIndex = 6;
            // 
            // changeYear
            // 
            this.changeYear.FormattingEnabled = true;
            this.changeYear.Location = new System.Drawing.Point(983, 59);
            this.changeYear.Name = "changeYear";
            this.changeYear.Size = new System.Drawing.Size(182, 21);
            this.changeYear.TabIndex = 7;
            this.changeYear.SelectedIndexChanged += new System.EventHandler(this.changeYear_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(712, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(559, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "                                                                                 " +
    "          ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Rankings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 734);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.changeYear);
            this.Controls.Add(this.pRanking);
            this.Controls.Add(this.btn_nonstandard);
            this.Controls.Add(this.btn_incident);
            this.Controls.Add(this.btn_street);
            this.Controls.Add(this.btn_city);
            this.Controls.Add(this.btn_firefighter);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Rankings";
            this.Text = "Ranking";
            this.Load += new System.EventHandler(this.Rankings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_firefighter;
        private System.Windows.Forms.Button btn_city;
        private System.Windows.Forms.Button btn_street;
        private System.Windows.Forms.Button btn_incident;
        private System.Windows.Forms.Button btn_nonstandard;
        private System.Windows.Forms.Panel pRanking;
        private System.Windows.Forms.ComboBox changeYear;
        private System.Windows.Forms.Label label2;
    }
}