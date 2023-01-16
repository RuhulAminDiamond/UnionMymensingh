using HDMS.Model.ShareHolder;
using HDMS.Service.ShareHolder;
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

namespace HDMS.Windows.Forms.UI.ShareHolder
{
    public partial class frmDividentWithdraw : Form
    {
        public frmDividentWithdraw()
        {
            InitializeComponent();
        }
        
        private void frmDividentWithdraw_Load(object sender, EventArgs e)
        {
            HideDefaultHidden();
            CtrlshareHolderSearch.Location =  new Point(txtSh.Location.X, txtSh.Location.Y + txtSh.Height);

            CtrlshareHolderSearch.ItemSelected += CtrlshareHolderSearch_ItemSelected;
        }

        private void CtrlshareHolderSearch_ItemSelected(Controls.SearchResultListControl<VMshareTransfer> sender, VMshareTransfer item)
        {
            txtSh.Text = item.ShName;
            txtSh.Tag = item;
            ShowCurrentDivident(item);
            sender.Visible = false;
        }

        private void ShowCurrentDivident(VMshareTransfer item)
        {
           
            List<ShareHolderLedger> shl = new ShareHolderService().GetShareHolderLedger(item.ShId);
            double balance = shl.Sum(x => x.Credit - x.Debit);
            lbldivident.Text = balance.ToString();
            txtWithdraw.Focus();
        }

        private void HideDefaultHidden()
        {
            CtrlshareHolderSearch.Visible = false;
            

        }
      
        private void btnSave_Click(object sender, EventArgs e)
        {

            double withdrawamount;
            double balance;

            double.TryParse(txtWithdraw.Text, out withdrawamount);
            double.TryParse(lbldivident.Text,out balance);

            if (withdrawamount > balance)
            {
                MessageBox.Show("Insufficient Balance");
                ClearField();
                return;
            }

            if (txtSh.Tag!=null)
            {

                VMshareTransfer sh = txtSh.Tag as VMshareTransfer;

                if(new ShareHolderService().WithDrawdivident(withdrawamount,sh.ShId,balance, MainForm.LoggedinUser.Name, Utils.GetServerDateAndTime()))
                {
                    MessageBox.Show("Withdrawn Successfull");
                    ClearField();
                }
                else
                {
                    MessageBox.Show("Withdrawn Failed");
                    ClearField();
                }
            }
            else
                MessageBox.Show("Please Fill Up All Required field");


        }

        private void ClearField()
        {
            txtSh.Text = "";
            txtWithdraw.Text = "";
            lbldivident.Text = "";
        }

        private void txtSh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                CtrlshareHolderSearch.Visible = true;
                CtrlshareHolderSearch.LoadData();
               
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                
            }
        }

        private void txtWithdraw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
