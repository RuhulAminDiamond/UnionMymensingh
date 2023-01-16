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
    public partial class RxCpAdviceSearchControl : SearchResultListControl<RxCPAdvice>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 2000;
            ColumnHeader header1, header2;

            header1 = new ColumnHeader();
            header1.Text = "Advice En";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 320;

            header2 = new ColumnHeader();
            header2.Text = "Advice Bn";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 390;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
        }

        protected override void FillListViewItem(ListViewItem lvItem, RxCPAdvice item)
        {
            lvItem.Text = item.AdviceEn;
            lvItem.SubItems.Add(item.AdviceBn);
        }

        protected override IList<RxCPAdvice> GetFilteredList(IList<RxCPAdvice> fullList, string filterstring)
        {
            if (fullList == null) return null;

           
            return fullList.Where(x => x.AdviceEn.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<RxCPAdvice> GetItems()
        {
            throw new NotImplementedException();
        }

        protected override IList<RxCPAdvice> GetItemsByType(string _type)
        {
            int _CpId = 0;
            int.TryParse(_type,out _CpId);

            return new RxService().GetRxCPAdvices(_CpId);
        }

        protected override IList<RxCPAdvice> GetItemsByTypeFromSuppliedList(string _type, List<RxCPAdvice> item)
        {
            throw new NotImplementedException();
        }
    }
}
