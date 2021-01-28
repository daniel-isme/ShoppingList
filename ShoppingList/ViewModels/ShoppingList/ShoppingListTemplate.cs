using System;
using ShoppingList.Views;
using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    public class ShoppingListTemplate : DataTemplateSelector
    {
        private DataTemplate ShoppingListCell { get; set; }

        public ShoppingListTemplate()
        {
            ShoppingListCell = new DataTemplate(typeof(ShoppingListCellView));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ShoppingListCell;
        }
    }
}
