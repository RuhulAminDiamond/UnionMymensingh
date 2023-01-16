using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Windows.Forms.UI.Vehicle;
using HDMS.Model.Vehicle;
using HDMS.Service.Vehicle;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class RouteSearchControl : SearchResultListControl<RoutingOrTripInfo>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader  header2,header3;

            

            header3 = new ColumnHeader();
            header3.Text = "Destination";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 350;

            header2 = new ColumnHeader();
            header2.Text = "Rent";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 130;
           
            view.Columns.Add(header2);
            view.Columns.Add(header3);
        }

        protected override void FillListViewItem(ListViewItem lvItem, RoutingOrTripInfo item)
        {
            lvItem.Text = item.Destination;
            
            lvItem.SubItems.Add(item.Rent.ToString());
        }

        protected override IList<RoutingOrTripInfo> GetFilteredList(IList<RoutingOrTripInfo> fullList, string filterstring)
        {
            if (fullList == null) return null;
            return fullList.Where(x => x.Destination.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<RoutingOrTripInfo> GetItems()
        {
            return new VehicleService().GetAllRoute();
       
        }

        protected override IList<RoutingOrTripInfo> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<RoutingOrTripInfo> GetItemsByTypeFromSuppliedList(string _type, List<RoutingOrTripInfo> item)
        {
            throw new NotImplementedException();
        }
    }
}
