using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeJewels.API.Models;
using CodeJewels.Repositories;
using CodeJewels.Data;
using CodeJewels.Models;

namespace CodeJewels.API.Controllers
{
    public class CodeJewelsController : ApiController
    {
        private IRepository<CodeJewel> CodeJewelsRepository;

        public CodeJewelsController()
        {
            var dbContext = new CodeJewelsContext();
            this.CodeJewelsRepository = new DbCodeJewelsRepository(dbContext);
        }

        public CodeJewelsController(IRepository<CodeJewel> repository)
        {
            this.CodeJewelsRepository = repository;
        }

        // GET api/CodeJewels
        public IEnumerable<CodeJewelModel> GetAll()
        {
            var entity = this.CodeJewelsRepository.All();

            var codeJewels =
                from codeJewel in entity
                select new CodeJewelModel()
                {
                    Name = codeJewel.Name,
                    Category=codeJewel.Category,
                    AuthorMail=codeJewel.AuthorMail,
                    Rating=codeJewel.Rating
                };

            return codeJewels.ToList();
        }

        // GET api/CodeJewels/5
        public CodeJewelFullModel GetById(int id)
        {
            var entity = this.CodeJewelsRepository.Get(id);

            if (entity != null)
            {
                var codeJewel = new CodeJewelFullModel()
                {
                    Name = entity.Name,
                    Category = entity.Category,
                    AuthorMail = entity.AuthorMail,
                    Rating = entity.Rating,
                    SourceCode=entity.SourceCode
                };

                return codeJewel;
            }
            else
            {
                return null;
            }
        }

        // POST api/CodeJewels
        public HttpResponseMessage Post([FromBody]CodeJewel value)
        {
            var entity = CodeJewelsRepository.Add(value);

            var responce = Request.CreateResponse(HttpStatusCode.OK, entity);
            responce.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.Id }));
         
            return responce;
        }

        // PUT api/CodeJewels/5
        public HttpResponseMessage Put(int id, [FromBody]CodeJewel value)
        {
            var entity = CodeJewelsRepository.Update(id, value);

            var responce = Request.CreateResponse(HttpStatusCode.OK, entity);
            responce.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.Id }));

            return responce;
        }

        // DELETE api/CodeJewels/5
        public HttpResponseMessage Delete(int id)
        {
            CodeJewelsRepository.Delete(id);

            var responce = Request.CreateResponse(HttpStatusCode.OK);

            return responce;
        }
    }
}
