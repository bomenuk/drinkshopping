using DrinkShopping.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkShopping.Business
{
    public class ShoppingListManager : IShoppingListManager
    {
        public List<ShoppingItem> ItemList { get; private set; } = new List<ShoppingItem>();
        
        public void AddDrink(IDrink drink, int quantity)
        {
            var item = ItemList.FirstOrDefault(i => i.Drink.Id == drink.Id);
            if(item==null)
            {
                ItemList.Add(new ShoppingItem { Drink = drink, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public ShoppingItem CheckDrink(string drinkName)
        {
            var item = ItemList.FirstOrDefault(i => i.Drink.Name == drinkName);
            return item;
        }

        public bool RemoveDrink(IDrink drink)
        {
            bool success = true;
            var item = ItemList.FirstOrDefault(i => i.Drink.Id == drink.Id);
            if (item != null)
            {
                ItemList.Remove(item);
            }
            else
            {
                success = false;
            }

            return success;
        }

        public void EmptyShopping()
        {
            ItemList.Clear();
        }

        public bool UpdateDrink(IDrink drink, int quantity)
        {
            bool success = true;
            var item = ItemList.FirstOrDefault(i => i.Drink.Id == drink.Id);
            if (item == null)
            {
                success = false;
            }
            else
            {
                item.Quantity = quantity;
            }

            return success;
        }
    }
}
