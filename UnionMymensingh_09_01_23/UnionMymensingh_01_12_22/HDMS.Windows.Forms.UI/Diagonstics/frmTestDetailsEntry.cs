using HDMS.Model;
using HDMS.Model.Diagnostic;
using HDMS.Model.ViewModel;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Controls;
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
    public partial class frmTestDetailsEntry : Form
    {
        bool isLoaded = false;
        bool unlocked = true;


        public frmTestDetailsEntry()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in gvTestItemDetail.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
            }
        }
        private void frmTestDetailsEntry_Load(object sender, EventArgs e)
        {

            isLoaded = false;

            ctlTestSearch.Location = new Point(txtTestCode.Location.X, txtTestCode.Location.Y);
            ctlTestSearch.ItemSelected += ctlTestSearch_ItemSelected;

            LoadTestGroups(0);

            List<PathologicalMachine> _pathMachines = new TestService().GetAllPathologicalMachines();
           
            isLoaded = true;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            
           
        }

        private void ctlTestSearch_ItemSelected(SearchResultListControl<TestItem> sender, TestItem item)
        {
            unlocked = false;

            txtTestCode.Text = item.Name;
            txtTestCode.Tag = item;

            ReportType _rType = new TestService().GetReportTypesById(item.ReportTypeId);

            LoadTestGroups(_rType.TestGroupId);

            LoadTestReportDefinationByTestId(item);



            txtTestCode.Focus();

            unlocked = true;
            sender.Visible = false;
        }


        private void LoadTestGroups(int groupId)
        {
            List<TestGroup> _testGroup = new TestService().GetAllGroup();
            _testGroup.Insert(0, new TestGroup { TestGroupId = 0, Name = "Select Group" });
            cmbGroup.DataSource = _testGroup;
            cmbGroup.DisplayMember = "Name";
            cmbGroup.ValueMember = "TestGroupId";

            if (groupId > 0)
            {
                cmbGroup.SelectedItem = _testGroup.Find(x => x.TestGroupId == groupId);
            }

        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {

               
                txtGrouptitle.Tag = new TestService().GetTestGroupById(Convert.ToInt32(cmbGroup.SelectedValue));
                txtGrouptitle.Text = cmbGroup.Text;
            }
        }

       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            float _lowerLimit = 0, _upperLimit = 0;
            int _reportOrder = 0;
            int _fontbold=0,_fontItalic=0,_fontUnderline=0;
            int _ageVariant = 0;
            int _keyVal = 0;
            int _PRId = 0; // Path Report Combo Type Option

            int testId = 0;

            if (txtTestCode.Tag == null)
            {
                MessageBox.Show("Plz. select test and try again."); return;
            }

            if (txtTestCode.Tag != null)
            {
                TestItem _tItem = txtTestCode.Tag as TestItem;
                testId = _tItem.TestId;
            }

            float.TryParse(txtLowerLimit.Text, out _lowerLimit);
            float.TryParse(txtUpperLimit.Text, out _upperLimit);
            int.TryParse(cmbFontBold.Text, out _fontbold);
            int.TryParse(cmbItalic.Text, out _fontItalic);
            int.TryParse(cmbUnderline.Text, out _fontUnderline);
            string _defaultValue = txtDefaultValue.Text;


            int.TryParse(txtReportOrder.Text, out _reportOrder);


            if (chkIsAgeVariant.Checked) _ageVariant = 1;

            if (chkKeyValue.Checked)
            {
                _keyVal = 1;
            }
            else
            {
                _keyVal = 0;
            }


            string _resultOption = string.Empty;
            
            _resultOption = txtResultOptions.Text;
            

            if (txtTestCriteria.Tag != null)
            {
                ReportDefination _reportDef = (ReportDefination)txtTestCriteria.Tag;
                _reportDef.GroupTitle = txtGrouptitle.Text;
                _reportDef.TestTitle = txtTestCriteria.Text;
                _reportDef.NormalValue = txtNormalValues.Text;
                _reportDef.ResultUnit = txtResultUnit.Text;
                _reportDef.LowerLimit = _lowerLimit;
                _reportDef.UpperLimit = _upperLimit;
                _reportDef.DetailReportOrder = _reportOrder;
                _reportDef.TestTitle_FontBold = _fontbold;
                _reportDef.TestTitle_FontItalic = _fontItalic;
                _reportDef.TestTitle_FontUnderline = _fontUnderline;
                _reportDef.IsKeyValue = _keyVal;
                _reportDef.ResultOption = _resultOption;
                _reportDef.DefaultValue = _defaultValue;
                if (new TestService().UpdateTestItemDetail(_reportDef))
                 {
                     MessageBox.Show("Report defination updated.", "HERP");
                   
                    
                     txtTestCriteria.Tag = null;
                     txtTestCriteria.Text = "";
                     txtNormalValues.Text = "";
                     txtResultUnit.Text = "";
                     txtLowerLimit.Text = "";
                     txtUpperLimit.Text = "";
                    txtDefaultValue.Text = "";
                     chkIsAgeVariant.Checked = false;
                     btnAdd.Text = "Add";
                     btnCancel.Visible = false;
                     btnDelete.Visible = false;
                    if (txtTestCode.Tag != null)
                    {
                        TestItem _tItem = txtTestCode.Tag as TestItem;
                        if (_tItem != null)
                        {
                            LoadTestReportDefinationByTestId(_tItem);
                        }
                    }
                }
               
               
            }
            else
            {

                ReportDefination _reportDefination = new ReportDefination();
                _reportDefination.GroupId = ((TestGroup)txtGrouptitle.Tag).TestGroupId;
                _reportDefination.GroupTitle = txtGrouptitle.Text;
                _reportDefination.TestId = testId;
                _reportDefination.TestTitle = txtTestCriteria.Text;
                _reportDefination.ResultUnit = txtResultUnit.Text;
                _reportDefination.NormalValue = txtNormalValues.Text;
                _reportDefination.LowerLimit = _lowerLimit;
                _reportDefination.UpperLimit = _upperLimit;
                _reportDefination.TestTitle_FontBold = _fontbold;
                _reportDefination.TestTitle_FontItalic = _fontItalic;
                _reportDefination.TestTitle_FontUnderline = _fontUnderline;
                _reportDefination.DetailReportOrder = _reportOrder;
                _reportDefination.IsKeyValue = _keyVal;
                _reportDefination.ResultOption = _resultOption;
                _reportDefination.DefaultValue = _defaultValue;
                if (new TestService().SaveReportDefination(_reportDefination))
                {

                    MessageBox.Show("Test criteria added successfully.", "HERP");
                    if (txtTestCode.Tag != null)
                    {
                        TestItem _tItem = txtTestCode.Tag as TestItem;
                        if (_tItem != null)
                        {
                            LoadTestReportDefinationByTestId(_tItem);
                        }
                    }
                    ClearFields();
                   

                }
                
            }

            //LoadTestsByGroup();
           
        }

        private void ClearFields()
        {
            txtTestCriteria.Text = "";
            txtNormalValues.Text = "";
            txtLowerLimit.Text = "";
            txtUpperLimit.Text = "";
            chkIsAgeVariant.Checked = false;
            txtResultUnit.Text = "";
            cmbFontBold.Text = "0";
            txtDefaultValue.Text = "";

        }

       

        private void LoadTestReportDefinationByTestId(TestItem item)
        {
            if (item == null) return;
            List<ReportDefination> testItemDetailList = new TestService().GetTestReportDefinationByTestId(item.TestId).ToList();
            var bindingList = new BindingList<ReportDefination>(testItemDetailList);
            var source = new BindingSource(bindingList, null);
            gvTestItemDetail.AutoGenerateColumns = false;
            gvTestItemDetail.DataSource = source;
        }

        private void gvTestItemDetail_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ReportDefination _def = new TestService().GetTestReportDefinationById(Convert.ToInt32(gvTestItemDetail.Rows[e.RowIndex].Cells["Id"].Value.ToString()));

            txtTestCriteria.Tag = _def;

            TestItem _tItem = new TestService().GetTestItemById(_def.TestId);
            txtTestCode.Name = _tItem.Name;
            txtTestCode.Tag = _tItem;

            txtTestCriteria.Text = gvTestItemDetail.Rows[e.RowIndex].Cells["TestCriteria"].Value.ToString();

            txtGrouptitle.Text = gvTestItemDetail.Rows[e.RowIndex].Cells["GroupTitle"].Value.ToString();

            cmbFontBold.Text = gvTestItemDetail.Rows[e.RowIndex].Cells["TestTitle_FontBold"].Value.ToString();
            cmbUnderline.Text = gvTestItemDetail.Rows[e.RowIndex].Cells["TestTitle_FontUnderline"].Value.ToString();

            if (gvTestItemDetail.Rows[e.RowIndex].Cells["NormalValues"].Value != null)
            {
                txtNormalValues.Text = gvTestItemDetail.Rows[e.RowIndex].Cells["NormalValues"].Value.ToString();
            }
            else
            {
                txtNormalValues.Text = "";
            }

            if (gvTestItemDetail.Rows[e.RowIndex].Cells["ResultUnit"].Value != null)
            {
                txtResultUnit.Text = gvTestItemDetail.Rows[e.RowIndex].Cells["ResultUnit"].Value.ToString();
            }
            else
            {
                txtResultUnit.Text = "";
            }

            if (gvTestItemDetail.Rows[e.RowIndex].Cells["Reportorder"].Value != null)
            {
                txtReportOrder.Text = gvTestItemDetail.Rows[e.RowIndex].Cells["Reportorder"].Value.ToString();
            }
            else
            {
                txtReportOrder.Text = "";
            }


            if(gvTestItemDetail.Rows[e.RowIndex].Cells["DefaultValue"].Value != null)
            {
                txtDefaultValue.Text = gvTestItemDetail.Rows[e.RowIndex].Cells["DefaultValue"].Value.ToString();
            }
            else
            {
                txtDefaultValue.Text = "";
            }
            //if (gvTestItemDetail.Rows[e.RowIndex].Cells["lowerLimit"].Value != null)
            //{
            //    txtLowerLimit.Text = gvTestItemDetail.Rows[e.RowIndex].Cells["lowerLimit"].Value.ToString();
            //}
            //else
            //{
            //    txtLowerLimit.Text = "";
            //}

            //if (gvTestItemDetail.Rows[e.RowIndex].Cells["UpperLimit"].Value != null)
            //{
            //    txtUpperLimit.Text = gvTestItemDetail.Rows[e.RowIndex].Cells["UpperLimit"].Value.ToString();
            //}
            //else
            //{
            //    txtUpperLimit.Text = "";
            //}

            //if (gvTestItemDetail.Rows[e.RowIndex].Cells["Mathod"].Value != null)
            //{
            //    txtmathod.Text = gvTestItemDetail.Rows[e.RowIndex].Cells["Mathod"].Value.ToString();
            //}
            //else
            //{
            //    txtmathod.Text = "";
            //}

            string _OnDischarge = gvTestItemDetail.Rows[e.RowIndex].Cells["IsKeyValue"].Value.ToString();

            if (_OnDischarge == "0")
            {
                chkKeyValue.Checked = false;
            }
            else
            {
                chkKeyValue.Checked = true;
            }

            btnAdd.Text = "Update";
            btnCancel.Visible = true;
            btnDelete.Visible = true;

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTestCriteria.Tag = null;
            txtTestCriteria.Text = "";
            txtNormalValues.Text = "";
            txtResultUnit.Text = "";
            txtLowerLimit.Text = "";
            txtUpperLimit.Text = "";
            chkIsAgeVariant.Checked = false;
            btnAdd.Text = "Add";
            btnCancel.Visible = false;
            btnDelete.Visible = false;
            txtDefaultValue.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtTestCriteria.Tag != null)
            {
                ReportDefination _reportDef = (ReportDefination)txtTestCriteria.Tag;
                if (new TestService().DeleteReportDefination(_reportDef))
                {
                    MessageBox.Show("Entry deleted successfully.");
                    LoadTestReportDefinationByTestId((TestItem)txtResultUnit.Tag);
                    ClearFields();
                }
            }
        }

        private void ctlTestSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtTestCode.Focus();
            }
        }

        private void txtTestCode_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtTestCode.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtTestCode.Text;
                    HideAllDefaultHidden();
                    ctlTestSearch.Visible = true;
                    ctlTestSearch.txtSearch.Text = _txt;
                    ctlTestSearch.txtSearch.SelectionStart = ctlTestSearch.txtSearch.Text.Length;

                    ctlTestSearch.LoadData();
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlTestSearch.Visible = false;
        }
    }
}
