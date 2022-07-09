
namespace FirefighterControlCenter.UserInterface.Forms
{
    partial class Garage
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
            this.TitleGarage = new System.Windows.Forms.Label();
            this.GB499z01 = new System.Windows.Forms.GroupBox();
            this.GB499z15 = new System.Windows.Forms.GroupBox();
            this.GB499z18 = new System.Windows.Forms.GroupBox();
            this.GB499z19 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // TitleGarage
            // 
            this.TitleGarage.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleGarage.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TitleGarage.Location = new System.Drawing.Point(0, 0);
            this.TitleGarage.Name = "TitleGarage";
            this.TitleGarage.Size = new System.Drawing.Size(1284, 37);
            this.TitleGarage.TabIndex = 3;
            this.TitleGarage.Text = "Garaż OSP Barlinek";
            this.TitleGarage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.TitleGarage.Click += new System.EventHandler(this.TitleGarage_Click);
            // 
            // GB499z01
            // 
            this.GB499z01.Location = new System.Drawing.Point(49, 127);
            this.GB499z01.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.GB499z01.Name = "GB499z01";
            this.GB499z01.Size = new System.Drawing.Size(280, 651);
            this.GB499z01.TabIndex = 4;
            this.GB499z01.TabStop = false;
            this.GB499z01.Text = "499z01";
            // 
            // GB499z15
            // 
            this.GB499z15.Location = new System.Drawing.Point(339, 127);
            this.GB499z15.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.GB499z15.Name = "GB499z15";
            this.GB499z15.Size = new System.Drawing.Size(280, 651);
            this.GB499z15.TabIndex = 5;
            this.GB499z15.TabStop = false;
            this.GB499z15.Text = "499z15";
            // 
            // GB499z18
            // 
            this.GB499z18.Location = new System.Drawing.Point(629, 127);
            this.GB499z18.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.GB499z18.Name = "GB499z18";
            this.GB499z18.Size = new System.Drawing.Size(280, 651);
            this.GB499z18.TabIndex = 5;
            this.GB499z18.TabStop = false;
            this.GB499z18.Text = "499z18";
            // 
            // GB499z19
            // 
            this.GB499z19.Location = new System.Drawing.Point(919, 127);
            this.GB499z19.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.GB499z19.Name = "GB499z19";
            this.GB499z19.Size = new System.Drawing.Size(280, 651);
            this.GB499z19.TabIndex = 5;
            this.GB499z19.TabStop = false;
            this.GB499z19.Text = "499z19";
            // 
            // Garage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1284, 787);
            this.Controls.Add(this.GB499z19);
            this.Controls.Add(this.GB499z18);
            this.Controls.Add(this.GB499z15);
            this.Controls.Add(this.GB499z01);
            this.Controls.Add(this.TitleGarage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Garage";
            this.Text = "Garage";
            this.Load += new System.EventHandler(this.Garage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleGarage;
        private System.Windows.Forms.GroupBox GB499z01;
        private System.Windows.Forms.GroupBox GB499z15;
        private System.Windows.Forms.GroupBox GB499z18;
        private System.Windows.Forms.GroupBox GB499z19;
    }
}