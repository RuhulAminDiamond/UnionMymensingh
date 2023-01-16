using HDMS.Model;
using HDMS.Model.Diagnostic;
using HDMS.Service.Diagonstics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts.Diag
{
    public partial class frmCategoryIdWtihReportTyeIdWithCommission : Form
    {
        public frmCategoryIdWtihReportTyeIdWithCommission()
        {
            InitializeComponent();

            ctrlReportTypeSearchControl.Location = new Point(txtReportType.Location.X, txtReportType.Location.Y + txtReportType.Height);


            ctrlReportTypeSearchControl.ItemSelected += ctrlReportTypeSearchControl_ItemSelected;

            ctrlMeidaCategoryController.Location = new Point(txtCategoryName.Location.X, txtCategoryName.Location.Y + txtCategoryName.Height);

            ctrlMeidaCategoryController.ItemSelected += ctrlMeidaCategoryController_ItemSelected;




            // LoadAllReportType();
            //LoadAllMediaCategory();
            HiddenAllDefaults();
            GetAllMediaCommissionTypeWithReportId();
        }

        private void frmCategoryIdWtihReportTyeIdWithCommission_Load(object sender, EventArgs e)
        {
            GetAllMediaCommissionTypeWithReportId();
        }

        //private void LoadAllMediaCategory()
        //{

        //    IList<MediaCategory> mediaCategory = new DiagFinancialService().GetAllMediaCategory();

        //    foreach(MediaCategory m in mediaCategory)
        //    {
        //        cmbCategoryType.Items.Add(m.CategoryName);
        //    }
        //    cmbCategoryType.Tag = mediaCategory;
        //}

        private void LoadAllReportType()
        {

            List<ReportType> reportType = new DiagFinancialService().LoadAllReportType();



        }

        private void ctrlReportTypeSearchControl_ItemSelected(Controls.SearchResultListControl<ReportType> sender, ReportType item)
        {
            txtReportType.Text = item.Report_Type;
            txtReportType.Tag = item;
            sender.Visible = false;
        }

        private void HiddenAllDefaults()
        {
            ctrlReportTypeSearchControl.Visible = false;
            ctrlMeidaCategoryController.Visible = false;
        }

        private void txtReportType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HiddenAllDefaults();
                ctrlReportTypeSearchControl.Visible = true;
                ctrlReportTypeSearchControl.LoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {



            ReportType reportType = txtReportType.Tag as ReportType;
            MediaCategory cate = txtCategoryName.Tag as MediaCategory;

            if(cate == null)
            {
                MessageBox.Show("Place Slect Category ");

                return;
            }


            if (!String.IsNullOrEmpty(txtCategoryName.Text))
            {
                //int _categoryId = 0;
                //int _repotTypeId = 0;
                double _commissionPercent = 0;
                double _commissionTk = 0;
                double.TryParse(txtCommissionTK.Text, out _commissionTk);
                double.TryParse(txtCommissionPercent.Text, out _commissionPercent);
                MediaCategoryReportTypeCommission mtc = new MediaCategoryReportTypeCommission();


                if (_commissionTk != 0 && _commissionPercent != 0)
                {
                    MessageBox.Show(" You can  Only one Commission Taka  or commission Percent ");
                    txtCommissionPercent.Text = "";
                    return;
                }

                if (_commissionPercent > 0)
                {
                    mtc.IsPercent = true;

                }

                mtc.CategoryId = cate.CategoryId;
                mtc.ReportTypeId = reportType.ReportTypeId;
                mtc.Commission = _commissionTk;
                mtc.CommissionPercent = _commissionPercent;



                if (new DiagFinancialService().SaveCategroyAndReprotTypeId(mtc))
                {
                    MessageBox.Show("Data has been Saved");
                    GetAllMediaCommissionTypeWithReportId();

                }
            }
            else
            {
                MessageBox.Show("place Select Categroy Name ");
            }


        }

        private void ctrlMeidaCategoryController_ItemSelected(Controls.SearchResultListControl<MediaCategory> sender, MediaCategory item)
        {
            txtCategoryName.Text = item.CategoryName;
            txtCategoryName.Tag = item;
            sender.Visible = false;


        }


        private void txtCategoryName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HiddenAllDefaults();
                ctrlMeidaCategoryController.Visible = true;
                ctrlMeidaCategoryController.LoadData();
            }
        }


        /*======================* Update *==========================*/

        private void UpdateMediaCommissionType()
        {

            ReportType reportType = txtReportType.Tag as ReportType;
            MediaCategory cate = txtCategoryName.Tag as MediaCategory;
            VMMediaCategoryReportTypeCommission item = txtCategoryName.Tag as VMMediaCategoryReportTypeCommission;

            if (!String.IsNullOrEmpty(txtCategoryName.Text))
            {
                //int _categoryId = 0;
                //int _repotTypeId = 0;
                double _commissionPercent = 0;
                double _commissionTk = 0;
                double.TryParse(txtCommissionTK.Text, out _commissionTk);
                double.TryParse(txtCommissionPercent.Text, out _commissionPercent);
                MediaCategoryReportTypeCommission mtc = new MediaCategoryReportTypeCommission();


                if (_commissionTk != 0 && _commissionPercent != 0)
                {
                    MessageBox.Show(" You can  Only one Commission Taka  or commission Percent ");
                    txtCommissionPercent.Text = "";
                    return;
                }

                if (_commissionPercent > 0)
                {
                    mtc.IsPercent = true;

                }

                mtc.CategoryId = item.CategoryId;
                mtc.ReportTypeId = item.ReportTypeId;
                mtc.Commission = _commissionTk;
                mtc.CommissionPercent = _commissionPercent;
                mtc.CategoryRepotTypeId = item.CategoryRepotTypeId;



                if (new DiagFinancialService().UpdateMediaCommissionType(mtc))
                {
                    MessageBox.Show("Data has been updated Succssfull");
                    GetAllMediaCommissionTypeWithReportId();

                }
            }
            else
            {
                MessageBox.Show("place Select Categroy Name ");
            }

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /*===================* Get All Media Commission Type  *=========================*/

        private void GetAllMediaCommissionTypeWithReportId()
        {
            List<VMMediaCategoryReportTypeCommission> vMMediaCategoryReportTypeCommission = new DiagFinancialService().GetAllMediaCommissionTypeWithReportId();
            FillGridCommissionType(vMMediaCategoryReportTypeCommission);

        }

        private void FillGridCommissionType(List<VMMediaCategoryReportTypeCommission> vmcrtc)
        {

            dgMediaCommission.SuspendLayout();
            dgMediaCommission.Font = new Font("Arial", 16, GraphicsUnit.Pixel);

            dgMediaCommission.Rows.Clear();
            foreach (VMMediaCategoryReportTypeCommission item in vmcrtc)
            {

                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.Font = new Font("Arial", 14.0f, GraphicsUnit.Pixel);
                row.Tag = item;
                row.CreateCells(dgMediaCommission, item.CategoryName, item.Report_Type, item.ReportTypeId, item.Commission, item.CommissionPercent);
                dgMediaCommission.Rows.Add(row);

            }
        }

        private void dgMediaCommission_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtCategoryName.Enabled = false;
            txtReportType.Enabled = false;
            if (e.RowIndex>= 0)
            {
                DataGridViewRow row = dgMediaCommission.Rows[e.RowIndex];
                txtCategoryName.Text = row.Cells["CategoryName"].Value.ToString();
                txtReportType.Text = row.Cells["ReportTypeName"].Value.ToString();
                txtCommissionTK.Text = row.Cells["Commission"].Value.ToString();
                txtCommissionPercent.Text = row.Cells["CommissionPercent"].Value.ToString();
                txtCategoryName.Tag = row.Tag;

            }

            // MessageBox.Show(e.RowIndex + " ");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            UpdateMediaCommissionType();
        }

    

        private void ctrlReportTypeSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtReportType.Focus();
            }
        }

        private void ctrlMeidaCategoryController_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtCategoryName.Focus();
            }
        }
    }
}
