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
    public class DbCommentsRepository:IRepository<Comment>
    {
        private DbContext dbContext;
        private DbSet<Comment> entitySet;

        public DbCommentsRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Comment>();
        }

        public Comment Add(Comment item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public Comment Update(int id, Comment item)
        {
            var comment = this.entitySet.Where(x => x.Id == id).FirstOrDefault();
            if (comment != null)
            {
                comment.Value = item.Value;
                comment.Username = item.Username;
                comment.Place = item.Place;
                this.dbContext.SaveChanges();
                return comment;
            }
            else
            {
                throw new ArgumentException(String.Format("There isn't comment with id={0}", id));
            }            
        }

        public void Delete(int id)
        {
            var comment = this.entitySet.Where(x => x.Id == id).FirstOrDefault();
            if (comment != null)
            {
                this.entitySet.Remove(comment);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException(String.Format("There isn't comment with id={0}", id));
            }
        }

        public void Delete(Comment item)
        {
            var comment = this.entitySet.Where(x => x.Id == item.Id).FirstOrDefault();
            if (comment != null)
            {
                this.entitySet.Remove(comment);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("There isn't such comment");
            }
        }

        public Comment Get(int id)
        {
            return this.entitySet.Where(x => x.Id == id).FirstOrDefault(); 
        }

        public IQueryable<Comment> All()
        {
            return this.entitySet;
        }

        public IQueryable<Comment> Find(System.Linq.Expressions.Expression<Func<Comment, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
