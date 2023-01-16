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
using HDMS.Model;
using HDMS.Service.Diagonstics;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class TestSearchControl : SearchResultListControl<TestItem>
    {
        public TestSearchControl()
        {
            InitializeComponent();
        }

        protected override IList<TestItem> GetItems()
        {
            return new TestService().GetAllTests();

        }

        protected override void FillListColumns(ListView view)
        {
            view.Width = 5500;
            ColumnHeader header1, header2, header3;

            header1 = new ColumnHeader();
            header1.Text = "Code";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 80;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 500;

            header3 = new ColumnHeader();
            header3.Text = "Rate";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 100;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
        }

        protected override void FillListViewItem(ListViewItem lvItem, TestItem item)
        {
            lvItem.Text = item.TestCode.ToString();
//            lvItem.SubItems.Add(item.Itemid.Tostring());
            lvItem.SubItems.Add(item.Name);
            lvItem.SubItems.Add(item.Rate.ToString());
        }

        protected override IList<TestItem> GetFilteredList(IList<TestItem> fullList, string filterstring)
        {

            if (fullList == null) return null;

            int itemId;
            if(int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.TestId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<TestItem> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<TestItem> GetItemsByTypeFromSuppliedList(string _type, List<TestItem> item)
        {
            throw new NotImplementedException();
        }
    }
}
