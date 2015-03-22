using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tetris.Data;
using Tetris.Models;

namespace TetrisAPI.Controllers
{
    public class PlayersController : ApiController
    {
        public TetrisContext context;

        public PlayersController()
        {
            this.context = new TetrisContext();
        }

        // GET api/values
        public IEnumerable<Player> Get()
        {
            return this.context.Players.ToList().OrderByDescending(x=>x.Score);
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Player value)
        {
            if (value.Name != "" && value.Name != String.Empty)
            {
                var entity=this.context.Players.Add(value);

                var responce = Request.CreateResponse(HttpStatusCode.OK, entity);
                responce.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = entity.Id }));

                context.SaveChanges();

                return responce;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
