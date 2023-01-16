using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Model.ViewModel;
using HDMS.Models.Pharmacy.ViewModels;
using Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Service.FoodAndBeverage
{
    public class FoodAndBeverageItemService
    {
        public void PopulateSelectedItemData(IList<SelectedProductsToSaleOrReceive> selectedItems, StoreProductInfo storeProductInfo, double v1, double v2)
        {
            throw new NotImplementedException();
        }

        public void PopulateSelectedItemDataForIssueAgainstRequisition(IList<SelectedProductsToSaleOrReceive> selectedItems, VMRequisitionList selectedItem)
        {
            throw new NotImplementedException();
        }

        public void PopulateSelectedItemDataForLabRequisition(IList<PhSelectedProductsToSaleOrReceiveOrOrder> selectedItems, StoreProductInfo storeProductInfo, double qty)
        {
            throw new NotImplementedException();
        }
    }
}
