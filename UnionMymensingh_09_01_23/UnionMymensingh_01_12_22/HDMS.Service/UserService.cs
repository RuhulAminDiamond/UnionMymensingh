using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Repository;
using HDMS.Repository.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HDMS.Service
{
    public class UserService
    {
        public bool CheckLogin(string userName, string password, out LoginUser user)
        {
            UserRepository repository = new UserRepository();
            user = repository.GetUserByName(userName);
            if(user == null) return false;
            string passwordToCheck = HashGenerator.GenerateSlatedHash(password, user.Salt);
            bool isLoginOk = string.Compare(user.Password, passwordToCheck) == 0;
            if (!isLoginOk) return isLoginOk;
            repository.FillPermissionData(user);
            return isLoginOk;   
        }

        public List<Model.Users.User> GetAllPharmacist()
        {
            return new UserRepository().GetAllPharmacist();
        }

        public bool CheckOldPassword(string userName, string password)
        {
            UserRepository repository = new UserRepository();
            LoginUser user = repository.GetUserByName(userName);
            if (user == null) return false;
            string passwordToCheck = HashGenerator.GenerateSlatedHash(password, user.Salt);
            bool isLoginOk = string.Compare(user.Password, passwordToCheck) == 0;
            if (!isLoginOk) return isLoginOk;
            
            return isLoginOk;
        }

      

        public void UpdateUser(Model.Users.User  _user)
        {
            new UserRepository().UpdateUser(_user);
        }

        public bool IsUserPermitted(string moduleName, LoginUser user)
        {
            if (string.IsNullOrEmpty(moduleName)) return false;
            if (user.Modules.IsModuleExists(moduleName)) return true;

            foreach(Role r in user.Roles)
            {
                if (r.Modules.IsModuleExists(moduleName)) return true;
            }
            return false;
        }

        public List<Model.Users.User> GetAll()
        {
            return new UserRepository().GetAll();
        }

        public Model.Users.User GetUserById(int _userId)
        {
            return new UserRepository().GetUserById(_userId);
        }

        public bool ChangePassword(Model.Users.User _user)
        {
            return new UserRepository().ChangePassword(_user);
        }

        public int CreateUser(Model.Users.User _user)
        {
            return new UserRepository().CreateUser(_user);
        }

        public void MapUserWithRole(Model.Users.UserRole _urole)
        {
            new UserRepository().MapUserWithRole(_urole);
        }

        public Model.Users.User GetIndentUserById(String operateBy)
        {
            return new UserRepository().GetIndentUserById(operateBy);
        }

        public List<Model.Users.Role> GetRoles()
        {
            return new UserRepository().GetRoles();
        }

        public IList<Model.Users.VMUserDetail> GetUserDetails()
        {
            return new UserRepository().GetUserDetails();
        }

        public bool IsLoginNameExists(string _loginName)
        {
            return new UserRepository().IsLoginNameExists(_loginName);
        }

        public Model.Users.Role GetRoleByName(string roleName)
        {
            return new UserRepository().GetRoleByName(roleName);
        }

        public List<Model.Users.User> GetUserByRoleId(int _roleId)
        {
            return new UserRepository().GetUserByRoleId(_roleId);
        }

        public IList<Model.Users.VMUserDetail> GetUserDetailsByLoginName(string _loginName)
        {
            return new UserRepository().GetUserDetailsByLoginName(_loginName);
        }

        public IList<Model.Users.VMUserDetail> GetCpAssistantUserDetails(int cPId)
        {
            return new UserRepository().GetCpAssistantUserDetails(cPId);
        }

        public List<Model.Users.User> GetAllUser()
        {
            return new UserRepository().GetAllUser();
        }
    }
}
