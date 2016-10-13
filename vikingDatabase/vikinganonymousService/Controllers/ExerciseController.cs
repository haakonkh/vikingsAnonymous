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
//    public class ExerciseController : TableController<Exercise>
//    {
//        protected override void Initialize(HttpControllerContext controllerContext)
//        {
//            base.Initialize(controllerContext);
//            DatabaseContext context = new DatabaseContext();
//            DomainManager = new EntityDomainManager<Exercise>(context, Request);
//        }

//        // GET tables/Exercise
//        public IQueryable<Exercise> GetAllExercise()
//        {
//            return Query(); 
//        }

//        // GET tables/Exercise/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public SingleResult<Exercise> GetExercise(string id)
//        {
//            return Lookup(id);
//        }

//        // PATCH tables/Exercise/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public Task<Exercise> PatchExercise(string id, Delta<Exercise> patch)
//        {
//             return UpdateAsync(id, patch);
//        }

//        // POST tables/Exercise
//        public async Task<IHttpActionResult> PostExercise(Exercise item)
//        {
//            Exercise current = await InsertAsync(item);
//            return CreatedAtRoute("Tables", new { id = current.Id }, current);
//        }

//        // DELETE tables/Exercise/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public Task DeleteExercise(string id)
//        {
//             return DeleteAsync(id);
//        }
//    }
//}
