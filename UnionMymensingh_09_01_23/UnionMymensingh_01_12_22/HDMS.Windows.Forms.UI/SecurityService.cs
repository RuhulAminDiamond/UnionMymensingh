using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Users;
using HDMS.Service;
using System;
using System.Linq;

namespace HDMS.Windows.Forms.UI
{
    public class SecurityService
    {
   
        public bool IsLicenseExipred()
        {

            User _user = new UserService().GetAllUser().FirstOrDefault();



            if (String.IsNullOrEmpty(_user.SKey))
            {
                return true;

            }
            else
            {

                try
                {
                    string _expdate = CryptoEngine.Decrypt(_user.SKey, "E-Medical-Soluti");

                    DateTime expireDate = Convert.ToDateTime(_expdate);

                    Patient _P = new SecurityRepository().GetLastEntryDiagnostic();
                    if (_P != null)
                    {

                        if (_P.EntryDate >= expireDate)
                        {
                            return true;

                        }
                        else
                        {
                            return false;
                        }

                    }
                    else

                    {
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    return true;
                }
            }


        }
    }
}