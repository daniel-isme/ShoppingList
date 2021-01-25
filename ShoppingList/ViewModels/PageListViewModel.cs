using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    public class PageListViewModel<D> : PageViewModel, IListContentViewModel
        where D : DataTemplateSelector, new()
    {
        public new Thickness SafeAreaInset
        {
            get => base.SafeAreaInset;
            set
            {
                base.SafeAreaInset = value;
                var newSafeAreaInset = new Thickness(SafeAreaInset.Left, 0, SafeAreaInset.Right, 0);
                foreach (var item in ListValues)
                {
                    item.SafeAreaInset = newSafeAreaInset;
                }
            }
        }

        private DataTemplateSelector itemTemplate = new D();
        public DataTemplateSelector ItemTemplate
        {
            get => itemTemplate;
            set => SetProperty(ref itemTemplate, value);
        }

        private ObservableCollection<BaseCellViewModel> listValues = new ObservableCollection<BaseCellViewModel>();
        public ObservableCollection<BaseCellViewModel> ListValues
        {
            get => listValues;
            set
            {
                var newSafeAreaInset = new Thickness(SafeAreaInset.Left, 0, SafeAreaInset.Right, 0);
                value.UpdateSafeAreaInset(newSafeAreaInset);
                SetProperty(ref listValues, value);
            }
        }

        private object selectedItem;
        public virtual object SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }

        public PageListViewModel(bool isBusy = true) : base(isBusy)
        {
        }

        /// <summary>
        /// Находим нужную нам ячейку и обновляем ее модель, далее сам listview перезагрузит ее
        /// </summary>
        /// <param name="cellViewModel"></param>
        public void UpdateCell(BaseCellViewModel cellViewModel)
        {
            try
            {
                if (ListValues == null || ListValues.Count <= 0)
                    return;
                var index = ListValues.IndexOf(cellViewModel);
                if (index < 0 || ListValues.Count < index)
                    return;
                ListValues[index] = cellViewModel;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write($"Problem update viewcell: {e}");
            }
        }
    }
}
