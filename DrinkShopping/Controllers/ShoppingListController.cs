using DrinkShopping.Contracts;
using DrinkShopping.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DrinkShopping.Controllers
{
    public class ShoppingListController : BaseAPIController
    {
        private static IShoppingListManager _shoppingListManager;

        public ShoppingListController(IShoppingListManager shoppingListManager)
        {
            if (_shoppingListManager == null)
            {
                _shoppingListManager = shoppingListManager;
            }
        }

        // GET api/values
        [HttpGet]
        public HttpResponseMessage Get(int pageSize, string pageNumber)
        {
            int realPageNumber = Int32.Parse(pageNumber);
            int realPageSize = pageSize < _shoppingListManager.ItemList.Count ? pageSize : _shoppingListManager.ItemList.Count;
            //int remainder = _shoppingListManager.ItemList.Count % pageSize;
            //int totalPageCount = remainder == 0 ? _shoppingListManager.ItemList.Count / pageSize : _shoppingListManager.ItemList.Count / pageSize + 1;

            var data = _shoppingListManager.ItemList.Skip(realPageSize * realPageNumber).Take(realPageSize).ToList();
            var basicDataList = new List<BasicShoppingItem>();
            data.ForEach(drink => basicDataList.Add(new BasicShoppingItem
            {
                DrinkId = drink.Drink.Id,
                DrinkName = drink.Drink.Name,
                Quantity = drink.Quantity
            }));
            
            return CreateResponseMessage(new BasicShoppingItemList
            {
                Count = data.Count,
                Data = basicDataList
            });
        }

        // GET api/values/5
        [HttpGet]
        public BasicShoppingItem Search(string drinkName)
        {
            var drink = _shoppingListManager.CheckDrink(drinkName);
            return new BasicShoppingItem
            {
                DrinkId = drink.Drink.Id,
                DrinkName = drink.Drink.Name,
                Quantity = drink.Quantity
            };
        }

        [HttpGet]
        public ShoppingItem Search()
        {
            var item = GetItemFromHeader(Request);
            return _shoppingListManager.CheckDrink(item.DrinkName);
        }

        // POST api/values
        [HttpPost]
        public void Post(int drinkId, int quantity)
        {
            var drink = _drinks.FirstOrDefault(d => d.Id == drinkId);
            if (drink != null)
            {
                _shoppingListManager.AddDrink(drink, quantity);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post()
        {
            var item = GetItemFromHeader(Request);

            var drink = _drinks.FirstOrDefault(d => d.Id == item.DrinkId);
            if (drink != null)
            {
                _shoppingListManager.AddDrink(drink, item.Quantity);
            }
            return CreateResponseMessage(item);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int drinkId, int quantity)
        {
            var drink = _drinks.FirstOrDefault(d => d.Id == drinkId);
            if (drink != null)
            {
                _shoppingListManager.UpdateDrink(drink, quantity);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put()
        {
            var item = GetItemFromHeader(Request);

            var drink = _drinks.FirstOrDefault(d => d.Id == item.DrinkId);
            if (drink != null)
            {
                _shoppingListManager.UpdateDrink(drink, item.Quantity);
            }
            return CreateResponseMessage(item);
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete()
        {
            _shoppingListManager.EmptyShopping();            
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int drinkId)
        {   
            var drink = _drinks.FirstOrDefault(d => d.Id == drinkId);
            if (drink != null)
            {
                _shoppingListManager.RemoveDrink(drink);
            }
            return CreateResponseMessage(drink);
        }

        private BasicShoppingItem GetItemFromHeader(HttpRequestMessage message)
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = requestContent.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<BasicShoppingItem>(jsonContent);
        }

        private HttpResponseMessage CreateResponseMessage(object item)
        {
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }
    }
}