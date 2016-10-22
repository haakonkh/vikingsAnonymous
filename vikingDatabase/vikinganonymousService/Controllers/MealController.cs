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
//    public class MealController : TableController<Meal>
//    {
//        protected override void Initialize(HttpControllerContext controllerContext)
//        {
//            base.Initialize(controllerContext);
//            DatabaseContext context = new DatabaseContext();
//            DomainManager = new EntityDomainManager<Meal>(context, Request);
//        }

//        // GET tables/Meal
//        public IQueryable<Meal> GetAllMeal()
//        {
//            return Query(); 
//        }

//        // GET tables/Meal/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public SingleResult<Meal> GetMeal(string id)
//        {
//            return Lookup(id);
//        }

//        // PATCH tables/Meal/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public Task<Meal> PatchMeal(string id, Delta<Meal> patch)
//        {
//             return UpdateAsync(id, patch);
//        }

//        // POST tables/Meal
//        public async Task<IHttpActionResult> PostMeal(Meal item)
//        {
//            Meal current = await InsertAsync(item);
//            return CreatedAtRoute("Tables", new { id = current.Id }, current);
//        }

//        // DELETE tables/Meal/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public Task DeleteMeal(string id)
//        {
//             return DeleteAsync(id);
//        }
//    }
//}
