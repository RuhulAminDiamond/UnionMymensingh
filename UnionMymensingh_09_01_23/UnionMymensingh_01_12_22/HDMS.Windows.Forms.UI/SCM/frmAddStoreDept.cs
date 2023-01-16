using HDMS.Model.Store;
using HDMS.Model.Users;
using HDMS.Windows.Forms.UI.Controls;
using Services.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.SCM
{
    public partial class frmAddStoreDept : Form
    {
        public frmAddStoreDept()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Tag != null)
            {
                // if (txtIndentUser.Tag != null && !String.IsNullOrEmpty(txtName.Text))
                {
                    VMStoreDept stDept = (VMStoreDept)txtName.Tag;
                    // VMUserDetail _u = (VMUserDetail)txtIndentUser.Tag;

                   


                    StoreDept _dept = new StoreItemService().GetStoreDeptById(stDept.DeptId);
                    if (_dept != null)
                    {
                        _dept.Name = txtName.Text;
                       // _dept.ApprovalUserId = _userId;
                       // _dept.IndentUserId = 1;


                        if (new StoreItemService().UpdateStoreDept(_dept))
                        {
                            MessageBox.Show("Department updated successfully.");
                            txtName.Text = "";
                            txtName.Tag = null;
                            //txtIndentUser.Text = "";
                            //txtIndentUser.Tag = null;
                            LoadDepartments();
                        }
                    }
                }
            }
            else
            {

               {
        
                    int _userId = 0;

                    if (txtDepartmentHead.Tag != null)
                    {
                        VMUserDetail _u = (VMUserDetail)txtDepartmentHead.Tag;

                        _userId = _u.Id;
                    }

                    StoreDept _dept = new StoreDept();
                    _dept.Name = txtName.Text;
                    _dept.ApprovalUserId = _userId;
                    _dept.IndentUserId = _userId;
                  
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

        private void LoadDepartments()
        {
            List<StoreDept> _stDeptList = new StoreItemService().GetStoreDeptList();
            dgDepts.SuspendLayout();
            dgDepts.Rows.Clear();

            foreach (var item in _stDeptList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgDepts, item.DeptId, item.Name);
                dgDepts.Rows.Add(row);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StoreDept _smg = (StoreDept)cmbDepartment.SelectedItem;
            if (_smg.DeptId == 0)
            {
                MessageBox.Show("Plz. select Department and try again."); return;
            }

            int _userId = 0;

            if (txtIndentUser.Tag != null)
            {
                VMUserDetail _u = (VMUserDetail)txtIndentUser.Tag;

                _userId = _u.Id;
            }

            if (!String.IsNullOrEmpty(txtIndentUser.Text))
            {
                StoreDeptUser _stdept = new StoreDeptUser();
                _stdept.DeptId = _smg.DeptId;
                _stdept.UserId = _userId;

                new StoreItemService().StoreDeptUser(_stdept);

                MessageBox.Show("Department Wise User Entry Successful.");

                LoadDepartmentsUser();

                txtIndentUser.Text = "";

            }
            else
            {
                MessageBox.Show("Department Name Required.");
            }
        }

        private void LoadDepartmentsUser()
        {
            List<VMStoreDept> _deptList = new StoreItemService().GetStoreDeptUserList();

            dgUsers.SuspendLayout();
            dgUsers.Rows.Clear();

            foreach (var item in _deptList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgUsers, item.Name, item.LoginName);
                dgUsers.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddStoreDept_Load(object sender, EventArgs e)
        {
            ctrlUserSearchControl.Location = new Point(txtIndentUser.Location.X, txtIndentUser.Location.Y + txtIndentUser.Height);
            ctrlUserSearchControl.ItemSelected += ctrlUserSearchControl_ItemSelected;

            ctrlUserSearchControl1.Location = new Point(txtIndentUser.Location.X, txtIndentUser.Location.Y + txtIndentUser.Height);
            ctrlUserSearchControl1.ItemSelected += ctrlUserSearchControl1_ItemSelected;


            LoadDepartments();

            List<StoreDept> _sm = new StoreItemService().GetStoreDepartment();
            _sm.Insert(0, new StoreDept() { DeptId = 0, Name = "Select Parent" });
            cmbDepartment.DataSource = _sm;
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "DeptId";

            LoadDepartmentsUser();
        }

        private void ctrlUserSearchControl1_ItemSelected(SearchResultListControl<VMUserDetail> sender, VMUserDetail item)
        {
            txtDepartmentHead.Text = item.LoginName;
            txtDepartmentHead.Tag = item;
            ctrlUserSearchControl1.Visible = false;
            btnSave.Focus();
        }

        private void ctrlUserSearchControl_ItemSelected(SearchResultListControl<VMUserDetail> sender, VMUserDetail item)
        {
            txtIndentUser.Text = item.LoginName;
            txtIndentUser.Tag = item;
            ctrlUserSearchControl.Visible = false;
            btnSave.Focus();
        }

        private void txtIndentUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ctrlUserSearchControl.Visible = true;
                ctrlUserSearchControl.LoadData();
            }
        }

        private void ctrlUserSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtIndentUser.Focus();
            }
        }

        private void txtDepartmentHead_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ctrlUserSearchControl1.Visible = true;
                ctrlUserSearchControl1.LoadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
   

