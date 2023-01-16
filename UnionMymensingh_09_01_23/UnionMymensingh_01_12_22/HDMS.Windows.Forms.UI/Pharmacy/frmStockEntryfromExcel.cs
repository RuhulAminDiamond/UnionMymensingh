using HDMS.Models.Pharmacy;
using HDMS.Service.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmStockEntryfromExcel : Form
    {
        public frmStockEntryfromExcel()
        {
            InitializeComponent();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog();//open dialog to choose file
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)//if there is a file choosen by the user
            {
                filePath = file.FileName;//get the path of the file
                fileExt = Path.GetExtension(filePath);//get the file extension
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = ReadExcel(filePath, fileExt);//read excel file
                        dgExcelData.Visible = true;
                        dgExcelData.DataSource = dtExcel;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);//custom messageBox to show error
                }
            }
        }

        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)//compare the extension of the file
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';";//for below excel 2007
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";//for above excel 2007
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con);//here we read data from sheet1
                    oleAdpt.Fill(dtexcel);//fill excel data into dataTable
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            return dtexcel;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //List<PhProductInfo> _pList = new List<PhProductInfo>();
            //List<PhReceiveDetail> _pReceiveDetails = new List<PhReceiveDetail>();
            //long _rowCount = 0;
            //foreach (DataGridViewRow row in dgExcelData.Rows)
            //{
            //    int count = 0;
            //    int _productId = 0;
            //    double _qty = 0;
            //    double _sp = 0;
            //    double _pp = 0;
            //    _rowCount = _rowCount + 1;
            //    PhProductInfo _pInfo = new PhProductInfo();
            //     PhReceiveDetail _receiveDetail = new PhReceiveDetail();
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        string _value= cell.Value.ToString();
            //        if (count >= 0 && count <= 5) {

            //            if (count == 0) {
            //                _productId= Convert.ToInt32(_value);
            //                _pInfo.ProductId = _productId;
            //                _receiveDetail.ProductId = _productId;
            //            }
                      
            //            if (count == 1) 
            //            if (count == 2) _pInfo.BrandName = _value;
            //            if (count == 3) {
                           
            //                double.TryParse(_value,out _pp);
            //                _pInfo.PurchasePrice = _pp;
            //            }
            //            if (count == 4)
            //            {
                           
            //                double.TryParse(_value, out _sp);
            //                _pInfo.SalePrice = _sp;
            //            }

            //            if (count == 5)
            //            {
            //                double.TryParse(_value, out _qty);
            //                _receiveDetail.Qty = _qty;

            //                _receiveDetail.PurchaseRate = _pp;
            //                _receiveDetail.Total = _pp * _qty;
            //                _receiveDetail.disCountInpercent = 0;
            //                _receiveDetail.grossDiscount = 0;
                            


            //            }

            //        }

            //        count++;

                    
            //        _pInfo.FormationId = 1;

            //        _pInfo.GenericId = 1;

            //        _pInfo.ManufacturerId = 1;


                 
            //        _receiveDetail.ReceivedId = 78;
            //        _receiveDetail.LotNo = 1;




            //    }

               
            //     if (_pInfo != null) _pList.Add(_pInfo);

            //    if (_receiveDetail != null) _pReceiveDetails.Add(_receiveDetail);
            //}

         
           
            //if (_pList.Count() > 0)
            //{
            //    btnSave.Text = "Please wait.....";
            //    btnSave.Enabled = false;

            //    if (new PhProductService().SaveBulkProductDataFromExcel(_pList))
            //    {
            //        new PhProductService().SaveBulkProductReceiveData(_pReceiveDetails);
            //        MessageBox.Show("Data Entry Successful");
            //        btnSave.Text = "Save";
            //        btnSave.Enabled = true;
            //    }
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int _rowCount = 0;
            try {

                foreach (DataGridViewRow row in dgExcelData.Rows)
                {
                    int count = 0;
                    int _productId = 0;
                    string _brandName = string.Empty;
                    _rowCount = _rowCount + 1;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string _value = cell.Value.ToString();

                        if (count >= 0 && count <= 1)
                        {
                            if (count == 0)
                            {
                                _productId = Convert.ToInt32(_value);

                            }

                            if (count == 1)
                            {
                                _brandName = _value.Trim();

                                PhProductInfo _pInfo = new PhProductService().GetProductById(_productId);
                                _pInfo.BrandName = _brandName;
                                new PhProductClassificationService().UpdateProduct(_pInfo);

                            }

                            count++;
                        }
                    }

                   
                }

                MessageBox.Show("Completed Total Rows: " + _rowCount.ToString());

            }
            catch(Exception ex)
                {
                MessageBox.Show("Exception block Completed Total Rows: " + _rowCount.ToString());
            }
            
        }
    }
}
