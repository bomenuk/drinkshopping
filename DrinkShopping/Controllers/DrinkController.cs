using DrinkShopping.Contracts;
using DrinkShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DrinkShopping.Controllers
{
    public class DrinkController : BaseAPIController
    {
        private IDrinkRepository _drinkRepo;
        public DrinkController(IDrinkRepository drinkRepository)
        {
            _drinkRepo = drinkRepository;

            if (_drinks.Count == 0)
            {
                _drinks = new List<DrinkModel>();

                foreach (var drink in _drinkRepo.GetDrinks())
                {
                    _drinks.Add(new DrinkModel(drink));
                }
            }
        }

        // GET api/Drink
        public List<DrinkModel> Get()
        {
            return _drinks;
        }

        // GET api/Drink/5
        public DrinkModel Get(int id)
        {
            return _drinks.FirstOrDefault(d=>d.Id == id);
        }

        // POST api/Drink
        public void Post([FromBody]DrinkModel value)
        {
            value.Id = _drinks.Max(d => d.Id) + 1;
            _drinks.Add(value);
        }

        // PUT api/Drink/5
        public void Put(int id, [FromBody]DrinkModel value)
        {
            var drink = _drinks.FirstOrDefault(d => d.Id == id);
            if(drink !=null)
            {
                drink.Name = value.Name;
                drink.Price = value.Price;
            }
        }

        // DELETE api/Drink/5
        public void Delete(int id)
        {
            var drink = _drinks.FirstOrDefault(d => d.Id == id);
            if (drink != null)
            {
                _drinks.Remove(drink);
            }            
        }
    }
}
