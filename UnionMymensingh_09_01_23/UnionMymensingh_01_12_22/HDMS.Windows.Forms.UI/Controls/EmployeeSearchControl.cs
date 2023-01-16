using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.HR;
using HDMS.Service.HR;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class EmployeeSearchControl : SearchResultListControl<VMEmployeeInfo>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4;

            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 220;

            header3 = new ColumnHeader();
            header3.Text = "Dept";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 120;

            header4 = new ColumnHeader();
            header4.Text = "Designation";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 150;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);
        }

        protected override void FillListViewItem(ListViewItem lvItem, VMEmployeeInfo item)
        {
            lvItem.Text = item.EmployeeId.ToString();
            lvItem.SubItems.Add(item.EmployeeName);
            lvItem.SubItems.Add(item.DeptName);
            lvItem.SubItems.Add(item.Designation);
        }

        protected override IList<VMEmployeeInfo> GetFilteredList(IList<VMEmployeeInfo> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.EmployeeId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.EmployeeName.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<VMEmployeeInfo> GetItems()
        {
            return new EmployeeService().GetEmployeeList();
        }

        protected override IList<VMEmployeeInfo> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<VMEmployeeInfo> GetItemsByTypeFromSuppliedList(string _type, List<VMEmployeeInfo> item)
        {
            throw new NotImplementedException();
        }
    }
}
