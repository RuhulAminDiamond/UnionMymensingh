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
    public partial class CantMemberSearchControl : SearchResultListControl<CantMemberInfo>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 4500;
            ColumnHeader header1, header2, header3;

            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 550;

            header3 = new ColumnHeader();
            header3.Text = "Address";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 550;


            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
        }

        protected override void FillListViewItem(ListViewItem lvItem, CantMemberInfo item)
        {
            lvItem.Text = item.MemberId.ToString();
            lvItem.SubItems.Add(item.Name);
            lvItem.SubItems.Add(item.Address);
        }

        protected override IList<CantMemberInfo> GetFilteredList(IList<CantMemberInfo> fullList, string filterstring)
        {
            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.MemberId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<CantMemberInfo> GetItems()
        {
            return new CantItemService().GetAllCustomer();
        }

        protected override IList<CantMemberInfo> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<CantMemberInfo> GetItemsByTypeFromSuppliedList(string _type, List<CantMemberInfo> item)
        {
            throw new NotImplementedException();
        }
    }
}
