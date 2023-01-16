using CrystalDecisions.Windows.Forms;
using HDMS.Common.Utils;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Windows.Forms.UI.Reports.OPD;
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

namespace HDMS.Windows.Forms.UI.Accounts.OPD
{
    public partial class frmOPDConsultancyStatement : Form
    {
        SqlDataAdapter da;

        public frmOPDConsultancyStatement()
        {
            InitializeComponent();
        }

        private void frmOPDConsultancyStatement_Load(object sender, EventArgs e)
        {

            ctlDoctorSearch.Location = new Point(txtRefdBy.Location.X, txtRefdBy.Location.Y + txtRefdBy.Height);
            ctlDoctorSearch.ItemSelected += ctlDoctorSearch_ItemSelected;

            LoadUseres();
        }

        private void LoadUseres()
        {

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);
            List<User> _User = new List<User>();
            _User = new UserService().GetAll();
            _User.Insert(0, new User() { UserId = 0, LoginName = "All" });

            cmbUser.DataSource = _User;
            cmbUser.DisplayMember = "LoginName";
            cmbUser.ValueMember = "Id";

        }

        private void ctlDoctorSearch_ItemSelected(UI.Controls.SearchResultListControl<Model.Doctor> sender, Model.Doctor item)
        {
            txtRefdBy.Text = item.Name;
            txtRefdBy.Tag = item.DoctorId;
            sender.Visible = false;
        }

        private void txtRefdBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlDoctorSearch.Visible = true;
                ctlDoctorSearch.LoadData();
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                ctlDoctorSearch.Visible = false;
                int id;
                if (int.TryParse(txtRefdBy.Text.Trim(), out id))
                {
                    txtRefdBy.Text = new DoctorService().GetDoctorById(id).Name;
                    txtRefdBy.Tag = new DoctorService().GetDoctorById(id).DoctorId;
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlDoctorSearch.Visible = false;
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            cmdShow.Text = "Please wait...";
            cmdShow.Enabled = false;

            int _consultantId = 0;
            if (txtRefdBy.Tag != null) _consultantId = Convert.ToInt32(txtRefdBy.Tag);


            da = new SqlDataAdapter();

            DateTime _startDateTime= dtpfrm.Value;

            DateTime _endDateTime = dtpto.Value;

            DataSet dsOpdConsultancy = new ReportService().GetOpdConsultancy(_startDateTime, _endDateTime,  _consultantId, cmbUser.Text);


            rptOPDConsultancyStatement _referredStatement = new rptOPDConsultancyStatement();
            //int c = dsReports.Tables[0].Rows.Count;



            _referredStatement.SetDataSource(dsOpdConsultancy.Tables[0]);




            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy hh:mm tt";
            _referredStatement.SetParameterValue("dtpfrm", _startDateTime.ToString(customFmts));
            _referredStatement.SetParameterValue("dtpto", _endDateTime.ToString(customFmts));
            _referredStatement.SetParameterValue("UserName", cmbUser.Text);

            //if (!String.IsNullOrEmpty(txtRefdBy.Text) && txtRefdBy.Tag != null)
            //{
            //    _referredStatement.SetParameterValue("Refdby", "Refd. By : " + txtRefdBy.Text);
            //}
            //else
            //{
            //    _referredStatement.SetParameterValue("Refdby", "");
            //}



            rv.crviewer.ReportSource = _referredStatement;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

            cmdShow.Text = "Show";
            cmdShow.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
