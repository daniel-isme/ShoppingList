using System;
using ShoppingList.Models;

namespace ShoppingList.ViewModels
{
    public class ShoppingListCellViewModel : BaseCellViewModel
    {
        private double price;
        public double Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }
        
        private bool marked;
        public bool Marked
        {
            get => marked;
            set => SetProperty(ref marked, value);
        }

        public ShoppingListCellViewModel(ShoppingListItem model)
        {
            Source = model;
            Title = model.Note;
            Price = model.Price;
            Marked = model.Marked;
        }
    }
}
