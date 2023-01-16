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
using HDMS.Service.Hospital;
using HDMS.Model.OPD.VM;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class ctrlOPDServiceItem :  SearchResultListControl<VMOPDServiceHead>
    {
        protected override void FillListColumns(System.Windows.Forms.ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3;

            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "Name";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 350;

            header3 = new ColumnHeader();
            header3.Text = "Rate";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 150;

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
        }

        protected override void FillListViewItem(System.Windows.Forms.ListViewItem lvItem, VMOPDServiceHead item)
        {
            lvItem.Text = item.ServiceHeadId.ToString();
            lvItem.SubItems.Add(item.ServiceHeadName);
            lvItem.SubItems.Add(item.Rate.ToString());
        }

        protected override IList<VMOPDServiceHead> GetItems()
        {
            return new HospitalService().GetAllOPDServiceHeads();
        }

        protected override IList<VMOPDServiceHead> GetFilteredList(IList<VMOPDServiceHead> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.ServiceHeadId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.ServiceHeadName.ToLower().Contains(filterstring.ToLower())).ToList();

        }

        protected override IList<VMOPDServiceHead> GetItemsByType(string _type)
        {
            return new HospitalService().GetAllOPDServiceHeadsByGroup(_type);
        }

        protected override IList<VMOPDServiceHead> GetItemsByTypeFromSuppliedList(string _type,List<VMOPDServiceHead> item)
        {
            return null; //new HospitalService().GetAllOPDServiceHeadsByGroup(_type);
        }
    }
}
