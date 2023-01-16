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

namespace HDMS.Windows.Forms.UI.Accounts.OPD
{
    public partial class frmOPDIncomeStatement : Form
    {
        DataSet ds;
        bool unlocked = true;

        public frmOPDIncomeStatement()
        {
            InitializeComponent();
        }

        private void frmOPDIncomeStatement_Load(object sender, EventArgs e)
        {

            HideAllDefaultHidden();

            dtpfrm.Value = DateTime.Now;
            dtpto.Value = DateTime.Now;

            ctlConsultantSearch.Location = new Point(txtConsultant.Location.X, txtConsultant.Location.Y);
            ctlConsultantSearch.ItemSelected += ctlConsultantSearch_ItemSelected;

            LoadUsers();

            LoadServiceType();
        }

        private void ctlConsultantSearch_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            unlocked = false;
            txtConsultant.Text = item.Name;
            txtConsultant.Tag = item;
        
            unlocked = true;
            sender.Visible = false;
        }

        private void LoadServiceType()
        {
            List<OPDServiceGroup> _sgroup = new HospitalService().getOpdServiceGroups();
            _sgroup.Insert(0, new OPDServiceGroup() { GroupId = 0, Name = "All" });
            cmbServiceType.DataSource = _sgroup;
            cmbServiceType.DisplayMember = "Name";
            cmbServiceType.ValueMember = "GroupId";
        }

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

            if (txtConsultant.Tag != null)
            {
                Doctor _d = (Doctor)txtConsultant.Tag;
                _doctorId = _d.DoctorId;
            }

            OPDServiceGroup _sgroup = (OPDServiceGroup)cmbServiceType.SelectedItem;


            ds = new DataSet();
            int _refdBy = 0;


            ds = new ReportService().GetOPDCollectionStatement(dtpfrm.Value, dtpto.Value, _sgroup.GroupId, cmbUser.Text, _reportOPtion, _doctorId);

            RptOPDPatientStatement _pstatement = new RptOPDPatientStatement();

            _pstatement.SetDataSource(ds.Tables[0]);
            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _pstatement.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _pstatement.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";

            _pstatement.DataDefinition.FormulaFields[2].Text = "'" + "User Name :" + cmbUser.Text + "'";



            if (txtConsultant.Tag != null)
            {
                _pstatement.SetParameterValue("ServiceTitle", "Consultant:");
                _pstatement.SetParameterValue("ServiceName", txtConsultant.Text);
            }
            else
            {
                _pstatement.SetParameterValue("ServiceTitle", "Service Type:");
                _pstatement.SetParameterValue("ServiceName", cmbServiceType.Text);
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
             
                if (unlocked)
                {
                    string _txt = txtConsultant.Text;
                    HideAllDefaultHidden();
                  
                    ctlConsultantSearch.Visible = true;
                    ctlConsultantSearch.txtSearch.Text = _txt;
                    ctlConsultantSearch.txtSearch.SelectionStart = ctlConsultantSearch.txtSearch.Text.Length;

                    ctlConsultantSearch.LoadData();
                   
                   
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlConsultantSearch.Visible = false;
        }

        private void txtConsultant_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtConsultant.Text))
            {
                txtConsultant.Tag = null;
            }
        }
    }
}
