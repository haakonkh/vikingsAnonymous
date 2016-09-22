using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using vikinganonymousService.DataObjects;
using vikinganonymousService.Models;

namespace vikinganonymousService.Controllers
{
    public class CommentsController : TableController<Comments>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            DatabaseContext context = new DatabaseContext();
            DomainManager = new EntityDomainManager<Comments>(context, Request);
        }

        // GET tables/Comments
        public IQueryable<Comments> GetAllComments()
        {
            return Query(); 
        }

        // GET tables/Comments/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Comments> GetComments(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Comments/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Comments> PatchComments(string id, Delta<Comments> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Comments
        public async Task<IHttpActionResult> PostComments(Comments item)
        {
            Comments current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Comments/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteComments(string id)
        {
             return DeleteAsync(id);
        }
    }
}
