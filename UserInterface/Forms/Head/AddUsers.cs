using FirefighterControlCenter.DataAccessLayer;
using FirefighterControlCenter.UserInterface.Programs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms.Head
{
    public partial class AddUsers : Form
    {
        public AddUsers()
        {
            InitializeComponent();
        }

        private void AddUsers_Load(object sender, EventArgs e)
        {
            CBStatus.DataSource = SqlConnector.ReadStatus();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (HelpPrograms.CheckingAddUser(TBName.Text, TBLastName.Text, CBStatus.Text) == 1)
            {
                List<string> data = new List<string>();
                try
                {
                    data.Add(TBLastName.Text + " " + TBName.Text.Substring(0, 1)); // 0 - Dodawanie Nicku
                    data.Add(TBName.Text); // 1 - Dodawanie Imienia
                    data.Add(TBLastName.Text); // 2 - Dodawanie nazwiska
                    DTPBirth.Format = DateTimePickerFormat.Custom;
                    DTPBirth.CustomFormat = "yyyy-MM-dd";
                    data.Add(DTPBirth.Text); // 3 - Dodawanie daty urodzin
                    DTPAdmission.Format = DateTimePickerFormat.Custom;
                    DTPAdmission.CustomFormat = "yyyy-MM-dd";
                    data.Add(DTPAdmission.Text); // 4 - Dodawanie daty wstąpienia    
                    DTPMedicalExamsDone.Format = DateTimePickerFormat.Custom;
                    DTPMedicalExamsDone.CustomFormat = "yyyy-MM-dd";
                    data.Add(DTPMedicalExamsDone.Text); // 5 - Dodawanie daty badania lekarskiego
                    data.Add(HelpPrograms.NextExams(DTPMedicalExamsDone.Text, 3)); // 6 - Dodawanie daty następnego badania lekarskiego
                    data.Add((CBStatus.SelectedIndex + 1).ToString()); // 7 - Dodawanie statusu strażaka
                    data.Add(HelpPrograms.Check(CBKatB.Checked)); // 8 - Dodawanie posiadania kat.B
                    data.Add(HelpPrograms.Check(CBKatC.Checked)); // 9 - Dodawanie posiadania kat.C
                    DTPTraining.Format = DateTimePickerFormat.Custom;
                    DTPTraining.CustomFormat = "yyyy-MM-dd";
                    data.Add(DTPTraining.Text); // 10 - Dodawanie daty szkoleń
                    DTPChamberExams.Format = DateTimePickerFormat.Custom;
                    DTPChamberExams.CustomFormat = "yyyy-MM-dd";
                    data.Add(DTPChamberExams.Text); // 11 - Dodawanie daty zaliczenia komory
                    data.Add(HelpPrograms.NextExams(DTPChamberExams.Text, 5)); // 12 - Dodawanie daty następnego zaliczenia komory
                    data.Add(HelpPrograms.Check(CBHelmsman.Checked)); // 13 - Dodawanie posiadania patentu sternika
                    data.Add(HelpPrograms.Check(CBFirstAidCourse.Checked)); // 14 - Dodawanie posiadania kwalifikowanej pierwszej pomocy 
                    data.Add(HelpPrograms.Check(CBWaterRescue.Checked)); // 15 - Dodawanie posiadania ratownictwa wodnego
                    data.Add(HelpPrograms.Check(CBChemicalEcological.Checked)); // 16 - Dodawanie posiadania ratownictwa chemiczno-ekologicznego
                    data.Add(HelpPrograms.Check(CBCommander.Checked)); // 17 - Dodawanie posiadania szkolenia dowódcy
                    data.Add(HelpPrograms.Check(CBHead.Checked)); // 18 - Dodawanie posiadania szkolenia naczelnika
                    data.Add(HelpPrograms.Check(CBAltitudeRescue.Checked)); // 19 - Dodawanie posiadania ratownictwo wysokościowe
                    data.Add(HelpPrograms.Check(CBAirAmbulanceService.Checked)); // 20 - Dodawanie posiadania szkolenia LPR
                    data.Add(HelpPrograms.Check(CBTechnicalRescue.Checked)); // 21 - Dodawanie posiadania ratownictwa technicznego



                    try
                    {
                        SqlConnector.InsertAddNewFirefighter(data);
                        MessageBox.Show("Prawidłowo zapisano nowego użytkownika");
                    }
                    catch
                    {
                        MessageBox.Show("Problem z zapisem danych do bazy danych");
                    }

                }
                catch
                {
                    MessageBox.Show("Problem z zebraniem danych");
                }




            }



        }


    }
}
