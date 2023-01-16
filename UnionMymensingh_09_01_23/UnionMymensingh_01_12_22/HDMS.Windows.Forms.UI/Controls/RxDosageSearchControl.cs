using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Rx;
using HDMS.Service.Rx;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class RxDosageSearchControl : SearchResultListControl<RxDosage>
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
            header2.Text = "Long Dose Bangla";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 300;

            header3 = new ColumnHeader();
            header3.Text = "Long Dose English";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 300;

            header4 = new ColumnHeader();
            header4.Text = "Short Dose Bangla";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 180;

            header5 = new ColumnHeader();
            header5.Text = "Short Dose English";
            header5.TextAlign = HorizontalAlignment.Left;
            header5.Width = 180;

            view.Columns.Add(header1);
            view.Columns.Add(header3);
            view.Columns.Add(header2);
            view.Columns.Add(header5);
            view.Columns.Add(header4);
        }

        protected override void FillListViewItem(ListViewItem lvItem, RxDosage item)
        {
            lvItem.Text = item.DoseId.ToString();
            lvItem.SubItems.Add(item.DoseEnLong);
            lvItem.SubItems.Add(item.DoseBnLong);
            lvItem.SubItems.Add(item.DoseEnShort);
            lvItem.SubItems.Add(item.DoseBnShort);
        }

        protected override IList<RxDosage> GetFilteredList(IList<RxDosage> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.DoseId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.DoseEnShort.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<RxDosage> GetItems()
        {
            return new RxService().GetRxCDbAllDosage();
        }

        protected override IList<RxDosage> GetItemsByType(string _type)
        {
            return null;
        }

        protected override IList<RxDosage> GetItemsByTypeFromSuppliedList(string _type, List<RxDosage> item)
        {
            throw new NotImplementedException();
        }
    }
}
