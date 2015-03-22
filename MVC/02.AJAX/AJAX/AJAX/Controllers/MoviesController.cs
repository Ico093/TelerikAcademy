using AJAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJAX.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesDbContext _context = new MoviesDbContext();

        public ActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult UpdateMovie(int? Id)
        {
            Movie movie = _context.Movies.Where(x => x.Id == Id).FirstOrDefault();

            if (movie == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(movie);
        }

        [HttpPost]
        public JsonResult UpdateMovie(Movie movie)
        {
            Movie movieToUpdate = _context.Movies.Where(x => x.Id == movie.Id).FirstOrDefault();

            movieToUpdate.Title = movie.Title;
            _context.SaveChanges();
            return this.Json(new { msg = "Success!" });
        }

        [HttpGet]
        public ActionResult DeleteMovie(int? Id)
        {
            Movie movie = _context.Movies.Where(x => x.Id == Id).FirstOrDefault();

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}