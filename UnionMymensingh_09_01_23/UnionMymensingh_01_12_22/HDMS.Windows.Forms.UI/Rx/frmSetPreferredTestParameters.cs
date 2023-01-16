using HDMS.Model;
using HDMS.Model.Rx;
using HDMS.Model.Rx.VModel;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
using HDMS.Service.Rx;
using HDMS.Windows.Forms.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Rx
{
    public partial class frmSetPreferredTestParameters : Form
    {
        bool unlocked = true;
        int _chamberPractitionerId = 0;

        public frmSetPreferredTestParameters()
        {
            InitializeComponent();
        }

        private void frmSetPreferredTestParameters_Load(object sender, EventArgs e)
        {
            HideAllDefaultHidden();


            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);
            _chamberPractitionerId = _user.ChamberPractitionerId;
            if (_chamberPractitionerId == 0)
            {
                _chamberPractitionerId = _user.CpId;
            }
            ChamberPractitioner Practitioner = new DoctorService().GetChamberPractitionerById(_chamberPractitionerId);


            ctlTestSearch.Location = new Point(txtTestCode.Location.X, txtTestCode.Location.Y);
            ctlTestSearch.ItemSelected += ctlTestSearch_ItemSelected;

        }

        private void ctlTestSearch_ItemSelected(SearchResultListControl<RxCPPreferredTest> sender, RxCPPreferredTest item)
        {
            txtTestCode.Text = item.TestName;
            txtTestCode.Tag = item;
            txtTestCode.Focus();
            sender.Visible = false;

            ShowTestParameters(item);
        }

        private void ShowTestParameters(RxCPPreferredTest item)
        {
            if (item.TestId > 0)
            {
                List<VMPreferredTestParameter> _ptpList = new RxService().GetPreferredTestParameterListByTestId(item.TestId).ToList();
                FillTestParamGrid(_ptpList);
            }
        }

        private void FillTestParamGrid(List<VMPreferredTestParameter> ptpList)
        {
            dgTestParams.Rows.Clear();
            dgTestParams.SuspendLayout();
            int srlNo = 0;
            foreach(var item in ptpList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                srlNo += 1;
                row.CreateCells(dgTestParams, srlNo, item.Parameter);
                dgTestParams.Rows.Add(row);
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlTestSearch.Visible = false;
        }

        private void txtTestCode_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtTestCode.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                   
                    string _txt = txtTestCode.Text;
                    HideAllDefaultHidden();
                    ctlTestSearch.Visible = true;
                    ctlTestSearch.txtSearch.Text = _txt;
                    ctlTestSearch.txtSearch.SelectionStart = ctlTestSearch.txtSearch.Text.Length;

                    ctlTestSearch.LoadDataByType(_chamberPractitionerId.ToString());
                }
            }
        }

        private void ctlTestSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtTestCode.Focus();
            }
        }
    }
}
