using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.HR;
using HDMS.Service.HR;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class JobCVSearchControl : SearchResultListControl<JobCV>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4;

            header1 = new ColumnHeader();
            header1.Text = "JCVId";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 80;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 220;

            header3 = new ColumnHeader();
            header3.Text = "Mobile No";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 100;

            header4 = new ColumnHeader();
            header4.Text = "Apply for";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 120;


            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);

        }

        protected override void FillListViewItem(ListViewItem lvItem, JobCV item)
        {
            lvItem.Text = item.JCVId.ToString();

            lvItem.SubItems.Add(item.ApplicatName);

            lvItem.SubItems.Add(item.ApplicatMobileNo);

            lvItem.SubItems.Add(item.Applyfor);
        }

        protected override IList<JobCV> GetFilteredList(IList<JobCV> fullList, string filterstring)
        {
            if (fullList == null) return null;


            return fullList.Where(x => x.ApplicatMobileNo.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<JobCV> GetItems()
        {
            return null;
        }

        protected override IList<JobCV> GetItemsByType(string _type)
        {
            return new HrCommonService().GetAllJobCVByCircular(_type);
        }

        protected override IList<JobCV> GetItemsByTypeFromSuppliedList(string _type, List<JobCV> item)
        {
            throw new NotImplementedException();
        }
    }
}
