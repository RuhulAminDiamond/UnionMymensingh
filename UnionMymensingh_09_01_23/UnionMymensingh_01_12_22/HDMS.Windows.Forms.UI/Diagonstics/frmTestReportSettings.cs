using HDMS.Model;
using HDMS.Model.Diagnostic;
using HDMS.Model.ViewModel;
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
    public partial class frmTestReportSettings : Form
    {

        bool isLoaded = false;
        public frmTestReportSettings()
        {
            InitializeComponent();
        }


        private IList<SelectedTestItemsForPatient> _SelectedTests;
        private void frmTestReportSettings_Load(object sender, EventArgs e)
        {

            _SelectedTests = new List<SelectedTestItemsForPatient>();

            isLoaded = false;

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

           
                //LoadTestsByGroup();
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
                //txtGroupId.Text = cmbGroup.SelectedValue.ToString();
                isLoaded = true;
            }

        }

        private void gvTestlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtReportOrder.Tag = new TestService().GetTestItemById(Convert.ToInt32(gvTestlist.Rows[e.RowIndex].Cells["Id"].Value.ToString()));

            if (txtReportOrder.Tag != null)
            {
                TestItem _testItem = (TestItem)txtReportOrder.Tag;

                txtTestName.Text = _testItem.Name;
                txtReportOrder.Text = _testItem.ReportOrder.ToString();
                
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int _reportOrder = 0;
            int.TryParse(txtReportOrder.Text, out _reportOrder);
            if (txtReportOrder.Tag != null)
            {
                TestItem _Item = (TestItem)txtReportOrder.Tag;
                _Item.ReportOrder = _reportOrder;
              

                new TestService().UpdateTestItem(_Item);
                MessageBox.Show("Test info updated.", "HERP");
                LoadTestsByGroup();
            }
            else
            {
                MessageBox.Show("Test not selected.", "HERP");
            }
        }



        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                cmbReportType.Tag = new TestService().GetReportTypesById(Convert.ToInt32(cmbReportType.SelectedValue));
                //txtReportTypeId.Text = cmbReportType.SelectedValue.ToString();
                LoadTestsByGroup();
            }
        }
    }
} 
