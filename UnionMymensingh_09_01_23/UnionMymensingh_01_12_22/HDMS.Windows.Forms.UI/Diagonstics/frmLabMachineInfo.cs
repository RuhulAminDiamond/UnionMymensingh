using HDMS.Model;
using HDMS.Model.Diagnostic.VM;
using HDMS.Service.Diagonstics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmLabMachineInfo : Form
    {
        bool isLoaded = false;

        public frmLabMachineInfo()
        {
            InitializeComponent();
        }

        private void frmLabMachineInfo_Load(object sender, EventArgs e)
        {

            LoadReportTypes(0);
            
            LoadLabMachines();
        }

        private void LoadReportTypes(int _reportTypeId)
        {
            isLoaded = false;
            List<ReportType> _rTypeList = new TestService().GetPathReportTypes();
            _rTypeList.Insert(0, new ReportType() { ReportTypeId = 0, Report_Type = "Select Report Type" });
            cmbReportType.DataSource = _rTypeList;
            cmbReportType.DisplayMember = "Report_Type";
            cmbReportType.ValueMember = "ReportTypeId";

            if (_reportTypeId > 0)
            {
                cmbReportType.SelectedItem = _rTypeList.Find(x => x.ReportTypeId == _reportTypeId);
            }
           
            isLoaded = true;
        }

        private void LoadLabMachines()
        {
            List<VMPathologicalMachine> _pathMachines = new TestService().GetPathLabMachineList();
            FillGridItem(_pathMachines);
        }

        private void FillGridItem(List<VMPathologicalMachine> pathMachines)
        {
            dgMachines.SuspendLayout();
            dgMachines.Rows.Clear();
            foreach(var item in pathMachines)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgMachines, item.Id,item.MachineShortName,item.MachineName,item.Priority,item.ReportType);

                dgMachines.Rows.Add(row);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgMachines_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VMPathologicalMachine item = dgMachines.SelectedRows[0].Tag as VMPathologicalMachine;
            if (item != null)
            {
                txtMachineCode.Text = item.MachineShortName;
                txtReportDescription.Text = item.MachineName;
                LoadReportTypes(item.ReportTypeId);

                txtPriority.Text = item.Priority.ToString();

                txtMachineCode.Tag = item;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMachineCode.Tag != null)
            {
                VMPathologicalMachine mObj = txtMachineCode.Tag as VMPathologicalMachine;
                if (mObj != null)
                {
                    int _priorityId = 0;
                    int.TryParse(txtPriority.Text, out _priorityId);
                    PathologicalMachine pathmObj = new TestService().GetPathologicalMachines(mObj.Id);
                    pathmObj.Priority = _priorityId;
                    new TestService().UpdatePathLabMachine(pathmObj);
                    LoadLabMachines();
                    MessageBox.Show("Update successful");
                }
            }
        }
    }
}
