using Models.Accounting;
using HDMS.Repository.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HDMS.Model.Accounting;

namespace HDMS.Service.Accounting
{
    public class VoucherService
    {

        public long AddMasterVoucher(Voucher masterVoucher)
        {
            try
            {
                return new VoucherRepository().AddNewMasterVoucher(masterVoucher);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
        }

        public long AddOrEditDetailsVoucher(VoucherDetail detailsVoucher)
        {
            try
            {
                return new VoucherRepository().AddOrEditDetailsVoucher(detailsVoucher);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public long AddDetailsVoucher(VoucherDetail detailsVoucher)
        {
            try
            {
                return new VoucherRepository().AddNewDetailsVoucher(detailsVoucher);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet GetPaymentOrDebitVoucher(long vMId)
        {
            return new VoucherRepository().GetPaymentOrDebitVoucher(vMId);
        }

        public DataSet GetReceiptOrCreditVoucher(long vMId)
        {
            return new VoucherRepository().GetReceiptOrCreditVoucher(vMId);
        }

        public bool UpdateMasterVoucher(Voucher _voucher)
        {
            return new VoucherRepository().UpdateMasterVoucher(_voucher);
        }

        public bool DepartmentalVoucherProcessing()
        {


            return true;
        }

        public bool CheckIsAlreadyImported(DateTime datefrm, DateTime dateto)
        {
            return new VoucherRepository().CheckIsAlreadyImported(datefrm, dateto);
        }

        public bool SaveAutoImportLog(AccountsAutoImportLog importLog)
        {
            return new VoucherRepository().SaveAutoImportLog(importLog);
        }
    }
}
