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
//    public class HealthPlanController : TableController<HealthPlan>
//    {
//        protected override void Initialize(HttpControllerContext controllerContext)
//        {
//            base.Initialize(controllerContext);
//            DatabaseContext context = new DatabaseContext();
//            DomainManager = new EntityDomainManager<HealthPlan>(context, Request);
//        }

//        // GET tables/HealthPlan
//        public IQueryable<HealthPlan> GetAllHealthPlan()
//        {
//            return Query(); 
//        }

//        // GET tables/HealthPlan/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public SingleResult<HealthPlan> GetHealthPlan(string id)
//        {
//            return Lookup(id);
//        }

//        // PATCH tables/HealthPlan/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public Task<HealthPlan> PatchHealthPlan(string id, Delta<HealthPlan> patch)
//        {
//             return UpdateAsync(id, patch);
//        }

//        // POST tables/HealthPlan
//        public async Task<IHttpActionResult> PostHealthPlan(HealthPlan item)
//        {
//            HealthPlan current = await InsertAsync(item);
//            return CreatedAtRoute("Tables", new { id = current.Id }, current);
//        }

//        // DELETE tables/HealthPlan/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public Task DeleteHealthPlan(string id)
//        {
//             return DeleteAsync(id);
//        }
//    }
//}
