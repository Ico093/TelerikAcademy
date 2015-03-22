using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WorkingWithData.Models;

namespace WorkingWithData.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string textToPost, string tagsToPost)
        {
            string[] tags = tagsToPost.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
            HashSet<Tag> tagsInDatabase = new HashSet<Tag>();

            foreach (var tag in tags)
            {
                Tag newTag = new Tag
                {
                    Text = tag
                };

                tagsInDatabase.Add(newTag);
            }

            Tweet tweet = new Tweet
            {
                Text = textToPost,
                Tags = tagsInDatabase,
                UserId = User.Identity.GetUserId()
            };

            _context.Tweets.Add(tweet);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Profile()
        {
            string userId = this.User.Identity.GetUserId();

            var tweets = _context.Tweets.Include("Tags").Where(x => x.UserId == userId)
                .AsQueryable().Select(TweetViewModel.FromTweet).ToList();

            return View(tweets);
        }


        [OutputCache(Duration = 15 * 60, VaryByParam = "query")]
        public ActionResult Search(string query)
        {
            List<TweetViewModel> tweets = new List<TweetViewModel>();

            if (!string.IsNullOrEmpty(query))
            {
                tweets = _context.Tweets.Include("Tags").Where(tweet => tweet.Tags.Where(tag => tag.Text == query).Any()).AsQueryable().Select(TweetViewModel.FromTweet).ToList();
            }

            return View(tweets);
        }
    }
}