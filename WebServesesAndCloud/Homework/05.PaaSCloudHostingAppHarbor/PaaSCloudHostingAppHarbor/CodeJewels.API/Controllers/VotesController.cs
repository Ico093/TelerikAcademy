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
    public class VotesController : ApiController
    {
        // POST api/Votes/5
        public HttpResponseMessage Post(int id,[FromBody]Vote value)
        {
            using(var context = new CodeJewelsContext())
            {
                if (value.Value >= 0 && value.Value <= 5)
                {
                    var codeJewel = context.CodeJewels.Where(x => x.Id == id).FirstOrDefault();

                    if (codeJewel != null)
                    {
                        codeJewel.Rating.Add(value);

                        CheckRating(context,codeJewel);

                        context.SaveChanges();
                    }
                    else
                    {
                        throw new ArgumentException("No such code jewel!");
                    }
                }
                else
                {
                    throw new ArgumentException("Value must be between 0 and 5!");
                }
            }


            var responce = Request.CreateResponse(HttpStatusCode.OK, value);

            return responce;
        }

        private void CheckRating(CodeJewelsContext context, CodeJewel codeJewel)
        {
            if (codeJewel.Rating.Average(x=>x.Value) < 1)
            {
                context.CodeJewels.Remove(codeJewel);
                context.SaveChanges();
            }
        }
    }
}
