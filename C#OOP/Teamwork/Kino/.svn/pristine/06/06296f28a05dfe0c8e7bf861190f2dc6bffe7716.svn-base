using Kino.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Classes
{
    class Admin :Person,ILoggable
    {
        string password;
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        public Admin(string name, string password) : base(name) 
        {
            this.Password = password;
        }

        public void AddMovie(string movieName, double price, List<Projection> projections)
        {
            MoviesStorage.Instance.AddMovie(new Movie(movieName, price, projections));
            MoviesStorage.Instance.SetInformation();
        }

        public void DeleteMovie(string movieName)
        {
            var removeMovie = MoviesStorage.Movies.Where(x => x.MovieName == movieName).Select(x => x).FirstOrDefault();
            if (removeMovie != null)
            {
                MoviesStorage.Movies.Remove(removeMovie);
                MoviesStorage.Instance.SetInformation();
            }
            else
            {
                throw new InvalidMovieException();
            }
        }

        public void AddProjectionToMovie(string movieName, Projection projection)
        {
            var movie = MoviesStorage.Movies.Where(x => x.MovieName == movieName).FirstOrDefault();
            if (movie != null)
            {
                movie.AddProjection(projection);
                MoviesStorage.Instance.SetInformation();
            }
            else
            {
                throw new InvalidMovieException();
            }
        }

        public void DeleteProjection(string movieName, String projectionHour)
        {
            var movie = MoviesStorage.Movies.Where(x => x.MovieName == movieName).FirstOrDefault();
            if (movie != null)
            {
                movie.DeleteProjection(projectionHour);
                MoviesStorage.Instance.SetInformation();
            }
            else
            {
                throw new InvalidMovieException();
            }
        }
    }
}
