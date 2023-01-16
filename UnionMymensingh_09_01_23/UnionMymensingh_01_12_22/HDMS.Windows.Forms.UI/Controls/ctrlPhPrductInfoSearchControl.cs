using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Models.Pharmacy;
using HDMS.Service.Pharmacy;
using HDMS.Model.Pharmacy.ViewModels;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class ctrlPhPrductInfoSearchControl : SearchResultListControl<VWPhProductInfo>
    {
        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4;

            header1 = new ColumnHeader();
            header1.Text = "Brand Name";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 290;

            header2 = new ColumnHeader();
            header2.Text = "Formation";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 100;

            header3 = new ColumnHeader();
            header3.Text = "Generic";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 200;


            header4 = new ColumnHeader();
            header4.Text = "Manufacturer";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 250;



            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);
           
        }

        protected override void FillListViewItem(ListViewItem lvItem, VWPhProductInfo item)
        {
            lvItem.Text = item.BrandName.ToString();
            lvItem.SubItems.Add(item.FormationShortName);
           // lvItem.SubItems.Add(item.Unit);
            lvItem.SubItems.Add(item.Generic);
            lvItem.SubItems.Add(item.Manufacturer);

            
        }

        protected override IList<VWPhProductInfo> GetFilteredList(IList<VWPhProductInfo> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.ProductId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.BrandName.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<VWPhProductInfo> GetItems()
        {
            throw new NotImplementedException();
        }

        protected override IList<VWPhProductInfo> GetItemsByType(string _filterString)
        {
          
            return new PhProductService().GetProductListByGenAndManufacturer(_filterString);
        }

        protected override IList<VWPhProductInfo> GetItemsByTypeFromSuppliedList(string _type, List<VWPhProductInfo> item)
        {
            throw new NotImplementedException();
        }
    }
}
