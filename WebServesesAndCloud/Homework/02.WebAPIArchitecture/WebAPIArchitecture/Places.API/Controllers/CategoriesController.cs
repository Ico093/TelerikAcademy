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

namespace Categories.API.Controllers
{
    public class CategoriesController : ApiController
    {
        private IRepository<Category> CategoriesRepository;

        public CategoriesController()
        {
            var dbContext = new PlacesContext();
            this.CategoriesRepository = new DbCategoriesRepository(dbContext);
        }

        public CategoriesController(IRepository<Category> repository)
        {
            this.CategoriesRepository = repository;
        }

        // GET api/Comments
        public IEnumerable<CategoryModel> GetAll()
        {
            var entity = this.CategoriesRepository.All();

            var categories =
                from category in entity
                select new CategoryModel()
                {
                    Name = category.Name
                };

            return categories.ToList();
        }

        // GET api/Comments/5
        public CategoryFullModel GetById(int id)
        {
            var entity = this.CategoriesRepository.Get(id);

            if (entity != null)
            {
                var category = new CategoryFullModel()
                {
                    Places=entity.Places
                };

                return category;
            }
            else
            {
                return null;
            }
        }

        // POST api/Comments
        public HttpResponseMessage Post([FromBody]Category value)
        {
            var entity = CategoriesRepository.Add(value);

            var responce = Request.CreateResponse(HttpStatusCode.OK, entity);
            responce.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.Id }));

            return responce;
        }

        // PUT api/Comments/5
        public HttpResponseMessage Put(int id, [FromBody]Category value)
        {
            var entity = CategoriesRepository.Update(id, value);

            var responce = Request.CreateResponse(HttpStatusCode.OK, entity);
            responce.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.Id }));

            return responce;
        }

        // DELETE api/Comments/5
        public HttpResponseMessage Delete(int id)
        {
            CategoriesRepository.Delete(id);

            var responce = Request.CreateResponse(HttpStatusCode.OK);

            return responce;
        }
    }
}
