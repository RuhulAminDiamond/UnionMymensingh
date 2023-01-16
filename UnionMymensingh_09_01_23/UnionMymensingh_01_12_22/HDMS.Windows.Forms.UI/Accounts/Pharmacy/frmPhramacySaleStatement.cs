using CrystalDecisions.Windows.Forms;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmPhramacySaleStatement : Form
    {
        public frmPhramacySaleStatement()
        {
            InitializeComponent();
        }

        private void frmPhramacySaleStatement_Load(object sender, EventArgs e)
        {
            LoadPharmacist();
        }

        private void LoadPharmacist()
        {
            List<User> _User = new UserService().GetAllPharmacist();
            _User.Insert(0, new User() { UserId = 0, LoginName = "All" });
            cmbUser.DataSource = _User;
            cmbUser.DisplayMember = "LoginName";
            cmbUser.ValueMember = "UserId";
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {

            cmdShow.Enabled = false;
            cmdShow.Text = "Plz. Wait..";

            if (radIPD.Checked)
            {

                ShowIPDSaleStatement();
                
            }
            else if (radOPD.Checked)
            {
                ShowOPDSaleStatement();
               
            }

            cmdShow.Enabled = true;
            cmdShow.Text = "Show Sale Details";

        }

        private void ShowOPDSaleStatement()
        {
            string _reportOPtion = string.Empty;
            string _reportHeader = string.Empty;
           
                _reportOPtion = "OPD";
                _reportHeader = "Pharmacy OPD Sale Statement";
           


            string _user = string.Empty;
            if (cmbUser.Text.ToLower() == "all")
            {
                _user = "";
            }
            else
            {
                _user = cmbUser.Text;
            }


            DataSet dsSales = new PhReportingService().GetPhOPDSaleStatement(dtpfrm.Value, dtpto.Value, _user, _reportOPtion);

            rptPhSaleStatement _phstatement = new rptPhSaleStatement();

            _phstatement.SetDataSource(dsSales.Tables[0]);


            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _phstatement.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _phstatement.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
            _phstatement.SetParameterValue("reporttitle", _reportHeader);


            rv.crviewer.ReportSource = _phstatement;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void ShowIPDSaleStatement()
        {
            string _reportOPtion = string.Empty;
            string _reportHeader = string.Empty;
           
                _reportOPtion = "IPD";
                _reportHeader = "Pharmacy IPD Sale Statement";
            


            string _user = string.Empty;
            if (cmbUser.Text.ToLower() == "all")
            {
                _user = "";
            }
            else
            {
                _user = cmbUser.Text;
            }


            DataSet dsSales = new PhReportingService().GetPhIPDaleStatement(dtpfrm.Value, dtpto.Value, _user, _reportOPtion);

            rptPhSaleStatement _phstatement = new rptPhSaleStatement();

            _phstatement.SetDataSource(dsSales.Tables[0]);


            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _phstatement.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _phstatement.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
            _phstatement.SetParameterValue("reporttitle", _reportHeader);
           // _phstatement.SetParameterValue("Dept", "");

            rv.crviewer.ReportSource = _phstatement;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnSummaryReport_Click(object sender, EventArgs e)
        {
            string _reportOPtion = string.Empty;
            string _reportHeader = string.Empty;
            if (radIPD.Checked)
            {
                _reportOPtion = "IPD";
                _reportHeader = "Pharmacy IPD Sale Summary";
            }
            else if (radOPD.Checked)
            {
                _reportOPtion = "OPD";
                _reportHeader = "Pharmacy OPD Sale Summary";
            }


            if (String.IsNullOrEmpty(_reportOPtion))
            {
                MessageBox.Show("Plz. select an report option and try again."); return;
            }




            string _user = string.Empty;
            if (cmbUser.Text.ToLower() == "all")
            {
                _user = "";
            }
            else
            {
                _user = cmbUser.Text;
            }


            User _userObj = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            DataSet dsSales = new PhReportingService().GetPhSaleSummaryStatement(dtpfrm.Value, dtpto.Value, _reportOPtion, _userObj.AssignedOutLet);

            rptPhSaleSummary _phstatement = new rptPhSaleSummary();

            _phstatement.SetDataSource(dsSales.Tables[0]);


            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _phstatement.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _phstatement.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
            _phstatement.SetParameterValue("reporttitle", _reportHeader);


            rv.crviewer.ReportSource = _phstatement;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
