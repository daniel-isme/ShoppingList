using System;
using ShoppingList.Models;
using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    public interface IContentViewModel
    {
        IValueModel Model { get; set; }

        Thickness SafeAreaInset { get; set; }
    }
}
