using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DrinkShopping.Contracts;

namespace DrinkShopping.Models
{
    public class DrinkModel:IDrink
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Drink Name is required", AllowEmptyStrings = false)]
        public string Name { get; set; }

        public decimal Price { get; set; }
        
        public DrinkModel(IDrink drink)
        {
            Id = drink.Id;
            Name = drink.Name;
            Price = drink.Price;
        }
    }
}