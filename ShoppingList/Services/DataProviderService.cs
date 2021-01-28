using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingList.Models;

namespace ShoppingList.Services
{
    public class DataProviderService
    {
        private static DataProviderService current;
        public static DataProviderService Current
        {
            get
            {
                if (current == null)
                    current = new DataProviderService();
                return current;
            }
        }

        public async Task<ShoppingListData> GetShoppingList()
        {
            return await Task.Run(() =>
            {
                return new ShoppingListData
                {
                    ListItems = new List<ShoppingListItem>
                    {
                        new ShoppingListItem { Note = "Item 1", Price = 149.99 },
                        new ShoppingListItem { Note = "Item 2", Price = 49.99 },
                        new ShoppingListItem { Note = "Item 3", Price = 70 },
                    }
                };
            });
        }
    }
}
