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
using HDMS.Windows.Forms.UI.Controls;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmHpPackageSubItem : Form
    {
        public bool IsLoaded = false;

        public frmHpPackageSubItem()
        {
            InitializeComponent();
        }

        private void frmHpPackageSubItem_Load(object sender, EventArgs e)
        {

             ctrlServicetem.Location = new Point(txtName.Location.X, txtName.Location.Y + txtName.Height);
             ctrlServicetem.ItemSelected += ctrlServicetem_ItemSelected;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            LoadPackages();
        }

        private void ctrl_LostFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //if (ctrl.Tag is Color)
            ctrl.BackColor = Color.White;
        }

        private void ctrl_GotFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.NavajoWhite;
        }

        private void ctrlServicetem_ItemSelected(SearchResultListControl<ServiceHead> sender, ServiceHead item)
        {
            txtName.Text = item.ServiceHeadName.ToString();
            txtName.Tag = item;
            txtAmount.Text = item.Rate.ToString();
            btnSave.Focus();
            sender.Visible = false;
            ctrlServicetem.Visible = false;
        }

        private void LoadPackages()
        {
            IsLoaded = false;

            List<HpPackage> _pKgList = new HospitalService().GetAllHpPackages();
            _pKgList.Insert(0, new HpPackage() { PkgId = 0,Name = "Select Package" });
            cmbPackages.DataSource = _pKgList;
            cmbPackages.DisplayMember = "Name";
            cmbPackages.ValueMember = "PkgId";

            IsLoaded = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HpPackage _package = (HpPackage)cmbPackages.SelectedItem;

            if (_package.PkgId == 0)
            {
                MessageBox.Show("Plz. select package and try again."); return;
            }

            double _amount = 0;
            double.TryParse(txtAmount.Text, out _amount);

            if (txtAmount.Tag != null)
            {
                if (txtName.Tag != null && !String.IsNullOrEmpty(txtName.Text))
                {
                    ServiceHead _head = (ServiceHead)txtName.Tag;
                    HpPkgSubItem _subItem = (HpPkgSubItem)txtAmount.Tag;


                    _subItem.PkgId = _package.PkgId;
                    _subItem.ServiceId = _head.ServiceHeadId;
                    _subItem.Name = txtName.Text;
                    _subItem.Amount = _amount;

                    if (new HospitalService().UpdateHpPackageSubItem(_subItem))
                    {
                        MessageBox.Show("Package sub item updated successfully.");
                        LoadPackageSubItems(_package.PkgId);
                    }
                }
            }
            else
            {
                if (txtName.Tag != null && !String.IsNullOrEmpty(txtName.Text))
                {
                    ServiceHead _head = (ServiceHead)txtName.Tag;

                    HpPkgSubItem _sItem = new HpPkgSubItem();
                    _sItem.PkgId = _package.PkgId;
                    _sItem.ServiceId = _head.ServiceHeadId;
                    _sItem.Name = txtName.Text;
                    _sItem.Amount = _amount;

                    if (new HospitalService().SaveHpPackageSubItem(_sItem))
                    {
                        MessageBox.Show("Package sub item added successfully.");
                        LoadPackageSubItems(_package.PkgId);
                    }
                }
            }

        }

        private void LoadPackageSubItems(int pkgId)
        {
            List<HpPkgSubItem> _subItems= new HospitalService().GetHpPackageSubItems(pkgId);
            dgPkgSubItems.Rows.Clear();

            double _pkgAmount = 0;

            foreach(var item in _subItems)
            {
                _pkgAmount = _pkgAmount + item.Amount;

                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgPkgSubItems,item.PkgSubItemId, item.Name,item.Amount);

                dgPkgSubItems.Rows.Add(row);
            }

            txtPkgAmount.Text = _pkgAmount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlServicetem.Visible = true;
                ctrlServicetem.LoadData();
            }
        }

        private void HideAllDefaultHidden()
        {
            
            ctrlServicetem.Visible = false;
        }

        private void ctrlServicetem_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtName.Focus();
            }
        }

        private void cmbPackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsLoaded)
            {
                HpPackage _package = (HpPackage)cmbPackages.SelectedItem;
                LoadPackageSubItems(_package.PkgId);
            }
        }

        private void dgPkgSubItems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            HpPkgSubItem pkg = dgPkgSubItems.Rows[e.RowIndex].Tag as HpPkgSubItem;


            ServiceHead _sHead = new HospitalService().GetServiceHeadById(pkg.ServiceId);


            txtName.Text = pkg.Name;
            txtName.Tag = _sHead;
            txtAmount.Text = pkg.Amount.ToString();
            txtAmount.Tag = pkg;
        }
    }
}
