using HDMS.Model.Common;
using HDMS.Service.Doctors;
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
    public class ctrlSerachCorporateClient : SearchResultListControl<CorporateClient>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2;


            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;


            header2 = new ColumnHeader();
            header2.Text = "Client Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 500;


            view.Columns.Add(header1);
            view.Columns.Add(header2);
        }

        protected override void FillListViewItem(ListViewItem lvItem, CorporateClient item)
        {
            lvItem.Text = item.CompanyId.ToString();
            lvItem.SubItems.Add(item.Name);
        }

        protected override IList<CorporateClient> GetFilteredList(IList<CorporateClient> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.CompanyId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<CorporateClient> GetItems()
        {
            return new DoctorService().GetAllCorporateClient();
        }

        protected override IList<CorporateClient> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<CorporateClient> GetItemsByTypeFromSuppliedList(string _type, List<CorporateClient> item)
        {
            throw new NotImplementedException();
        }
    }
}
