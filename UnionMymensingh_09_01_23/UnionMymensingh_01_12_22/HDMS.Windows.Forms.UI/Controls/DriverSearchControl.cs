using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Vehicle;
using HDMS.Service.Vehicle;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class DriverSearchControl : SearchResultListControl<DriverInfo>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3;

            header1 = new ColumnHeader();
            header1.Text = "Name";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 150;

            header2 = new ColumnHeader();
            header2.Text = "Mobile No";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 130;

            header3 = new ColumnHeader();
            header3.Text = "Address";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 200;

            


            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            
            
        }

        protected override void FillListViewItem(ListViewItem lvItem, DriverInfo item)
        {
            lvItem.Text = item.DriverName;
           
            lvItem.SubItems.Add(item.MobileNo);
            lvItem.SubItems.Add(item.Address);
        }

        protected override IList<DriverInfo> GetFilteredList(IList<DriverInfo> fullList, string filterstring)
        {
            if (fullList == null) return null;
            return fullList.Where(x=>x.DriverName.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<DriverInfo> GetItems()
        {
            return new VehicleService().GetAllAvailableDriver();
          
        }

        protected override IList<DriverInfo> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<DriverInfo> GetItemsByTypeFromSuppliedList(string _type, List<DriverInfo> item)
        {
            throw new NotImplementedException();
        }
    }
}
