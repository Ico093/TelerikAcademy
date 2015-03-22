using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkingWithData.Models;
using Microsoft.AspNet.Identity;

namespace WorkingWithData.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            IEnumerable<Tweet> tweets = _context.Tweets.Where(x => x.UserId == User.Identity.GetUserId()).ToList();

            return View(tweets);
        }
    }
}