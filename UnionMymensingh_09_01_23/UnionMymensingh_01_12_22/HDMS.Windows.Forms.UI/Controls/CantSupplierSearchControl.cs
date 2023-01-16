using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Common;
using Services.POS;
using HDMS.Service.Common;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class CantSupplierSearchControl :  SearchResultListControl<SupplierInfo>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 4500;
            ColumnHeader header1, header2;

            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 200;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 550;


            view.Columns.Add(header1);
            view.Columns.Add(header2);

        }

        protected override void FillListViewItem(ListViewItem lvItem, SupplierInfo item)
        {
            lvItem.Text = item.SupplierId.ToString();
            lvItem.SubItems.Add(item.Name);

        }

        protected override IList<SupplierInfo> GetItems()
        {
            return new SupplierService().GetCanteenSuppliers();
        }

        protected override IList<SupplierInfo> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<SupplierInfo> GetFilteredList(IList<SupplierInfo> fullList, string filterstring)
        {
            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.SupplierId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<SupplierInfo> GetItemsByTypeFromSuppliedList(string _type, List<SupplierInfo> item)
        {
            throw new NotImplementedException();
        }
    }
}
