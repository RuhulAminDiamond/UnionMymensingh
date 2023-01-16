using HDMS.Repositories.Pharmacy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Models.Pharmacy;

namespace HDMS.Service.Pharmacy
{
    public class PhReportingService
    {
        public DataSet GetOrderedItemDataSetByOrderId(long _OrderId)
        {
            return new PhReportingRepository().GetOrderedItemDataSetByOrderId(_OrderId);
        }

        public DataSet GetSaleEntryDataSetByinvocieId(long invocieId)
        {
            return new PhReportingRepository().GetSaleEntryDataSetByinvocieId(invocieId);
        }

        public DataSet GetProductList(int _manufId)
        {
            return new PhReportingRepository().GetProductList(_manufId);
        }

        public PhInvoice GetPhInvoiceById(long invocieId)
        {
            return new PhReportingRepository().GetPhInvoiceById(invocieId);
        }

        public DataSet GetPhProfitAndLoss(DateTime dtpfrm, DateTime dtpto)
        {
            return new PhReportingRepository().GetPhProfitAndLoss(dtpfrm, dtpto);
        }

        public DataSet GetPhSaleStatement(DateTime dtpfrm, DateTime dtpto, string _user, string _reportOption)
        {
            return new PhReportingRepository().GetPhSaleStatement(dtpfrm, dtpto, _user, _reportOption);
        }

        public DataSet GetIndoorInvoiceDataByinvocieId(long invocieId)
        {
            return new PhReportingRepository().GetIndoorInvoiceDataByinvocieId(invocieId);
        }

        public DataSet GetMedicineDetailsByPatientId(long _admissionId)
        {
            return new PhReportingRepository().GetMedicineDetailsByPatientId(_admissionId);
        }

        public DataSet GetIndoorToOTInvoiceDataByinvocieId(long invocieId)
        {
            return new PhReportingRepository().GetIndoorToOTInvoiceDataByinvocieId(invocieId);
        }

        public DataSet GetIndoorOTInvoiceDataByinvocieId(long invocieId)
        {
            return new PhReportingRepository().GetIndoorOTInvoiceDataByinvocieId(invocieId);
        }

        public DataSet GetPhSaleSummaryStatement(DateTime dtfrm, DateTime dtto, string _reportOPtion, int _outletId)
        {
            return new PhReportingRepository().GetPhSaleSummaryStatement(dtfrm, dtto, _reportOPtion, _outletId);
        }

        public DataSet GetPhOPDSaleStatement(DateTime dtpfrm, DateTime dtpto, string _user, string _reportOPtion)
        {
            return new PhReportingRepository().GetPhOPDSaleStatement(dtpfrm, dtpto, _user, _reportOPtion);
        }

        public DataSet GetSaleEntryDataSetByReturnReceiveId(long _ReceiveId)
        {
            return new PhReportingRepository().GetSaleEntryDataSetByReturnReceiveId(_ReceiveId);
        }

        public DataSet GetPhIPDaleStatement(DateTime dtpfrm, DateTime dtpto, string _user, string _reportOption)
        {
            return new PhReportingRepository().GetPhIPDaleStatement(dtpfrm, dtpto, _user, _reportOption);
        }

        public DataSet GetPhDeptWiseIPDaleStatement(DateTime dtpfrm, DateTime dtpto, string _user, string _reportOPtion, int _deptId)
        {
            return new PhReportingRepository().GetPhDeptWiseIPDaleStatement(dtpfrm, dtpto, _user, _reportOPtion, _deptId);
        }
    }
}
