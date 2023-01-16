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
using HDMS.Service.Diagonstics;

namespace HDMS.Windows.Forms.UI.Controls
{
    public partial class DischargeTemplateSearchControl : SearchResultListControl<DischargeTemplate>
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
            header2.Text = "Template Description";
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Width = 500;


            view.Columns.Add(header1);
            view.Columns.Add(header2);
        }

        protected override void FillListViewItem(ListViewItem lvItem, DischargeTemplate item)
        {
            lvItem.Text = item.TId.ToString();
            lvItem.SubItems.Add(item.TemplateName);
        }

        protected override IList<DischargeTemplate> GetFilteredList(IList<DischargeTemplate> fullList, string filterstring)
        {
            if (fullList == null) return null;

            int itemId;
            if (int.TryParse(filterstring, out itemId))
            {
                return fullList.Where(x => x.TId.ToString().Contains(filterstring)).ToList();
            }
            return fullList.Where(x => x.TemplateName.ToLower().Contains(filterstring.ToLower())).ToList();
        }

        protected override IList<DischargeTemplate> GetItems()
        {
            return new TemplateService().GetAllDischargeTemplates();
        }

        protected override IList<DischargeTemplate> GetItemsByType(string _type)
        {
            throw new NotImplementedException();
        }

        protected override IList<DischargeTemplate> GetItemsByTypeFromSuppliedList(string _type, List<DischargeTemplate> item)
        {
            throw new NotImplementedException();
        }
    }
}
