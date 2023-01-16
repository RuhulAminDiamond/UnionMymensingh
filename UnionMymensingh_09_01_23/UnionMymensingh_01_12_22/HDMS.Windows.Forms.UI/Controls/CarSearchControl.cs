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
    public partial class CarSearchControl : SearchResultListControl<CarInfo>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 4500;
            ColumnHeader  header2, header3,header4;

           

            header2 = new ColumnHeader();
            header2.Text = "Car No";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 130;

            header3 = new ColumnHeader();
            header3.Text = "Car Chasis";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 150;

            header4 = new ColumnHeader();
            header4.Text = "Car Condition";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 150;

            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);
        }

        protected override void FillListViewItem(ListViewItem lvItem, CarInfo item)
        {
            lvItem.Text = item.CarNo;
            
            lvItem.SubItems.Add(item.ChasisNo);
            lvItem.SubItems.Add(item.Condiotion);
        }

        protected override IList<CarInfo> GetFilteredList(IList<CarInfo> fullList, string filterstring)
        {
            if (fullList == null)
                return null;
            return fullList.Where(x=>x.CarNo.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<CarInfo> GetItems()
        {
            return new VehicleService().GetAllAvailableCar();
        }

        protected override IList<CarInfo> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<CarInfo> GetItemsByTypeFromSuppliedList(string _type, List<CarInfo> item)
        {
            throw new NotImplementedException();
        }
    }
}
