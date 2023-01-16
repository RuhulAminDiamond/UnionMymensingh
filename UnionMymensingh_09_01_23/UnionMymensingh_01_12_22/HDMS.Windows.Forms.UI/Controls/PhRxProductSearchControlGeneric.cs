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
    public partial class PhRxProductSearchControlGeneric : SearchResultListControl_2<VMPhProductListForRxPerspective>
    {

        protected override void FillListColumns(ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2, header3, header4;

            header1 = new ColumnHeader();
            header1.Text = "Brand Name";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 350;

            header2 = new ColumnHeader();
            header2.Text = "Manufacturer";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 220;

            header3 = new ColumnHeader();
            header3.Text = "Generic";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 290;

        
            header4 = new ColumnHeader();
            header4.Text = "Stock";
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Width = 100;

           

            view.Columns.Add(header1);
            view.Columns.Add(header2);
            view.Columns.Add(header3);
            view.Columns.Add(header4);
          
            
        }

        protected override void FillListViewItem(ListViewItem lvItem, VMPhProductListForRxPerspective item)
        {
            lvItem.Text = item.BrandName;
            lvItem.SubItems.Add(item.Manufacturer);
            lvItem.SubItems.Add(item.GenericName);
            lvItem.SubItems.Add("");
       
        }

        protected override IList<VMPhProductListForRxPerspective> GetItems()
        {

            return null; // new PhProductService().GetRxBasicProductInfoList("","");
        }

        protected override IList<VMPhProductListForRxPerspective> GetItemsByType(string _filterString)
        {
            //int _outLetId = 0;
            //int.TryParse(_type, out _outLetId);
            return null; // new PhProductService().GetRxProductListWithStock(_filterString);
        }

        protected override IList<VMPhProductListForRxPerspective> GetRxItemsByType(string _brand, string _generic, string _formation, int cpId, List<VMPhProductListForRxPerspective> item)
        {
            //int _outLetId = 0;
            //int.TryParse(_type, out _outLetId);
            return item.Where(x => x.GenericName.ToLower().Contains(_generic.ToLower())).OrderBy(x=>x.BrandName).ToList();   //new PhProductService().GetBasicProductInfoListForRxPerspective(_brand, _generic);
        }

        protected override IList<VMPhProductListForRxPerspective> GetFilteredList(IList<VMPhProductListForRxPerspective> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.ProductId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.BrandName.ToLower().StartsWith(filterstring.ToLower())).ToList();
        }

        protected override VMPhProductListForRxPerspective GetFilteredObj(IList<VMPhProductListForRxPerspective> fullList, string filterstring)
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
