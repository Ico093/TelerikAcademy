namespace Identity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Identity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Identity.Models.ApplicationDbContext context)
        {
            if(context.Roles.Any())
            {
                return;
            }

            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Id = "1", Name = "User" });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Id = "2", Name = "Moderator" });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Id = "3", Name = "Administrator" });

            context.SaveChanges();
        }
    }
}
