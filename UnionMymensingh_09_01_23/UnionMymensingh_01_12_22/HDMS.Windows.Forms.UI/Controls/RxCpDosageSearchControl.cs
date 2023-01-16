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
    public partial class RxCpDosageSearchControl : SearchResultListControl<RxCpDosage>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3;

            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "Dose In Bangla";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 300;

            header3 = new ColumnHeader();
            header3.Text = "Dose In English";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 300;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
        }

        protected override void FillListViewItem(ListViewItem lvItem, RxCpDosage item)
        {
            lvItem.Text = item.DoseId.ToString();
            lvItem.SubItems.Add(item.DoseBnLong);
            lvItem.SubItems.Add(item.DoseEnLong);
        }

        protected override IList<RxCpDosage> GetFilteredList(IList<RxCpDosage> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.DoseId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.DoseEnLong.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<RxCpDosage> GetItems()
        {
            return new RxService().GetAllDosage();
        }

        protected override IList<RxCpDosage> GetItemsByType(string _type)
        {
            int _CpId = 0;
            int.TryParse(_type, out _CpId);

            return new RxService().GetRxCPDosages(_CpId);
        }

        protected override IList<RxCpDosage> GetItemsByTypeFromSuppliedList(string _type, List<RxCpDosage> item)
        {
            throw new NotImplementedException();
        }
    }
}
