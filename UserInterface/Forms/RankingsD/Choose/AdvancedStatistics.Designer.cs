namespace FirefighterControlCenter.UserInterface.Forms.Rankings.Choose
{
    partial class AdvancedStatistics
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
            this.CBChoose = new System.Windows.Forms.ComboBox();
            this.BtnClick = new System.Windows.Forms.Button();
            this.CBFrom = new System.Windows.Forms.ComboBox();
            this.CBTo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CBChoose
            // 
            this.CBChoose.FormattingEnabled = true;
            this.CBChoose.Items.AddRange(new object[] {
            "Ilość wyjazdów - podzielona na miesiące"});
            this.CBChoose.Location = new System.Drawing.Point(12, 12);
            this.CBChoose.Name = "CBChoose";
            this.CBChoose.Size = new System.Drawing.Size(776, 21);
            this.CBChoose.TabIndex = 0;
            // 
            // BtnClick
            // 
            this.BtnClick.Location = new System.Drawing.Point(279, 352);
            this.BtnClick.Name = "BtnClick";
            this.BtnClick.Size = new System.Drawing.Size(230, 80);
            this.BtnClick.TabIndex = 1;
            this.BtnClick.Text = "Pokaż";
            this.BtnClick.UseVisualStyleBackColor = true;
            this.BtnClick.Click += new System.EventHandler(this.BtnClick_Click);
            // 
            // CBFrom
            // 
            this.CBFrom.FormattingEnabled = true;
            this.CBFrom.Location = new System.Drawing.Point(216, 100);
            this.CBFrom.Name = "CBFrom";
            this.CBFrom.Size = new System.Drawing.Size(121, 21);
            this.CBFrom.TabIndex = 2;
            // 
            // CBTo
            // 
            this.CBTo.FormattingEnabled = true;
            this.CBTo.Location = new System.Drawing.Point(412, 100);
            this.CBTo.Name = "CBTo";
            this.CBTo.Size = new System.Drawing.Size(121, 21);
            this.CBTo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "OD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(463, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "DO";
            // 
            // AdvancedStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CBTo);
            this.Controls.Add(this.CBFrom);
            this.Controls.Add(this.BtnClick);
            this.Controls.Add(this.CBChoose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdvancedStatistics";
            this.Text = "AdvancedStatistics";
            this.Load += new System.EventHandler(this.AdvancedStatistics_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBChoose;
        private System.Windows.Forms.Button BtnClick;
        private System.Windows.Forms.ComboBox CBFrom;
        private System.Windows.Forms.ComboBox CBTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}