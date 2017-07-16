using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrinkShopping.Models
{
    public class BasicShoppingItemList
    {
        public int Count { get; set; }
        public List<BasicShoppingItem> Data { get; set; }
    }
}