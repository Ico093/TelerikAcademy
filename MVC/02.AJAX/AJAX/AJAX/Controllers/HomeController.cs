using AJAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJAX.Controllers
{
    public class HomeController : Controller
    {
        private MoviesDbContext _context = new MoviesDbContext();

        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();

            return View(movies);
        }

        public JsonResult GetMoviesAsJSON()
        {
            var movies = _context.Movies.ToList();

            return this.Json(movies, JsonRequestBehavior.AllowGet);
        }
    }
}