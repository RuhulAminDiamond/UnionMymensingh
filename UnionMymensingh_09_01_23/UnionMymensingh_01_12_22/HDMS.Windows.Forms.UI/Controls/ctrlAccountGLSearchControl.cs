using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Windows.Forms.UI.Controls;

using HDMS.Service.Accounting;
using Models.Accounting;
using HDMS.Model.Accounting.VModel;

namespace HDMS.Windows.Forms.UI.Accounts
{
    public partial class CtrlAccountGLSearchControl : SearchResultListControl<VMAccountHeads>
    {
        protected override void FillListColumns(System.Windows.Forms.ListView view)
        {
            view.Width = 5000;
            ColumnHeader header1, header2, header3;

            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "G. Ledger Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 450;

            header3 = new ColumnHeader();
            header3.Text = "Group Name";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 450;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
        }

        protected override void FillListViewItem(System.Windows.Forms.ListViewItem lvItem, VMAccountHeads item)
        {
            lvItem.Text = item.AccId.ToString();
            lvItem.SubItems.Add(item.AccountHeadName);
            lvItem.SubItems.Add(item.GroupName);
        }

        protected override IList<VMAccountHeads> GetItems()
        {
            return new AccountService().GetAllPostingAccountHeads();
        }

        protected override IList<VMAccountHeads> GetFilteredList(IList<VMAccountHeads> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.AccId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.AccountHeadName.ToLower().Contains(filterstring.ToLower())).ToList();

        }

        protected override IList<VMAccountHeads> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<VMAccountHeads> GetItemsByTypeFromSuppliedList(string _type, List<VMAccountHeads> item)
        {
            throw new NotImplementedException();
        }

    }
}
