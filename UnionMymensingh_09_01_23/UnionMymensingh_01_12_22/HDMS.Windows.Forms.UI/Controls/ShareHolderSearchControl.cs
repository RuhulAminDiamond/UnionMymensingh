using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.ShareHolder;
using System.CodeDom;
using HDMS.Service.ShareHolder;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class ShareHolderSearchControl : SearchResultListControl<VMshareTransfer>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4;

            header1 = new ColumnHeader();
            header1.Text = "Name";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 150;

            header2 = new ColumnHeader();
            header2.Text = "Share No";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 130;

            header3 = new ColumnHeader();
            header3.Text = "Mobile No";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 100;

            header4 = new ColumnHeader();
            header4.Text = "Äddress";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 180;


            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);
        }

        
        protected override void FillListViewItem(ListViewItem lvItem, VMshareTransfer item)
        {
            lvItem.Text = item.ShId.ToString();
            lvItem.SubItems.Add(item.ShName);
            lvItem.SubItems.Add(item.ShMobile);
            lvItem.SubItems.Add(item.ShPermanentAddress);
        }
        protected override IList<VMshareTransfer> GetFilteredList(IList<VMshareTransfer> fullList, string filterstring)
        {
            if (fullList == null) return null;
            return fullList.Where(x => x.ShName.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<VMshareTransfer> GetItems()
        {
            return new ShareHolderService().GetShareHolderDetails();
        }

        protected override IList<VMshareTransfer> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<VMshareTransfer> GetItemsByTypeFromSuppliedList(string _type, List<VMshareTransfer> item)
        {
            throw new NotImplementedException();
        }
    }
}
