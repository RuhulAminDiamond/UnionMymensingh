using System;
using System.Collections.Generic;

using System.Windows.Forms;


namespace HDMS.Windows.Forms.UI.Controls
{
    public abstract partial class SearchResultListControlForPharmacy<T> : UserControl
    {
        IList<T> _Items;
        bool isBackSpace = false;
        public event ItemSelectedEventHandler ItemSelected;
        public event SearchEscapeEventHandler SearchEsacaped;
        public SearchResultListControlForPharmacy()
        {
            InitializeComponent();
            FillListColumns(lstSearch);
        }

        protected abstract void FillListColumns(ListView view);
        protected abstract void FillListViewItem(ListViewItem lvItem, T item);
        protected abstract IList<T> GetItems();
        protected abstract IList<T> GetItemsByType(string _type);
        protected abstract IList<T> GetItemsByTypeFromSuppliedList(string _type,List<T> item);
        public void LoadData()
        {
            _Items = GetItems();
            PopulateList(_Items);
            txtSearch.Focus();
        }

        public void LoadDataByType(string _type)
        {
            _Items = GetItemsByType(_type);
            PopulateList(_Items);
            txtSearch.Focus();
        }

        public void LoadDataByTypeFromSuppliedList(string _type, List<T> item)
        {
            _Items = GetItemsByTypeFromSuppliedList(_type, item);
            PopulateList(_Items);
            txtSearch.Focus();
        }

        private void PopulateList(IList<T> list)
        {
            if (list != null)
            {
                lstSearch.Items.Clear();
                foreach (T item in list)
                {
                    ListViewItem lvItem = new ListViewItem();
                    FillListViewItem(lvItem, item);
                    lvItem.Tag = item;
                    lstSearch.Items.Add(lvItem);

                }
                
                if (lstSearch.Items.Count > 0) lstSearch.Items[0].Selected = true;
            }
        }

        protected abstract IList<T> GetFilteredList(IList<T> fullList, string filterstring);

        public delegate void ItemSelectedEventHandler(SearchResultListControlForPharmacy<T> sender, T item);
        public delegate void SearchEscapeEventHandler(bool IsEscaped);

        private void lstSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstSearch.SelectedItems.Count > 0 && ItemSelected != null) ItemSelected(this, (T)lstSearch.SelectedItems[0].Tag);
        }

        private void lstSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && lstSearch.SelectedItems.Count > 0 && ItemSelected != null) ItemSelected(this, (T)lstSearch.SelectedItems[0].Tag);

            if (e.KeyChar == (char)Keys.Escape) {

                SearchEsacaped(true);
                this.Visible = false;
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           if(!isBackSpace && txtSearch.Text.Length>2)
            PopulateList(GetFilteredList(_Items, txtSearch.Text));
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                lstSearch.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                SearchEsacaped(true);
                this.Visible = false;
            }

            if(e.KeyCode == Keys.Back)
            {
                isBackSpace = true;
            }
            else
            {
                isBackSpace = false;
            }
           
        }
    }

}
