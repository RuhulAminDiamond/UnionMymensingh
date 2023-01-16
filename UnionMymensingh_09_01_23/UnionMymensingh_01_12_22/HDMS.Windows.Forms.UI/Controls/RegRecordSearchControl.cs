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
    public partial class RegRecordSearchControl : SearchResultListControl<RegRecord>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4;

            header1 = new ColumnHeader();
            header1.Text = "Reg No";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 120;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 350;

            header3 = new ColumnHeader();
            header3.Text = "Mobile No";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 150;


            header4 = new ColumnHeader();
            header4.Text = "Address";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 200;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);
        }

        protected override void FillListViewItem(ListViewItem lvItem, RegRecord _record)
        {

            lvItem.Text = _record.RegNo.ToString();
            lvItem.SubItems.Add(_record.FullName);
            lvItem.SubItems.Add(_record.MobileNo);
            lvItem.SubItems.Add(_record.Address);
        }

        protected override IList<RegRecord> GetFilteredList(IList<RegRecord> fullList, string filterstring)
        {

            return fullList.Where(x => x.RegNo.ToString(). Contains(filterstring.ToLower())).ToList();
        }
        
        protected override IList<RegRecord> GetItems()
        {
            throw new NotImplementedException();
        }

        protected override IList<RegRecord> GetItemsByType(string _RegNo)
        {
            return new RegRecordService().GetAllRegistrationByRegNoWildCard(_RegNo);
        }

        protected override IList<RegRecord> GetItemsByTypeFromSuppliedList(string _type, List<RegRecord> item)
        {
            throw new NotImplementedException();
        }
    }
}
