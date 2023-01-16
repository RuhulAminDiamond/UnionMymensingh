using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Service.Hospital;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class ExtraCabinSearchControl : SearchResultListControl<VMCabinInfo>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4;

            header1 = new ColumnHeader();
            header1.Text = "CabinId";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "Cabin No";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 120;

            header3 = new ColumnHeader();
            header3.Text = "Floor";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 200;

            header4 = new ColumnHeader();
            header4.Text = "Rent";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 100;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);
        }

        protected override void FillListViewItem(ListViewItem lvItem, VMCabinInfo item)
        {
            lvItem.Text = item.CabinId.ToString();
            lvItem.SubItems.Add(item.CabinNo);
            lvItem.SubItems.Add(item.Floor);
            lvItem.SubItems.Add(item.Rent.ToString());
        }

        protected override IList<VMCabinInfo> GetFilteredList(IList<VMCabinInfo> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.CabinId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.CabinNo.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<VMCabinInfo> GetItems()
        {
            return new HospitalCabinBedService().GetVMAllCabinList();
        }

        protected override IList<VMCabinInfo> GetItemsByType(string _type)
        {
            return new HospitalCabinBedService().GetVMExtraCabinList(_type);
        }

        protected override IList<VMCabinInfo> GetItemsByTypeFromSuppliedList(string _type, List<VMCabinInfo> item)
        {
            throw new NotImplementedException();
        }
    }
}
