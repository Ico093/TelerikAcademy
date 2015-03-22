using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bookstore.Logs
{
    class LogsContext : DbContext
    {
        public LogsContext()
            : base("LogsContext")
        {
        }

        public DbSet<SearchLog> SearchLogs { get; set; }

        public static void AddLog(string text)
        {
           using(var db=new LogsContext())
           {
               SearchLog log = new SearchLog();
               log.Date = DateTime.Now;
               log.QueryXml = text;
               db.SearchLogs.Add(log);
               db.SaveChanges();
           }
        }
    }
}
