using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirefighterControlCenter.DataAccessLayer;
using FirefighterControlCenter.UserInterface.Programs;
using UserInterface;

namespace FirefighterControlCenter.UserInterface.Forms.HeadPanels
{
    public partial class AddUsers : Form
    {

        

        string Nick;
        string Name;
        string LastName;
        string DateBirth;
        string DateAdmission;
        string DateTraining;
        string DateMedicalExamsDone;
        string NextMedicalExams;
        string ChamberExams;
        string NextChamberExams;
        string Status;
        string FirstAidCourse;
        string KatB;
        string KatC;
        string TechnicalRescue;
        string WaterRescue;
        string ChemicalEcological;
        string Commander;
        string Head;
        string AltitudeRescue;
        string AirAmbulanceService;




        public AddUsers()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if(HelpPrograms.CheckingAddUser(TBName.Text,TBLastName.Text, CBStatus.Text) == 1)
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
                    DTPTraining.Format = DateTimePickerFormat.Custom;
                    DTPTraining.CustomFormat = "yyyy-MM-dd";
                    data.Add(DTPTraining.Text); // 5 - Dodawanie daty szkoleń
                    DTPMedicalExamsDone.Format = DateTimePickerFormat.Custom;
                    DTPMedicalExamsDone.CustomFormat = "yyyy-MM-dd";
                    data.Add(DTPMedicalExamsDone.Text); // 6 - Dodawanie daty badania lekarskiego
                    data.Add(HelpPrograms.NextExams(DTPMedicalExamsDone.Text, 3)); // 7 - Dodawanie daty następnego badania lekarskiego
                    DTPChamberExams.Format = DateTimePickerFormat.Custom;
                    DTPChamberExams.CustomFormat = "yyyy-MM-dd";
                    data.Add(DTPChamberExams.Text); // 8 - Dodawanie daty zaliczenia komory
                    data.Add(HelpPrograms.NextExams(DTPChamberExams.Text, 5)); // 9 - Dodawanie daty następnego zaliczenia komory
                    data.Add(CBStatus.Text); // 10 - Dodawanie statusu strażaka
                    data.Add(HelpPrograms.Check(CBKatB.Checked)); // 11 - Dodawanie posiadania kat.B
                    data.Add(HelpPrograms.Check(CBKatC.Checked)); // 12 - Dodawanie posiadania kat.C
                    data.Add(HelpPrograms.Check(CBHelmsman.Checked)); // 13 - Dodawanie posiadania patentu sternika
                    data.Add(HelpPrograms.Check(CBFirstAidCourse.Checked)); // 14 - Dodawanie posiadania kwalifikowanej pierwszej pomocy 
                    data.Add(HelpPrograms.Check(CBTechnicalRescue.Checked)); // 15 - Dodawanie posiadania ratownictwa technicznego
                    data.Add(HelpPrograms.Check(CBWaterRescue.Checked)); // 16 - Dodawanie posiadania ratownictwa wodnego
                    data.Add(HelpPrograms.Check(CBChemicalEcological.Checked)); // 17 - Dodawanie posiadania ratownictwa chemiczno-ekologicznego
                    data.Add(HelpPrograms.Check(CBCommander.Checked)); // 18 - Dodawanie posiadania szkolenia dowódcy
                    data.Add(HelpPrograms.Check(CBHead.Checked)); // 19 - Dodawanie posiadania szkolenia naczelnika
                    data.Add(HelpPrograms.Check(CBAltitudeRescue.Checked)); // 20 - Dodawanie posiadania ratownictwo wysokościowe
                    data.Add(HelpPrograms.Check(CBAirAmbulanceService.Checked)); // 21 - Dodawanie posiadania szkolenia LPR


                    try
                    {
                        SqlConnector.InsertAddNewFirefighter(data);
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
