using HDMS.Model;
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
    public partial class ReportTypeSearchControl : SearchResultListControl<ReportType>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 3500;
            ColumnHeader header1, header2;

            header1 = new ColumnHeader();
            header1.Text = "ReportType.Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 80;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 350;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
        }

        protected override void FillListViewItem(ListViewItem lvItem, ReportType item)
        {
            lvItem.Text = item.ReportTypeId.ToString();
            lvItem.SubItems.Add(item.Report_Type);
        }

        protected override IList<ReportType> GetFilteredList(IList<ReportType> fullList, string filterstring)
        {
            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.ReportTypeId.ToString().Contains(filterstring)).ToList();
            }

            return fullList.Where(x => x.Report_Type.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<ReportType> GetItems()
        {
            return new TestService().GetAllReportTypes();
        }

        protected override IList<ReportType> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<ReportType> GetItemsByTypeFromSuppliedList(string _type, List<ReportType> item)
        {
            throw new NotImplementedException();
        }
    }
}
