using HDMS.Model.Users;
using HDMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Common
{
    public partial class frmGrantAccessToMenus : Form
    {
        bool isLoaded = false;

        public frmGrantAccessToMenus()
        {
            InitializeComponent();
        }

        private void frmGrantAccessToMenus_Load(object sender, EventArgs e)
        {
            isLoaded = false;

            List<Role> _Role = new UserService().GetRoles();
            _Role.Insert(0, new Role() { RoleId = 0, Name = "Select Role" });
            cmbRole.DataSource = _Role;
            cmbRole.DisplayMember = "Name";
            cmbRole.ValueMember = "RoleId";

            List<Module> _parentmodule = new MenuModuleService()._GetParentModules();
            _parentmodule.Insert(0, new Module() { ModuleId = 0, Name = "Select Menu" });
            cmbMenuGroup.DataSource = _parentmodule;
            cmbMenuGroup.DisplayMember = "Name";
            cmbMenuGroup.ValueMember = "ModuleId";

            isLoaded = true;
        }

        private void cmbMenuGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {

                int _parentId = Convert.ToInt32(cmbMenuGroup.SelectedValue);
                int _userId = Convert.ToInt32(cmbRole.SelectedValue);

                List<Module> _mlist = new MenuModuleService().GetModulesByParentId(_parentId);
                dgMenu.AutoGenerateColumns = false;
                dgMenu.DataSource = _mlist;

                AddToStatusToGrid(_parentId, _userId);
            }

        }

        private void AddToStatusToGrid(int _pId, int _uId)
        {

            System.Windows.Forms.DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
         
            dgvCmb.ValueType = typeof(bool);
            dgvCmb.Name = "Chk";
            dgvCmb.HeaderText = "Is Allowed";
            dgMenu.Columns.Add(dgvCmb);

            List<ModulePermission> _mlist = new MenuModuleService().GetAllowedModules(_pId, _uId);

            foreach (DataGridViewRow row in dgMenu.Rows)
            {
                int _mId = Convert.ToInt32(row.Cells["Id"].Value);
                if (_mlist.Exists(x => x.ModuleId == _mId))
                {
                    chkParent.Checked = true;
                    row.Cells["Chk"].Value = true;
                }
                else
                {
                    row.Cells["Chk"].Value = false;
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int _parentId = Convert.ToInt32(cmbMenuGroup.SelectedValue);
            int _roleId = Convert.ToInt32(cmbRole.SelectedValue);

            List<ModulePermission> _mPermission = new List<ModulePermission>();
            new MenuModuleService().DeleteExitingPermission(_roleId, _parentId);

            List<ModulePermission> _mlist = new List<ModulePermission>();

             ModulePermission _mp = new ModulePermission();
            _mp.PermissionId = _roleId;
            _mp.PermissionType = ModulePermission.PermissionTypeEnum.Role;
            _mp.ModuleId = Convert.ToInt32(cmbMenuGroup.SelectedValue);
            _mp.Permission = HDMS.Model.Users.ModulePermission.PermissionEnum.Permitted;
            _mlist.Add(_mp);

            foreach (DataGridViewRow row in dgMenu.Rows)
            {
                if ((bool)row.Cells["Chk"].Value == true)
                {
                   _mp = new ModulePermission();
                   _mp.PermissionId = _roleId;
                   _mp.PermissionType = ModulePermission.PermissionTypeEnum.Role;
                   _mp.ModuleId = Convert.ToInt32(row.Cells["Id"].Value);
                   _mp.Permission = ModulePermission.PermissionEnum.Permitted;
                   _mlist.Add(_mp);
               }
                
               
            }

            if (_mlist != null)
            {
                if (new MenuModuleService().SavePermissionList(_mlist))
                {
                    MessageBox.Show("Permission granted.");
                }
            }
        }

        private void dgMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)//set your checkbox column index instead of 2
            {
                if (Convert.ToBoolean(dgMenu.Rows[e.RowIndex].Cells[0].EditedFormattedValue) == true)
                {
                    chkParent.Checked = true;
                }
            }
        }
    }
}
