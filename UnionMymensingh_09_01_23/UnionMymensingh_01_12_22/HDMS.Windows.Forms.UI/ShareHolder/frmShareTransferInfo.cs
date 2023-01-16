using HDMS.Model.ShareHolder;
using HDMS.Model.ShareHolder.VM;
using HDMS.Service.ShareHolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.ShareHolder
{
    public partial class frmShareTransferInfo : Form
    {
        public frmShareTransferInfo()
        {
            InitializeComponent();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Int32.TryParse(txtSellingAmount.Text, out int sellingAmount);

            if (txtReceiptNo.Tag != null)
            {
                VMShareTransferDetail transferDetail = txtReceiptNo.Tag as VMShareTransferDetail;
                ShareTransferInfo obj = new ShareHolderService().GetShareTransferRecord(transferDetail.transferId);

                long prevSellShareAmount = obj.SellShareAmount;

                obj.SellShareAmount = sellingAmount;
                obj.TDate = dtptfDob.Value;

                Int32.TryParse(txtShareCountStart.Text, out int shareCountStart);
                obj.ShareCountStart = shareCountStart;
                Int32.TryParse(txtShareCountEnd.Text, out int shareCountEnd);
                obj.ShareCountEnd = shareCountEnd;
                Int64.TryParse(txtReceiptNo.Text, out long receiptNo);
                obj.ReceiptNo = receiptNo;

                ShareInfo sh = new ShareHolderService().GetShareInfoById((int)obj.TrfFromId);
                if (sellingAmount > (sh.TotalShare + prevSellShareAmount))
                {
                    MessageBox.Show("Transferrer doesn't have this amount of share");
                    LoadDGVShareTransfer();
                    ClearForm();
                    return;
                }

                if (new ShareHolderService().UpdateShareTransferInfo(obj, prevSellShareAmount))
                {
                    MessageBox.Show("Updated successfully");
                }
                else
                {
                    MessageBox.Show("Failed! Unable to update now.");
                }
            }
            else
            {
                if (isvalid())
                {
                    

                    if (txtTransferFrom.Tag != null && txtTransferTo.Tag != null)
                    {
                        VMshareTransfer tranferFromObj = txtTransferFrom.Tag as VMshareTransfer;
                        ShareInfo sh = new ShareHolderService().GetShareInfoById(tranferFromObj.ShId);
                        VMshareTransfer tranferToObj = txtTransferTo.Tag as VMshareTransfer;
                        if (sellingAmount > sh.TotalShare)
                        {
                            MessageBox.Show("Transferrer doesn't have this amount of share");
                            LoadDGVShareTransfer();
                            ClearForm();
                            return;
                        }
                        VMTransferCarrier Obj = new VMTransferCarrier();
                        Obj.TransferFrom = tranferFromObj;
                        Obj.TransferTo = tranferToObj;
                        Obj.transferedShare = sellingAmount;
                        Obj.TDate = dtptfDob.Value;
                        Obj.TransferBy = MainForm.LoggedinUser.Name;

                        Int32.TryParse(txtShareCountStart.Text, out int shareCountStart);
                        Obj.ShareCountStart = shareCountStart;
                        Int32.TryParse(txtShareCountEnd.Text, out int shareCountEnd);
                        Obj.ShareCountEnd = shareCountEnd;
                        Int64.TryParse(txtReceiptNo.Text, out long receiptNo);
                        Obj.ReceiptNo = receiptNo;

                        if (new ShareHolderService().ShareTransfer(Obj))
                        {
                            MessageBox.Show("Transferred successfully");
                        }
                        else
                        {
                            MessageBox.Show("transfer Failed");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Failed! Please fill up all the required fields and try again.");
                }
            }
            LoadDGVShareTransfer();
            ClearForm();
        }

        private void ClearForm()
        {
            txtTransferFrom.Tag = null;
            txtTransferTo.Tag = null;
            txtReceiptNo.Tag = null;

            txtTransferFrom.Text = "";
            txtSellingAmount.Text = "";
            txtTransferTo.Text = "";
            txtReceiptNo.Text = "";
            dtptfDob.Value = DateTime.Now;
            txtShareCountStart.Text = "";
            txtShareCountEnd.Text = "";

            btnTransfer.Text = "Transfer";
        }

        private bool isvalid()
        {
            bool flag = true;
            if (string.IsNullOrWhiteSpace(txtTransferTo.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtTransferFrom.Text)) flag = false;
            if (string.IsNullOrWhiteSpace(txtSellingAmount.Text)) flag = false;
            return flag;
        }

        private void frmShareTransferInfo_Load(object sender, EventArgs e)
        {
            HideDefaultHidden();

            ctrlShareHolderFrom.Location = new Point(txtTransferFrom.Location.X, txtTransferFrom.Location.Y + txtTransferFrom.Height);
            ctrlShareHolderTo.Location = new Point(txtTransferTo.Location.X, txtTransferTo.Location.Y + txtTransferTo.Height);

            ctrlShareHolderFrom.ItemSelected += CtrlShareHolderFrom_ItemSelected;
            ctrlShareHolderTo.ItemSelected += CtrlShareHolderTo_ItemSelected;

            LoadDGVShareTransfer();
        }

        private void LoadDGVShareTransfer()
        {
            List<VMShareTransferDetail> transferInfoes = new ShareHolderService().GetShareTransferInfoes();

            dgvShareTransfer.SuspendLayout();
            dgvShareTransfer.Rows.Clear();

            foreach(var transferInfo in transferInfoes)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = transferInfo;
                row.CreateCells(dgvShareTransfer, transferInfo.TDate, transferInfo.ReceiptNo, transferInfo.SellShareAmount, transferInfo.TransferrerShareNo, transferInfo.ReceiverShareNo, transferInfo.TransferrerName, transferInfo.ReceiverName);

                dgvShareTransfer.Rows.Add(row);
            }

        }

        private void HideDefaultHidden()
        {
            ctrlShareHolderFrom.Visible = false;
            ctrlShareHolderTo.Visible = false;

        }

        private void CtrlShareHolderTo_ItemSelected(Controls.SearchResultListControl<VMshareTransfer> sender, VMshareTransfer item)
        {
            txtTransferTo.Text = item.ShName;
            txtTransferTo.Tag = item;
            dtptfDob.Focus();
            sender.Visible = false;
        }

        private void CtrlShareHolderFrom_ItemSelected(Controls.SearchResultListControl<VMshareTransfer> sender, VMshareTransfer item)
        {
            txtTransferFrom.Text = item.ShName;
            txtTransferFrom.Tag = item;
            txtSellingAmount.Focus();
            sender.Visible = false;
        }

        private void txtTransferFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ctrlShareHolderFrom.Visible = true;
                ctrlShareHolderFrom.LoadData();
            }


        }

        private void txtSellingAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtTransferTo.Focus();

            }
        }

        private void txtTransferTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ctrlShareHolderTo.Visible = true;
                ctrlShareHolderTo.LoadData();
            }


        }

        private void dtptfDob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnTransfer.Focus();
            }
        }

        private void ctrlShareHolderFrom_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtTransferFrom.Focus();
            }
        }

        private void ctrlShareHolderTo_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtTransferTo.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvShareTransfer_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnTransfer.Text = "Update";

            VMShareTransferDetail transferInfo = dgvShareTransfer.SelectedRows[0].Tag as VMShareTransferDetail;

            if(transferInfo != null)
            {
                //txtTransferFrom.Text = transferInfo.TransferrerName;
                txtTransferFrom.Text = "***This field can't be modified*** " + transferInfo.TransferrerName;
                txtSellingAmount.Text = transferInfo.SellShareAmount.ToString();
                //txtTransferTo.Text = transferInfo.ReceiverName;
                txtTransferTo.Text = "***This field can't be modified*** " + transferInfo.ReceiverName;
                txtReceiptNo.Text = transferInfo.ReceiptNo.ToString();
                dtptfDob.Value = transferInfo.TDate;
                txtShareCountStart.Text = transferInfo.ShareCountStart.ToString();
                txtShareCountEnd.Text = transferInfo.ShareCountEnd.ToString();

                txtReceiptNo.Tag = transferInfo;
            }
        }
    }
}
