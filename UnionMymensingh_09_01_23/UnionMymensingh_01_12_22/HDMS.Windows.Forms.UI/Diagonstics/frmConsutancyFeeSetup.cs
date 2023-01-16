using HDMS.Model;
using HDMS.Model.Diagnostic;
using HDMS.Model.Diagnostic.VM;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
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
    public partial class frmConsutancyFeeSetup : Form
    {
        bool isLoaded = false;

        public frmConsutancyFeeSetup()
        {
            InitializeComponent();
        }

        private void frmConsutancyFeeSetup_Load(object sender, EventArgs e)
        {

            isLoaded = false;

            List<ReportConsultant> ReportDoctors = new DoctorService().GetAllConsultants().ToList(); //new DoctorService().GetlAlReportDoctorOtherThanPathologyLegay().ToList();
            if (ReportDoctors != null)
            {
                ReportDoctors.Insert(0, new ReportConsultant()
                {
                    RCId = 0,
                    Name = "Select Consulatnt"
                });
            }

            cmbConsultant.DataSource = ReportDoctors;
            cmbConsultant.DisplayMember = "Name";
            cmbConsultant.ValueMember = "RCId";


            List<TestGroup> _testGroup = new TestService().GetAllGroup();
            _testGroup.Insert(0, new TestGroup() { TestGroupId = 0, Name = "Select Group" });
            cmbGroup.DataSource = _testGroup;
            cmbGroup.DisplayMember = "Name";
            cmbGroup.ValueMember = "TestGroupId";

            isLoaded = true;


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
             
                isLoaded = true;
            }
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                cmbReportType.Tag = new TestService().GetReportTypesById(Convert.ToInt32(cmbReportType.SelectedValue));
                
                LoadTestsByGroup();
            }
        }

        private void LoadTestsByGroup()
        {
            if (isLoaded)
            {
                List<TestItem> testList = new TestService().GetAllTestByReportTypeId(Convert.ToInt32(cmbReportType.SelectedValue));
                //var bindingList = new BindingList<TestItem>(testList);
                //var source = new BindingSource(bindingList, null);
                //gvTestlist.AutoGenerateColumns = false;
                //gvTestlist.DataSource = source;

                List<VMConsultantFee> _vcfList = new List<VMConsultantFee>();

                ReportConsultant _consultant = ((ReportConsultant)cmbConsultant.SelectedItem);

               foreach (TestItem item in testList)
               {
                    VMConsultantFee _fee = new VMConsultantFee();
                    _fee.RCId = _consultant.RCId;
                    _fee.TestId = item.TestId;
                    _fee.TestName = item.Name;
                    ConsultantFee _currenCf = new TestService().GetCurrentCosultantFeeByTestId(_consultant.RCId,item.TestId);
                    if (_currenCf != null)
                    {
                        _fee.FeeInPercent = _currenCf.FeeInPercent;
                        _fee.FeeInGross = _currenCf.FeeInGross;

                    }else
                    {
                        _fee.FeeInPercent = 0;
                        _fee.FeeInGross = 0;
                    }

                    _vcfList.Add(_fee);

               }


                FillCFGrid(_vcfList);
            }
        }

        private void FillCFGrid(List<VMConsultantFee> _vcfList)
        {
            gvTestlist.SuspendLayout();
            gvTestlist.Rows.Clear();
            foreach (var item in _vcfList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = item;


                row.CreateCells(gvTestlist, item.TestId, item.TestName, item.FeeInPercent, item.FeeInGross);
                gvTestlist.Rows.Add(row);

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            int _feePercent = 0;
            int _feeGross = 0;

            ReportConsultant _consultant = ((ReportConsultant)cmbConsultant.SelectedItem);

            List<ConsultantFee> _newCFlist = new List<ConsultantFee>();

            foreach (DataGridViewRow row in gvTestlist.Rows)
            {
                VMConsultantFee _cf = row.Tag as VMConsultantFee;

                ConsultantFee _currenCf = new TestService().GetCurrentCosultantFeeByTestId(_consultant.RCId, _cf.TestId);

                int.TryParse((row.Cells[2].Value).ToString(), out _feePercent);
                int.TryParse((row.Cells[3].Value).ToString(), out _feeGross);

                if (_currenCf == null)
                {

                    ConsultantFee _vcL = new ConsultantFee();
                    _vcL.RCId = _consultant.RCId;
                    _vcL.TestId = _cf.TestId;
                    _vcL.FeeInPercent = _feePercent;
                    _vcL.FeeInGross = _feeGross;
                    _vcL.UserId = MainForm.LoggedinUser.UserId;
                    _vcL.CreateDate = DateTime.Now;
                    _vcL.ModifiedDate = DateTime.Now;
                    _newCFlist.Add(_vcL);

                }
                else
                {
                    _currenCf.RCId = _consultant.RCId;
                    _currenCf.FeeInPercent = _feePercent;
                    _currenCf.FeeInGross = _feeGross;
                    new TestService().UpdateConsultancyFeeRate(_currenCf);
                }

            }

            if (_newCFlist.Count > 0)
            {
                new TestService().AddConsultancyFeeRate(_newCFlist);
            }

            MessageBox.Show("Execution successful.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
