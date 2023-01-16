using CrystalDecisions.Windows.Forms;
using HDMS.Model.Common;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
using Services.POS;
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
using HDMS.Model.HR;
using HDMS.Service.Pharmacy;

namespace HDMS.Windows.Forms.UI.Accounts.Pharmacy
{
    public partial class frmOPDCustomerLedger : Form
    {
        public frmOPDCustomerLedger()
        {
            InitializeComponent();
        }

        private void frmCustomerLedger_Load(object sender, EventArgs e)
        {
            HiddenDefault();

            ctlCustomerSearch.Location = new Point(txtCustomer.Location.X, txtCustomer.Location.Y + txtCustomer.Height);
            ctlCustomerSearch.ItemSelected += CtlCustomerSearch_ItemSelected;

            ctlEmployeeSearchControl.Location = new Point(txtEmployee.Location.X, txtEmployee.Location.Y);
            ctlEmployeeSearchControl.ItemSelected += ctlEmployeeSearchControl_ItemSelected;

            dtpFromdate.Value = DateTime.Now;
            dtpTodate.Value = DateTime.Now;
        }

        private void ctlEmployeeSearchControl_ItemSelected(SearchResultListControl<VMEmployeeInfo> sender, VMEmployeeInfo item)
        {
            txtEmployee.Text = item.EmployeeName;
            txtEmployee.Tag = item;
            double _balance = 0;
            PhMemberInfo _memberInfo = new PhFinancialService().GetPhMemberByEmployeeId(item.EmployeeId);
            if (_memberInfo != null)
            {
                txtCustomer.Text = _memberInfo.Name;
                txtCustomer.Tag = _memberInfo;
               

                sender.Visible = false;
            }
            else
            {
                MessageBox.Show("Member entry not found against this employee.");
                txtCustomer.Text = "";
                txtCustomer.Tag = null;
                txtEmployee.Focus();
                sender.Visible = false;
                return;
            }
        }

        private void CtlCustomerSearch_ItemSelected(SearchResultListControl<PhMemberInfo> sender, PhMemberInfo item)
        {
            txtCustomer.Text = item.Name;
            txtCustomer.Tag = item;
            sender.Visible = false;
        }

        private void HiddenDefault()
        {
            ctlCustomerSearch.Visible = false;
            ctlEmployeeSearchControl.Visible = false;
        }

        private void CtlMemberSearch_ItemSelected(Controls.SearchResultListControl<Model.Common.MemberInfo> sender, Model.Common.MemberInfo item)
        {
            txtCustomer.Text = item.Name;
            txtCustomer.Tag = item;
            txtCustomer.Focus();
            sender.Visible = false;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rptCustomerLedger _rpt = new rptCustomerLedger();

            DateTime Fromdate = dtpFromdate.Value;
            DateTime Todate = dtpTodate.Value;

            if (txtCustomer.Tag == null)
            {
                MessageBox.Show("Member not selected."); return;
            }

            PhMemberInfo _mInfo = (PhMemberInfo)txtCustomer.Tag;


            DataSet ds = new PhFinancialService().GetOPDCustomerLedger(_mInfo.MemberId, Fromdate.Date, Todate.Date);
            _rpt.SetDataSource(ds.Tables[0]);
            // Company _company = new ProductService().GetAllCompany().FirstOrDefault();

            _rpt.SetParameterValue("companyName", "Mount Adora Hospital");
            _rpt.SetParameterValue("CustomerName", txtCustomer.Text);

            _rpt.SetParameterValue("dtfrm", dtpFromdate.Value.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("dtto", dtpTodate.Value.ToString("dd/MM/yyyy"));




            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void txtMember_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ctlCustomerSearch.Visible = true;
                ctlEmployeeSearchControl.LoadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlCustomerSearch.Visible = true;
                ctlCustomerSearch.LoadData();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlCustomerSearch.Visible = false;
            ctlEmployeeSearchControl.Visible = false;
        }

        private void txtEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlEmployeeSearchControl.Visible = true;
                ctlEmployeeSearchControl.LoadData();
            }
        }

        private void ctlEmployeeSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtEmployee.Focus();
            }
        }

        private void ctlCustomerSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtCustomer.Focus();
            }
        }

        private void btnProductDetails_Click(object sender, EventArgs e)
        {
            PhMemberInfo _mInfo = (PhMemberInfo)txtCustomer.Tag;

            if (_mInfo != null) {

                ReportViewer rv = new ReportViewer();
                rptOPDMedicineDetailByCustomer _rpt = new rptOPDMedicineDetailByCustomer();


                DataSet ds = new PhFinancialService().GetOPDCustomerProductDetails(dtpFromdate.Value, dtpTodate.Value, _mInfo.MemberId);
                _rpt.SetDataSource(ds.Tables[0]);
                // Company _company = new ProductService().GetAllCompany().FirstOrDefault();

             //   _rpt.SetParameterValue("companyName", "Mount Adora Hospital");
                _rpt.SetParameterValue("CustomerName", txtCustomer.Text);

                _rpt.SetParameterValue("dtfrm", dtpFromdate.Value.ToString("dd/MM/yyyy"));
                _rpt.SetParameterValue("dtto", dtpTodate.Value.ToString("dd/MM/yyyy"));




                rv.crviewer.ReportSource = _rpt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();
            }
        }
    }
}
