using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Users;
using HDMS.Service;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class UserSearchControl : SearchResultListControl<VMUserDetail>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4;

            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 75;

            header2 = new ColumnHeader();
            header2.Text = "Login Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 150;

            header3 = new ColumnHeader();
            header3.Text = "Full Name";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 150;

            header4 = new ColumnHeader();
            header4.Text = "Role";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 150;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);

        }

        protected override void FillListViewItem(ListViewItem lvItem, VMUserDetail item)
        {
            lvItem.Text = item.Id.ToString();
            lvItem.SubItems.Add(item.LoginName);
            lvItem.SubItems.Add(item.FullName);
            lvItem.SubItems.Add(item.RoleName);
        }

        protected override IList<VMUserDetail> GetFilteredList(IList<VMUserDetail> fullList, string filterstring)
        {
            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.Id.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.LoginName.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<VMUserDetail> GetItems()
        {
            return new UserService().GetUserDetails().ToList();
        }

        protected override IList<VMUserDetail> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<VMUserDetail> GetItemsByTypeFromSuppliedList(string _type, List<VMUserDetail> item)
        {
            throw new NotImplementedException();
        }
    }
}
