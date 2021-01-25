using System;
using System.Collections.ObjectModel;
using ShoppingList.Models;
using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    public class BaseCellViewModel : BaseViewModel
    {
        public static BaseCellViewModel Create(string newTitle)
        {
            return new BaseCellViewModel
            {
                title = newTitle
            };
        }

        public static BaseCellViewModel Create(BaseValueModel source)
        {
            return new BaseCellViewModel
            {
                title = source.Title,
                Source = source
            };
        }

        public IValueModel Source { get; set; }

        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private Thickness safeAreaInset;
        public Thickness SafeAreaInset
        {
            get => safeAreaInset;
            set => SetProperty(ref safeAreaInset, value);
        }
    }

    public static class ListBaseCellViewModelExt
    {
        public static void UpdateSafeAreaInset(this ObservableCollection<BaseCellViewModel> collection, Thickness newSafeAreaInset)
        {
            if (collection == null)
                return;

            foreach (var item in collection)
            {
                if (item == null)
                    return;
                item.SafeAreaInset = new Thickness(newSafeAreaInset.Left, 0, newSafeAreaInset.Right, 0);
            }
        }
    }
}
