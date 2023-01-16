using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Services.POS;
using HDMS.Model.Pharmacy;
using HDMS.Service.Pharmacy;
using HDMS.Models.Pharmacy;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class PhProductSearchControl : SearchResultListControl<VWPhProductList>
    {

        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4, header5, header6;

            header1 = new ColumnHeader();
            header1.Text = "Formation";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "Brand Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 290;

            header5 = new ColumnHeader();
            header5.Text = "Stock";
            header5.TextAlign = HorizontalAlignment.Left;
            header5.Width = 100;

            header6 = new ColumnHeader();
            header6.Text = "Sale Rate";
            header6.TextAlign = HorizontalAlignment.Left;
            header6.Width = 100;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            //view.Columns.Add(header3);
            //view.Columns.Add(header4);
            view.Columns.Add(header5);
            view.Columns.Add(header6);
        }

        protected override void FillListViewItem(ListViewItem lvItem, VWPhProductList item)
        {
            lvItem.Text = item.FormationShortName;
            lvItem.SubItems.Add(item.BrandName);
            //lvItem.SubItems.Add(item.BatchNo);
            //lvItem.SubItems.Add(item.ExpireDate.ToString("dd/MM/yyyy"));
            lvItem.SubItems.Add(item.StockAvailable.ToString());
            lvItem.SubItems.Add(item.SaleRate.ToString());
            lvItem.SubItems.Add(item.PurchaseRate.ToString());

        }

        protected override IList<VWPhProductList> GetItems()
        {
           
            return new PhProductService().GetBasicProductInfoList("","");
        }

        protected override IList<VWPhProductList> GetItemsByType(string _filterString)
        {
            //int _outLetId = 0;
            //int.TryParse(_type, out _outLetId);
            return new PhProductService().GetProductListWithStock(_filterString);
        }

        protected override IList<VWPhProductList> GetFilteredList(IList<VWPhProductList> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.ProductId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.BrandName.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<VWPhProductList> GetItemsByTypeFromSuppliedList(string _type, List<VWPhProductList> item)
        {
            throw new NotImplementedException();
        }
    }
}
