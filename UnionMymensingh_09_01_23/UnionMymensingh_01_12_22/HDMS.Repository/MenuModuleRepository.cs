using HDMS.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HDMS.Model.Users.ModulePermission;

namespace HDMS.Repository
{
    public class MenuModuleRepository
    {

        string sql = string.Empty;
        public List<Module> _GetParentModules()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Modules.Where(x=>x.ParentId==0).ToList();
            }
        }

       
        public List<Module> GetModulesByParentId(int _parentId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Modules.Where(x => x.ParentId == _parentId).ToList();
            }
        }

        public List<ModulePermission> GetAllowedModules(int _pId, int _uId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ModulePermissions.SqlQuery("select p.Id,p.PermissionId,p.PermissionType,p.ModuleId,p.Permission from ModulePermission p join Module m on p.ModuleId=m.ModuleId where p.PermissionId={0} and m.ParentId={1}",_uId,_pId).ToList();
            }
        }

        public void DeleteExitingPermission(int _userId, int _parentId)
        {
            using (DBEntities entities = new DBEntities())
            {
                IEnumerable<ModulePermission> list = entities.ModulePermissions.SqlQuery(@"select [dbo].[ModulePermission].* from [dbo].[ModulePermission] join [dbo].[Module] on [ModulePermission].ModuleId=
                [Module].ModuleId and [Module].ParentId={0} and [ModulePermission].PermissionId={1}", _parentId, _userId).ToList();
                entities.ModulePermissions.RemoveRange(list);
                entities.SaveChanges();
            }
        }

        public void DeleteAssignedPermission(int userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                 entities.ModulePermissions.RemoveRange(entities.ModulePermissions.Where(x=>x.PermissionId== userId));
                 entities.SaveChanges();
            }
        }

        public List<Module> GetAllMenus()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Modules.OrderBy(x => x.DisplayOrder).ToList();
            }
        }

        public List<ModulePermission> GetPermittedModulesByUserId(int _userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ModulePermissions.Where(x => x.PermissionId == _userId).ToList();
            }
        }

        public void GrantCpAssistantPermission(ModulePermission mp)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.ModulePermissions.Add(mp);
                entities.SaveChanges();
            }
        }
        public void GrantPermission(List<int> _selectedModules, int _userId)
        {
            List<ModulePermission> _permissionList = new List<ModulePermission>();
            foreach (int _modId in _selectedModules)
            {
                ModulePermission _mp = new ModulePermission();
                _mp.PermissionId = _userId;
                _mp.PermissionType = PermissionTypeEnum.User;
                _mp.ModuleId = _modId;
                _mp.Permission = PermissionEnum.Permitted;
                _permissionList.Add(_mp);
            }

            using (DBEntities entities = new DBEntities())
            {
                entities.ModulePermissions.AddRange(_permissionList);
                entities.SaveChanges();
            }
        }
        public List<Module> GetPermittedParentsByUser(int userId)
        {

            using (DBEntities entities = new DBEntities())
            {
                sql = string.Format(@"Select * from Module Where ModuleId in (select  Module.ModuleId from Module join  ModulePermission on  Module.ModuleId=ModulePermission.ModuleId  where  Module.IsActive=1 and   ModulePermission.PermissionId={0})", userId);
                return entities.Modules.SqlQuery(sql).ToList();
            }

       }

        public bool SavePermissionList(List<ModulePermission> _mlist)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.ModulePermissions.AddRange(_mlist);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<Model.Users.Module> GetParentModules()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Modules.Where(x => x.ParentId == 0).ToList();
            }
        }
    }
}
