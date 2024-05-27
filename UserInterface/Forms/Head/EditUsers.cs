using FirefighterControlCenter.DataAccessLayer;
using FirefighterControlCenter.UserInterface.Programs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            
            CBNick.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
            CBNick.Text = "";
            
        }

        private void CBNick_TextChanged(object sender, EventArgs e)
        {
            if (CBNick.Text != "")
            {
                List<string> data = SqlConnector.ReadFirefighters(CBNick.Text);

                if (data.Count == 0) { MessageBox.Show("Brak informacji na temat użytkownika"); }

                #region Wypisywanie danych
                else
                {
                    TBName.Text = data[0];
                    TBLastName.Text = data[1];
                    DTPBirth.Text = data[2];
                    DTPAdmission.Text = data[3];
                    DTPTraining.Text = data[4];
                    DTPMedicalExamsDone.Text = data[5];
                    DTPChamberExams.Text = data[6];
                    CBStatus.Text = data[7];
                    CBKatB.Checked = HelpPrograms.CheckBi(int.Parse(data[8]));
                    CBKatC.Checked = HelpPrograms.CheckBi(int.Parse(data[9]));
                    CBCommander.Checked = HelpPrograms.CheckBi(int.Parse(data[10]));
                    CBHead.Checked = HelpPrograms.CheckBi(int.Parse(data[11]));
                    CBFirstAidCourse.Checked = HelpPrograms.CheckBi(int.Parse(data[12]));
                    CBAirAmbulanceService.Checked = HelpPrograms.CheckBi(int.Parse(data[13]));
                    CBTechnicalRescue.Checked = HelpPrograms.CheckBi(int.Parse(data[14]));
                    CBWaterRescue.Checked = HelpPrograms.CheckBi(int.Parse(data[15]));
                    CBChemicalEcological.Checked = HelpPrograms.CheckBi(int.Parse(data[16]));
                    CBAltitudeRescue.Checked = HelpPrograms.CheckBi(int.Parse(data[17]));
                    CBTechnicalRescue.Checked = HelpPrograms.CheckBi(int.Parse(data[18]));
                    CBHelmsman.Checked = HelpPrograms.CheckBi(int.Parse(data[18]));


                }
                #endregion
            }

        }
    }

    /*SELECT firefighter.name, firefighter.last_name, firefighter.Date_birth, firefighter.Date_admission, training.Date_training, firefighter.Medical_exams_done, training.Chamber_exams_done, firefighter_status.Name, firefighter.Kat_B, firefighter.Kat_C, training.Commander, training.Head, training.First_aid_course, training.air_ambulance_service, training.Technical_rescue, training.Water_rescue, training.Chemical_ecological, training.Altitude_rescue, training.Helsman FROM firefighter, training, firefighter_status where firefighter.Nick = 'Dobrzeniecki D' AND firefighter.ID_firefighter = training.ID_firefighter AND firefighter.ID_Status = firefighter_status.ID;*/
}
