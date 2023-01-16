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
    public partial class RxTestTemplateSearchControl : SearchResultListControl<RxCPTestTemplateMaster>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 3500;
            ColumnHeader header1, header2;

            header1 = new ColumnHeader();
            header1.Text = "T.Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 350;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
        }

        protected override void FillListViewItem(ListViewItem lvItem, RxCPTestTemplateMaster item)
        {
            lvItem.Text = item.TemplateId.ToString();
            lvItem.SubItems.Add(item.Name);
        }

        protected override IList<RxCPTestTemplateMaster> GetFilteredList(IList<RxCPTestTemplateMaster> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.TemplateId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<RxCPTestTemplateMaster> GetItems()
        {
            throw new NotImplementedException();
        }

        protected override IList<RxCPTestTemplateMaster> GetItemsByType(string _type)
        {
            return new RxService().GetRxTestTemplateItems(_type);
        }

        protected override IList<RxCPTestTemplateMaster> GetItemsByTypeFromSuppliedList(string _type, List<RxCPTestTemplateMaster> item)
        {
            throw new NotImplementedException();
        }
    }
}
