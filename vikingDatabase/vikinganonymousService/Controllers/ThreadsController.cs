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
//    public class ThreadsController : TableController<Threads>
//    {
//        protected override void Initialize(HttpControllerContext controllerContext)
//        {
//            base.Initialize(controllerContext);
//            DatabaseContext context = new DatabaseContext();
//            DomainManager = new EntityDomainManager<Threads>(context, Request);
//        }

//        // GET tables/Threads
//        public IQueryable<Threads> GetAllThreads()
//        {
//            return Query(); 
//        }

//        // GET tables/Threads/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public SingleResult<Threads> GetThreads(string id)
//        {
//            return Lookup(id);
//        }

//        // PATCH tables/Threads/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public Task<Threads> PatchThreads(string id, Delta<Threads> patch)
//        {
//             return UpdateAsync(id, patch);
//        }

//        // POST tables/Threads
//        public async Task<IHttpActionResult> PostThreads(Threads item)
//        {
//            Threads current = await InsertAsync(item);
//            return CreatedAtRoute("Tables", new { id = current.Id }, current);
//        }

//        // DELETE tables/Threads/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public Task DeleteThreads(string id)
//        {
//             return DeleteAsync(id);
//        }
//    }
//}
