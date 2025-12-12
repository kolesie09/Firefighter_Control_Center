using FirefighterControlCenter.DataAccessLayer;
using FirefighterControlCenter.UserInterface.Programs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms.Head
{
    public partial class EditUsers : Form
    {
        public EditUsers()
        {
            InitializeComponent();
        }

        private void EditUsers_Load(object sender, EventArgs e)
        {

            CBNick.DataSource = SqlConnector.SelectFirefighterDepartureCard("All", "");
            CBNick.SelectedItem = null;
            TBName.Text = "";
            TBLastName.Text = "";
            DTPBirth.Text = "";
            DTPAdmission.Text = "";
            DTPTraining.Text = "";
            DTPMedicalExamsDone.Text = "";
            DTPChamberExams.Text = "";
            CBStatus.Text = "";
            CBKatB.Checked = false;
            CBKatC.Checked = false;
            CBCommander.Checked = false;
            CBHead.Checked = false;
            CBFirstAidCourse.Checked = false;
            CBAirAmbulanceService.Checked = false;
            CBTechnicalRescue.Checked = false;
            CBWaterRescue.Checked = false;
            CBChemicalEcological.Checked = false;
            CBAltitudeRescue.Checked = false;
            CBTechnicalRescue.Checked = false;
            CBHelmsman.Checked = false;





            CBStatus.DataSource = SqlConnector.ReadStatus();
        }

        private void CBNick_TextChanged(object sender, EventArgs e)
        {
            if (CBNick.Text != "")
            {
                try
                {
                    List<string> data = SqlConnector.ReadFirefighters(CBNick.Text);



                    if (data.Count == 0) { MessageBox.Show("Brak informacji na temat użytkownika"); }

                    #region Wypisywanie danych
                    else
                    {
                        #region Czyszczenie
                        TBName.Text = "";
                        TBLastName.Text = "";
                        DTPBirth.Text = "";
                        DTPAdmission.Text = "";
                        DTPTraining.Text = "";
                        DTPMedicalExamsDone.Text = "";
                        DTPChamberExams.Text = "";
                        CBStatus.Text = "";
                        CBKatB.Checked = false;
                        CBKatC.Checked = false;
                        CBCommander.Checked = false;
                        CBHead.Checked = false;
                        CBFirstAidCourse.Checked = false;
                        CBAirAmbulanceService.Checked = false;
                        CBTechnicalRescue.Checked = false;
                        CBWaterRescue.Checked = false;
                        CBChemicalEcological.Checked = false;
                        CBAltitudeRescue.Checked = false;
                        CBTechnicalRescue.Checked = false;
                        CBHelmsman.Checked = false;
                        #endregion
                        TBName.Text = data[0];
                        TBLastName.Text = data[1];
                        DTPBirth.Text = data[2];
                        DTPAdmission.Text = data[3];
                        DTPMedicalExamsDone.Text = data[4];
                        CBStatus.Text = data[5];
                        CBKatB.Checked = HelpPrograms.IfBool(data[6]);
                        CBKatC.Checked = HelpPrograms.IfBool(data[7]);
                        DTPTraining.Text = HelpPrograms.IfString(data[8]);
                        DTPChamberExams.Text = HelpPrograms.IfString(data[9]);
                        CBCommander.Checked = HelpPrograms.IfBool(data[10]);
                        CBHead.Checked = HelpPrograms.IfBool(data[11]);
                        CBFirstAidCourse.Checked = HelpPrograms.IfBool(data[12]);
                        CBAirAmbulanceService.Checked = HelpPrograms.IfBool(data[13]);
                        CBTechnicalRescue.Checked = HelpPrograms.IfBool(data[14]);
                        CBWaterRescue.Checked = HelpPrograms.IfBool(data[15]);
                        CBChemicalEcological.Checked = HelpPrograms.IfBool(data[16]);
                        CBAltitudeRescue.Checked = HelpPrograms.IfBool(data[17]);
                        CBHelmsman.Checked = HelpPrograms.IfBool(data[18]);


                    }
                    #endregion
                }
                catch
                {
                    MessageBox.Show("Brak informacji na temat tej osoby");
                }
            }

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
                    DTPChamberExams.Format = DateTimePickerFormat.Custom;
                    DTPChamberExams.CustomFormat = "yyyy-MM-dd";
                    data.Add((CBStatus.SelectedIndex + 1).ToString()); // 7 - Dodawanie statusu strażaka
                    data.Add(HelpPrograms.Check(CBKatB.Checked)); // 8 - Dodawanie posiadania kat.B
                    data.Add(HelpPrograms.Check(CBKatC.Checked)); // 9 - Dodawanie posiadania kat.C
                    DTPTraining.Format = DateTimePickerFormat.Custom;
                    DTPTraining.CustomFormat = "yyyy-MM-dd";
                    data.Add(DTPTraining.Text); // 10 - Dodawanie daty szkoleń
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
                    data.Add(CBNick.Text);




                    try
                    {
                        SqlConnector.UpdateFirefighter(data);
                        MessageBox.Show("Prawidłowo zapisano zmiany");
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
