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
    public partial class OPDPatientSearchControl : SearchResultListControl<VMIPDInfo>
    {
       

        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4;

            header1 = new ColumnHeader();
            header1.Text = "BillNo";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 150;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 250;

            header3 = new ColumnHeader();
            header3.Text = "Cabin";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 150;

           
            header4 = new ColumnHeader();
            header4.Text = "Status";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 120;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);
          
        }

        protected override void FillListViewItem(ListViewItem lvItem, VMIPDInfo item)
        {
            lvItem.Text = item.BillNo.ToString();
      
            lvItem.SubItems.Add(item.Name);

            lvItem.SubItems.Add(item.BedCabinNo);

            lvItem.SubItems.Add(item.Status);

        }

        protected override IList<VMIPDInfo> GetItems()
        {
            return new HospitalService().GetCurrentOPDInfo();
        }

        protected override IList<VMIPDInfo> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<VMIPDInfo> GetFilteredList(IList<VMIPDInfo> fullList, string filterstring)
        {
            if (fullList == null) return null;

            //int AdmissionNo;
            //if (int.TryParse(filterstring, out AdmissionNo))
            //{
            //    return fullList.Where(x => x.AdmissionId.ToString().Contains(filterstring)).ToList();
            //}
            return fullList.Where(x => x.BedCabinNo.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<VMIPDInfo> GetItemsByTypeFromSuppliedList(string _type, List<VMIPDInfo> item)
        {
            throw new NotImplementedException();
        }
    }
}
