using System.Collections.Generic;

namespace DrinkShopping.Contracts
{
    public interface IShoppingListManager
    {
        List<ShoppingItem> ItemList { get; }
        void AddDrink(IDrink drink, int quantity);
        bool UpdateDrink(IDrink drink, int quantity);
        bool RemoveDrink(IDrink drink);

        void EmptyShopping();
        ShoppingItem CheckDrink(string drinkName);
    }
}