using HDMS.Model.ShareHolder;
using HDMS.Service.ShareHolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.ShareHolder
{
    public partial class frmAddShareInfo : Form
    {
        public frmAddShareInfo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            long shareno; int totalshare; double facevalue;
            Int64.TryParse(txtShareNo.Text, out shareno);
            Int32.TryParse(txtTotalShare.Text, out totalshare);
            double.TryParse(txtFaceValue.Text, out facevalue);
            ShareHolderBasicData shd = lblSh.Tag as ShareHolderBasicData;

            if (txtShareNo.Tag != null)
            {
                //  VMshareTransfer vMshareTransfer = new ShareHolderService().GetVMShareHolderById(shd.ShId);
                ShareInfo sh = new ShareHolderService().GetShareHolderById(shd.ShId);
                sh.ShareNo = shareno;
                sh.TotalShare = totalshare;
                sh.FaceValue = facevalue;
                sh.ShId = shd.ShId;
                sh.TotalInvestment = (facevalue * (double)totalshare);


                if (new ShareHolderService().UpShareInfo(sh))
                {
                    MessageBox.Show("Updated Successfully");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Not Updated");
                }

            }
            else
            {
                if (!string.IsNullOrWhiteSpace(lblSh.Text))
                {
                    if (!string.IsNullOrWhiteSpace(txtShareNo.Text) && !string.IsNullOrWhiteSpace(txtFaceValue.Text) && !string.IsNullOrWhiteSpace(txtTotalShare.Text))
                    {
                        VMshareTransfer vMshareTransfer = new VMshareTransfer();
                        ShareInfo shareInfo = new ShareInfo();
                        shareInfo.ShareNo = shareno;
                        shareInfo.TotalShare = totalshare;
                        shareInfo.FaceValue = facevalue;
                        shareInfo.ShId = shd.ShId;
                        shareInfo.TotalInvestment = (facevalue * (double)totalshare);
                        vMshareTransfer.ShId = shd.ShId;
                        vMshareTransfer.Shareno = shareno;
                        vMshareTransfer.ShMobile = shd.ShMobile;
                        vMshareTransfer.ShPermanentAddress = shd.ShPermanentAddress;
                        if (new ShareHolderService().SaveShareInfo(shareInfo))
                        {
                            MessageBox.Show("Saved Successfully");
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Not Saved");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Fill up all required field");
                    }
                }
                else
                    MessageBox.Show("Please Select Shareholder Name");

            }
        }

        private void LoadData()
        {
            IList<ShareInfo> sh_list = new ShareHolderService().GetAllShareInfo();
            FillGrid(sh_list);
            txtShareNo.Text = "";
            txtFaceValue.Text = "";
            txtTotalShare.Text = "";
            lblAmount.Text = "";
            lblSh.Text = "";
            lblSh.Tag = null;
            txtShareNo.Tag = null;
        }

        private void FillGrid(IList<ShareInfo> sh_list)
        {
            dgShareInfo.SuspendLayout();
            dgShareInfo.Rows.Clear();
            foreach (ShareInfo sh in sh_list)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = sh;
                row.CreateCells(dgShareInfo, sh.ShareNo, sh.TotalShare, sh.FaceValue, sh.TotalInvestment);
                dgShareInfo.Rows.Add(row);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtShareNo.Text = "";
            txtTotalShare.Text = "";
            txtFaceValue.Text = "";
            lblSh.Text = "";
            lblAmount.Text = "";
            txtShareNo.Tag = null;
            lblSh.Tag = null;
            LoadData();
        }

        private void txtFaceValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            long totalshare; double facevalue;

            Int64.TryParse(txtTotalShare.Text, out totalshare);
            double.TryParse(txtFaceValue.Text, out facevalue);
            if (e.KeyChar == (char)Keys.Enter)
            {
                lblAmount.Text = (facevalue * (double)totalshare).ToString();
                btnSave.Focus();
            }
        }

        private void txtShareNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtTotalShare.Focus();
            }
        }

        private void txtTotalShare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtFaceValue.Focus();
            }
        }

        private void PhSearch2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PhSearch2.Text) || PhSearch2.Text.Trim() == "Search By Shareholder")
            {
                LoadShData();
                LoadData();
            }
            else
            {
                LoadShDataName(PhSearch2.Text);
            }
        }

        private void LoadShDataName(string text)
        {
            IList<ShareHolderBasicData> sh_list = new ShareHolderService().GetShareHolderByName(text);
            FillGridSh(sh_list);

        }

        private void LoadShData()
        {
            IList<ShareHolderBasicData> sh_list = new ShareHolderService().GetAllShareHolder();
            FillGridSh(sh_list);


        }

        private void FillGridSh(IList<ShareHolderBasicData> sh_list)
        {
            dgShShareInfo.SuspendLayout();
            dgShShareInfo.Rows.Clear();
            foreach (ShareHolderBasicData sh in sh_list)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = sh;
                row.CreateCells(dgShShareInfo, sh.ShId, sh.ShName);
                dgShShareInfo.Rows.Add(row);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddShareInfo_Load(object sender, EventArgs e)
        {
            LoadShData();
        }

        private void dgShShareInfo_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtShareNo.Text = "";
            txtFaceValue.Text = "";
            txtTotalShare.Text = "";
            lblAmount.Text = "";
            lblSh.Text = "";

            ShareHolderBasicData sh = dgShShareInfo.SelectedRows[0].Tag as ShareHolderBasicData;
            if (sh != null)
            {
                lblSh.Text = sh.ShName;
                lblSh.Tag = sh;
                IList<ShareInfo> sh_list = new ShareHolderService().DgSh(sh.ShId);
                FillGrid(sh_list);
            }
        }
    }
}
