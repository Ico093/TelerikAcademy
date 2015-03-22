using Places.API.Models;
using Places.Data;
using Places.Models;
using Places.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Places.API.Controllers
{
    public class PlacesController : ApiController
    {
        private IRepository<Place> placesRepository;

        public PlacesController()
        {
            var dbContext = new PlacesContext();
            this.placesRepository = new DbPlacesRepository(dbContext);
        }

        public PlacesController(IRepository<Place> repository)
        {
            this.placesRepository = repository;
        }

        // GET api/places
        public IEnumerable<PlaceModel> GetAll()
        {
            var entity= this.placesRepository.All();

            var places =
                from place in entity
                select new PlaceModel()
                {
                    Name=place.Name,
                    Description = place.Description
                };

            return places.ToList();
        }

        // GET api/places/5
        public PlaceFullModel GetById(int id)
        {
            var entity = this.placesRepository.Get(id);

            if (entity != null)
            {
                var place = new PlaceFullModel()
                {
                    Name = entity.Name,
                    Description = entity.Description,
                    Latitude = entity.Latitude,
                    Longitude = entity.Longitude
                };

                return place;
            }
            else
            {
                return null;
            }
        }

        // POST api/places
        public HttpResponseMessage Post([FromBody]Place value)
        {
            var entity = placesRepository.Add(value);

            var responce = Request.CreateResponse(HttpStatusCode.OK, entity);
            responce.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.Id }));

            return responce;
        }

        // PUT api/places/5
        public HttpResponseMessage Put(int id, [FromBody]Place value)
        {
            var entity = placesRepository.Update(id, value);

            var responce = Request.CreateResponse(HttpStatusCode.OK, entity);
            responce.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.Id }));

            return responce;
        }

        // DELETE api/places/5
        public HttpResponseMessage Delete(int id)
        {
            placesRepository.Delete(id);

            var responce = Request.CreateResponse(HttpStatusCode.OK);

            return responce;
        }
    }
}
