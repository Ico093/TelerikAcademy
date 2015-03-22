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
    public class SongsController : ApiController
    {
        private MusicStoreContext db = new MusicStoreContext();

        public HttpResponseMessage Get()
        {
            var songs = db.Songs.ToList();

            return this.Request.CreateResponse(HttpStatusCode.OK, songs);
        }

        public HttpResponseMessage Get(int id)
        {
            Song song = db.Songs.Where(x => x.SongId == id).FirstOrDefault();

            return this.Request.CreateResponse(HttpStatusCode.OK, song);
        }

        public HttpResponseMessage Post([FromBody]Song value)
        {
            if (value.Title.Length <100)
            {
                db.Songs.Add(value);
                db.SaveChanges();
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Incorrect input!");
            }
        }

        public HttpResponseMessage Put(int id, [FromBody]Song value)
        {
            if (value.Title.Length < 100)
            {
                Song song = db.Songs.Where(x => x.SongId == id).FirstOrDefault();
                if (song != null)
                {
                    song.Title = value.Title;
                    song.Type = value.Type;
                    song.Year = value.Year;

                    db.SaveChanges();
                    return this.Request.CreateResponse(HttpStatusCode.OK);
                }
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "No such song!");
            }
            else
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Incorrect input!");
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            Song song = db.Songs.Where(x => x.SongId == id).FirstOrDefault();
            if (song != null)
            {
                db.Songs.Remove(song);

                db.SaveChanges();
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "No such song!");
            }
        }
    }
}
