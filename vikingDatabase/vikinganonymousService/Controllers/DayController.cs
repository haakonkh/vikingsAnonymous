//using System.Linq;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Http.Controllers;
//using System.Web.Http.OData;
//using Microsoft.Azure.Mobile.Server;
//using vikinganonymousService.DataObjects;
//using vikinganonymousService.Models;

//namespace vikinganonymousService.Controllers
//{
//    public class DayController : TableController<Day>
//    {
//        protected override void Initialize(HttpControllerContext controllerContext)
//        {
//            base.Initialize(controllerContext);
//            DatabaseContext context = new DatabaseContext();
//            DomainManager = new EntityDomainManager<Day>(context, Request);
//        }

//        // GET tables/Day
//        public IQueryable<Day> GetAllDay()
//        {
//            return Query(); 
//        }

//        // GET tables/Day/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public SingleResult<Day> GetDay(string id)
//        {
//            return Lookup(id);
//        }

//        // PATCH tables/Day/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public Task<Day> PatchDay(string id, Delta<Day> patch)
//        {
//             return UpdateAsync(id, patch);
//        }

//        // POST tables/Day
//        public async Task<IHttpActionResult> PostDay(Day item)
//        {
//            Day current = await InsertAsync(item);
//            return CreatedAtRoute("Tables", new { id = current.Id }, current);
//        }

//        // DELETE tables/Day/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public Task DeleteDay(string id)
//        {
//             return DeleteAsync(id);
//        }
//    }
//}
