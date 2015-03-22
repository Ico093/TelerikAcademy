using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Places.API.Models;
using Places.Repositories;
using Places.Data;
using Places.Models;

namespace Comments.API.Controllers
{
    public class CommentsController : ApiController
    {
        private IRepository<Comment> CommentsRepository;

        public CommentsController()
        {
            var dbContext = new PlacesContext();
            this.CommentsRepository = new DbCommentsRepository(dbContext);
        }

        public CommentsController(IRepository<Comment> repository)
        {
            this.CommentsRepository = repository;
        }

        // GET api/Comments
        public IEnumerable<CommentModel> GetAll()
        {
            var entity= this.CommentsRepository.All();

            var comments =
                from comment in entity
                select new CommentModel()
                {
                    Value = comment.Value
                };

            return comments.ToList();
        }

        // GET api/Comments/5
        public CommentFullModel GetById(int id)
        {
            var entity = this.CommentsRepository.Get(id);

            if (entity != null)
            {
                var comment = new CommentFullModel()
                {
                    Value = entity.Value,
                    Username=entity.Username,
                    Place=entity.Place
                };

                return comment;
            }
            else
            {
                return null;
            }
        }

        // POST api/Comments
        public HttpResponseMessage Post([FromBody]Comment value)
        {
            var entity = CommentsRepository.Add(value);

            var responce = Request.CreateResponse(HttpStatusCode.OK, entity);
            responce.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.Id }));

            return responce;
        }

        // PUT api/Comments/5
        public HttpResponseMessage Put(int id, [FromBody]Comment value)
        {
            var entity = CommentsRepository.Update(id, value);

            var responce = Request.CreateResponse(HttpStatusCode.OK, entity);
            responce.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.Id }));

            return responce;
        }

        // DELETE api/Comments/5
        public HttpResponseMessage Delete(int id)
        {
            CommentsRepository.Delete(id);

            var responce = Request.CreateResponse(HttpStatusCode.OK);

            return responce;
        }
    }
}
