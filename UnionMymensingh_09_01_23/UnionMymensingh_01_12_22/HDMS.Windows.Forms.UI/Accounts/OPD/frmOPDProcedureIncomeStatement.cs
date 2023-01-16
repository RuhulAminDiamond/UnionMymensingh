using CrystalDecisions.Windows.Forms;
using HDMS.Model.OPD;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Service.Diagonstics;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Reports.Accounts.OPD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.OPD.VM;

namespace HDMS.Windows.Forms.UI.Accounts.OPD
{
    public partial class frmOPDProcedureIncomeStatement : Form
    {
        DataSet ds;
        bool unlocked = true;

        public frmOPDProcedureIncomeStatement()
        {
            InitializeComponent();
        }

        private void frmOPDIncomeStatement_Load(object sender, EventArgs e)
        {

            HideAllDefaultHidden();

            dtpfrm.Value = DateTime.Now;
            dtpto.Value = DateTime.Now;

            ctrlProcedureSearch.Location = new Point(txtProcedure.Location.X, txtProcedure.Location.Y);
            ctrlProcedureSearch.ItemSelected += CtrlProcedureSearch_ItemSelected;

            LoadUsers();

            //LoadServiceType();
        }

        private void CtrlProcedureSearch_ItemSelected(SearchResultListControl<VMOPDServiceHead> sender, VMOPDServiceHead item)
        {
            txtProcedure.Text = item.ServiceHeadName;
            txtProcedure.Tag = item;
            //txtRate.Text = item.Rate.ToString();
            //txtQty.Text = "1";
            txtProcedure.Focus();
            sender.Visible = false;
        }

        private void ctlConsultantSearch_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            unlocked = false;
            txtProcedure.Text = item.Name;
            txtProcedure.Tag = item;
        
            unlocked = true;
            sender.Visible = false;
        }

        //private void LoadServiceType()
        //{
        //    List<OPDServiceGroup> _sgroup = new HospitalService().getOpdServiceGroups();
        //    _sgroup.Insert(0, new OPDServiceGroup() { GroupId = 0, Name = "All" });
        //    cmbServiceType.DataSource = _sgroup;
        //    cmbServiceType.DisplayMember = "Name";
        //    cmbServiceType.ValueMember = "GroupId";
        //}

        private void LoadUsers()
        {

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);
            List<User> _User = new List<User>();
            _User = new UserService().GetAll();
            _User.Insert(0, new User() { UserId = 0, LoginName = "All" });

            cmbUser.DataSource = _User;
            cmbUser.DisplayMember = "LoginName";
            cmbUser.ValueMember = "Id";

            //if (_user.RoleId == 1)
            //{
            //    _User = new UserService().GetAll();
            //    _User.Insert(0, new User() { UserId = 0, LoginName = "All" });

            //    cmbUser.DataSource = _User;
            //    cmbUser.DisplayMember = "LoginName";
            //    cmbUser.ValueMember = "Id";

            //}
            //else if (_user.RoleId == 3 || _user.RoleId == 10)
            //{
            //    _User = new UserService().GetUserByRoleId(4);
            //    _User.Insert(0, new User() { UserId = 0, LoginName = "All" });

            //    cmbUser.DataSource = _User;
            //    cmbUser.DisplayMember = "LoginName";
            //    cmbUser.ValueMember = "Id";
            //}
            //else
            //{
            //    _User = new UserService().GetAll();
            //    cmbUser.DataSource = _User;
            //    cmbUser.DisplayMember = "LoginName";
            //    cmbUser.ValueMember = "Id";
            //    cmbUser.SelectedItem = _User.Find(q => q.UserId == MainForm.LoggedinUser.UserId);
            //    cmbUser.Enabled = false;
            //}

        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            string _reportOPtion = string.Empty;
            string _reportHeader = string.Empty;
           
            _reportOPtion = "OPD";
            _reportHeader = "OPD Collection Statement";

            int _doctorId = 0;

            if (txtProcedure.Tag != null)
            {
                //Doctor _d = (Doctor)txtProcedure.Tag;
                //_doctorId = _d.DoctorId;
            }

           // OPDServiceGroup _sgroup = (OPDServiceGroup)cmbServiceType.SelectedItem;


            ds = new DataSet();
            int _refdBy = 0;


            ds = new ReportService().GetOPDProcedureCollectionStatement(dtpfrm.Value, dtpto.Value,  txtProcedure.Text, _reportOPtion);

            RptOPDProcedureIncomeStatement _pstatement = new RptOPDProcedureIncomeStatement();

            _pstatement.SetDataSource(ds.Tables[0]);
            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _pstatement.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _pstatement.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";

            _pstatement.DataDefinition.FormulaFields[2].Text = "'" + "User Name :" + cmbUser.Text + "'";



            if (txtProcedure.Tag != null)
            {
                _pstatement.SetParameterValue("ServiceTitle", "Service Name:");
                _pstatement.SetParameterValue("ServiceName", txtProcedure.Text);
            }
            else
            {
                _pstatement.SetParameterValue("ServiceTitle", "");
                _pstatement.SetParameterValue("ServiceName", "");
            }
         

            rv.crviewer.ReportSource = _pstatement;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnStatement_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtConsultant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
             
                //if (unlocked)
                //{
                //    string _txt = txtProcedure.Text;
                //    HideAllDefaultHidden();
                  
                //    ctlConsultantSearch.Visible = true;
                //    ctlConsultantSearch.txtSearch.Text = _txt;
                //    ctlConsultantSearch.txtSearch.SelectionStart = ctlConsultantSearch.txtSearch.Text.Length;

                //    ctlConsultantSearch.LoadData();
                   
                   
                //}
            }
        }

        private void HideAllDefaultHidden()
        {
            ctrlProcedureSearch.Visible = false;
        }
        private void txtProcedure_TextChanged(object sender, EventArgs e)
        {
            if (unlocked)
            {
                string _txt = txtProcedure.Text;
                HideAllDefaultHidden();

                ctrlProcedureSearch.Visible = true;
                ctrlProcedureSearch.txtSearch.Text = _txt;
                ctrlProcedureSearch.txtSearch.SelectionStart = ctrlProcedureSearch.txtSearch.Text.Length;

                ctrlProcedureSearch.LoadData();


            }
        }

        private void txtConsultant_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtProcedure.Text))
            {
                txtProcedure.Tag = null;
            }
        }
    }
}
