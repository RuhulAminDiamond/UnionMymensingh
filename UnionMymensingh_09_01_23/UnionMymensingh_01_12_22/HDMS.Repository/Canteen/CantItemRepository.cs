using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ViewModel;
using System.Data;
using System.Data.Entity;
using Models.Canteen;
using HDMS.Model;
using HDMS.Common.Utils;
using HDMS.Models.Pharmacy;
using HDMS.Model.Common;
using HDMS.Model.Store;

namespace Repositories.POS
{
    public class CantItemRepository
    {
        string sql = string.Empty;
        SqlDataAdapter da;
        SqlConnection con;
        SqlCommand cmd;

        public List<CantGroup> GetAllGroups()
        {
           using(DBEntities entities=new DBEntities())
           {
               return entities.CantGroups.ToList();
           }
           
        }

        public IList<CantGroup> GetAllCategory()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CantGroups.ToList();
            }
        }

        public bool AddNewProduct(CantProductInfo _pInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.CantProductInfos.Add(_pInfo);
                    entities.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                } 
               

            }
        }

     

        public IList<CantProductInfo> GetAllProduct()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CantProductInfos.ToList();
            }
        }

        public CantProductInfo GetProductById(int pId)
        {
             using (DBEntities entities = new DBEntities())
            {
                return entities.CantProductInfos.Where(x=>x.Id==pId).FirstOrDefault();
            }
        }

        public bool UpdateProductInfo(CantProductInfo _P)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_P).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public IList<OrderSource> GetAllSource()
        {
            using (DBEntities entities = new DBEntities())
            {
                return null; //entities.OrderSources.ToList();
            }
        }

        public IList<CantVWItemInfo> GetBasicItemInfoList(string name, string _type)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();

                if (!String.IsNullOrEmpty(name))
                {

                    sql = string.Format(@"SELECT dbo.CantProductInfoes.Id, dbo.CantProductInfoes.ProductCode, dbo.CantProductInfoes.Name, dbo.CantProductInfoes.PurchaseRate, dbo.CantProductInfoes.SaleRate, dbo.CantProductInfoes.Unit, dbo.CantGroups.Name AS GroupName
                                           FROM dbo.CantProductInfoes INNER JOIN
                                          dbo.CantGroups ON dbo.CantProductInfoes.GroupId = dbo.CantGroups.Id  Where dbo.CantProductInfoes.Name like '{0}%'", name);
                }
                else
                {
                    sql = string.Format(@"SELECT dbo.CantProductInfoes.Id, dbo.CantProductInfoes.ProductCode, dbo.CantProductInfoes.Name, dbo.CantProductInfoes.PurchaseRate, dbo.CantProductInfoes.SaleRate, dbo.CantProductInfoes.Unit, dbo.CantGroups.Name AS GroupName
                                           FROM dbo.CantProductInfoes INNER JOIN
                                          dbo.CantGroups ON dbo.CantProductInfoes.GroupId = dbo.CantGroups.Id");
                }

                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<CantVWItemInfo> pInfoList = new List<CantVWItemInfo>();


                pInfoList = new List<CantVWItemInfo>(
                    (from dRow in dt.AsEnumerable()
                     select (GetBasicProductInfoDataTableRow(dRow)))
                    );

                return pInfoList;

            }
            catch (Exception ex)
            {
                return new List<CantVWItemInfo>();

            }
        }

        private CantVWItemInfo GetBasicProductInfoDataTableRow(DataRow dr)
        {
            CantVWItemInfo _itemInfo = new CantVWItemInfo();
            _itemInfo.ProductId = Convert.ToInt32( dr["Id"]);
            _itemInfo.ProductCode = dr["ProductCode"].ToString();
            _itemInfo.ProductName= dr["Name"].ToString();
            _itemInfo.PurchaseRate = Convert.ToDouble(dr["PurchaseRate"]);
            _itemInfo.SaleRate = Convert.ToDouble(dr["SaleRate"]);
            _itemInfo.GroupName= dr["GroupName"].ToString();
            _itemInfo.Unit = dr["Unit"].ToString();

            return _itemInfo;
        }

       

        public CantProductInfo GetProductByCode(string pCode)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CantProductInfos.Where(x => x.ProductCode == pCode).FirstOrDefault();
            }
        }


        public long AddNewInvoices(CantInvoice _invoice)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.CantInvoices.Add(_invoice);
                    entities.SaveChanges();
                    return _invoice.InvoiceId ;
                }
                catch (Exception ex)
                {
                    return 0;
                }


            }
        }

        public bool AddNewInvDetails(List<CantInvoiceDetail> _invDetailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.CantInvoiceDetails.AddRange(_invDetailsList);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }


            }
        }


        public long SaveReceivedInvoice(CantReceive _receive)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.CantReceives.Add(_receive);
                    entities.SaveChanges();
                    return _receive.Id;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public List<CantInvoiceDetail> GetSoldItems(long invoiceId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CantInvoiceDetails.Where(x => x.InvoiceId == invoiceId).ToList();
            }
        }

        public CantInvoice GetInvoiceByInvoiceNumber(long _InvoiceNumber)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CantInvoices.Where(x => x.InvoiceNumber == _InvoiceNumber).FirstOrDefault();
            }
        }
        public bool SaveReceiveDetails(List<CantReceiveDetail> _rDeatailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.CantReceviceDetails.AddRange(_rDeatailsList);
                    entities.SaveChanges();

                    foreach(var rd in _rDeatailsList)
                    {
                        CantProductInfo _pInfo = this.GetProductById(rd.ProductId);
                        _pInfo.SaleRate = rd.PurchaseRate;
                        entities.Entry(_pInfo).State = EntityState.Modified;
                        entities.SaveChanges();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }


            }
        }

        public OrderSource GetOrderSourceById(int orderFrom)
        {
            using (DBEntities entities= new DBEntities())
            {
                return null; // entities.OrderSources.Where(x => x.SourceId == orderFrom).FirstOrDefault();
            }
        }

        public void DeleteInvoiceItem(long _InvoiceId, int prodId)
        {
            try
            {
                sql = string.Format("Delete from InvoiceDetails Where InvoiceId={0} and ProductId={1}", _InvoiceId, prodId);
                con = new SqlConnection(Configuration.ConnectionString);
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();


            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteExistingLedger(long _InvoiceId)
        {
            try
            {
                sql = string.Format("Delete from RSaleLedgers Where InvoiceId={0}", _InvoiceId);
                con = new SqlConnection(Configuration.ConnectionString);
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();

               
            }
            catch(Exception ex)
            {
               
            }
            finally
            {
                con.Close();
            }
        }

        public double GetCurrentStockByProductId(int _pId)
        {
            try
            {
                sql = string.Format("select CurrentStock from VWCantProductInfoWithCurrentStock Where Id={0}", _pId);
                con = new SqlConnection(Configuration.ConnectionString);
                cmd = new SqlCommand(sql, con);
                con.Open();
                double _currentStock = Convert.ToDouble(cmd.ExecuteScalar());
               
                return _currentStock;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public IList<CantMemberInfo> GetAllCustomer()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CantMemberInfoes.ToList();
            }
        }
        public long GetAllInvoiceCount()
        {
            using (DBEntities entities = new DBEntities())
            {
               
                return entities.CantInvoices.ToList().Count();
            }
        }

        // Add code on 2018-03-24
        // For CR : Invoice and Challan No Auto Generate

        public int GetAllReceivedCount(string shortName)
        {
            using (DBEntities entities = new DBEntities())
            {
                string strInvNO = "" + shortName + "_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + "INV";
                return entities.CantReceives.Where(x => x.SInvoiceNo.Contains(strInvNO)).ToList().Count();
            }
        }


        public IList<PhCompany> GetAllCompany()
        {
            using (DBEntities entities = new DBEntities())
            {
                return null; // entities.Companys.ToList();
            }
        }

       

        public bool AddGroup(CantGroup _group)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.CantGroups.Add(_group);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }


            }
        }

        public IList<CantInvoiceDetail> GetInvoiceDetails(Int64 _InvoiceNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CantInvoiceDetails.Where(x => x.InvoiceId == _InvoiceNo).ToList();
            }
        }

        public CantInvoice GetInvoiceByInvoiceNo(Int64 _InvoiceNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CantInvoices.Where(x => x.InvoiceId == _InvoiceNo).FirstOrDefault();
            }
        }

        public void UpdateInvoice(CantInvoice _Invoice)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_Invoice).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                   
                }
                catch
                {
                  
                }
            }
        }

     

        public CantReceive GetReceiveInvoiceInfo(int _receiveId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CantReceives.Where(x => x.Id == _receiveId).FirstOrDefault();
            }
        }

        public List<CantReceiveDetail> GetReceiveDetails(long _receiveId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CantReceviceDetails.Where(x => x.ReceivedId == _receiveId).ToList();
            }
        }

   
    }
}
