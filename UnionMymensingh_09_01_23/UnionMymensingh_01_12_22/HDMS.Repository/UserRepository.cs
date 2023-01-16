using HDMS.Model;
using HDMS.Model.Users;
using HDMS.Repository.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace HDMS.Repository
{
    public class UserRepository
    {

        string sql = string.Empty;

        public LoginUser GetUserByName(string userName)
        {
            using(DBEntities entitties =new DBEntities())
            {
                var anom = entitties.Users.Select(s => new 
                {
                    s.UserId,
                    Name = s.LoginName,
                    s.Password,
                    s.RoleId,
                    s.Salt
                }
                    ).Where(x => string.Compare(x.Name,userName, true) == 0 && !string.IsNullOrEmpty(x.Name)).FirstOrDefault();

                if (anom == null) return null;
                return new LoginUser()
                {
                    UserId = anom.UserId,
                    Name = anom.Name,
                    Password = anom.Password,
                    Salt = anom.Salt,
                    RoleName = GetRoleById(anom.RoleId).Name
                };
            }
        }

        public void FillPermissionData(LoginUser user)
        {
            using(DBEntities entities = new DBEntities())
            {
                var roles = entities.Roles.SqlQuery("SELECT r.* FROM Role r INNER JOIN UserRole ur ON r.RoleId = ur.RoleId WHERE ur.UserId = @p0", user.UserId).ToList();
                roles.ForEach(x => user.Roles.Add(new ServiceObjects.Role() { RoleId = x.RoleId, Name = x.Name }));
                foreach(ServiceObjects.Role r in user.Roles)
                {
                    var modules = entities.Modules.SqlQuery("SELECT m.* FROM Module m INNER JOIN ModulePermission mp ON m.ModuleId = mp.ModuleId WHERE mp.PermissionId = @p0 AND mp.PermissionType = @p1", r.RoleId, HDMS.Model.Users.ModulePermission.PermissionTypeEnum.Role).ToList();
                    modules.ForEach(x => r.Modules.Add(new ServiceObjects.Module(){Name = x.Name}));
                }
                var umodules = entities.Modules.SqlQuery("SELECT m.* FROM Module m INNER JOIN ModulePermission mp ON m.ModuleId = mp.ModuleId WHERE mp.PermissionId = @p0 AND mp.PermissionType = @p1", user.UserId, HDMS.Model.Users.ModulePermission.PermissionTypeEnum.User).ToList();
                umodules.ForEach(x => user.Modules.Add(new ServiceObjects.Module() { Name = x.Name }));
            }
        }

        public void UpdateUser(Model.Users.User _user)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_user).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public List<Model.Users.User> GetAll()
        {
            using (DBEntities entities = new DBEntities())
            {
                //return entities.Users.SqlQuery("Select * from [User] Where RoleId in (3,4,5,6)").ToList();
                return entities.Users.SqlQuery("Select * from [User] Where RoleId in (3,4,5,6,2,1)").ToList();
            }
        }

        public List<Model.Users.User> GetAllPharmacist()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Users.SqlQuery("Select * from [User] Where RoleId in (20,21)").ToList();
            }
        }

        public void MapUserWithRole(Model.Users.UserRole _urole)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.UserRoles.Add(_urole);
                entities.SaveChanges();
            }
        }

        public List<Model.Users.User> GetUserByRoleId(int _roleId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Users.Where(x => x.RoleId == _roleId).ToList();
            }
        }

        public IList<Model.Users.VMUserDetail> GetUserDetailsByLoginName(string _loginName)
        {
            using (DBEntities entities = new DBEntities())
            {

                sql = string.Format("SELECT *  FROM [User] Where LoginName like '%{0}%'", _loginName);
                var udetail = entities.Users.SqlQuery(sql).ToList();

                List<Model.Users.VMUserDetail> _userList = new List<Model.Users.VMUserDetail>();

                foreach (var u in udetail)
                {
                    Model.Users.VMUserDetail _udetail = new Model.Users.VMUserDetail();
                    _udetail.Id = u.UserId;
                    _udetail.LoginName = u.LoginName;
                    _udetail.FullName = u.FullName;
                    _udetail.MobileNo = u.MobileNo;
                    _udetail.RoleName = GetRoleById(u.RoleId).Name;
                    _udetail.Status = u.Status;
                    _udetail.FloorId = u.FloorId;
                    _udetail.ChamberPractitionerId = u.ChamberPractitionerId;
                    _udetail.AssignedOutLet = u.AssignedOutLet;
                    _udetail.MedicineRequisitionForwardToOutlet = u.MedicineRequisitionForwardToOutLet;
                    _userList.Add(_udetail);


                }

                return _userList;
            }
        }

        public List<Model.Users.User> GetAllUser()
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {

                    return entities.Users.ToList();

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public IList<VMUserDetail> GetCpAssistantUserDetails(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
                var udetail = entities.Users.SqlQuery("SELECT *  FROM [User] Where CpId={0}", cPId).ToList();

                List<Model.Users.VMUserDetail> _userList = new List<Model.Users.VMUserDetail>();

                foreach (var u in udetail)
                {
                    Model.Users.VMUserDetail _udetail = new Model.Users.VMUserDetail();
                    _udetail.Id = u.UserId;
                    _udetail.LoginName = u.LoginName;
                    _udetail.FullName = u.FullName;
                    _udetail.MobileNo = u.MobileNo;
                    _udetail.RoleName = GetRoleById(u.RoleId).Name;
                    _udetail.Status = u.Status;
                    _udetail.FloorId = u.FloorId;
                    _udetail.ChamberPractitionerId = u.ChamberPractitionerId;
                    _udetail.AssignedOutLet = u.AssignedOutLet;
                    _udetail.MedicineRequisitionForwardToOutlet = u.MedicineRequisitionForwardToOutLet;
                    _userList.Add(_udetail);


                }

                return _userList;
            }
        }

        public Model.Users.User GetUserById(int _userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Users.Where(x=>x.UserId==_userId).FirstOrDefault();
            }
        }

        public Model.Users.Role GetRoleByName(string roleName)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Roles.Where(x => x.Name == roleName).FirstOrDefault();
            }
        }

        public User GetIndentUserById(string operateBy)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Users.Where(x => x.LoginName == operateBy).FirstOrDefault();
            }
        }

        public bool ChangePassword(Model.Users.User _user)
        {
            using (DBEntities entities = new DBEntities())
            {
              try{
                   entities.Entry(_user).State = EntityState.Modified;
                   entities.SaveChanges();
                   return true;
              }
              catch
              {
                  return false;
              }
               
            }
        }

        public int CreateUser(Model.Users.User _user)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Users.Add(_user);
                    entities.SaveChanges();
                    return _user.UserId;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public List<Model.Users.Role> GetRoles()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Roles.OrderBy(x=>x.RoleId).ToList();
            }
        }

        public IList<Model.Users.VMUserDetail> GetUserDetails()
        {
            using (DBEntities entities = new DBEntities())
            {
                var udetail = entities.Users.SqlQuery("SELECT *  FROM [User]").ToList();

               List<Model.Users.VMUserDetail> _userList = new List<Model.Users.VMUserDetail>();
              
                foreach (var u in udetail)
               {
                   Model.Users.VMUserDetail _udetail = new Model.Users.VMUserDetail();
                   _udetail.Id = u.UserId;
                   _udetail.LoginName = u.LoginName;
                   _udetail.FullName = u.FullName;
                   _udetail.MobileNo = u.MobileNo;
                   _udetail.RoleName = GetRoleById(u.RoleId).Name;
                   _udetail.Status = u.Status;
                    _udetail.FloorId = u.FloorId;
                    _udetail.ChamberPractitionerId = u.ChamberPractitionerId;
                    _udetail.AssignedOutLet = u.AssignedOutLet;
                    _udetail.MedicineRequisitionForwardToOutlet = u.MedicineRequisitionForwardToOutLet;
                   _userList.Add(_udetail);

                  
               }

                return _userList;
            }
        }

        private Model.Users.Role GetRoleById(int _roleId)
        {
             using (DBEntities entities = new DBEntities())
             {
                 return entities.Roles.Where(x => x.RoleId == _roleId).FirstOrDefault();
             }
        }

        public bool IsLoginNameExists()
        {
            throw new NotImplementedException();
        }

        public bool IsLoginNameExists(string _loginName)
        {
            using (DBEntities entities = new DBEntities())
            {
                var _user = entities.Users.Where(x => x.LoginName == _loginName).FirstOrDefault();
                if (_user == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
