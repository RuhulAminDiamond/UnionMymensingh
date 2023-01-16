using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Users;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.Store;
using Services.Store;

namespace HDMS.Windows.Forms.UI.FoodAndBeverage
{
    public partial class frmAddFBDept : Form
    {
        public frmAddFBDept()
        {
            InitializeComponent();
        }

        private void frmAddStoreDept_Load(object sender, EventArgs e)
        {
            ctrlUserSearchControl.Location = new Point(txtIndentUser.Location.X, txtIndentUser.Location.Y + txtIndentUser.Height);
            ctrlUserSearchControl.ItemSelected += ctrlUserSearchControl_ItemSelected;

            LoadDepartments();
        }

        private void ctrlUserSearchControl_ItemSelected(SearchResultListControl<VMUserDetail> sender, VMUserDetail item)
        {
            txtIndentUser.Text = item.LoginName;
            txtIndentUser.Tag = item;
            ctrlUserSearchControl.Visible = false;
            btnSave.Focus();
        }

        private void LoadDepartments()
        {
            List<VMStoreDept> _stDeptList = null; // new StoreItemService().GetStoreDeptList();
            dgDepts.SuspendLayout();
            dgDepts.Rows.Clear();

            foreach (var item in _stDeptList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgDepts, item.DeptId, item.Name, item.LoginName, item.FullName);
                dgDepts.Rows.Add(row);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Tag != null)
            {
                if (txtIndentUser.Tag != null && !String.IsNullOrEmpty(txtName.Text))
                {
                    VMStoreDept stDept = (VMStoreDept)txtName.Tag;
                    VMUserDetail _u = (VMUserDetail)txtIndentUser.Tag;

                    StoreDept _dept = new StoreItemService().GetStoreDeptById(stDept.DeptId);
                    if (_dept != null)
                    {
                        _dept.Name = txtName.Text;
                        //_dept.IndentUserId = _u.Id;

                        if (new StoreItemService().UpdateStoreDept(_dept))
                        {
                            MessageBox.Show("Department updated successfully.");
                            txtName.Text = "";
                            txtName.Tag = null;
                            txtIndentUser.Text = "";
                            txtIndentUser.Tag = null;
                            LoadDepartments();
                        }
                    }
                }
            }
            else
            {

                if (txtIndentUser.Tag != null && !String.IsNullOrEmpty(txtName.Text))
                {

                    VMUserDetail _u = (VMUserDetail)txtIndentUser.Tag;

                    StoreDept _dept = new StoreDept();
                    _dept.Name = txtName.Text;
                   // _dept.IndentUserId = _u.Id;
                    if (new StoreItemService().CreateDepartment(_dept))
                    {
                        MessageBox.Show("Department created successfully.");
                        txtName.Text = "";
                        txtName.Tag = null;
                        txtIndentUser.Text = "";
                        txtIndentUser.Tag = null;
                        LoadDepartments();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgDepts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgDepts.Rows.Count > 0)
            {
                VMStoreDept _dept = dgDepts.SelectedRows[0].Tag as VMStoreDept;
                if (_dept != null)
                {
                    txtName.Text = _dept.Name;
                    txtName.Tag = _dept;
                }
            }
        }

        private void txtIndentUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ctrlUserSearchControl.Visible = true;
                ctrlUserSearchControl.LoadData();
            }
        }
    }
}
