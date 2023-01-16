using HDMS.Model.Hospital;
using HDMS.Service.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmHpPackageCreate : Form
    {
        public frmHpPackageCreate()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double _pkgAmount = 0;
            double.TryParse(txtPkgAmount.Text, out _pkgAmount);

            if (!String.IsNullOrEmpty(txtName.Text))
            {
                if (txtName.Tag != null)
                {
                    HpPackage _pkg = (HpPackage)txtName.Tag;
                    _pkg.Name = txtName.Text;
                   // _pkg.Amount = Convert. ToInt64(txtPkgAmount.Text);
                    _pkg.PkgTotal = _pkgAmount;
                    if (new HospitalService().UpdateHpPackage(_pkg))
                    {
                        MessageBox.Show("Package updated successfully.");
                        LoadPackages();
                    }

                }
                else
                {
                    
                    HpPackage _pkg = new HpPackage();
                    _pkg.Name = txtName.Text;
                    _pkg.PkgTotal = _pkgAmount;

                    if (new HospitalService().SaveHpPackage(_pkg))
                    {
                        MessageBox.Show("Package created successfully.");
                        LoadPackages();
                    }



                }
            }
        }

        private void LoadPackages()
        {
            List<HpPackage> _pKgList = new HospitalService().GetAllHpPackages();

            dgPackages.Rows.Clear();

            foreach (var item in _pKgList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgPackages,item.PkgId,item.Name,item.PkgTotal);

                dgPackages.Rows.Add(row);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHpPackageCreate_Load(object sender, EventArgs e)
        {
            LoadPackages();
        }

        private void dgPackages_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            HpPackage pkg = dgPackages.Rows[e.RowIndex].Tag as HpPackage;

            txtName.Text = pkg.Name;
            txtPkgAmount.Text = pkg.PkgTotal.ToString();
            txtName.Tag = pkg;

        }
    }
}
