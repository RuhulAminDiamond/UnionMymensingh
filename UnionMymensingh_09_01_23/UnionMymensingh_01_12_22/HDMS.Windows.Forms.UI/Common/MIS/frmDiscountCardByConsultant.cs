using HDMS.Model.Common;
using HDMS.Service.Common;
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
using HDMS.Windows.Forms.UI.Reports.Common;
using CrystalDecisions.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Common.MIS
{
    public partial class frmDiscountCardByConsultant : Form
    {
        public frmDiscountCardByConsultant()
        {
            InitializeComponent();
        }

        private void txtConsultant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlDoctorSearch.Visible = true;
                ctlDoctorSearch.LoadData();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlDoctorSearch.Visible = false;
        }

        private void frmDiscountCardByConsultant_Load(object sender, EventArgs e)
        {

            ctlDoctorSearch.Location = new Point(txtConsultant.Location.X, txtConsultant.Location.Y + txtConsultant.Height);
            ctlDoctorSearch.ItemSelected += ctlDoctorSearch_ItemSelected;

            LoadCardTypes();
        }

        private void ctlDoctorSearch_ItemSelected(SearchResultListControl<Doctor> sender, Doctor item)
        {
            txtConsultant.Text = item.Name;
         
            txtConsultant.Tag = item;
            cmbCardType.Focus();
            sender.Visible = false;
         
        }

        private void LoadCardTypes()
        {
            List<DiscountCardType> _cardList = new CommonService().GetAllCardTypes();
            _cardList.Insert(0, new DiscountCardType() { CardTypeId = 0, Name = "Select Card Type" });

            cmbCardType.DataSource = _cardList;
            cmbCardType.DisplayMember = "Name";
            cmbCardType.ValueMember = "CardTypeId";

        }

        private void btnUnUsedCardList_Click(object sender, EventArgs e)
        {
            int doctorId = 0;

            if (txtConsultant.Tag != null)
            {
                Doctor _d = (Doctor)txtConsultant.Tag;
                doctorId = _d.DoctorId;

                DataSet ds = new CommonService().GetUsedCardList(doctorId);

                rptUsedCards _rpt = new rptUsedCards();

                _rpt.SetDataSource(ds.Tables[0]);



                ReportViewer rv = new ReportViewer();
                //string customFmts = "dd/MM/yyyy";

                _rpt.SetParameterValue("ConsultantName", txtConsultant.Text);

                rv.crviewer.ReportSource = _rpt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();

            }else
            {
                MessageBox.Show("Consultant not selected."); return;
            }
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int doctorId = 0;

            if (txtConsultant.Tag != null)
            {
                Doctor _d = (Doctor)txtConsultant.Tag;
                doctorId = _d.DoctorId;

                DataSet ds = new CommonService().GetUnUsedCardList(doctorId);

                rptUnUsedCards _rpt = new rptUnUsedCards();

                _rpt.SetDataSource(ds.Tables[0]);



                ReportViewer rv = new ReportViewer();
                //string customFmts = "dd/MM/yyyy";

                _rpt.SetParameterValue("ConsultantName", txtConsultant.Text);

                rv.crviewer.ReportSource = _rpt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();

            }else
            {
                MessageBox.Show("Consultant not selected."); return;
            }
          
        }
    }
}
