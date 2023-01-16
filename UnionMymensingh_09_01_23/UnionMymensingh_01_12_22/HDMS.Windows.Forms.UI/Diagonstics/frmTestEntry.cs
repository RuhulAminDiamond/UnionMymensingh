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
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.ViewModel;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmTestEntry : Form
    {
        bool isLoaded = false;
        int _MainTestId = 0;
        public frmTestEntry()
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

            foreach (DataGridViewColumn col in dgvTestSubItem.Columns)
            {
                col.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgvTestSubItem.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }

        private IList<VMTestSubItem> _SubItems;
        private void frmTestEntry_Load(object sender, EventArgs e)
        {
            isLoaded = false;
            _SubItems = new List<VMTestSubItem>();

            ctrlReportTypeSearch.Location = new Point(txtReportType.Location.X,txtReportType.Location.Y+txtReportType.Height);
            ctrlReportTypeSearch.ItemSelected += CtrlReportTypeSearch_ItemSelected;
           
            ctrlTestGroupSearch.Location= new Point(txtGroup.Location.X, txtGroup.Location.Y + txtGroup.Height);
            ctrlTestGroupSearch.ItemSelected += CtrlTestGroupSearch_ItemSelected;

            ctlTestSearch.Location = new Point(txtTestCode.Location.X, txtTestCode.Location.Y + txtTestCode.Height);
            ctlTestSearch.ItemSelected += ctlTestSearch_ItemSelected;


           

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }


            //LoadTestsByGroup();

            isLoaded = true;

        }

        private void CtrlTestGroupSearch_ItemSelected(SearchResultListControl<TestGroup> sender, TestGroup item)
        {
            txtGroup.Text = item.Name;
            txtGroup.Tag = item;
            sender.Visible = false;
            int _reportTypeId = 0;
            if (txtReportType.Tag != null)
            {
                ReportType _rType = txtReportType.Tag as ReportType;
                _reportTypeId = _rType.ReportTypeId;
            }
            else
            {
                ReportType _rt = new TestService().GetReportTypeByGroupId(item.TestGroupId);
                txtReportType.Tag = _rt;
                _reportTypeId = _rt.ReportTypeId;
            }

            LoadTestsByGroupAndReportType(_reportTypeId, item.TestGroupId);

        }

        private void LoadTestsByGroupAndReportType(int reportTypeId, int testGroupId)
        {
            List<TestItem> _testLists = new TestService().GetAllTestByReportTypeAndGroup(reportTypeId, testGroupId);
            FillTestItemGrid(_testLists);
        
        }

        private void CtrlReportTypeSearch_ItemSelected(SearchResultListControl<ReportType> sender, ReportType item)
        {
            txtReportType.Text = item.Report_Type;
            txtReportType.Tag = item;
            LoadTestsByReportType(item.ReportTypeId);
            sender.Visible = false;
        }

        private void LoadTestsByReportType(int reportTypeId)
        {
            List<TestItem> _testList = new TestService().GetAllTestByReportTypeId(reportTypeId);
            FillTestItemGrid(_testList);
        }

        private void ctlTestSearch_ItemSelected(SearchResultListControl<TestItem> sender, TestItem item)
        {
            txtTestCode.Text = item.TestId.ToString();
            txtTestCode.Tag = item;
            //txtTestCode.Focus();
            sender.Visible = false;
            ctlTestSearch.Visible = false;
            txtQty.Text = "1";
            txtPkgRate.Text = item.Rate.ToString();
            txtPkgRate.Focus();
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool IsGluTest = false;
           
            if (radYes.Checked)
            {
                IsGluTest = true;
            }
            else
            {
                IsGluTest = false;
            }

            double pkgDiscount = 0;
            double.TryParse(txtPkgDiscount.Text, out pkgDiscount);

            double _mediacomm = 0;
            double.TryParse(txtMediaComm.Text, out _mediacomm);

            double _ReferralComm;
            double.TryParse(txtReferralComm.Text, out _ReferralComm);
            
            int reportOrder=0;
            int _groupId = 0;

            if (txtGroup.Tag != null)
            {
                TestGroup _group = txtGroup.Tag as TestGroup;
                _groupId = _group.TestGroupId;
            }

            int _reportTypeId = 0;
            if (txtReportType.Tag != null)
            {
                ReportType _rType = txtReportType.Tag as ReportType;
                _reportTypeId = _rType.ReportTypeId;
            }

            if (_reportTypeId == 0)
            {
                MessageBox.Show("Report type not found."); return;
            }

            int _rate = 0;
            int.TryParse(txtCost.Text, out _rate);

            int _testCode = 0;
            int.TryParse(txtCodeNo.Text, out _testCode);

            int _processTime = 0;
            int.TryParse(txtProcessDays.Text, out _processTime);





            if (_rate <= 0)
            {
                MessageBox.Show("Rate not set. Plz. check it and try again.");
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Test name blank. Plz. check it and try again.");
            }

            if (_groupId == 0)
            {
                MessageBox.Show("Select group then try again."); return;
            }

            if (txtName.Tag != null)
            {
                List<TestItem> _ItemList = new TestService().GetAllTestItemByTestCode(_testCode);

                if (_ItemList.Count() > 1)
                {
                    MessageBox.Show("Duplicate test code found. Plz. change test code and try again.");
                    return;
                }

                TestItem _Item = (TestItem)txtName.Tag;
                if(_Item.TestCode != _testCode)
                {
                    List<TestSubItem> _testSubItem = new TestService().GetSubTestListByTestId(_Item.TestId);
                    if (_testSubItem.Count() > 0)
                    {
                        new TestService().UpdateSubItemTestCode(_Item.TestId, _testCode);
                    }

                }

                _Item.TestCode = _testCode;
                _Item.Name = txtName.Text;
                _Item.ReportTypeId = _reportTypeId;
                _Item.Rate = Convert.ToInt32(txtCost.Text);
                _Item.Specimen = cmbSpecimen.Text;
                _Item.ReportOrder = reportOrder;
                _Item.Comments = txtComments.Text;
                _Item.ShortName = txtShortName.Text;
                _Item.DayNeededForReportDelivery = _processTime;
                _Item.DeliveryTimeOnReportDay = Utils.GetServerDateAndTime();
                _Item.IsGLUTest = IsGluTest;
                _Item.GLUIdentityExt = txtGLUExt.Text;
                _Item.IsPackage = radPkgYes.Checked;
                _Item.PackageDiscount = pkgDiscount;
                _Item.ReferralCommission = _ReferralComm;
                _Item.MediaComm = _mediacomm;
                new TestService().UpdateTestItem(_Item);
                MessageBox.Show("Test info updated.", "HERP");
                txtName.Tag = null;
                btnSave.Text = "Add";
            }
            else
            {
                TestItem _Item = new TestService().GetTestItemByTestCode(_testCode);

                if (_Item != null)
                {
                    MessageBox.Show("Test code already used. Plz. change test code and try again.");
                    return;
                }

                TestItem _tItem = new TestItem();
                _tItem.TestCode = _testCode;
                _tItem.Name = txtName.Text;
                _tItem.ReportTypeId = _reportTypeId;
                _tItem.Rate = Convert.ToDouble(txtCost.Text);
                _tItem.Specimen = cmbSpecimen.Text;
                _tItem.ReportOrder = reportOrder;
                _tItem.Comments = txtComments.Text;
                _tItem.ShortName = txtShortName.Text;
                _tItem.DayNeededForReportDelivery = _processTime;
                _tItem.DeliveryTimeOnReportDay = Utils.GetServerDateAndTime();
                _tItem.IsGLUTest = IsGluTest;
                _tItem.GLUIdentityExt = txtGLUExt.Text;
                _tItem.IsPackage = radPkgYes.Checked;
                _tItem.PackageDiscount = pkgDiscount;
                _tItem.ReferralCommission = _ReferralComm;
                _tItem.MediaComm = _mediacomm;
                if (new TestService().SaveTest(_tItem))
                {
                    MessageBox.Show("New test created.", "HERP");

                }
            }

            txtCost.Text = "";
            txtPkgDiscount.Text = "";
            txtMediaComm.Text = "";
            txtReferralComm.Text = "";
            LoadTestsByGroup();

        }

        private int GetReportType()
        {

            int _reportTypeId = 0;
           // int.TryParse(txtReportTypeId.Text, out _reportTypeId);
            return _reportTypeId;
            // return Convert.ToInt32(cmbReportType.SelectedValue);
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void LoadTestsByGroup()
        {
           
        }

        private void FillTestItemGrid(List<TestItem> testList)
        {
            gvTestlist.SuspendLayout();
            gvTestlist.Rows.Clear();
            foreach (TestItem item in testList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = item;
                row.DefaultCellStyle.BackColor = Color.Yellow;
                row.CreateCells(gvTestlist, item.TestId, item.TestCode, item.Name, item.Specimen, item.Rate,item.MediaComm,item.ReferralCommission, item.IsGLUTest,item.GLUIdentityExt, false);
                gvTestlist.Rows.Add(row);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete this test?", "Confirmation", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                if (txtName.Tag != null)
                {

                    TestItem _tItem = (TestItem)txtName.Tag;
                    List<ReportDefination> _rdefination = new TestService().GetTestReportDefinationByTestId(_tItem.TestId).ToList();

                    if (_rdefination.Count() > 0)
                    {
                        MessageBox.Show("Data in report defination exits under this test. Please delete report defination first and try again.");
                        return;
                    }

                    foreach (DataGridViewRow item in this.gvTestlist.SelectedRows)
                    {
                        gvTestlist.Rows.RemoveAt(item.Index);
                        new TestService().DeleteTestItem((TestItem)txtName.Tag);
                        MessageBox.Show("Test deleted.", "HERP");
                    }
                }
                else
                {
                    MessageBox.Show("No test selected for delete.","HERP");
                }
            }
        }

        private void gvTestlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtName.Tag = new TestService().GetTestItemById(Convert.ToInt32(gvTestlist.Rows[e.RowIndex].Cells["Id"].Value.ToString()));
            btnSave.Text = "Update";
            if (txtName.Tag != null)
            {
                _SubItems = new List<VMTestSubItem>();

                TestItem _testItem = (TestItem)txtName.Tag;
                //cmbGroup.SelectedIndex = _testItem.GroupId-3; //As Test Group Id starts from 3

                txtCodeNo.Text = _testItem.TestCode.ToString();
                txtName.Text = _testItem.Name;
                txtCost.Text = _testItem.Rate.ToString();
                txtPkgDiscount.Text = _testItem.PackageDiscount.ToString();
                txtProcessDays.Text = _testItem.DayNeededForReportDelivery.ToString();
                cmbSpecimen.Text = _testItem.Specimen;
                txtReferralComm.Text = _testItem.ReferralCommission.ToString();
                txtMediaComm.Text = _testItem.MediaComm.ToString();

                txtShortName.Text = _testItem.ShortName;

                ReportType _rType = new TestService().GetReportTypesById(_testItem.ReportTypeId);
                txtReportType.Tag = _rType;
                txtReportType.Text = _rType.Report_Type;

                TestGroup _tg = new TestService().GetTestGroupById(_rType.TestGroupId);
                txtGroup.Tag = _tg;
                txtGroup.Text = _tg.Name;

                if (_testItem.IsPackage)
                {
                    radPkgYes.Checked = true;
                }
                else
                {
                    radPkgNo.Checked = true;
                }

                LoadSubTestItems(_testItem.TestId);

            }
           
        }

        private void LoadSubTestItems(int _testId)
        {
            _MainTestId = _testId;

            List<TestSubItem> ListTestSubItems = new TestService().GetSubTestListByTestId(_testId);
            new TestService().PopulateSubTestItemData(_SubItems, ListTestSubItems, null,0,1,0,radPkgYes.Checked);

            FillTestGridForPreviousEntry();
          
        }

        private void btnSaveSubItem_Click(object sender, EventArgs e)
        {
            List<TestSubItem> _sItemList = new List<TestSubItem>();
            foreach (VMTestSubItem item in _SubItems)
            {
                if (item.AdditionType.ToLower() == "new") { 
                    TestSubItem _sitem = new TestSubItem();
                    _sitem.MainTestId = item.MainTestId;
                    _sitem.TestId = item.TestId;
                    _sitem.Name = item.Name;
                    _sitem.Rate = item.Rate;
                    _sitem.Qty = item.Qty;
                    _sitem.ReportTypeId = item.ReportTypeId;
                    _sitem.SC = item.SC;
                    _sitem.Specimen = item.Specimen;
                    _sitem.Vatable = false;
                    _sitem.Exclusive = false;

                    _sItemList.Add(_sitem);
                }

            }

            if (_sItemList.Count() == 0)
            {
                MessageBox.Show("No new entry found to save");
            }else
            {
                if (new TestService().SaveSubItem(_sItemList))
                {
                    MessageBox.Show("Information saved successfully.");
                    dgvTestSubItem.Rows.Clear();
                }
            }

        }

        private void txtTestCode_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlTestSearch.Visible = true;
                ctlTestSearch.txtSearch.Text = "";
                ctlTestSearch.LoadData();
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {

                txtQty.Text = "1";
                txtQty.Focus();
            }
        }

        private void FillTestGridForPreviousEntry()
        {

            dgvTestSubItem.SuspendLayout();
            dgvTestSubItem.Rows.Clear();
            foreach (VMTestSubItem item in _SubItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = item;
                row.DefaultCellStyle.BackColor = Color.Yellow;
                row.CreateCells(dgvTestSubItem, item.MainTestId, item.TestId, item.Name,  item.Rate, item.Qty, false);
                dgvTestSubItem.Rows.Add(row);
            }
        }

        private void HideAllDefaultHidden()
        {
           ctlTestSearch.Visible=false;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void FillTestGrid()
        {
            dgvTestSubItem.SuspendLayout();
            dgvTestSubItem.Rows.Clear();
            foreach (VMTestSubItem item in _SubItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = item;
                if (item.AdditionType.ToLower() == "old")
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
              
                row.CreateCells(dgvTestSubItem, item.MainTestId, item.TestId, item.Name, item.Rate, item.Qty, false);
                dgvTestSubItem.Rows.Add(row);
            }
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Tag = null;
            txtName.Text = "";
            txtCost.Text = "";
            txtComments.Text = "";

            txtGLUExt.Text = "";
            radYes.Checked = false;
            radNo.Checked = false;
           
            cmdDelete.Visible = false;
            btnCancel.Visible = false;
            btnSave.Text = "Save";
        }

        private void txtCodeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtName.Focus();
            }

        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbSpecimen.Focus();
            }
        }

        private void cmbSpecimen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCost.Focus();
            }
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtComments.Focus();
            }
        }

        private void txtComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void txtPkgRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int _Qty = 1;
                int.TryParse(txtQty.Text, out _Qty);
                double _rate = 0;
                double.TryParse(txtPkgRate.Text, out _rate);

                if (e.KeyChar == (char)Keys.Enter)
                {
                    ctlTestSearch.Visible = false;
                    new TestService().PopulateSubTestItemData(_SubItems, null, txtTestCode.Tag as TestItem, _MainTestId, _Qty, _rate,radPkgYes.Checked);
                    FillTestGrid();
                    txtQty.Text = "";
                    txtTestCode.Focus();
                }
            }
        }

        private void txtSearchTest_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchTest.Text != "Search Test")
            {
                List<TestItem> _testList = new TestService().GetAllFilteredPathologicalTest(txtSearchTest.Text);
                FillTestItemGrid(_testList);
            }
        }

        private void txtReportType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlReportTypeSearch.Visible = true;
                ctrlReportTypeSearch.LoadData();
            }
        }

        private void txtGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlTestGroupSearch.Visible = true;
                ctrlTestGroupSearch.LoadData();
            }
        }
    }
}
