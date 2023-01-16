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
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Service.Diagonstics;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class TemplateSearchControl : SearchResultListControl<Template>
    {
        protected override void FillListColumns(System.Windows.Forms.ListView view)
        {
            view.Width = 6500;
            ColumnHeader header1, header2;

            header1 = new ColumnHeader();
            header1.Text = "Id";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 100;

            header2 = new ColumnHeader();
            header2.Text = "Template Description";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 500;

          
            view.Columns.Add(header1);
            view.Columns.Add(header2);
          
              
        }

        protected override void FillListViewItem(System.Windows.Forms.ListViewItem lvItem, Template item)
        {
            lvItem.Text = item.Id.ToString();
            lvItem.SubItems.Add(item.TemplateName);
        }

        protected override IList<Template> GetItems()
        {
            return new TemplateService().GetAllTemplate();
        }

        protected override IList<Template> GetItemsByType(string _type)
        {
            return new TemplateService().GetItemsByType(_type);
        }

        protected override IList<Template> GetFilteredList(IList<Template> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.Id.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.TemplateName.ToLower().Contains(filterstring.ToLower())).ToList();

        }

        protected override IList<Template> GetItemsByTypeFromSuppliedList(string _type, List<Template> item)
        {
            throw new NotImplementedException();
        }
    }
}
