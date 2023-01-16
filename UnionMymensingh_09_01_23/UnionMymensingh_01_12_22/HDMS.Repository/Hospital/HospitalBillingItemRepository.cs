using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.Hospital
{
    public class HospitalBillingItemRepository
    {
        SqlConnection con;
        SqlDataAdapter da;
        string sql;
        SqlCommand cmd;
       

        public List<ServiceHead> GetAllBillingItems()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ServiceHeads.ToList();
            }
        }

      

      
        public bool SaveBillInfo(HospitalBill hbill)
        {
           
           using (DBEntities entities = new DBEntities())
           {
                   try{
                       entities.HospitalBills.Add(hbill);
                       entities.SaveChanges();
                       return true;
                   }catch{
                       return false;
                   }
           }
        }

        public void SaveBillDetails(List<HospitalBillDetail> billItems)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HospitalBillDetails.AddRange(billItems);
                entities.SaveChanges();
            }
        }

        public void SaveBillRecord(List<LedgerOfHospitalBillPayment> _ledgerlist)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.LedgerOfHospitalBillPayments.AddRange(_ledgerlist);
                entities.SaveChanges();
            }
        }

        public void SaveBillInfo(LedgerOfHospitalBillPayment ledger)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.LedgerOfHospitalBillPayments.Add(ledger);
                entities.SaveChanges();
            }
        }

        public VWHospitalBillCollectionDetails GetBillCollectionInfoByInvoice(int InvoiceId)
        {
            con = new SqlConnection();
            con.ConnectionString = Utility.GetLegacyDbConnectionString();
            con.Open();
            da = new SqlDataAdapter("select * from dbo.VWHospitalBillStatement where BillId=" + InvoiceId, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            if (dt.Rows.Count > 0)
            {
                return GetBillCollectionTableRow(dt.Rows[0]);
            }
            else
            {
                return new VWHospitalBillCollectionDetails();
            }
        }

        private VWHospitalBillCollectionDetails GetBillCollectionTableRow(DataRow dr)
        {
            VWHospitalBillCollectionDetails ttype = new VWHospitalBillCollectionDetails();
            ttype.HospitalPaymentByCash = Utility.getDoubleValue(dr["HospitalPaymentByCash"].ToString());
            ttype.HospitalBillPaymentByPF = Utility.getDoubleValue(dr["HospitalBillPaymentByPF"].ToString());
            ttype.DiscountOnHospital = Utility.getDoubleValue(dr["DiscountOnHospital"].ToString());
            ttype.HospitalPaymentByHCV = Utility.getDoubleValue(dr["HospitalPaymentByHCV"].ToString());

            return ttype;
        }

        public HospitalBill GetHospitalBillByRegNo(long _regNo)
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.HospitalBills.Where(x => x.AdmissionId == _regNo).FirstOrDefault();
               
            }
        }

        public List<HospitalBillDetail> GetHospitalBillItemDetails(int InvoiceNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HospitalBillDetails.Where(x => x.HospitalBillId == InvoiceNo).ToList();

            }
        }

       
    }
}
