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
    public partial class JobCircularSearchControl :  SearchResultListControl<JobCirculation>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3;

            header1 = new ColumnHeader();
            header1.Text = "JCId";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 150;

            header2 = new ColumnHeader();
            header2.Text = "Circular No";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 150;

            header3 = new ColumnHeader();
            header3.Text = "Circular Title";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 350;



            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);

        }

        protected override void FillListViewItem(ListViewItem lvItem, JobCirculation item)
        {
            lvItem.Text = item.JCId.ToString();

            lvItem.SubItems.Add(item.CirculationNo);

            lvItem.SubItems.Add(item.CirculationTitle);


        }

        protected override IList<JobCirculation> GetFilteredList(IList<JobCirculation> fullList, string filterstring)
        {
            if (fullList == null) return null;


            return fullList.Where(x => x.CirculationNo.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<JobCirculation> GetItems()
        {
            return new HrCommonService().GetAllJobCircular();
        }

        protected override IList<JobCirculation> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<JobCirculation> GetItemsByTypeFromSuppliedList(string _type, List<JobCirculation> item)
        {
            throw new NotImplementedException();
        }
    }

}
