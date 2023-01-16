using HDMS.Model;
using HDMS.Model.Diagnostic;
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
    public partial class frmSetSampleCollectionRole : Form
    {

        bool isLoaded = false;

        public frmSetSampleCollectionRole()
        {
            InitializeComponent();

            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in gvTestlist.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            gvTestlist.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

          
        }

        private IList<VMSampleCollectionRole> _SCRole;
        private void frmSetSampleCollectionRole_Load(object sender, EventArgs e)
        {

            _SCRole = new List<VMSampleCollectionRole>();
            List<TestGroup> _testGroup = new TestService().GetAllGroup();
            _testGroup.Insert(0, new TestGroup() { TestGroupId = 0, Name = "Select Group" });
            cmbGroup.DataSource = _testGroup;
            cmbGroup.DisplayMember = "Name";
            cmbGroup.ValueMember = "TestGroupId";

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }


           // LoadTestsByGroup();

            isLoaded = true;

        }

        private void LoadTestsByGroup()
        {
            if (isLoaded)
            {
                List<TestItem> testList = new TestService().GetAllTestByReportTypeId(Convert.ToInt32(cmbReportType.SelectedValue));
                var bindingList = new BindingList<TestItem>(testList);
                var source = new BindingSource(bindingList, null);
                gvTestlist.AutoGenerateColumns = false;
                gvTestlist.DataSource = source;
                AddToStatusToGrid();
            }
        }


        private void AddToStatusToGrid()
        {

            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();

            dgvCmb.ValueType = typeof(bool);
            dgvCmb.Name = "Chk";
            dgvCmb.HeaderText = "Check for Single Tube";
            dgvCmb.Width = 200;
            gvTestlist.Columns.Add(dgvCmb);

           // List<TestsCost> _collectedTest = new PatientService().GetSampleCollectedTests(_pId);

            foreach (DataGridViewRow row in gvTestlist.Rows)
            {
                TestItem _Item = new TestService().GetTestItemById(Convert.ToInt32(row.Cells["Id"].Value));
                if (_Item.CollectionTypeId == 1)
                {
                    row.Cells["Chk"].Value = true;
                }
                else
                {
                    row.Cells["Chk"].Value = false;
                }
                

            }
        }

        private void ctrl_LostFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //if (ctrl.Tag is Color)
            ctrl.BackColor = Color.White;
        }

        private void ctrl_GotFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.NavajoWhite;
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                cmbReportType.Tag = new TestService().GetReportTypesById(Convert.ToInt32(cmbReportType.SelectedValue));
                txtReportTypeId.Text = cmbReportType.SelectedValue.ToString();
                LoadTestsByGroup();
            }
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                isLoaded = false;
                List<ReportType> _rTypeList = new TestService().GetReportTypesByGroupId(Convert.ToInt32(cmbGroup.SelectedValue));
                _rTypeList.Insert(0, new ReportType() { ReportTypeId = 0, Report_Type = "Select Report Type" });
                cmbReportType.DataSource = _rTypeList;
                cmbReportType.DisplayMember = "Report_Type";
                cmbReportType.ValueMember = "ReportTypeId";
                txtGroupId.Text = cmbGroup.SelectedValue.ToString();
                isLoaded = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            List<TestItem> _tList = new List<TestItem>();
            foreach (DataGridViewRow row in gvTestlist.Rows)
            {
                if ((bool)row.Cells["Chk"].Value == true)
                {
                 
                    
                        TestItem _tItem = new TestItem();
                       _tItem.TestId = Convert.ToInt32(row.Cells["Id"].Value);
                       _tItem.CollectionTypeId = 1; // 1 means this sample required individual single tube

                        _tList.Add(_tItem);
                }
            }

            if (!String.IsNullOrEmpty(txtReportTypeId.Text))
            {
                int _reportTypeId = 0;
                int.TryParse(txtReportTypeId.Text, out _reportTypeId);
                if (new TestService().UpdateTestItemCollectionType(_tList, _reportTypeId))
                {
                    MessageBox.Show("Information saved successfully.");
                }
            }


         }

        private void gvTestlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtReportTypeId.Tag = new TestService().GetTestItemById(Convert.ToInt32(gvTestlist.Rows[e.RowIndex].Cells["Id"].Value.ToString()));
            
            if (txtReportTypeId.Tag != null)
            {
                TestItem _testItem = (TestItem)txtReportTypeId.Tag;
                LoadSampleCollectionSettings(_testItem.TestId);

            }
        }

        private void LoadSampleCollectionSettings(int testId)
        {
            int _MainTestId = testId;

            List<SampleCollectionSetting> ListSCRole = new TestService().GetSampleCollectionSetting(testId);
            new TestService().PopulateSampleCollectionSettingData(_SCRole, ListSCRole, null, 0, 1);

            FillCollectionSettingGrid();
        }

        private void FillCollectionSettingGrid()
        {
            dgvSCS.SuspendLayout();
            dgvSCS.Rows.Clear();
            foreach (VMSampleCollectionRole item in _SCRole)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = item;
                row.DefaultCellStyle.BackColor = Color.Yellow;
                row.CreateCells(dgvSCS, item.MainTestId, item.SerialNo, item.Description,  false);
                dgvSCS.Rows.Add(row);
            }
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtReportTypeId.Tag != null)
                {
                    VMSampleCollectionRole _SCS = new VMSampleCollectionRole();
                    _SCS.MainTestId = ((TestItem)txtReportTypeId.Tag).TestId;
                    _SCS.SerialNo = _SCRole.Count() + 1;
                    _SCS.Description = txtDescription.Text;

                    _SCRole.Add(_SCS);

                    FillCollectionSettingGrid();
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            List<SampleCollectionSetting> _sItemList = new List<SampleCollectionSetting>();
            foreach (VMSampleCollectionRole item in _SCRole)
            {
               
                    SampleCollectionSetting _sitem = new SampleCollectionSetting();
                    _sitem.MainTestId = item.MainTestId;
                    _sitem.SerialNo = item.SerialNo;
                    _sitem.Description = item.Description;
                   

                    _sItemList.Add(_sitem);
                

            }

            if (_sItemList.Count() == 0)
            {
                MessageBox.Show("No new entry found to save");
            }
            else
            {
                if (new TestService().SaveSampleCollectionSetting(_sItemList))
                {
                    MessageBox.Show("Information saved successfully.");
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
