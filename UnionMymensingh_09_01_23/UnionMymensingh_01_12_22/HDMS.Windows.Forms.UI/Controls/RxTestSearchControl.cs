using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model;
using HDMS.Service.Diagonstics;
using HDMS.Model.Rx;
using HDMS.Service.Rx;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class RxTestSearchControl : SearchResultListControl<RxCPPreferredTest>
    {
      
        protected override IList<RxCPPreferredTest> GetItems()
        {
            return new RxService().GetCpAllPreferredTests();

        }

        protected override void FillListColumns(ListView view)
        {
            view.Width = 2500;
            ColumnHeader header1, header2;

            header1 = new ColumnHeader();
            header1.Text = "Code";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 80;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 350;

            

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            
        }

        protected override void FillListViewItem(ListViewItem lvItem, RxCPPreferredTest item)
        {
            lvItem.Text = item.CPPTId.ToString();
//            lvItem.SubItems.Add(item.Itemid.Tostring());
            lvItem.SubItems.Add(item.TestName);
            
        }

        protected override IList<RxCPPreferredTest> GetFilteredList(IList<RxCPPreferredTest> fullList, string filterstring)
        {

            if (fullList == null) return null;

            int itemId;
            if(int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.TestId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.TestName.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<RxCPPreferredTest> GetItemsByType(string _type)
        {
            int _CpId = 0;
            int.TryParse(_type,out _CpId);
            return new RxService().GetRxCpAllPreferredTests(_CpId);
        }

        protected override IList<RxCPPreferredTest> GetItemsByTypeFromSuppliedList(string _type, List<RxCPPreferredTest> item)
        {
            throw new NotImplementedException();
        }
    }
}
