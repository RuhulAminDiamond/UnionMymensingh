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
using HDMS.Service.Hospital;
using HDMS.Model.Hospital;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class HospitalBillItemSearchControl : SearchResultListControl<ServiceHead>
    {
        protected override void FillListColumns(System.Windows.Forms.ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2,header3;

            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 250;

            header3 = new ColumnHeader();
            header3.Text = "Rate";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 150;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
        }

        protected override void FillListViewItem(System.Windows.Forms.ListViewItem lvItem, ServiceHead item)
        {
            lvItem.Text = item.ServiceHeadId.ToString();
            lvItem.SubItems.Add(item.ServiceHeadName);
            lvItem.SubItems.Add(item.Rate.ToString());
        }

        protected override IList<ServiceHead> GetItems()
        {
            return new HospitalBillingItemService().GetAllBillingItems();
        }

        protected override IList<ServiceHead> GetFilteredList(IList<ServiceHead> fullList, string filterstring)
        {
            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.ServiceHeadId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.ServiceHeadName.ToLower().Contains(filterstring.ToLower())).ToList();

        }

        protected override IList<ServiceHead> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<ServiceHead> GetItemsByTypeFromSuppliedList(string _type,List<ServiceHead> item)
        {
            throw new NotImplementedException();
        }
    }
 }

