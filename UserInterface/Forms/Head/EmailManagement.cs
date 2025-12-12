using FirefighterControlCenter.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms.Head
{
    public partial class EmailManagement : Form
    {
        private int MaxHeight;
        private List<string> Emails;
        private SqlConnectorv2 SQL;

        public EmailManagement()
        {
            InitializeComponent();
            Emails = SqlConnectorv2.SelectEmail();
            ShowAllEmail(Emails);

            MaxHeight = Emails.Count;
            SQL = new SqlConnectorv2();
        }

        private void ShowAllEmail(List<string> Emails)
        {
            for (int i = 1; i < Emails.Count; i++)
            {
                TextBox TB = new TextBox
                {
                    Text = Emails[i],
                    Name = i + 1 + "TB",
                    Location = new System.Drawing.Point(10, 25 * i),
                    Size = new System.Drawing.Size(300, 20)
                };

                Button BTN = new Button
                {
                    Text = "-",
                    Name = i + 1 + "BTN",
                    Location = new System.Drawing.Point(320, 25 * i),
                    Size = new System.Drawing.Size(20, 20)
                };

                BTN.Click += (sender, e) => BTN_Click(sender, e);
                BTN.Click += (sender, e) => BtnSave_Click(sender, e);

                GPEmail.Controls.Add(TB);
                GPEmail.Controls.Add(BTN);

            }
        }

        private void BTN_Click(object sender, EventArgs e)
        {


            Button BTNQ = sender as Button;




            Control BTN = GPEmail.Controls[BTNQ.Name];

            Control TB = GPEmail.Controls[BTNQ.Name.Substring(0, 1) + "TB"];




            GPEmail.Controls.Remove(BTN);
            GPEmail.Controls.Remove(TB);
        }

        private void AddNewEmail()
        {


            TextBox TB = new TextBox
            {
                Text = "",
                Name = MaxHeight + 1 + "TB",
                Location = new System.Drawing.Point(10, 25 * MaxHeight),
                Size = new System.Drawing.Size(300, 20)
            };

            Button BTN = new Button
            {
                Text = "-",
                Name = MaxHeight + 1 + "BTN",
                Location = new System.Drawing.Point(320, 25 * MaxHeight),
                Size = new System.Drawing.Size(20, 20)
            };

            BTN.Click += (sender, e) => BTN_Click(sender, e);
            BTN.Click += (sender, e) => BtnSave_Click(sender, e);

            GPEmail.Controls.Add(TB);
            GPEmail.Controls.Add(BTN);
            MaxHeight++;
        }

        private void BtnAddNewEmail_Click(object sender, EventArgs e)
        {
            AddNewEmail();
        }

        private void UpdateEmail(List<string> OldEmail, List<string> NewEmail)
        {

            for (int i = 0; i < NewEmail.Count; i++)
            {
                bool IsOrNot = false;
                for (int j = 1; j < OldEmail.Count; j++)
                {
                    if (OldEmail[j] == NewEmail[i])
                    {
                        IsOrNot = true;
                    }
                }
                if (IsOrNot == false)
                {
                    SQL.AddEmail(NewEmail[i]);
                }
            }

            for (int i = 1; i < OldEmail.Count; i++)
            {
                bool IsOrNot = false;
                for (int j = 0; j < NewEmail.Count; j++)
                {
                    if (NewEmail[j] == OldEmail[i])
                    {
                        IsOrNot = true;
                    }
                }
                if (IsOrNot == false)
                {
                    SQL.RemoveEmail(OldEmail[i]);
                }

            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            try
            {
                List<string> New = new List<string>();

                foreach (Control GP in GPEmail.Controls)
                {
                    if (GP is TextBox TB)
                    {
                        if (TB.Text != "")
                        {
                            New.Add(TB.Text);
                        }

                    }
                }

                UpdateEmail(Emails, New);
                MessageBox.Show("Wszystkie dane zapisane poprawnie");
            }
            catch
            {
                MessageBox.Show("Problem z zapisaniem danych");
            }




        }
    }
}
