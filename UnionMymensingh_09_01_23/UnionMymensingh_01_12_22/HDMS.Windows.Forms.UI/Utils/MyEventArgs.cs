using HDMS.Model;
using HDMS.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Windows.Forms.UI.Classes
{
    public class MyEventArgs : EventArgs
    {
        public List<VMPractitionerWisePatientSerial> EventInfo;
        public MyEventArgs(List<VMPractitionerWisePatientSerial> pList)
        {
            EventInfo = pList;
        }
        public List<VMPractitionerWisePatientSerial> GetPatientList()
        {
            return EventInfo;
        }
    }
}
