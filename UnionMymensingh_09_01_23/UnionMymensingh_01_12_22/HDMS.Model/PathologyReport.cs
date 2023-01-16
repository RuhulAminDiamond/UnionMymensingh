using HDMS.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model
{
    public class MsWordReport
    {
        public int Id { get; set; }
        public string RegNo { get; set; }
        public long PatientId { get; set; }
        public ViewModelReportTests TestInfo { get; set; }
        public byte[] ReportContent { get; set; }
        public ReportConsultant _ReportDoctor { get; set; }
        public string PreparedBy { get; set; }
        public DateTime PreparedDate { get; set; }
        public string Preparedtime { get; set; }
        public string ReportType { get; set; }
        public string Printed_By { get; set; }
    }
}
