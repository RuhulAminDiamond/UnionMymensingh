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
    public partial class frmReportTypeEntry : Form
    {
        bool isLoaded = false;
        int _MainTestId = 0;
        public frmReportTypeEntry()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgvReportType.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgvReportType.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);


        }

       
        private void frmTestEntry_Load(object sender, EventArgs e)
        {
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


          

            isLoaded = true;

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
            int reportOrder=0;
            int _groupId = 0;
            int.TryParse(txtGroupId.Text, out _groupId);


            if (string.IsNullOrEmpty(txtReportType.Text))
            {
                MessageBox.Show("Report type name blank. Plz. check it and try again.");
            }

            if (_groupId == 0)
            {
                MessageBox.Show("Select group then try again."); return;
            }



            if (txtReportType.Tag != null)
            {
                ReportType _rType = (ReportType)txtReportType.Tag;
                _rType.Report_Type = txtReportType.Text;
          
                _rType.ReportOrder = reportOrder;
                _rType.TestCarriedOutBy = txtTestCarriedoutby.Text;

                new TestService().UpdateReportType(_rType);
                MessageBox.Show("Report type updated.", "HERP");
                txtReportType.Tag = null;
                btnSave.Text = "Add";
                btnCancel.Visible = false;
                cmdDelete.Visible = false;
            }
            else
            {
                ReportType _rType = new ReportType();
                _rType.Report_Type = txtReportType.Text;
                _rType.TestGroupId = _groupId;
                if (radioPath.Checked)
                {
                    _rType.IsPathReport = true;
                    _rType.IsImageReport = false;
                }else if(radioImage.Checked)
                {
                    _rType.IsPathReport = false;
                    _rType.IsImageReport = true;
                }else
                {
                    _rType.IsPathReport = false;
                    _rType.IsImageReport = false;
                }
                
                _rType.ReportOrder = reportOrder;
                _rType.TestCarriedOutBy = txtTestCarriedoutby.Text;

                if (new TestService().SaveReportType(_rType))
                {
                    MessageBox.Show("New report type created.", "HERP");

                }
            }


            LoadReportTypes();
            

        }

       

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                isLoaded = false;

                LoadReportTypes();

                txtGroupId.Text = cmbGroup.SelectedValue.ToString();
                isLoaded = true;
            }
        }

        private void LoadReportTypes()
        {
            List<ReportType> _rTypeList = new TestService().GetReportTypesByGroupId(Convert.ToInt32(cmbGroup.SelectedValue));
            dgvReportType.AutoGenerateColumns = false;
            dgvReportType.DataSource = _rTypeList;

        }

        
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete this type?", "Confirmation", MessageBoxButtons.YesNoCancel);

            

            if (result == DialogResult.Yes)
            {
                if (txtReportType.Tag != null)
                {

                    ReportType _rtype = (ReportType)txtReportType.Tag;
                    List<TestItem> _testList = new TestService().GetAllTestByReportTypeId(_rtype.ReportTypeId);

                    if (_testList.Count() > 0)
                    {
                        MessageBox.Show("Test exists under this report type.Please delete tests under this report type first and try again.");
                        return;
                    }

                    foreach (DataGridViewRow item in this.dgvReportType.SelectedRows)
                    {
                   
                        new TestService().DeleteReportType((ReportType)txtReportType.Tag);
                        MessageBox.Show("Report type deleted.", "HERP");
                    }

                    LoadReportTypes();
                }
                else
                {
                    MessageBox.Show("No type selected for delete.","HERP");
                }
            }
        }

        private void gvTestlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
           
        }

        private void dgvReportType_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtReportType.Tag = new TestService().GetReportTypesById(Convert.ToInt32(dgvReportType.Rows[e.RowIndex].Cells["ReportTypeId"].Value.ToString()));
            
            if (txtReportType.Tag != null)
            {
                ReportType _rtype = (ReportType)txtReportType.Tag;

                txtReportType.Text = dgvReportType.Rows[e.RowIndex].Cells["Report_Type"].Value.ToString();

                bool isPathReport = (bool)dgvReportType.Rows[e.RowIndex].Cells["IsPathReport"].Value;
                bool isImageReport = (bool)dgvReportType.Rows[e.RowIndex].Cells["IsImageReport"].Value;

                 radioPath.Checked = isPathReport;
                 radioImage.Checked = isImageReport;

                if (String.IsNullOrEmpty(_rtype.TestCarriedOutBy))
                {
                    txtTestCarriedoutby.Text = "";
                }
                else
                {
                    txtTestCarriedoutby.Text = dgvReportType.Rows[e.RowIndex].Cells["TestCarriedOutBy"].Value.ToString();
                }

                btnSave.Text = "Update";
                btnCancel.Visible = true;
                cmdDelete.Visible = true;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtReportType.Tag = null;
            radioPath.Checked = false;
            radioImage.Checked = false;
            txtReportType.Text = "";
            txtTestCarriedoutby.Text = "";
            cmdDelete.Visible = false;
            btnCancel.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
