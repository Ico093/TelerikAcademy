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

namespace Votes.API.Controllers
{
    public class VotesController : ApiController
    {
        private IRepository<Vote> VotesRepository;

        public VotesController()
        {
            var dbContext = new PlacesContext();
            this.VotesRepository = new DbVotesRepository(dbContext);
        }

        public VotesController(IRepository<Vote> repository)
        {
            this.VotesRepository = repository;
        }

        // GET api/Votes
        public IEnumerable<VoteModel> GetAll()
        {
            var entity= this.VotesRepository.All();

            var votes =
                from vote in entity
                select new VoteModel()
                {
                    Value = vote.Value
                };

            return votes.ToList();
        }

        // GET api/Votes/5
        public VoteFullModel GetById(int id)
        {
            var entity = this.VotesRepository.Get(id);

            if (entity != null)
            {
                var vote = new VoteFullModel()
                {
                    Value = entity.Value,
                    Username=entity.Username,
                    Place=entity.Place
                };

                return vote;
            }
            else
            {
                return null;
            }
        }

        // POST api/Votes
        public HttpResponseMessage Post([FromBody]Vote value)
        {
            var entity = VotesRepository.Add(value);

            var responce = Request.CreateResponse(HttpStatusCode.OK, entity);
            responce.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.Id }));

            return responce;
        }

        // PUT api/Votes/5
        public HttpResponseMessage Put(int id, [FromBody]Vote value)
        {
            var entity = VotesRepository.Update(id, value);

            var responce = Request.CreateResponse(HttpStatusCode.OK, entity);
            responce.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.Id }));

            return responce;
        }

        // DELETE api/Votes/5
        public HttpResponseMessage Delete(int id)
        {
            VotesRepository.Delete(id);

            var responce = Request.CreateResponse(HttpStatusCode.OK);

            return responce;
        }
    }
}
