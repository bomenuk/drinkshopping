using DrinkShopping.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrinkShopping.Models
{
    public class ShoppingListModel
    {
        public ShoppingListModel(List<ShoppingItem> itemList)
        {
            ItemList = itemList;
        }

        public List<ShoppingItem> ItemList { get; private set; }

        public decimal TotalPrice
        {
            get
            {
                return ItemList.Sum(i => i.Drink.Price * i.Quantity);
            }
        }
    }
}