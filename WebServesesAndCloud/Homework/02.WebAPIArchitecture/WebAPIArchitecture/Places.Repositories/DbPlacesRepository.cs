using Places.Data;
using Places.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.Repositories
{
    public class DbPlacesRepository:IRepository<Place>
    {
        private DbContext dbContext;
        private DbSet<Place> entitySet;

        public DbPlacesRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Place>();
        }

        public Place Add(Place item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public Place Update(int id, Place item)
        {
            var place = this.entitySet.Where(x => x.Id == id).FirstOrDefault();
            if(place!=null)
            {
                place.Name = item.Name;
                place.Latitude = item.Latitude;
                place.Longitude = item.Longitude;
                place.Description = item.Description;
                this.dbContext.SaveChanges();
                return place;
            }
            else
            {
                throw new ArgumentException(String.Format("There isn't place with id={0}", id));
            }            
        }

        public void Delete(int id)
        {
            var place = this.entitySet.Where(x => x.Id == id).FirstOrDefault();
            if (place != null)
            {
                this.entitySet.Remove(place);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException(String.Format("There isn't place with id={0}",id));
            }
        }

        public void Delete(Place item)
        {
            var place = this.entitySet.Where(x => x.Id == item.Id).FirstOrDefault();
            if (place != null)
            {
                this.entitySet.Remove(place);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("There isn't such place");
            }
        }

        public Place Get(int id)
        {
            return this.entitySet.Where(x => x.Id == id).FirstOrDefault(); 
        }

        public IQueryable<Place> All()
        {
            return this.entitySet;
        }

        public IQueryable<Place> Find(System.Linq.Expressions.Expression<Func<Place, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
