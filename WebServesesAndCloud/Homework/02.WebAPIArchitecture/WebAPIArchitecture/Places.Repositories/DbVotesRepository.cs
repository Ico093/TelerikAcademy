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
    public class DbVotesRepository:IRepository<Vote>
    {
        private DbContext dbContext;
        private DbSet<Vote> entitySet;

        public DbVotesRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Vote>();
        }

        public Vote Add(Vote item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public Vote Update(int id, Vote item)
        {
            var vote = this.entitySet.Where(x => x.Id == id).FirstOrDefault();
            if (vote != null)
            {
                vote.Value = item.Value;
                vote.Username = item.Username;
                vote.Place = item.Place;
                this.dbContext.SaveChanges();
                return vote;
            }
            else
            {
                throw new ArgumentException(String.Format("There isn't vote with id={0}", id));
            }            
        }

        public void Delete(int id)
        {
            var vote = this.entitySet.Where(x => x.Id == id).FirstOrDefault();
            if (vote != null)
            {
                this.entitySet.Remove(vote);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException(String.Format("There isn't vote with id={0}", id));
            }
        }

        public void Delete(Vote item)
        {
            var vote = this.entitySet.Where(x => x.Id == item.Id).FirstOrDefault();
            if (vote != null)
            {
                this.entitySet.Remove(vote);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("There isn't such vote");
            }
        }

        public Vote Get(int id)
        {
            return this.entitySet.Where(x => x.Id == id).FirstOrDefault(); 
        }

        public IQueryable<Vote> All()
        {
            return this.entitySet;
        }

        public IQueryable<Vote> Find(System.Linq.Expressions.Expression<Func<Vote, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
