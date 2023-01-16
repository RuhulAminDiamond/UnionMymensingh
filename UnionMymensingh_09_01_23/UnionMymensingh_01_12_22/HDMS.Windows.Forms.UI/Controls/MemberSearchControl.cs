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
using HDMS.Service.Common;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class MemberSearchControl : SearchResultListControl<MemberInfo>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4;

            header1 = new ColumnHeader();
            header1.Text = "MemberId";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 220;

            header3 = new ColumnHeader();
            header3.Text = "Mobile No";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 120;

            header4 = new ColumnHeader();
            header4.Text = "Address";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 250;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);
        }

        protected override void FillListViewItem(ListViewItem lvItem, MemberInfo item)
        {
            lvItem.Text = item.MemberId.ToString();
            lvItem.SubItems.Add(item.Name);
            lvItem.SubItems.Add(item.MobileNo);
            lvItem.SubItems.Add(item.Address);
        }

        protected override IList<MemberInfo> GetFilteredList(IList<MemberInfo> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.MemberId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<MemberInfo> GetItems()
        {
            return new MemberService().GetMemberList();
        }

        protected override IList<MemberInfo> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<MemberInfo> GetItemsByTypeFromSuppliedList(string _type, List<MemberInfo> item)
        {
            throw new NotImplementedException();
        }
    }
}
