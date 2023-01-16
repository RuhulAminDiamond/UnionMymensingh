using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model;
using HDMS.Service.Doctors;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class DoctorSearchControl2 : SearchResultListControl<Doctor>
    {
        protected override void FillListColumns(System.Windows.Forms.ListView view)
        {
            view.Width = 6800;
            ColumnHeader header1, header2, header3, header4, header5, header6, header7, header8;

            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "Doctor Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 380;

            header3 = new ColumnHeader();
            header3.Text = "C.Fee(B.New)";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 140;


            header4 = new ColumnHeader();
            header4.Text = "C.Fee(New)";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 130;


            header5 = new ColumnHeader();
            header5.Text = "C.Fee(Old)";
            header5.TextAlign = HorizontalAlignment.Left;
            header5.Width = 130;

            header6 = new ColumnHeader();
            header6.Text = "C.Fee(S/G)";
            header6.TextAlign = HorizontalAlignment.Left;
            header6.Width = 130;

          
            header7 = new ColumnHeader();
            header7.Text = "C.Fee(IPD)";
            header7.TextAlign = HorizontalAlignment.Left;
            header7.Width = 130;

            header8 = new ColumnHeader();
            header8.Text = "C.Fee(Report)";
            header8.TextAlign = HorizontalAlignment.Left;
            header8.Width = 140;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);
            view.Columns.Add(header5);
            view.Columns.Add(header6);
            view.Columns.Add(header7);
            view.Columns.Add(header8);
        }

        protected override void FillListViewItem(System.Windows.Forms.ListViewItem lvItem, Doctor item)
        {
            lvItem.Text = item.DoctorId.ToString();
            lvItem.SubItems.Add(item.Name);
            lvItem.SubItems.Add(item.ConsultancyFee1.ToString());
            lvItem.SubItems.Add(item.ConsultancyFee2.ToString());
            lvItem.SubItems.Add(item.ConsultancyFee3.ToString());
            lvItem.SubItems.Add(item.ConsultancyFee4.ToString());
            lvItem.SubItems.Add(item.IPDConsultancyFee.ToString());
            lvItem.SubItems.Add(item.ConsultancyFeeReportOpinion.ToString());
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
