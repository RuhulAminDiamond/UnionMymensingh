using HDMS.Model.ShareHolder;
using HDMS.Model.ShareHolder.VM;
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
    public partial class frmRightShareDistribution : Form
    {
        bool isLoaded=false;
        
        public frmRightShareDistribution()
        {
            InitializeComponent();
        }

        private void frmRightShareDistribution_Load(object sender, EventArgs e)
        {
            isLoaded = false;
            
            List<int> years = new List<int>();
            for(int count = -10; count <= 50; count++)
            {
                int year = DateTime.Now.AddYears(count).Year;
                years.Add(year);
            }

            cmbFiscalYear.DataSource = years;

            isLoaded = true;
        }

        private void btnDistribute_Click(object sender, EventArgs e)
        {
            int.TryParse(cmbFiscalYear.Text, out int fiscalYear);
            double.TryParse(txtRightShare.Text, out double rightShare);

            if(fiscalYear != 0 && rightShare != 0)
            {
                if(new ShareHolderService().IsRightShareDistributed(fiscalYear))
                {
                    new ShareHolderService().DeleteRightShareInfoes(fiscalYear);
                }

                if(new ShareHolderService().DistributeRightShare(fiscalYear, rightShare))
                {
                    MessageBox.Show("Distributed successfully");

                    List<VMRightShareInfo> rsList = new ShareHolderService().GetDistributedRightShareList(fiscalYear);
                    FillRightShareGrid(rsList);
                }
                else
                {
                    MessageBox.Show("Distribution failed");
                }
            }
            else
            {
                MessageBox.Show("Please fill out all the fields with valid data.");
            }    
        }

        private void FillRightShareGrid(List<VMRightShareInfo> rsList)
        {
            dgRightShare.SuspendLayout();
            dgRightShare.Rows.Clear();
            double _totalRightShare = 0;
            foreach(var item in rsList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                _totalRightShare = _totalRightShare + item.RightShare;
                row.CreateCells(dgRightShare, item.ShName, item.TotalShare, item.RightShare, item.IssuedShare,item.ExtraShare);
                dgRightShare.Rows.Add(row);
            }

            lblTotalRightShare.Text = _totalRightShare.ToString();
        }

        private void cmbFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (isLoaded)
            {
                int _fiscalYear = 0;
                lblFiscalYear.Text = cmbFiscalYear.Text;
                int.TryParse(lblFiscalYear.Text, out _fiscalYear);
                List<VMRightShareInfo> rsList = new ShareHolderService().GetDistributedRightShareList(_fiscalYear);
                FillRightShareGrid(rsList);
            }

        }

        private void btnDeleteCurrentDistribution_Click(object sender, EventArgs e)
        {
            if (dgRightShare.Rows.Count > 0)
            {
                int _fiscalYear = 0;
                lblFiscalYear.Text = cmbFiscalYear.Text;
                int.TryParse(lblFiscalYear.Text, out _fiscalYear);
                new ShareHolderService().DeleteRightShareInfoes(_fiscalYear);
                List<VMRightShareInfo> rsList = new ShareHolderService().GetDistributedRightShareList(_fiscalYear);
                FillRightShareGrid(rsList);
                MessageBox.Show("Right Share Deleted.");
            }
        }
    }
}
