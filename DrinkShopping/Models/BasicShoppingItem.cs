using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrinkShopping.Models
{
    public class BasicShoppingItem
    {
        public int DrinkId { get; set; }

        public int Quantity { get; set; }

        public string DrinkName { get; set; }
    }
}