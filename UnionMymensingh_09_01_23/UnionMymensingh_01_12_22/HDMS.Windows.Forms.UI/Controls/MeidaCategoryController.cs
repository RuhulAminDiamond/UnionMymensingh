using HDMS.Model.Diagnostic;
using HDMS.Service.Diagonstics;
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
    public partial class MeidaCategoryController : SearchResultListControl<MediaCategory>
    {


        protected override void FillListViewItem(ListViewItem lvItem, MediaCategory item)
        {
            lvItem.Text = item.CategoryId.ToString();
            lvItem.SubItems.Add(item.CategoryName);
        

        }
        protected override void FillListColumns(ListView view)
        {
            view.Width = 2000;
            ColumnHeader header1, header2;

            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 250;

          


            view.Columns.Add(header1);
            view.Columns.Add(header2);
           
        }

        protected override IList<MediaCategory> GetItems()
        {
            return new DiagFinancialService().GetAllMediaCategory();
        }

        protected override IList<MediaCategory> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<MediaCategory> GetItemsByTypeFromSuppliedList(string _type, List<MediaCategory> item)
        {
            throw new NotImplementedException();
        }

        protected override IList<MediaCategory> GetFilteredList(IList<MediaCategory> fullList, string filterstring)
        {
            throw new NotImplementedException();
        }
    }
}
