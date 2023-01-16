using HDMS.Model.OPD;
using HDMS.Service.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.OPD
{
    public partial class ctrlCreateOPDPackage : UserControl
    {
        public ctrlCreateOPDPackage()
        {
            InitializeComponent();
        }

        private void ctrlCreateOPDPackage_Load(object sender, EventArgs e)
        {
            LoadServiceHeads(0);
        }

        private void LoadServiceHeads(int headId)
        {
            List<OPDServiceGroup> _sgroup = new HospitalService().getOpdServiceGroups();
            _sgroup.Insert(0, new OPDServiceGroup() { GroupId = 0, Name = "Select Service" });
            cmbServiceHead.DataSource = _sgroup;
            cmbServiceHead.DisplayMember = "Name";
            cmbServiceHead.ValueMember = "GroupId";

            if (headId > 0)
            {
                cmbServiceHead.SelectedItem = _sgroup.Find(q => q.GroupId == headId);
            }
        }
    }
}
