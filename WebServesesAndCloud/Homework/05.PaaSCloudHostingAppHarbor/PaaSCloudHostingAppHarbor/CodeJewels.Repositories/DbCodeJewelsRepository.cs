using CodeJewels.Data;
using CodeJewels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJewels.Repositories
{
    public class DbCodeJewelsRepository : IRepository<CodeJewel>
    {
        private DbContext dbContext;
        private DbSet<CodeJewel> entitySet;

        public DbCodeJewelsRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<CodeJewel>();
        }

        public CodeJewel Add(CodeJewel item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public CodeJewel Update(int id, CodeJewel item)
        {
            var codeJewel = this.entitySet.Where(x => x.Id == id).FirstOrDefault();
            if (codeJewel != null)
            {
                codeJewel.Name = item.Name;
                codeJewel.Category = item.Category;
                codeJewel.AuthorMail = item.AuthorMail;
                codeJewel.Rating = item.Rating;
                codeJewel.SourceCode = item.SourceCode;

                this.dbContext.SaveChanges();
                return codeJewel;
            }
            else
            {
                throw new ArgumentException(String.Format("There isn't code jewel with id={0}.", id));
            }
        }

        public void Delete(int id)
        {
            var codeJewel = this.entitySet.Where(x => x.Id == id).FirstOrDefault();
            if (codeJewel != null)
            {
                this.entitySet.Remove(codeJewel);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException(String.Format("There isn't code jewel with id={0}.", id));
            }
        }

        public void Delete(CodeJewel item)
        {
            var codeJewel = this.entitySet.Where(x => x.Id == item.Id).FirstOrDefault();
            if (codeJewel != null)
            {
                this.entitySet.Remove(codeJewel);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("There isn't such code jewel.");
            }
        }

        public CodeJewel Get(int id)
        {
            return this.entitySet.Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<CodeJewel> All()
        {
            return this.entitySet;
        }

        public IQueryable<CodeJewel> Find(System.Linq.Expressions.Expression<Func<CodeJewel, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
