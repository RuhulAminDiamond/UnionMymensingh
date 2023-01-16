using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Pharmacy;
using HDMS.Service.Pharmacy;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class ctrlPhProductInfoWithGenMan : SearchResultListControl<VWPhProductList>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4;

            header1 = new ColumnHeader();
            header1.Text = "Product Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 150;

            header2 = new ColumnHeader();
            header2.Text = "Brand Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 250;


            header3 = new ColumnHeader();
            header3.Text = "Generic";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 200;



            header4 = new ColumnHeader();
            header4.Text = "Manufacturer";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 250;

           
            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);
            
        }

        protected override void FillListViewItem(ListViewItem lvItem, VWPhProductList item)
        {
            lvItem.Text = item.ProductId.ToString();
            lvItem.SubItems.Add(item.BrandName);
            lvItem.SubItems.Add(item.GenericName);
            lvItem.SubItems.Add(item.Manufacturer.ToString());
            
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

        protected override IList<VWPhProductList> GetItems()
        {
            throw new NotImplementedException();
        }

        protected override IList<VWPhProductList> GetItemsByType(string _filterString)
        {
            return new PhProductService().GetProductListWithStock(_filterString);
        }

        protected override IList<VWPhProductList> GetItemsByTypeFromSuppliedList(string _type, List<VWPhProductList> item)
        {
            throw new NotImplementedException();
        }
    }
}
