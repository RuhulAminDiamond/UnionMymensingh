using HDMS.Model;
using HDMS.Model.Diagnostic;
using HDMS.Model.Enums;
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
    public partial class TestGroupEntry : Form
    {
        public TestGroupEntry()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in gvTestGroup.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
            }

            foreach (DataGridViewColumn c in dgvMaster.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int _reportorder = 0;
            int _tokenorder = 0;

            int.TryParse(txtReportOrder.Text, out _reportorder);
            int.TryParse(txtTokenOrder.Text, out _tokenorder);

            if (txtGroupName.Tag == null)
            {
                if (!String.IsNullOrEmpty(txtGroupName.Text))
                {
                    TestGroup _testGroup = new TestGroup();
                    _testGroup.Name = txtGroupName.Text;
                    _testGroup.MasterTestGroupId = ((MasterTestGroup)cmbParent.SelectedItem).MasterTestGroupId;   //TestGroupTypeEnum.None.ToString();
                    _testGroup.SummaryGroup = cmbParent.Text;
                    _testGroup.ReportOrder = _reportorder;
                    _testGroup.TokenOrder = _tokenorder;
                    if (new TestService().SaveTestGroup(_testGroup))
                    {
                        MessageBox.Show("New group created successfully.", "HERP");
                        LoadGroup();
                    }

                }
            }
            else
            {
                TestGroup _tgroup = (TestGroup)txtGroupName.Tag;
                _tgroup.Name = txtGroupName.Text;
                _tgroup.MasterTestGroupId = ((MasterTestGroup)cmbParent.SelectedItem).MasterTestGroupId;
                _tgroup.SummaryGroup = cmbParent.Text;
                _tgroup.ReportOrder = _reportorder;
                _tgroup.TokenOrder = _tokenorder;
                if(new TestService().UpdateTestGroup(_tgroup))
                {
                    MessageBox.Show("Group info updated successfully.", "HERP");
                    LoadGroup();
                }
            }
        }

        private void TestGroupEntry_Load(object sender, EventArgs e)
        {

            LoadMasterGrid();
            LoadGroup();

            PopulateGroupCombo();
        }

        private void PopulateGroupCombo()
        {
            List<MasterTestGroup> mList = new TestService().GetMasterGroups();
            mList.Insert(0, new MasterTestGroup() { MasterTestGroupId = 0, Name = "Select Master Group" });
            cmbParent.DataSource = mList;
            cmbParent.DisplayMember = "Name";
            cmbParent.ValueMember = "MasterTestGroupId";
        }

        private void LoadGroup()
        {
            List<TestGroup> groupList = new TestService().GetAllGroup();
            var bindingList = new BindingList<TestGroup>(groupList);
            var source = new BindingSource(bindingList, null);
            gvTestGroup.AutoGenerateColumns = false;
            gvTestGroup.DataSource = source;
            

        }

        private void gvTestGroup_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtGroupName.Tag = new TestService().GetTestGroupById(Convert.ToInt32(gvTestGroup.Rows[e.RowIndex].Cells["Id"].Value.ToString()));
            txtGroupName.Text = gvTestGroup.Rows[e.RowIndex].Cells["GroupName"].Value.ToString();

            cmbParent.Text= gvTestGroup.Rows[e.RowIndex].Cells["ParentGroup"].Value.ToString();
           
            txtReportOrder.Text= gvTestGroup.Rows[e.RowIndex].Cells["ReportOrder"].Value.ToString();
            txtTokenOrder.Text = gvTestGroup.Rows[e.RowIndex].Cells["TokenOrder"].Value.ToString();

            btnSave.Text = "Update";
            btnCancel.Visible = true;
            btnDelete.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtGroupName.Tag = null;
            txtGroupName.Text = "";
            cmbParent.Text = "";
            txtReportOrder.Text = "";
            txtTokenOrder.Text = "";
            btnSave.Text = "Save";
            btnDelete.Visible = false;
            btnCancel.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Tag != null)
            {
                TestGroup _tGroup = (TestGroup)txtGroupName.Tag;
                List<ReportType> _rTypes = new TestService().GetReportTypesByGroupId(_tGroup.TestGroupId);
                if (_rTypes.Count() > 0)
                {
                    MessageBox.Show("Report types exists under this group. Please delete report type first then try again.");
                }
                else
                {
                    if(new TestService().DeleteTestGroup(_tGroup))
                    {
                        MessageBox.Show("Group name deleted successfully.");

                        txtGroupName.Tag = null;
                        txtGroupName.Text = "";
                        cmbParent.Text = "";
                        txtReportOrder.Text = "";
                        txtTokenOrder.Text = "";
                        btnSave.Text = "Save";
                        btnDelete.Visible = false;
                        btnCancel.Visible = false;

                        LoadGroup();
                    }
                }
            }
        }

        private void btnSaveMaster_Click(object sender, EventArgs e)
        {
            int _reportOrder = 0, _tokenOrder=0;
            int.TryParse(txtMasterReportOrder.Text, out _reportOrder);
            int.TryParse(txtMasterTokenOrder.Text, out _tokenOrder);

            if (txtMasterGroupName.Tag != null)
            {

                MasterTestGroup _mg = (MasterTestGroup)txtMasterGroupName.Tag;

                MasterTestGroup _master = new TestService().GetMasterTestGroupById(_mg.MasterTestGroupId);
                _master.Name = txtMasterGroupName.Text;
                _master.ReportOrder = _reportOrder;
                _master.TokenOrder = _tokenOrder;

                if (new TestService().UpdateMasterGroup(_master))
                {

                    MessageBox.Show("Master group updated successfully.");
                    LoadMasterGrid();
                    PopulateGroupCombo();
                    btnSaveMaster.Text = "Save";
                    btnCancelMaster.Visible = false;
                    btnDeleteMaster.Visible = false;
                    txtMasterGroupName.Text = "";
                    txtMasterReportOrder.Text = "";
                    txtMasterTokenOrder.Text = "";
                    txtMasterGroupName.Tag = null;
                }



               
            }else
            {

                MasterTestGroup _masterTestGroup = new MasterTestGroup();
                _masterTestGroup.Name = txtMasterGroupName.Text;
                _masterTestGroup.ReportOrder = _reportOrder;
                _masterTestGroup.TokenOrder = _tokenOrder;

                if (new TestService().SaveMasterGroup(_masterTestGroup))
                {
                    MessageBox.Show("Master group created successfully.");
                    LoadMasterGrid();
                    PopulateGroupCombo();
                    btnSaveMaster.Text = "Save";
                    btnCancelMaster.Visible = false;
                    btnDeleteMaster.Visible = false;
                    txtMasterGroupName.Text = "";
                    txtMasterReportOrder.Text = "";
                    txtMasterTokenOrder.Text = "";
                    txtMasterGroupName.Tag = null;
                }
            }
        }

        private void LoadMasterGrid()
        {
            List<MasterTestGroup> _listMaster = new TestService().GetMasterGroups();
            dgvMaster.AutoGenerateColumns = false;
            dgvMaster.DataSource = _listMaster;
        }

        private void dgvMaster_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtMasterGroupName.Tag = new TestService().GetMasterTestGroupById(Convert.ToInt32(dgvMaster.Rows[e.RowIndex].Cells["MasterId"].Value.ToString()));
            txtMasterGroupName.Text = dgvMaster.Rows[e.RowIndex].Cells["MasterName"].Value.ToString();

            txtMasterReportOrder.Text = dgvMaster.Rows[e.RowIndex].Cells["MasterReportOrder"].Value.ToString();
            txtMasterTokenOrder.Text = dgvMaster.Rows[e.RowIndex].Cells["MasterTokenOrder"].Value.ToString();

            btnSaveMaster.Text = "Update";
            btnCancelMaster.Visible = true;
            btnDeleteMaster.Visible = true;
        }

        private void btnCancelMaster_Click(object sender, EventArgs e)
        {
            btnSaveMaster.Text = "Save";
            btnCancelMaster.Visible = false;
            btnDeleteMaster.Visible = false;
            txtMasterGroupName.Text = "";
            txtMasterReportOrder.Text = "";
            txtMasterTokenOrder.Text = "";
            txtMasterGroupName.Tag = null;
        }
    }
}
