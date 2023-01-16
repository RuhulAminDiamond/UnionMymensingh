using HDMS.Model.Users;
using HDMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HDMS.Model.Users.ModulePermission;

namespace HDMS.Service
{
    public class MenuModuleService
    {
        public List<Module> _GetParentModules()
        {
            
                return new MenuModuleRepository()._GetParentModules();
          
        }

        public List<Module> GetModulesByParentId(int _parentId)
        {
            return new MenuModuleRepository().GetModulesByParentId(_parentId);
        }

        public List<ModulePermission> GetAllowedModules(int _pId, int _uId)
        {
            return new MenuModuleRepository().GetAllowedModules(_pId, _uId);
        }

        public void DeleteExitingPermission(int _userId, int _parentId)
        {
            new MenuModuleRepository().DeleteExitingPermission(_userId, _parentId);
        }

        public bool SavePermissionList(List<ModulePermission> _mlist)
        {
          return  new MenuModuleRepository().SavePermissionList(_mlist);
        }

        public List<Module> GetPermittedParentsByUser(int userId)
        {
            return new MenuModuleRepository().GetPermittedParentsByUser(userId);
        }

        public List<Model.Users.Module> GetParentModules()
        {
            return new MenuModuleRepository().GetParentModules();
        }

        public void DeleteAssignedPermission(int userId)
        {
            new MenuModuleRepository().DeleteAssignedPermission(userId);
        }

        public void GrantPermission(List<int> _selectedModules, int _userId)
        {
            new MenuModuleRepository().GrantPermission(_selectedModules, _userId);
        }

        public List<ModulePermission> GetPermittedModulesByUserId(int _userId)
        {
           return   new MenuModuleRepository().GetPermittedModulesByUserId(_userId);
        }

        public List<Module> GetAllMenus()
        {
            return new MenuModuleRepository().GetAllMenus();
        }

        public void GrantCpAssistantPermission(int moduleId, int userId)
        {
            ModulePermission mp = new ModulePermission();
            mp.ModuleId = moduleId;
            mp.PermissionId = userId;
            mp.PermissionType = PermissionTypeEnum.User;
            mp.Permission = PermissionEnum.Permitted;
            new MenuModuleRepository().GrantCpAssistantPermission(mp);

        }
    }
}
