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
    public partial class BookDetails : Page
    {
        private LybrarySystemDbContext _context = new LybrarySystemDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Book FormViewBookDetails_GetItem([QueryString("id")]int? id)
        {
            if (!id.HasValue)
            {
                Response.Redirect("~/");
            }

            return _context.Books.FirstOrDefault(x => x.Id == id.Value);
        }
    }
}