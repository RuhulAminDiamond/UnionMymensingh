using HDMS.Model.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.HR
{
    public partial class frmLeaveApplicationApprovalSetting : Form
    {
        public frmLeaveApplicationApprovalSetting()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LeaveApprovalSetting _lapp = new LeaveApprovalSetting();



           // _lapp.ApprovalLevel_1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
