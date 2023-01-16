using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models.Canteen;
using Services.POS;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class CantProductSearchControl : SearchResultListControl<CantProductInfo>
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

        protected override void FillListViewItem(ListViewItem lvItem, CantProductInfo item)
        {
            lvItem.Text = item.Id.ToString();
            lvItem.SubItems.Add(item.Name);
            lvItem.SubItems.Add(new CantItemService().GetCurrentStockByProductId(item.Id).ToString());
             lvItem.SubItems.Add(item.PurchaseRate.ToString());
           lvItem.SubItems.Add(item.SaleRate.ToString());
            
        }

        protected override IList<CantProductInfo> GetFilteredList(IList<CantProductInfo> fullList, string filterstring)
        {
            if (fullList == null || fullList.Count == 0) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.Id.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<CantProductInfo> GetItems()
        {
            return new CantItemService().GetAllProduct();
        }

        protected override IList<CantProductInfo> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<CantProductInfo> GetItemsByTypeFromSuppliedList(string _type, List<CantProductInfo> item)
        {
            throw new NotImplementedException();
        }
    }
}
