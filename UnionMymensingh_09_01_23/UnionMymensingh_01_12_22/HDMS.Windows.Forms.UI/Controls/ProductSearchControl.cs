using HDMS.Model;
using Services.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class ProductSearchControl :  SearchResultListControl<ProductInfo>
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

        protected override void FillListViewItem(ListViewItem lvItem, ProductInfo item)
        {
            lvItem.Text = item.Id.ToString();
            lvItem.SubItems.Add(item.Name);
            lvItem.SubItems.Add(new ProductService().GetCurrentStockByProductId(item.Id).ToString());

            
                lvItem.SubItems.Add(item.PurchaseRate.ToString());
            

        }

        protected override IList<ProductInfo> GetItems()
        {
            return new ProductService().GetAllProduct();
        }

        protected override IList<ProductInfo> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<ProductInfo> GetFilteredList(IList<ProductInfo> fullList, string filterstring)
        {
            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.Id.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();
        }
    }
}
