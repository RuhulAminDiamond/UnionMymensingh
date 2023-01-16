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
    public partial class DiagnosisSearchControl : SearchResultListControl<RxDiagnosis>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2;

            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 450;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
          
        }

        protected override void FillListViewItem(ListViewItem lvItem, RxDiagnosis item)
        {
            lvItem.Text = item.DiagnosisId.ToString();
            lvItem.SubItems.Add(item.Name);
         
        }

        protected override IList<RxDiagnosis> GetFilteredList(IList<RxDiagnosis> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.DiagnosisId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<RxDiagnosis> GetItems()
        {
            return new RxService().GetAllDiagnosis();
        }

        protected override IList<RxDiagnosis> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<RxDiagnosis> GetItemsByTypeFromSuppliedList(string _type, List<RxDiagnosis> item)
        {
            throw new NotImplementedException();
        }
    }
}
