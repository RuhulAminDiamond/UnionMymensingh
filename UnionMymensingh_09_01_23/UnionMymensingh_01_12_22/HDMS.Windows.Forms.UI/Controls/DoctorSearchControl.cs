using HDMS.Model;
using HDMS.Service.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Controls
{
    public class DoctorSearchControl:SearchResultListControl<Doctor>
    {
        protected override void FillListColumns(System.Windows.Forms.ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2;

            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "Doctor Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 500;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
        }

        protected override void FillListViewItem(System.Windows.Forms.ListViewItem lvItem, Doctor item)
        {
            lvItem.Text = item.DoctorId.ToString();
            lvItem.SubItems.Add(item.Name);
        }

        protected override IList<Doctor> GetItems()
        {
            return new DoctorService().GetAllDoctors();
        }

        protected override IList<Doctor> GetFilteredList(IList<Doctor> fullList, string filterstring)
        {

            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.DoctorId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();

        }

        protected override IList<Doctor> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<Doctor> GetItemsByTypeFromSuppliedList(string _type, List<Doctor> item)
        {
            throw new NotImplementedException();
        }
    }
}
