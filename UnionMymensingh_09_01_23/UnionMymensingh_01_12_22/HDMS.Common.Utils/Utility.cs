using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
//using System.Threading.Tasks;

namespace HDMS.Common.Utils
{
    public static class Utility
    {
        //static string _server = @"Server;";
        //static string _LISServer = @"Server;";

        static string _server = @"Server;";
        static string _LISServer = @"Server;";

        public static string GetConcatenatedAge(string years, string months, string days)
        {
            return string.Format("{0}{1}{2}", PrepareAgeString(years, "Yrs "), PrepareAgeString(months, "M "), PrepareAgeString(days, "D ")).Trim();
          
        }

        private static string PrepareAgeString(string age, string postfix)
        {
            int _chkVal = 0;


            int.TryParse(age, out _chkVal);

            if (_chkVal == 0) return null;

            if (string.IsNullOrEmpty(age)) return null;
            if (age == "0") return null;
            return string.Format("{0}{1} ", age, postfix.Trim());
        }

        public static bool IsNumeric(string strToCheck)
        {
            int _num = 0;
           if(int.TryParse(strToCheck, out _num))
            {
                return true;
            }
            else
            {
                return false;
            }
         }

   public static bool FileInUse(string path)
   {
        try
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                if(fs.CanWrite) return false;
            }
            return false;
        }
        catch (IOException ex)
        {
            return true;
        }
   }

   public static string GetLabDbConnectionString()
   {
      
       return "Data Source="+_server + "Initial Catalog=LabReport;" + "Persist Security Info=False;User ID=sa;Password=emslsoft@2018;";
   }

   public static string  GetLegacyDbConnectionString()
   {
     
       return "Data Source=" + _server + "Initial Catalog=UnionHMymensinghDB;" + "Persist Security Info=False;User ID=sa;Password=emslsoft@2018;";
   
   }

   public static string GetImageDbConnectionString()
   {
           
            return "Data Source=" + _server + "Initial Catalog=MImage;" + "Persist Security Info=False;User ID=sa;Password=emslsoft@2018;";
   }

    public static string GetLISDbConnectionString()
    {

            return "Data Source=" + _LISServer + "Initial Catalog=InterfacingData;" + "Persist Security Info=False;User ID=sa;Password=emslsoft@2018;";

    }

   public static string GetReportGroupName(int groupId)
   {
            if (groupId == 5 || groupId==22 || groupId== 29 || groupId== 31 || groupId== 32 || groupId== 33) return "DEPT. OF RADIOLOGY & IMAGING";
            if (groupId == 4 || groupId == 8 || groupId == 9 || groupId == 13 || groupId == 17) return "DEPARTMENT OF CARDIOLOGY";
            if (groupId == 3 || groupId == 11 || groupId == 12) return "DEPARTMENT OF GASTROENTEROLOGY";
            if (groupId == 28) return "DEPARTMENT OF UROLOGY";
            if (groupId == 23) return "DEPARTMENT OF NEUROLOGY";
            

            return "";

   }

        public static DataTable ToDataTable<T>(List<T> items,object barcodeimg)
   {
       DataTable dataTable = new DataTable(typeof(T).Name);
       //Get all the properties
       PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
       foreach (PropertyInfo prop in Props)
       {
           //Setting column names as Property names
           dataTable.Columns.Add(prop.Name);
       }
       dataTable.Columns.Add("RegNoImg");
       foreach (T item in items)
       {
           var values = new object[Props.Length+1];
           for (int i = 0; i < Props.Length; i++)
           {
               //inserting property values to datatable rows
               values[i] = Props[i].GetValue(item, null);
           }

           values[Props.Length] = ObjectToByteArray(barcodeimg);
           dataTable.Rows.Add(values);
       }
       //put a breakpoint here and check datatable
       return dataTable;
   }

   public static byte[] ObjectToByteArray(Object obj)
   {
       BinaryFormatter bf = new BinaryFormatter();
       using (var ms = new MemoryStream())
       {
           bf.Serialize(ms, obj);
           return ms.ToArray();
       }
   }

   public static double getDoubleValue(string doubleval)
   {
       double _val;
       double.TryParse(doubleval,out  _val);
       return _val;
   }

   

   public static int GetIntNum(string num)
   {
       int _num = 0;
       int.TryParse(num, out _num);
       return _num;
   }

       

       

    }
}
