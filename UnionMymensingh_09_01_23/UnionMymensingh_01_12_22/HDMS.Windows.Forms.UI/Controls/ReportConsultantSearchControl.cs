using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model;
using HDMS.Service.Doctors;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class ReportConsultantSearchControl : SearchResultListControl<ReportConsultant>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4, header5;

            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "Doctor Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 300;

            header3 = new ColumnHeader();
            header3.Text = "Identity 1";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 200;


            header4 = new ColumnHeader();
            header4.Text = "Identity 2";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 200;

            header5 = new ColumnHeader();
            header5.Text = "Identity 3";
            header5.TextAlign = HorizontalAlignment.Left;
            header5.Width = 200;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);
            view.Columns.Add(header5);
        }

        protected override void FillListViewItem(ListViewItem lvItem, ReportConsultant item)
        {
            lvItem.Text = item.RCId.ToString();
            lvItem.SubItems.Add(item.Name);
            lvItem.SubItems.Add(item.DIdentityLine1);
            lvItem.SubItems.Add(item.DIdentityLine2);
            lvItem.SubItems.Add(item.DIdentityLine3);
        }

        protected override IList<ReportConsultant> GetFilteredList(IList<ReportConsultant> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.RCId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<ReportConsultant> GetItems()
        {
            return new DoctorService().GetAllConsultants();
        }

        protected override IList<ReportConsultant> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<ReportConsultant> GetItemsByTypeFromSuppliedList(string _type, List<ReportConsultant> item)
        {
            throw new NotImplementedException();
        }
    }
}
