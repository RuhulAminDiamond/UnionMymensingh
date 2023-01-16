using CrystalDecisions.Windows.Forms;
using HDMS.Model.Accounting;
using HDMS.Model.Users;
using HDMS.Repository.ServiceObjects;
using HDMS.Service;
using HDMS.Service.Common;
using HDMS.Service.Diagonstics;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Accounts;
using HDMS.Windows.Forms.UI.Common;
using HDMS.Windows.Forms.UI.Diagonstics;
using HDMS.Windows.Forms.UI.MiniAccounts;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI
{
    public partial class MainForm : Form
    {
        public static LoginUser LoggedinUser{get; set;}
        public static OrgSetting orgSetting { get; set; }
        public static string WorkStationId { get; set; }
        public MainForm(LoginUser user)
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
            PatientEntry pe = new PatientEntry();
            pe.Show();
            //ShowChildForm();
        }

        private void mnugroupEntry_Click(object sender, EventArgs e)
        {
            ShowChildForm(new TestGroupEntry());
        }

        private void testEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmTestEntry());
        }

      
        private async void MainForm_Load(object sender, EventArgs e)
        {

            //MenuStrip MnuStrip = new MenuStrip();
            //MnuStrip.Items.Add("File", imgListLage.Images[0]);
            //this.Controls.Add(MnuStrip);

            List<HDMS.Model.Users.Module> _PermittedParentsList = new MenuModuleService().GetPermittedParentsByUser(LoggedinUser.UserId);
            _PermittedParentsList = _PermittedParentsList.OrderBy(x => x.DisplayOrder).ToList();

            ImageList imageList = new ImageList { ImageSize = new Size(200, 200) };
            Image img = new Bitmap(Properties.Resources.folderImage2);
            treeImageList.Images.Add("imgFolder", img);
            treeMenu.ImageList = treeImageList; 
            //this.listView1.Items.Add(new ListViewItem { ImageIndex = 0 });
            //this.listView1.LargeImageList = imageList;



            FillNode(_PermittedParentsList, null);

            //foreach (ToolStripMenuItem item in this.menuStrip1.Items)
            //{
            //    if (new UserService().IsUserPermitted(Convert.ToString(item.Tag), LoggedinUser))
            //    {
            //        item.Enabled = true;
            //        SetEnabled(item);
            //    }
            //    else
            //    {
            //        item.Enabled = false;
            //    }
            //}

            this.FormClosed += MainForm_FormClosed;

            string _macAddress = GetMacAddress();

            lblWorkStationId.Text = "Workstation Id: " + _macAddress + "   Logged in as " + MainForm.LoggedinUser.Name;
            WorkStationId = _macAddress;
            // this.lblUserNameLabel.Text = "Welcome,";
            //this.lblUserName.Text = LoggedinUser.Name;

            if (!new PhProductService().IsOpeningStockSet(Utils.GetServerDateAndTime()))
            {
                await new PhProductService().SetOpeningStock(Utils.GetServerDateAndTime());
            }

            orgSetting = new CommonService().GetOrgSettings();

        }

        private string GetMacAddress()
        {
            const int MIN_MAC_ADDR_LENGTH = 12;
            string macAddress = string.Empty;
            long maxSpeed = -1;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                //log.Debug(
                //    "Found MAC Address: " + nic.GetPhysicalAddress() +
                //    " Type: " + nic.NetworkInterfaceType);

                string tempMac = nic.GetPhysicalAddress().ToString();
                if (nic.Speed > maxSpeed &&
                    !string.IsNullOrEmpty(tempMac) &&
                    tempMac.Length >= MIN_MAC_ADDR_LENGTH)
                {
                    //log.Debug("New Max Speed = " + nic.Speed + ", MAC: " + tempMac);
                    maxSpeed = nic.Speed;
                    macAddress = tempMac;
                }
            }

            return macAddress;
        }

        private void FillNode(List<HDMS.Model.Users.Module> items, TreeNode node)
        {
            string[] strArr = null;

            if (node != null)
            {
                strArr = node.Tag.ToString().Split('|');
            }

            var parentID = node != null
                ? Convert.ToInt32(strArr[0])
                : 0;

            var nodesCollection = node != null
                ? node.Nodes
                : treeMenu.Nodes;

            foreach (var item in items.Where(i => i.ParentId == parentID))
            {
                var newNode = nodesCollection.Add(item.Name, item.Name);
                newNode.Tag = item.ModuleId+"|" + item.frmName + "|" + item.DisplayType;
                newNode.ImageKey = "imgFolder";
                newNode.SelectedImageKey = "";
                FillNode(items, newNode);
            }

           
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
           
        }

        private void receiptStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserwisePatientReceiptStatement _frm = new frmUserwisePatientReceiptStatement();
            _frm.Show();
        }

        private void printDepositSlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepositSlip _frm = new frmDepositSlip();
            _frm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PatientEntry _pe = new PatientEntry();
            _pe.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmTestEntry _testEntry = new frmTestEntry();
            _testEntry.Show();
        }

        private void treeMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);

            var selectedNode = e.Node.Tag;

            if (selectedNode == null) return;

            string[] strArr = null;
            if (selectedNode != null)
            {
                strArr = selectedNode.ToString().Split('|');
            }

            if (strArr[1] == null) return;

            if (strArr[2] == null) return;

            string _frm = strArr[1];
            string _displayType= strArr[2];

            foreach (Type type in frmAssembly.GetTypes())

            {

                //MessageBox.Show(type.Name);

                if (type.BaseType == typeof(Form))
                {

                   // MessageBox.Show(type.Name);
                    if (type.Name == _frm)

                    {


                        Form frmShow = (Form)frmAssembly.CreateInstance(type.ToString());

                        // then we  close all of the child Forms with  simple below code



                        foreach (Form form in this.MdiChildren)

                        {

                            form.Close();

                        }


                        if (_displayType == "MDIChild") {

                            frmShow.MdiParent = this;
                            frmShow.WindowState = FormWindowState.Maximized;
                            frmShow.Show();
                        }
                        else if(_displayType == "WS")
                        {
                            frmShow.WindowState = FormWindowState.Maximized;
                            frmShow.ShowDialog();
                            //this.Enabled = false;
                        }else
                        {
                            frmShow.ShowDialog();
                            //this.Enabled = false;
                        }

                        
                        
                        //frmShow.ControlBox = false;

                       
                        
                    }

                }
                else if (type.BaseType == typeof(MaterialForm))
                {
                    if (type.Name == _frm)
                    {

                        MaterialForm frmShow = (MaterialForm)frmAssembly.CreateInstance(type.ToString());
                        frmShow.WindowState = FormWindowState.Maximized;
                        frmShow.ShowDialog();
                    }
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
