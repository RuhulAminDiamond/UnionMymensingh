using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Services.POS;
using HDMS.Model.Pharmacy;
using HDMS.Service.Pharmacy;
using HDMS.Models.Pharmacy;
using HDMS.Model.Pharmacy.ViewModels;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class PhRxProductSearchControl : SearchResultListControl_2<VMPhProductListForRxPerspective>
    {

        public bool searchBybrand = true;

        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4, header5;

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
            header3.Width = 300;

            header4 = new ColumnHeader();
            header4.Text = "Manufacturer";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 150;

            header5 = new ColumnHeader();
            header5.Text = "Stock";
            header5.TextAlign = HorizontalAlignment.Left;
            header5.Width = 100;

           

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);
            view.Columns.Add(header5);

        }

        protected override void FillListViewItem(ListViewItem lvItem, VMPhProductListForRxPerspective item)
        {
            lvItem.Text = item.BrandName;
            lvItem.SubItems.Add(item.FormationShortName);
            lvItem.SubItems.Add(item.GenericName);
            lvItem.SubItems.Add(item.Manufacturer);
            lvItem.SubItems.Add("");
        
        }

        protected override IList<VMPhProductListForRxPerspective> GetItems()
        {

            return null;  //new PhProductService().GetRxBasicProductInfoList("","");
        }

        protected override IList<VMPhProductListForRxPerspective> GetItemsByType(string _filterString)
        {
            //int _outLetId = 0;
            //int.TryParse(_type, out _outLetId);
            return null;  //new PhProductService().GetRxProductListWithStock(_filterString);
        }

        protected override IList<VMPhProductListForRxPerspective> GetRxItemsByType(string brand, string gen, string _formation, int _cpId, List<VMPhProductListForRxPerspective> item)
        {
           
            List<VMPhProductListForRxPerspective> pList = new List<VMPhProductListForRxPerspective>();
            if (!string.IsNullOrEmpty(brand) && !string.IsNullOrEmpty(gen))
            {
                pList = item.Where(x => x.BrandName.ToLower().StartsWith(brand.Trim().ToLower()) && x.GenericName.ToLower().Contains(gen.Trim().ToLower())).ToList();
            }
            else if (!string.IsNullOrEmpty(brand))
            {
                pList = item.Where(x => x.BrandName.ToLower().StartsWith(brand.Trim().ToLower())).ToList();
            }
            else if (!string.IsNullOrEmpty(gen))
            {
                pList = item.Where(x => x.GenericName.ToLower().Contains(gen.Trim().ToLower())).ToList();
            }

            return pList;
        }

        protected override IList<VMPhProductListForRxPerspective> GetFilteredList(IList<VMPhProductListForRxPerspective> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.ProductId.ToString().Contains(filterstring)).ToList();
            }


            if(searchBybrand)
              return fullList.Where(x => x.BrandName.ToLower().Contains(filterstring.ToLower())).ToList();

            return fullList.Where(x => x.GenericName.ToLower().Contains(filterstring.ToLower())).ToList();

        }

        protected override VMPhProductListForRxPerspective GetFilteredObj(IList<VMPhProductListForRxPerspective> fullList, string filterstring)
        {
            throw new NotImplementedException();
        }
    }
}
