using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Hospital;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class HpPackageSearchControl : SearchResultListControl<HpPackage>
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
            header2.Text = "Package Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 500;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
        }

        protected override void FillListViewItem(ListViewItem lvItem, HpPackage item)
        {
            lvItem.Text = item.PkgId.ToString();
            lvItem.SubItems.Add(item.Name);
        }

        protected override IList<HpPackage> GetFilteredList(IList<HpPackage> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.PkgId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.Name.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<HpPackage> GetItems()
        {
            return new Service.Hospital.HospitalService().GetAllHpPackages();
        }

        protected override IList<HpPackage> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<HpPackage> GetItemsByTypeFromSuppliedList(string _type, List<HpPackage> item)
        {
            throw new NotImplementedException();
        }
    }
}
