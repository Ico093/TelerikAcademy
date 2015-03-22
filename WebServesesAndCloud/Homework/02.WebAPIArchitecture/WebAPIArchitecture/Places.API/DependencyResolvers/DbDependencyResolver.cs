using Categories.API.Controllers;
using Comments.API.Controllers;
using Places.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Votes.API.Controllers;

namespace Places.API.DependencyResolvers
{
    public class DbDependencyResolver:IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(PlacesController))
            {
                return new PlacesController();
            }
            if (serviceType == typeof(CategoriesController))
            {
                return new CategoriesController();
            }
            if (serviceType == typeof(CommentsController))
            {
                return new CommentsController();
            }
            if (serviceType == typeof(VotesController))
            {
                return new VotesController();
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}