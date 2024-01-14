using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirefighterControlCenter.UserInterface.Forms;
using FirefighterControlCenter.UserInterface.Forms.HeadPanels;

namespace FirefighterControlCenter.UserInterface.Forms
{
    public partial class HeadPanel : Form
    {
        public HeadPanel()
        {
            InitializeComponent();
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            AddUsers frm = new AddUsers();
            frm.Show();
        }

        
    }
}
