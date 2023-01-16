using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Services.Store;
using Models.Store;
using HDMS.Windows.Forms.UI.Controls;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class StoreProductSearchControl : SearchResultListControl<StoreProductInfo>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4;

            header1 = new ColumnHeader();
            header1.Text = "Code";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 75;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 350;

            header3 = new ColumnHeader();
            header3.Text = "Stock";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 150;


            header4 = new ColumnHeader();
            header4.Text = "Rate";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 200;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);
        }

        protected override void FillListViewItem(ListViewItem lvItem, StoreProductInfo item)
        {
            lvItem.Text = item.ProductId.ToString();
            lvItem.SubItems.Add(item.Name);
            lvItem.SubItems.Add(new StoreItemService().GetCurrentStockByProductId(item.ProductId).ToString());
            lvItem.SubItems.Add(item.PurchaseRate.ToString());
          

        }

        protected override IList<StoreProductInfo> GetFilteredList(IList<StoreProductInfo> fullList, string filterstring)
        {
            if (fullList == null || fullList.Count == 0) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.ProductId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<StoreProductInfo> GetItems()
        {
            return new StoreItemService().GetAllProduct();
        }

        protected override IList<StoreProductInfo> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<StoreProductInfo> GetItemsByTypeFromSuppliedList(string _type, List<StoreProductInfo> item)
        {
            throw new NotImplementedException();
        }
    }
}
