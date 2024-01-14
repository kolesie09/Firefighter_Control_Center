using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirefighterControlCenter.UserInterface.Programs;
using UserInterface;

namespace FirefighterControlCenter.UserInterface.Forms.HeadPanels
{
    public partial class AddUsers : Form
    {
        public AddUsers()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {

            string Nick = HelpPrograms.CreateNick(TBName.Text,TBLastName.Text);
            string Name = TBName.Text;
            string LastName = TBLastName.Text;
            DTPBirth.Format = DateTimePickerFormat.Custom;
            DTPBirth.CustomFormat = "yyyy-MM-dd";
            string DateBirth = DTPBirth.Text;
            DTPAdmission.Format = DateTimePickerFormat.Custom;
            DTPAdmission.CustomFormat = "yyyy-MM-dd";
            string DateAdmission = DTPAdmission.Text;
            DTPTraining.Format = DateTimePickerFormat.Custom;
            DTPTraining.CustomFormat = "yyyy-MM-dd";
            string DateTraining = DTPTraining.Text;
            DTPMedicalExamsDone.Format = DateTimePickerFormat.Custom;
            DTPMedicalExamsDone.CustomFormat = "yyyy-MM-dd";
            string DateMedicalExamsDone = DTPMedicalExamsDone.Text;
            string NextMedicalExams = HelpPrograms.NextExams(DateMedicalExamsDone, 3);
            DTPChamberExams.Format = DateTimePickerFormat.Custom;
            DTPChamberExams.CustomFormat = "yyyy-MM-dd";
            string ChamberExams = DTPChamberExams.Text;
            string NextChamberExams = HelpPrograms.NextExams(ChamberExams, 5);
            string Status = "1";
            if(CBKatB.Checked == true) { string KatB = "1"; }else { string KatB = "0"; }
            if(CBKatC.Checked == true) { string KatC = "1"; }else { string KatC = "0"; }
            if(CBFirstAidCourse.Checked == true) { string FirstAidCourse = "1"; }else { string FirstAidCourse = "0"; }
            if(CBTechnicalRescue.Checked == true) { string TechnicalRescue = "1"; }else { string TechnicalRescue = "0"; }
            if(CBWaterRescue.Checked == true) { string WaterRescue = "1"; }else { string WaterRescue = "0"; }
            if(CBChemicalEcological.Checked == true) { string ChemicalEcological = "1"; }else { string ChemicalEcological = "0"; }
            if(CBCommander.Checked == true) { string Commander = "1"; }else { string Commander = "0"; }
            if(CBHead.Checked == true) { string Head = "1"; }else { string Head = "0"; }
            if(CBAltitudeRescue.Checked == true) { string AltitudeRescue = "1"; }else { string AltitudeRescue = "0"; }
            if(CBAirAmbulanceService.Checked == true) { string AirAmbulanceService = "1"; }else { string AirAmbulanceService = "0"; }

        }
    }
}
