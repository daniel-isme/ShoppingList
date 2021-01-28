using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ShoppingList.Models;
using ShoppingList.Services;

namespace ShoppingList.ViewModels
{
    public class ShoppingListViewModel : PageListViewModel<ShoppingListTemplate>
    {
        private double totalPrice;
        public double TotalPrice
        {
            get => totalPrice;
            set => SetProperty(ref totalPrice, value);
        }

        public ShoppingListViewModel()
        {
        }

        public override async Task<IValueModel> GetModel()
        {
            return await DataProviderService.Current.GetShoppingList();
        }

        public override void SetModelView(IValueModel valueModel)
        {
            base.SetModelView(valueModel);

            if (!(valueModel is ShoppingListData model))
            {
                SetViewNoData();
                return;
            }

            var newList = model.ListItems.Select(x => new ShoppingListCellViewModel(x));

            SetViewSuccess();
            ListValues = new ObservableCollection<BaseCellViewModel>(newList);
        }
    }
}
