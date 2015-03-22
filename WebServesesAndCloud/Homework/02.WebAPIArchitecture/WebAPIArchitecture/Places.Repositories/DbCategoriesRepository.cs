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
    public class DbCategoriesRepository:IRepository<Category>
    {
        private DbContext dbContext;
        private DbSet<Category> entitySet;

        public DbCategoriesRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Category>();
        }

        public Category Add(Category item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public Category Update(int id, Category item)
        {
            var category = this.entitySet.Where(x => x.Id == id).FirstOrDefault();
            if(category!=null)
            {
                category.Name=item.Name;
                category.Places=item.Places;
                this.dbContext.SaveChanges();
                return category;
            }
            else
            {
                throw new ArgumentException(String.Format("There isn't category with id={0}", id));
            }            
        }

        public void Delete(int id)
        {
            var category = this.entitySet.Where(x => x.Id == id).FirstOrDefault();
            if (category != null)
            {
                this.entitySet.Remove(category);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException(String.Format("There isn't category with id={0}", id));
            }
        }

        public void Delete(Category item)
        {
            var category = this.entitySet.Where(x => x.Id == item.Id).FirstOrDefault();
            if (category != null)
            {
                this.entitySet.Remove(category);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("There isn't such category");
            }
        }

        public Category Get(int id)
        {
            return this.entitySet.Where(x => x.Id == id).FirstOrDefault(); 
        }

        public IQueryable<Category> All()
        {
            return this.entitySet;
        }

        public IQueryable<Category> Find(System.Linq.Expressions.Expression<Func<Category, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
