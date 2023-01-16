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
using HDMS.Service.Diagonstics;
using HDMS.Model.ViewModel;
using HDMS.Service.Rx;
using HDMS.Model.Rx;
using HDMS.Model.Rx.VModel;

namespace HDMS.Windows.Forms.UI.Rx
{
    public partial class frmAddTestTemplate : Form
    {
        bool unlocked = true;

        public frmAddTestTemplate()
        {
            InitializeComponent();
        }

        private void txtInvestigation_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtInvestigation.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtInvestigation.Text;
                    HideAllDefaultHidden();
                    ctlTestSearch.Visible = true;
                    ctlTestSearch.txtSearch.Text = _txt;
                    ctlTestSearch.txtSearch.SelectionStart = ctlTestSearch.txtSearch.Text.Length;

                    ctlTestSearch.LoadData();
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlTestSearch.Visible = false;
        }


        private IList<RxVMTestTemplate> _SelectedTests;
        private void frmAddTestTemplate_Load(object sender, EventArgs e)
        {

            _SelectedTests = new List<RxVMTestTemplate>();
            ctlTestSearch.Location = new Point(txtInvestigation.Location.X, txtInvestigation.Location.Y);
            ctlTestSearch.ItemSelected += ctlTestSearch_ItemSelected;
        }

        private void ctlTestSearch_ItemSelected(SearchResultListControl<TestItem> sender, TestItem item)
        {
            unlocked = false;
            txtInvestigation.Text = item.TestId.ToString();
            txtInvestigation.Tag = item;
            txtInvestigation.Focus();


            //new RxService().PopulateRxSelectedTestData(_SelectedTests, txtInvestigation.Tag as RxCPPreferredTest, txtInvestigation.Text,"0");
            FillTestGrid();




            txtInvestigation.Focus();
            txtInvestigation.Text = "";
            unlocked = true;
            sender.Visible = false;
        }

        private void FillTestGrid()
        {
            dgTests.SuspendLayout();
            dgTests.Rows.Clear();

            foreach(var  item in _SelectedTests)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgTests, item.CPPTId, item.Name);
                dgTests.Rows.Add(row);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(!String.IsNullOrEmpty(txtName.Text) && dgTests.Rows.Count > 0)
            {
                ChamberPractitioner _ch = null; // RxControl.consultant;

                RxCPTestTemplateMaster _templateMaster = new RxCPTestTemplateMaster();
                _templateMaster.Name = txtName.Text;
                _templateMaster.CPId = _ch.CPId;
                _templateMaster.CreateDate = Utils.GetServerDateAndTime();

                if(new RxService().SaveRxTestTemplateMaster(_templateMaster))
                {
                    List<RxCPTestTemplateDetail> _tdList = new List<RxCPTestTemplateDetail>();
                    foreach(var item in _SelectedTests)
                    {
                        RxCPTestTemplateDetail _templateDetail = new RxCPTestTemplateDetail();
                        _templateDetail.TemplateId = _templateMaster.TemplateId;
                        _templateDetail.CPPTId = item.CPPTId;
                        _tdList.Add(_templateDetail);
                    }

                    if (_tdList.Count > 0)
                    {
                        new RxService().SaveRxTestTemplateDetail(_tdList);
                    }

                    MessageBox.Show("Template created successfully.");

                    txtName.Text = "";
                    dgTests.Rows.Clear();
                   
                }

            }

        }
    }
}
