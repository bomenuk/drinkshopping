using DrinkShopping.Contracts;
using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;
using DrinkShopping.Data;
using DrinkShopping.Business;

namespace DrinkShopping
{
    public class IocContainerConfig
    {
        public static void IocContainerInitialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IDrink, FakeDrink>(Lifestyle.Transient);
            container.Register<IDrinkRepository, FakeDrinkRepository>(Lifestyle.Transient);            
            container.Register<IShoppingListManager, ShoppingListManager>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}