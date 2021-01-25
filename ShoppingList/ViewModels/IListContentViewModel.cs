using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    public interface IListContentViewModel
    {
        ObservableCollection<BaseCellViewModel> ListValues { get; set; }

        object SelectedItem { set; }

        DataTemplateSelector ItemTemplate { get; set; }
    }
}
