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
    public partial class frmIssueRightShare : Form
    {
        public frmIssueRightShare()
        {
            InitializeComponent();
        }

        private void frmIssueRightShare_Load(object sender, EventArgs e)
        {
            ctrlShareHolderFrom.Location = new Point(txtShareHolder.Location.X, txtShareHolder.Location.Y + txtShareHolder.Height);
            ctrlShareHolderFrom.ItemSelected += CtrlShareHolderFrom_ItemSelected;
        }

        private void CtrlShareHolderFrom_ItemSelected(SearchResultListControl<VMshareTransfer> sender, VMshareTransfer item)
        {
            txtShareHolder.Text = item.ShName;
            txtShareHolder.Tag = item;
            GetDistributedShare(item, dtp.Value);
            sender.Visible = false;
        }

        private void GetDistributedShare(VMshareTransfer item, DateTime _dt)
        {
            RightShareInfo _rsi = new ShareHolderService().GetRightShareInfo(item.ShId, _dt.Year);
            if (_rsi != null)
            {
                txtShare.Text = _rsi.RightShare.ToString();
                txtShare.Tag = _rsi.RightShare;
            }
        }

        private void txtShareHolder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ctrlShareHolderFrom.Visible = true;
                ctrlShareHolderFrom.LoadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

            if (txtShare.Tag == null) return;
            
            
            int _issuedShare = 0, distributedShare=0;
            int.TryParse(txtShare.Text, out _issuedShare);

            int.TryParse(txtShare.Tag.ToString(), out distributedShare); 

            if(_issuedShare> distributedShare)
            {
                MessageBox.Show("Issued share can not be greater than right share."); return;
            }

            if(txtShareHolder.Tag!=null && _issuedShare > 0)
            {
                if(new ShareHolderService().IssueRightShare(txtShareHolder.Tag as VMshareTransfer, _issuedShare, Utils.GetServerDateAndTime().Year, txtParticulars.Text))
                {
                    MessageBox.Show("Right Share Issue Successful.");
                    txtShareHolder.Tag = null;
                }
            }

        }
    }
}
