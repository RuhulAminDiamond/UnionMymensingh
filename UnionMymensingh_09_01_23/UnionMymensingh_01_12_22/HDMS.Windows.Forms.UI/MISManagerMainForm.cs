using CrystalDecisions.Windows.Forms;
using HDMS.Repository.ServiceObjects;
using HDMS.Service;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Accounts;
using HDMS.Windows.Forms.UI.Common;
using HDMS.Windows.Forms.UI.Diagonstics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI
{
    public partial class MISManagerMainForm : Form
    {
        public static LoginUser LoggedinUser{get; set;}
        public MISManagerMainForm(LoginUser user)
        {
            InitializeComponent();
            LoggedinUser = user;
        }

      


        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.MdiParent = this;
            form.Show();
        }

        public void LoginSuccess(LoginUser user)
        {
           
            //this.lblUserId.Text = LoggedinUser.Id.ToString();
        }

        private void SetEnabled(ToolStripMenuItem item)
        {
            foreach (ToolStripMenuItem childItem in item.DropDownItems)
            {
                if (new UserService().IsUserPermitted(Convert.ToString(childItem.Tag), LoggedinUser))
                {
                    childItem.Enabled = true;
                    SetEnabled(childItem);
                }
                else
                {
                    childItem.Enabled = false;
                }
            }
        }

       
        private void ShowChildForm(Form form)
        {
            form.MdiParent = this;
            form.WindowState = FormWindowState.Minimized;
            form.Show();
            form.WindowState = FormWindowState.Maximized;

        }

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new PatientEntry());
        }

        

        private void tubeSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void AddMasterTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new FrmAddMasterTemplate());
        }

        private void newPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new PatientEntry());
        }

        private void mnugroupEntry_Click(object sender, EventArgs e)
        {
            ShowChildForm(new TestGroupEntry());
        }

        private void testEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmTestEntry());
        }

      
        private void MainForm_Load(object sender, EventArgs e)
        {
            
            foreach (ToolStripMenuItem item in this.menuStrip1.Items)
            {
                if (new UserService().IsUserPermitted(Convert.ToString(item.Tag), LoggedinUser))
                {
                    item.Enabled = true;
                    SetEnabled(item);
                }
                else
                {
                    item.Enabled = false;
                }
            }

            this.FormClosed += MainForm_FormClosed;

            // this.lblUserNameLabel.Text = "Welcome,";
            //this.lblUserName.Text = LoggedinUser.Name;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void mnuPatientStatement_Click(object sender, EventArgs e)
        {
            frmDiagPatientStatement frmdps = new frmDiagPatientStatement();
            frmdps.Show();
        }

   
        private void testReportCriteriaEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmTestDetailsEntry());
        }

      
        private void pathologicalReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPathologyReports _preport = new frmPathologyReports();
            _preport.Show();
            
        }

        private void cashBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCashBook frm = new frmCashBook();
            frm.Show();
        }

        private void accountsSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void expenseEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void summarySheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSummarySheet _frmSS = new frmSummarySheet();
            _frmSS.Show();
        }

        private void voucherEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void userwisePatientReceiptStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserwisePatientReceiptStatement _frm = new frmUserwisePatientReceiptStatement();
            _frm.Show();
        }

        private void dueListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDueList _frm = new frmDueList();
            _frm.Show();
        }

        private void referredCasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReferredCases _frm = new frmReferredCases();
            _frm.Show();
        }

        private void dueCollectionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDueCollectionList _frm = new frmDueCollectionList();
            _frm.Show();
        }

        private void consultancyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultancy _frm = new frmConsultancy();
            _frm.Show();
        }

        private void newConsultantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmAddConultant());
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void grantMenuPermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmGrantAccessToMenus());
        }

        private void paymentIrregularityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepriciationList _frm = new frmDepriciationList();
            _frm.Show();
        }

        private void refundStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRefundReport _frm = new frmRefundReport();
            _frm.Show();
        }

        private void headwiseExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void depriciationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepriciationList _frm = new frmDepriciationList();
            _frm.Show();
        }

        private void testsSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestSummary _frm = new frmTestSummary();
            _frm.Show();
        }

        private void changeUXReportConsultantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmChangeReportConsultancy());
        }

        private void patientSerialEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmPatientSerialEntry());
        }

        private void chamberPractitionerEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmChamberPractitionerEntry());
        }

        private void testDetailsEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmTestDetailsEntry());
        }

        private void testReportSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmTestReportSettings());
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmChangePassword());
        }

        private void createNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmCreateUser());
        }

        private void addNewTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new FrmAddTemplate());
        }

        private void headwiseExpenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void expenseByChequeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void patientStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDailyStatement _frmds = new frmDailyStatement();
            _frmds.Show();
        }

        private void monthlyStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonthlyStatement _frmds = new frmMonthlyStatement();
            _frmds.Show();
        }

        

        private void discountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiscountList _frmds = new frmDiscountList();
            _frmds.Show();
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistration _reg = new frmRegistration(null);
            _reg.Show();
        }

        private void capturePhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWebCam _frmWebcam = new frmWebCam();
            _frmWebcam.Show();
        }

        private void editPatinetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditPatientInfo _frmedit = new frmEditPatientInfo();
            _frmedit.Show();
        }
    }
}
