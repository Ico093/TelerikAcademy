using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LybrarySystem.Models;

namespace LybrarySystem
{
    public partial class _Default : Page
    {
        private LybrarySystemDbContext _context = new LybrarySystemDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> ListViewCategories_GetData()
        {
            return _context.Categories;
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Search.aspx?q={0}", TextBoxSearch.Text));
        }
    }
}