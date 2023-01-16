using HDMS.Model;
using HDMS.Service.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class ctrlPatientSerialBooking : SearchResultListControl<PractitionerWisePatientSerial>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3;

            header1 = new ColumnHeader();
            header1.Text = "Mobile";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 160;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 200;

            header3 = new ColumnHeader();
            header3.Text = "Age";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 80;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
        }

        protected override void FillListViewItem(ListViewItem lvItem, PractitionerWisePatientSerial item)
        {
            lvItem.Text = item.MobileNo.ToString();
            lvItem.SubItems.Add(item.PatientName);
            lvItem.SubItems.Add(item.AgeYear.ToString());
        }

        protected override IList<PractitionerWisePatientSerial> GetFilteredList(IList<PractitionerWisePatientSerial> fullList, string filterstring)
        {
            if (fullList == null)
                return null;
            return fullList.Where(x=>x.MobileNo.Contains(filterstring)).ToList();
        }

        protected override IList<PractitionerWisePatientSerial> GetItems()
        {
            return new CommonService().GetAllPatient();

        }

        protected override IList<PractitionerWisePatientSerial> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<PractitionerWisePatientSerial> GetItemsByTypeFromSuppliedList(string _type, List<PractitionerWisePatientSerial> item)
        {
            throw new NotImplementedException();
        }
    }
}
