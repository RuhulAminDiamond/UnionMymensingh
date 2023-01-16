using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Common;
using HDMS.Service.Doctors;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class MediaSearchControl : SearchResultListControl<BusinessMedia>
    {
        protected override void FillListColumns(System.Windows.Forms.ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4;

            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "Media/Marketing Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 300;

            header3 = new ColumnHeader();
            header3.Text = "Type";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 300;

            header4 = new ColumnHeader();
            header4.Text = "Category";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 300;


            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);
        }

        protected override void FillListViewItem(System.Windows.Forms.ListViewItem lvItem, BusinessMedia item)
        {
            lvItem.Text = item.MediaId.ToString();
            lvItem.SubItems.Add(item.Name);
            lvItem.SubItems.Add(item.MediaType);
            lvItem.SubItems.Add(item.CategoryId.ToString());
        }

        protected override IList<BusinessMedia> GetItems()
        {
            return new DoctorService().GetAllMedias();
        }

        protected override IList<BusinessMedia> GetFilteredList(IList<BusinessMedia> fullList, string filterstring)
        {

            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.MediaId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();

        }

        protected override IList<BusinessMedia> GetItemsByType(string _type)
        {
            return new DoctorService().GetAllMediasByType(_type);
        }

        protected override IList<BusinessMedia> GetItemsByTypeFromSuppliedList(string _type, List<BusinessMedia> item)
        {
            throw new NotImplementedException();
        }
    }
}
