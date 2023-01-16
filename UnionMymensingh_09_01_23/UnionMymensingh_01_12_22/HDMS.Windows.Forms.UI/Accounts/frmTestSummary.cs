using CrystalDecisions.Windows.Forms;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Accounts;
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
using HDMS.Model;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Service.Doctors;

namespace HDMS.Windows.Forms.UI.Accounts
{
    public partial class frmTestSummary : Form
    {
        SqlDataAdapter da;
        DataSet ds;
        public frmTestSummary()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {

            int _doctorId = 0;

            string _consultant = "All";

            if(txtRefdBy.Tag != null)
            {
                int.TryParse(txtRefdBy.Tag.ToString(),out _doctorId);
                _consultant = txtRefdBy.Text;
            }


            ds = new DataSet();
            ds = new ReportService().GetTestSummary(dtpfrm.Value, dtpto.Value, _doctorId);
          

            RptTestSummary _testSummary = new RptTestSummary();

            _testSummary.SetDataSource(ds.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _testSummary.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _testSummary.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";
            _testSummary.SetParameterValue("refConsultant", _consultant);
            
            rv.crviewer.ReportSource = _testSummary;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void frmTestSummary_Load(object sender, EventArgs e)
        {
            ctlDoctorSearch.Location = new Point(txtRefdBy.Location.X, txtRefdBy.Location.Y + txtRefdBy.Height);
            ctlDoctorSearch.ItemSelected += ctlDoctorSearch_ItemSelected;
        }

        private void ctlDoctorSearch_ItemSelected(UI.Controls.SearchResultListControl<Model.Doctor> sender, Model.Doctor item)
        {
            txtRefdBy.Text = item.Name;
            txtRefdBy.Tag = item.DoctorId;
            sender.Visible = false;
        }

        private void HideAllDefaultHidden()
        {
            ctlDoctorSearch.Visible = false;
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

        private void txtRefdBy_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRefdBy.Text))
            {
                txtRefdBy.Tag = null;
            }
        }
    }
}
