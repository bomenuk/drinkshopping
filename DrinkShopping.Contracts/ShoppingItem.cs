using DrinkShopping.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkShopping.Contracts
{
    public class ShoppingItem
    {
        public IDrink Drink { get; set; }
        public int Quantity { get; set; }
    }
}
