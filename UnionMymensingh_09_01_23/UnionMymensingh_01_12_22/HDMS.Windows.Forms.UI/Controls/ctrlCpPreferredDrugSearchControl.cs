using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Service.Pharmacy;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class ctrlCpPreferredDrugSearchControl : SearchResultListControl_2<VWRxPhProductList>
    {
        public bool searchBybrand = true;

        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4;

            header1 = new ColumnHeader();
            header1.Text = "Brand Name";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 200;

            header2 = new ColumnHeader();
            header2.Text = "Generic";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 250;

            header3 = new ColumnHeader();
            header3.Text = "Manufacturer";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 150;

           


            header4 = new ColumnHeader();
            header4.Text = "Stock";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 100;



            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);
          

        }

        protected override void FillListViewItem(ListViewItem lvItem, VWRxPhProductList item)
        {
            lvItem.Text = item.BrandName;
            lvItem.SubItems.Add(item.Generic);
            lvItem.SubItems.Add(item.Manufacturer);
            lvItem.SubItems.Add(item.CurrentStock.ToString());

        }

        protected override IList<VWRxPhProductList> GetItems()
        {

            return new PhProductService().GetRxBasicProductInfoList("", "");
        }

        protected override IList<VWRxPhProductList> GetItemsByType(string _filterString)
        {
            //int _outLetId = 0;
            //int.TryParse(_type, out _outLetId);
            return new PhProductService().GetRxProductListWithStock(_filterString);
        }

        protected override IList<VWRxPhProductList> GetRxItemsByType(string _brand, string _generic, string _formation, int cpId, List<VWRxPhProductList> item)
        {
            //int _outLetId = 0;
            //int.TryParse(_type, out _outLetId);
            return new PhProductService().GetFilteredRxCpPreferredProductListWithStock(_brand, _generic, _formation, cpId);
        }

        protected override IList<VWRxPhProductList> GetFilteredList(IList<VWRxPhProductList> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.ProductId.ToString().Contains(filterstring)).ToList();
            }


            if (searchBybrand)
                return fullList.Where(x => x.BrandName.ToLower().Contains(filterstring.ToLower())).ToList();

            return fullList.Where(x => x.Generic.ToLower().Contains(filterstring.ToLower())).ToList();

        }

        protected override VWRxPhProductList GetFilteredObj(IList<VWRxPhProductList> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.ProductId.ToString().Contains(filterstring)).FirstOrDefault();
            }

            return fullList.Where(x => x.BrandName.ToLower().Contains(filterstring.ToLower())).FirstOrDefault();
        }
    }
}
