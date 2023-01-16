using HDMS.Model.Diagnostic;
using HDMS.Service.Diagonstics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class TestGroupSearchControl : SearchResultListControl<TestGroup>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 3500;
            ColumnHeader header1, header2;

            header1 = new ColumnHeader();
            header1.Text = "Group.Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 80;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 350;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
           
        }

        protected override void FillListViewItem(ListViewItem lvItem, TestGroup item)
        {
            lvItem.Text = item.TestGroupId.ToString();
            lvItem.SubItems.Add(item.Name);
        }

        protected override IList<TestGroup> GetFilteredList(IList<TestGroup> fullList, string filterstring)
        {
            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.TestGroupId.ToString().Contains(filterstring)).ToList();
            }

            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<TestGroup> GetItems()
        {
            return new TestService().GetTestGroups();
        }

        protected override IList<TestGroup> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<TestGroup> GetItemsByTypeFromSuppliedList(string _type, List<TestGroup> item)
        {
            throw new NotImplementedException();
        }
    }
}
