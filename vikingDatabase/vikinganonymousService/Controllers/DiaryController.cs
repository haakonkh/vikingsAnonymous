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
//    public class DiaryController : TableController<Diary>
//    {
//        protected override void Initialize(HttpControllerContext controllerContext)
//        {
//            base.Initialize(controllerContext);
//            DatabaseContext context = new DatabaseContext();
//            DomainManager = new EntityDomainManager<Diary>(context, Request);
//        }

//        // GET tables/Diary
//        public IQueryable<Diary> GetAllDiary()
//        {
//            return Query(); 
//        }

//        // GET tables/Diary/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public SingleResult<Diary> GetDiary(string id)
//        {
//            return Lookup(id);
//        }

//        // PATCH tables/Diary/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public Task<Diary> PatchDiary(string id, Delta<Diary> patch)
//        {
//             return UpdateAsync(id, patch);
//        }

//        // POST tables/Diary
//        public async Task<IHttpActionResult> PostDiary(Diary item)
//        {
//            Diary current = await InsertAsync(item);
//            return CreatedAtRoute("Tables", new { id = current.Id }, current);
//        }

//        // DELETE tables/Diary/48D68C86-6EA6-4C25-AA33-223FC9A27959
//        public Task DeleteDiary(string id)
//        {
//             return DeleteAsync(id);
//        }
//    }
//}
