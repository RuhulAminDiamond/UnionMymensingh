using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Marketing;
using HDMS.Service.Common;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class MarketingAgentSearchControl : SearchResultListControl<MarketingAgent>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 4500;
            ColumnHeader header1, header2;

            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 200;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 550;


            view.Columns.Add(header1);
            view.Columns.Add(header2);
        }

        protected override void FillListViewItem(ListViewItem lvItem, MarketingAgent item)
        {
            lvItem.Text = item.MAId.ToString();
            lvItem.SubItems.Add(item.Name);
        }

        protected override IList<MarketingAgent> GetFilteredList(IList<MarketingAgent> fullList, string filterstring)
        {
            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.MAId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<MarketingAgent> GetItems()
        {
            return new CommonService().GetAllMarketingAgents();
        }

        protected override IList<MarketingAgent> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<MarketingAgent> GetItemsByTypeFromSuppliedList(string _type, List<MarketingAgent> item)
        {
            throw new NotImplementedException();
        }
    }
}
