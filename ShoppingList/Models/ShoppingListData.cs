using System;
using System.Collections.Generic;

namespace ShoppingList.Models
{
    public class ShoppingListData : IValueModel
    {
        public List<ShoppingListItem> ListItems { get; set; }
    }

    public class ShoppingListItem : IValueModel
    {
        public bool Marked { get; set; }

        public string Note { get; set; }

        public double Price { get; set; }
    }
}
