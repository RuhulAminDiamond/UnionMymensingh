using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Pharmacy;
using HDMS.Service.Pharmacy;
using HDMS.Model.Pharmacy.ViewModels;
using System.IO;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class PhProductSaleSearchControl : SearchResultListControlForPharmacy<VWPhProductListForSale>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4, header5, header6, header7, header8, header9, header10;

            
            header1 = new ColumnHeader();
            header1.Text = "Forms";
            header1.TextAlign = HorizontalAlignment.Right;
            header1.Width = 80;

            header2 = new ColumnHeader();
            header2.Text = "Brand Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 280;

            header3 = new ColumnHeader();
            header3.Text = "Expire Date";
            header3.TextAlign = HorizontalAlignment.Right;
            header3.Width = 150;

            header4 = new ColumnHeader();
            header4.Text = "Stock(Qty)";
            header4.TextAlign = HorizontalAlignment.Right;
            header4.Width = 120;

            header5 = new ColumnHeader();
            header5.Text = "Sale Rate";
            header5.TextAlign = HorizontalAlignment.Right;
            header5.Width = 110;

            header6 = new ColumnHeader();
            header6.Text = "Booked(Qty)";
            header6.TextAlign = HorizontalAlignment.Right;
            header6.Width = 120;

            header7 = new ColumnHeader();
            header7.Text = "Booked By";
            header7.TextAlign = HorizontalAlignment.Right;
            header7.Width = 120;

            header8 = new ColumnHeader();
            header8.Text = "Rack No";
            header8.TextAlign = HorizontalAlignment.Right;
            header8.Width = 120;

            header9 = new ColumnHeader();
            header9.Text = "Block No";
            header9.TextAlign = HorizontalAlignment.Right;
            header9.Width = 120;

            header9 = new ColumnHeader();
            header9.Text = "Block No";
            header9.TextAlign = HorizontalAlignment.Right;
            header9.Width = 120;

            header10 = new ColumnHeader();
            header10.Text = "P.R";
            header10.TextAlign = HorizontalAlignment.Right;
            header10.Width = 100;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);   
            view.Columns.Add(header5);
            view.Columns.Add(header6);
            view.Columns.Add(header7);
            view.Columns.Add(header8);
            view.Columns.Add(header9);
            view.Columns.Add(header10);

        }

        protected override void FillListViewItem(ListViewItem lvItem, VWPhProductListForSale item)
        {
               
            
                lvItem.Text = item.FormationShortName; // item.LotNo.ToString();
                lvItem.SubItems.Add(item.BrandName);
              
                lvItem.SubItems.Add(item.ExpireDate.ToString("dd/MM/yyyy"));
                lvItem.SubItems.Add(item.StockAvailable.ToString());
                lvItem.SubItems.Add(item.SalePrice.ToString());
                lvItem.SubItems.Add(item.BookedQty.ToString());
                lvItem.SubItems.Add(item.BookedBy.ToString());
                lvItem.SubItems.Add(item.RackNo.ToString());
                lvItem.SubItems.Add(item.BlockNo.ToString());
                lvItem.SubItems.Add(item.PurchasePrice.ToString());

                DateTime _todaysDate = Utils.GetServerDateAndTime();

           
            if (item.ExpireDate > _todaysDate && item.ExpireDate < _todaysDate.AddDays(60))
            {
                lvItem.BackColor = Color.Yellow;

            }else if(item.ExpireDate< _todaysDate)
            {
                lvItem.BackColor = Color.Red;
            }

           

        }

        protected override IList<VWPhProductListForSale> GetFilteredList(IList<VWPhProductListForSale> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.ProductId.ToString().Contains(filterstring)).ToList();
            }

         
            return fullList. Where(x => x.BrandName.ToLower().StartsWith(filterstring.ToLower())).ToList();
        }

        protected override IList<VWPhProductListForSale> GetItems()
        {
            return null;  //new PhProductService().GetStockListForSale("");
        }

      

        protected override IList<VWPhProductListForSale> GetItemsByType(string _filterString)
        {
            return new PhProductService().GetPhItemForSale(_filterString);
        }

        protected override IList<VWPhProductListForSale> GetItemsByTypeFromSuppliedList(string _type, List<VWPhProductListForSale> item)
        {
            string filterString = string.Empty;
            int _outLetId = 0;

            string[] arr = null;
            arr = _type.Split('>');

            if (arr.Length > 1)
            {
                filterString = arr[0];
                _outLetId = Convert.ToInt32(arr[1]);
            }

            return item.Where(x=>x.OutLetId== _outLetId && x.BrandName.ToLower().StartsWith(filterString.ToLower())).ToList();
        }
    }
}
