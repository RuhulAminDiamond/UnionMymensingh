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
using HDMS.Service.Pharmacy;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class ctrlPhMemberSearchControl : SearchResultListControl<PhMemberInfo>
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
            header2.Width = 250;

            header3 = new ColumnHeader();
            header3.Text = "Category";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 250;


            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
        }

        protected override void FillListViewItem(ListViewItem lvItem, PhMemberInfo item)
        {
            lvItem.Text = item.MemberId.ToString();
            lvItem.SubItems.Add(item.Name);
            lvItem.SubItems.Add(item.MembershipCategory);

        }

        protected override IList<PhMemberInfo> GetFilteredList(IList<PhMemberInfo> fullList, string filterstring)
        {
            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.MemberId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<PhMemberInfo> GetItems()
        {
            return new PhFinancialService().GetAllMember();
        }

        protected override IList<PhMemberInfo> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<PhMemberInfo> GetItemsByTypeFromSuppliedList(string _type, List<PhMemberInfo> item)
        {
            throw new NotImplementedException();
        }
    }
}
