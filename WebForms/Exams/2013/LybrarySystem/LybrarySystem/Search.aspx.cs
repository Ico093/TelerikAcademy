using LybrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LybrarySystem
{
    public partial class Search : System.Web.UI.Page
    {
        private LybrarySystemDbContext _context = new LybrarySystemDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Book> RepeaterResults_GetData([QueryString("q")] string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                Response.Redirect("~/");
            }

            LiteralQuery.Text = query;
            return _context.Books.Where(x=>x.Title.Contains(query) || x.Author.Contains(query));
        }
    }
}