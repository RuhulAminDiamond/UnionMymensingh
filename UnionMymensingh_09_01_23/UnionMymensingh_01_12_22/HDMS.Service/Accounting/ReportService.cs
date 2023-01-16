using Repositories.Accounting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Accounting
{
    public class ReportService
    {
        public DataSet GetTotalExpense(DateTime dtpfrm, DateTime dtpto, int _mode)
        {
            return new ReportRepository().GetTotalExpense(dtpfrm, dtpto, _mode);
        }

        public DataSet GetCashBook(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            return new ReportRepository().GetCashBook(dateTime1, dateTime2, _CheckPaymentState, _userName, _bUnitId);
        }

        public double GetCashBookTotal()
        {
            return new ReportRepository().GetCashBookTotal();
        }

        public double GetCashBookCreditTotal()
        {
            return new ReportRepository().GetCashBookCreditTotal();
        }

        public double GetCashBookDebitTotal()
        {
            return new ReportRepository().GetCashBookDebitTotal();
        }

       
    }
}
