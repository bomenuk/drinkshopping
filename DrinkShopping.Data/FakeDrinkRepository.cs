using DrinkShopping.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using Newtonsoft.Json;

namespace DrinkShopping.Data
{
    public class FakeDrinkRepository : IDrinkRepository
    {
        public IEnumerable<IDrink> GetDrinks()
        {
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/product.json");

            var json = System.IO.File.ReadAllText(filePath);

            var drinks = JsonConvert.DeserializeObject<List<FakeDrink>>(json);

            return drinks;
        }
    }
}
