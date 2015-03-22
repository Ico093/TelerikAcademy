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
    public class AlbumsController : ApiController
    {
        private MusicStoreContext db = new MusicStoreContext();

        public HttpResponseMessage Get()
        {
            var albums = db.Albums.ToList();

            return this.Request.CreateResponse(HttpStatusCode.OK, albums);
        }

        public HttpResponseMessage Get(int id)
        {
            Album album = db.Albums.Where(x => x.AlbumId == id).FirstOrDefault();

            return this.Request.CreateResponse(HttpStatusCode.OK, album);
        }

        public HttpResponseMessage Post([FromBody]Album value)
        {
            if (value.Title.Length < 100 && value.Producer.Length <100)
            {
                db.Albums.Add(value);
                db.SaveChanges();
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Incorrect input!");
            }
        }

        public HttpResponseMessage Put(int id, [FromBody]Album value)
        {
            if (value.Title.Length < 100 && value.Producer.Length < 100)
            {
                Album album = db.Albums.Where(x => x.AlbumId == id).FirstOrDefault();
                if (album != null)
                {
                    album.Title = value.Title;
                    album.Producer = value.Producer;
                    album.Year = value.Year;

                    db.SaveChanges();
                    return this.Request.CreateResponse(HttpStatusCode.OK);
                }
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "No such album!");
            }
            else
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Incorrect input!");
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            Album album = db.Albums.Where(x => x.AlbumId == id).FirstOrDefault();
            if (album != null)
            {
                db.Albums.Remove(album);

                db.SaveChanges();
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "No such album!");
            }
        }
    }
}
