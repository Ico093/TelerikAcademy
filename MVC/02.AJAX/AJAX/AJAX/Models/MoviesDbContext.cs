using AJAX.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AJAX.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesDbContext, Configuration>());
        }

        public DbSet<Movie> Movies { get; set; }
    }
}