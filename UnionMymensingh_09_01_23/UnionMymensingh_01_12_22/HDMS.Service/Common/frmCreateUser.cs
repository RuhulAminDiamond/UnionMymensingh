using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Hospital;
using HDMS.Model.Pharmacy;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Service.Doctors;
using HDMS.Service.Hospital;
using HDMS.Service.Pharmacy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Common
{
    public partial class frmCreateUser : Form
    {
        bool isLoaded = false;
        public frmCreateUser()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgUsers.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgUsers.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Tag != null)
            {
                VMUserDetail _uDetail = (VMUserDetail)txtUserName.Tag;

                User _user = new UserService().GetUserById(_uDetail.Id);
                _user.FullName = txtFullName.Text;
                _user.MobileNo = txtMobileNo.Text;
                _user.RoleId = ((Role)cmbRole.SelectedItem).RoleId;

                new UserService().UpdateUser(_user);

                new MenuModuleService().DeleteAssignedPermission(_user.UserId);

                List<int> _selectedModules = new List<int>();
                foreach(ModulePermission _mp in _permissionList)
                {
                    _selectedModules.Add(_mp.ModuleId);
                }

                new MenuModuleService().GrantPermission(_selectedModules, _user.UserId);

                MessageBox.Show("Update Successful");

                txtUserName.Tag = null;
                LoadMenus();
                btnSave.Text = "Save";

                txtFullName.Text = "";
                txtMobileNo.Text = "";
                txtUserName.Text = "";

                LoadMenus();

            }
            else
            {
                if (txtUserName.Text.Contains(" "))
                {
                    MessageBox.Show("Login name should not contain any space", "HERP");
                    return;
                }

                if (String.IsNullOrEmpty(txtUserName.Text) || String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtConfirmPassword.Text))
                {
                    MessageBox.Show("Login name, password and confim password are mandatory field. ", "HERP");
                    return;
                }

                if (new UserService().IsLoginNameExists(txtUserName.Text))
                {
                    MessageBox.Show("Login name already taken by another user. Please try using another name ", "HERP");
                    return;
                }

                List<int> _selectedModules = CheckedModules(treeMenu.Nodes);

                if (_selectedModules.Count() == 0)
                {
                    MessageBox.Show("Plz. selecte at least one menu item");
                    return;
                }

                int _roleId = Convert.ToInt32(cmbRole.SelectedValue);
                int _consultantId = Convert.ToInt32(cmbConsultant.SelectedValue);

                if (_roleId == 9)
                {

                    if (_consultantId == 0)
                    {
                        MessageBox.Show("Please select consultant for this user name ", "HERP");
                        return;
                    }

                }else
                {
                    _consultantId = 0;
                }

                int _outLetId = Convert.ToInt32(cmbOutlet.SelectedValue);

                if (_roleId==20 || _roleId == 21 || _roleId == 34)
                {
                    if (_outLetId == 0)
                    {
                        MessageBox.Show("Please select outlet for this user name ", "HERP");
                        return;
                    }
                }else
                {
                    _outLetId = 0;
                }

                int _floorId = Convert.ToInt32(cmbFloor.SelectedValue);

                if (_roleId == 22 || _roleId >= 26 && _roleId <= 33)
                {
                 
                    if (_floorId == 0)
                    {
                        MessageBox.Show("Please select floor for this user name ", "HERP");
                        return;
                    }

                }


                if (String.Compare(txtPassword.Text, txtConfirmPassword.Text) == 0)
                {
                    string[] _arr = HashGenerator.GetPasswordHashAndSalt(txtPassword.Text);
                    User _user = new User();
                    _user.LoginName = txtUserName.Text;
                    _user.FullName = txtFullName.Text;
                    _user.MobileNo = txtMobileNo.Text;
                    _user.Password = _arr[0];
                    _user.RoleId = Convert.ToInt32(cmbRole.SelectedValue);
                    _user.AssignedOutLet = _outLetId;
                    _user.FloorId = _floorId;
                    _user.Salt = _arr[1];

                    _user.Status = "Active";

                    int _userId = new UserService().CreateUser(_user);

                    if (_userId > 0)
                    {

                        new MenuModuleService().GrantPermission(_selectedModules, _userId);

                        UserRole _urole = new UserRole();
                        _urole.UserId = _userId;
                        _urole.RoleId = Convert.ToInt32(cmbRole.SelectedValue);

                        // new UserService().MapUserWithRole(_urole);
                        MessageBox.Show("User created successfully.", "H-ERP");

                        if (_roleId == 9)
                        {
                            if (_consultantId > 0)
                            {
                                ReportConsultant _rConsultant = (ReportConsultant)cmbConsultant.Tag;
                                _rConsultant.ConsultantUserId = _userId;
                                new DoctorService().UpdateReportConsultant(_rConsultant);
                            }

                        }

                        ClearPage();
                        LoadActiveUsers();
                    }
                    else
                    {
                        MessageBox.Show("Fail to create user.", "HERP");
                    }

                }
                else
                {
                    MessageBox.Show("Password and confirm password did not match.", "HERP");
                }
            }
        }

        public List<int> CheckedModules(TreeNodeCollection theNodes)
        {
            List<int> aResult = new List<int>();

            if (theNodes != null)
            {
                foreach (TreeNode aNode in theNodes)
                {
                    if (aNode.Checked)
                    {
                        string[] arr = null;
                        arr = aNode.Tag.ToString().Split('|');
                        aResult.Add(Convert.ToInt32(arr[0]));
                    }

                    aResult.AddRange(CheckedModules(aNode.Nodes));
                }
            }

            return aResult;
        }

        private void ClearPage()
        {
            txtUserName.Text = "";
            txtFullName.Text = "";
            txtMobileNo.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        List<ModulePermission> _permissionList;
        private void frmCreateUser_Load(object sender, EventArgs e)
        {

            _permissionList = new List<ModulePermission>();

            isLoaded = false;

            List<Role> _role = new UserService().GetRoles();

            cmbRole.DataSource = _role;
            cmbRole.DisplayMember = "Name";
            cmbRole.ValueMember = "RoleId";


            LoadMenus();

            LoadOutlets();

            LoadFloors();

            cmbOutlet.Enabled = false;
            cmbFloor.Enabled = false;

            IList<ReportConsultant> ReportDoctors = new DoctorService().GetlAlReportDoctorOtherThanPathologyLegay();
            if (ReportDoctors != null)
            {
                ReportDoctors.Insert(0, new ReportConsultant()
                {
                    RCId = 0,
                    Name = "Select Consulatnt"
                });
            }

            cmbConsultant.DataSource = ReportDoctors;
            cmbConsultant.DisplayMember = "Name";
            cmbConsultant.ValueMember = "RCId";

            isLoaded = true;

            cmbConsultant.Enabled = false;

            LoadActiveUsers();

        }

        private void LoadFloors()
        {
            List<FloorInfo> _floorList = new HospitalService().GetFloors();
            _floorList.Insert(0, new FloorInfo() { FloorId = 0, Name = "Select Floor" });
            cmbFloor.DataSource = _floorList;
            cmbFloor.DisplayMember = "Name";
            cmbFloor.ValueMember = "FloorId";
        }

        private void LoadOutlets()
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmbOutlet.DataSource = _outletLists;
            cmbOutlet.DisplayMember = "Name";
            cmbOutlet.ValueMember = "OutletId";

        }

        private void LoadMenus()
        {
            List<HDMS.Model.Users.Module> _PermittedParentsList = new MenuModuleService().GetAllMenus();

            if (_PermittedParentsList.Count() > 0)
            {
                treeMenu.Nodes.Clear();
                FillNode(_PermittedParentsList, null);
                treeMenu.ExpandAll();
            }

        }

        private void FillNode(List<HDMS.Model.Users.Module> items, TreeNode node)
        {
            string[] strArr = null;

            if (node != null)
            {
                strArr = node.Tag.ToString().Split('|');
            }

            var parentID = node != null
                ? Convert.ToInt32(strArr[0])
                : 0;

            var nodesCollection = node != null
                ? node.Nodes
                : treeMenu.Nodes;

            foreach (var item in items.Where(i => i.ParentId == parentID))
            {
                var newNode = nodesCollection.Add(item.Name, item.Name);
                newNode.Tag = item.ModuleId + "|" + item.frmName + "|" + item.DisplayType;

                FillNode(items, newNode);
            }


        }


        private void LoadActiveUsers()
        {
            List<VMUserDetail> _userDetail = new UserService().GetUserDetails().ToList();

            dgUsers.SuspendLayout();
            dgUsers.Rows.Clear();
            foreach (VMUserDetail user in _userDetail)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 35;
                row.Tag = user;
                row.CreateCells(dgUsers, user.Id, user.LoginName,user.FullName,user.MobileNo, user.RoleName, user.Status, false);
                dgUsers.Rows.Add(row);
            }

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded) {
                int _roleId = Convert.ToInt32(cmbRole.SelectedValue);
               
                if (_roleId ==9)
                {
                    cmbConsultant.Enabled = true;
                }
                else
                {
                    cmbConsultant.Enabled = false;
                }


                if (_roleId == 20 || _roleId==21 || _roleId==34)
                {
                    cmbOutlet.Enabled = true;
                }
                else
                {
                    cmbOutlet.Enabled = false;
                }

                if (_roleId == 22 || _roleId >= 26 && _roleId <= 36)
                {
                    cmbFloor.Enabled = true;

                }else
                {
                    cmbFloor.Enabled = false;
                }


            }
        }

        private void cmbConsultant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {

                ReportConsultant _rConsultant = new DoctorService().GetReportConsultantById(Convert.ToInt32(cmbConsultant.SelectedValue));
                cmbConsultant.Tag = _rConsultant;
            }
        }

        private void dgUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _permissionList = new List<ModulePermission>();

            VMUserDetail _udetail = dgUsers.SelectedRows[0].Tag as VMUserDetail;
            txtUserName.Tag = _udetail;
            btnSave.Text = "Update";

            _permissionList = new MenuModuleService().GetPermittedModulesByUserId(_udetail.Id);
            LoadMenus();

            foreach(ModulePermission _permission in _permissionList)
            {
                CheckPermittedNode(_permission.ModuleId,treeMenu.Nodes);

            }

            txtUserName.Text = _udetail.LoginName;
            txtFullName.Text = _udetail.FullName;
            txtMobileNo.Text = _udetail.MobileNo;
            List<Role> _role = new UserService().GetRoles();
            
            cmbRole.SelectedItem = _role.Find(q => q.RoleId == new UserService().GetRoleByName(_udetail.RoleName).RoleId); ;
            cmbRole.DisplayMember = "Name";
            cmbRole.ValueMember = "RoleId";
            
        }

        private void CheckPermittedNode(int moduleId, TreeNodeCollection tNodes)
        {
            foreach(TreeNode node in tNodes)
            {
                string[] arr = null;
                arr = node.Tag.ToString().Split('|');
                if(Convert.ToInt32(arr[0])== moduleId)
                {
                    node.Checked = true;

                }else
                {
                    if (node.Nodes.Count > 0)
                    {
                        CheckPermittedNode(moduleId, node.Nodes);
                    }
                }
            }
        }

        private void treeMenu_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (e.Node.Checked)
            {
                if (txtUserName.Tag != null && _permissionList.Count > 0)
                {
                    
                    string[] arr = null;
                    arr = e.Node.Tag.ToString().Split('|');
                    if (_permissionList.Any(x => x.ModuleId == Convert.ToInt32(arr[0]))){ return; }

                    _permissionList.Add(new ModulePermission { PermissionId = MainForm.LoggedinUser.UserId, PermissionType = ModulePermission.PermissionTypeEnum.User, ModuleId = Convert.ToInt32(arr[0]), Permission = ModulePermission.PermissionEnum.Permitted });


                }
            }

            if (!e.Node.Checked)
            {
                if(txtUserName.Tag!=null && _permissionList.Count > 0)
                {
                    string[] arr = null;
                    arr = e.Node.Tag.ToString().Split('|');
                    var moduleToRemove = _permissionList.SingleOrDefault(s => s.ModuleId == Convert.ToInt32(arr[0]));
                    if (moduleToRemove.ModuleId != 0)
                    {
                        _permissionList.Remove(moduleToRemove);
                    }

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Tag = null;
            LoadMenus();
            btnSave.Text = "Save";

            txtFullName.Text = "";
            txtMobileNo.Text = "";
            txtUserName.Text = "";
        }
    }
}
