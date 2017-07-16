using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace DrinkShopping.Controllers
{
    public class UserAPIController : BaseAPIController
    {
        public HttpResponseMessage Get()
        {
            //return ToJson(UserDB.TblUsers.AsEnumerable());
            return ToJson(Ok());
        }

       public HttpResponseMessage Post([FromBody]object value)
        {
            //UserDB.TblUsers.Add(value);             
            //return ToJson(UserDB.SaveChanges());
            return ToJson(Ok());
        }

        public HttpResponseMessage Put(int id, [FromBody]object value)
        {
            ////UserDB.Entry(value).State = EntityState.Modified;
            return ToJson(Ok());
        }
        public HttpResponseMessage Delete(int id)
        {
            //UserDB.TblUsers.Remove(UserDB.TblUsers.FirstOrDefault(x => x.Id == id));
            return ToJson(Ok());
        }
    }
}
