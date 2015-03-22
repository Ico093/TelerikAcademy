using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Classes
{
    public class Movie
    {
        private string movieName;
        private double price;
        private List<Projection> projections;

        public string MovieName
        {
            get { return this.movieName; }
            set { this.movieName = value; }
        }

        public double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public List<Projection> Projections
        {
            get { return this.projections; }
            set { this.projections = value; }
        }

        public Movie(string movieName, double price, List<Projection> projections)
        {
            MovieName = movieName;
            Price = price;
            Projections = projections;
        }

        public void AddProjection(Projection projection)
        {
            Projections.Add(projection);
        }

        public void DeleteProjection(String projectionHour)
        {
            var projection = Projections.Where(x => x.ProjectionHour == projectionHour).Select(x => x).FirstOrDefault();
            if (projection != null)
            {
                Projections.Remove(projection);
            }
            else
            {
                //WrongProjectionException
            }
        }
        public Projection GetProjection(String projectionHour) 
        {
            return Projections.Where(x => x.ProjectionHour.Equals(projectionHour)).Select(x => x).FirstOrDefault();
        }

        
    }
}
