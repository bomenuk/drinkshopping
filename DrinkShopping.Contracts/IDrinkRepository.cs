using System.Collections.Generic;

namespace DrinkShopping.Contracts
{
    public interface IDrinkRepository
    {
        IEnumerable<IDrink> GetDrinks();
    }
}