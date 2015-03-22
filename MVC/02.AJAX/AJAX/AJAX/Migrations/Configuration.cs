namespace AJAX.Migrations
{
    using AJAX.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AJAX.Models.MoviesDbContext context)
        {
            if(context.Movies.Any())
            {
                return;
            }

            List<Movie> movies = new List<Movie>
            {
                new Movie
                {
                    Title="Titanic",
                    Director = "George Lucas",
                    Year = 1994,
                    LeadingMaleRole= "Leonardo Dicaprio",
                    LeadingFemaleRole = "Kiira Nightly",
                    Age=20,
                    Studio="Lucas Arts",
                    StudioAddress="San Francisco"
                },
                new Movie
                {
                    Title="Avatar",
                    Director = "George Lucas",
                    Year = 2010,
                    LeadingMaleRole= "somebody",
                    LeadingFemaleRole = "she",
                    Age=5,
                    Studio="Lucas Arts",
                    StudioAddress="San Francisco"
                }
            };

            context.Movies.AddRange(movies);
            context.SaveChanges();
        }
    }
}
