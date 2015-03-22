using MusicStore.Data;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicStore.Api.Controllers
{
    public class ArtistsController : ApiController
    {
        private MusicStoreContext db = new MusicStoreContext();

        public HttpResponseMessage Get()
        {
            var artists = db.Artists.ToList();

            return this.Request.CreateResponse(HttpStatusCode.OK, artists);
        }

        public HttpResponseMessage Get(int id)
        {
            Artist artist = db.Artists.Where(x => x.ArtistId == id).FirstOrDefault();

            return this.Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        public HttpResponseMessage Post([FromBody]Artist value)
        {
            if (value.Country.Length < 50 && value.Name.Length <= 100)
            {
                db.Artists.Add(value);
                db.SaveChanges();
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Incorrect input!");
            }
        }

        public HttpResponseMessage Put(int id, [FromBody]Artist value)
        {
            if (value.Country.Length < 50 && value.Name.Length <= 100)
            {
                Artist artist = db.Artists.Where(x => x.ArtistId == id).FirstOrDefault();
                if (artist != null)
                {
                    artist.Name = value.Name;
                    artist.Country = value.Country;
                    artist.DateOfBirth = value.DateOfBirth;

                    db.SaveChanges();
                    return this.Request.CreateResponse(HttpStatusCode.OK);
                }
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "No such user!");
            }
            else
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Incorrect input!");
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            Artist artist = db.Artists.Where(x => x.ArtistId == id).FirstOrDefault();
            if (artist != null)
            {
                db.Artists.Remove(artist);

                db.SaveChanges();
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "No such user!");
            }
        }
    }
}
