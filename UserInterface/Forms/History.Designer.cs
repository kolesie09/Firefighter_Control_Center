
namespace FirefighterControlCenter.UserInterface.Forms
{
    partial class History
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
            this.PHistory = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PHistory
            // 
            this.PHistory.Location = new System.Drawing.Point(0, 0);
            this.PHistory.Name = "PHistory";
            this.PHistory.Size = new System.Drawing.Size(1250, 645);
            this.PHistory.TabIndex = 0;
            this.PHistory.Scroll += new System.Windows.Forms.ScrollEventHandler(this.PHistory_Scroll);
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 695);
            this.Controls.Add(this.PHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "History";
            this.Text = "History";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PHistory;
    }
}