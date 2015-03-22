using LybrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LybrarySystem.Admin
{
    public partial class EditBooks : System.Web.UI.Page
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
        public IQueryable<LybrarySystem.Models.Book> GridViewBooks_GetData()
        {
            return _context.Books;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewBooks_UpdateItem(int Id)
        {
            Book item = null;
            item = _context.Books.Find(Id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", Id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                _context.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewBooks_DeleteItem(int Id)
        {
            Book item = null;
            item = _context.Books.Find(Id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", Id));
                return;
            }

            if (ModelState.IsValid)
            {
                _context.Books.Remove(item);
                _context.SaveChanges();
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> DropDownListCategories_GetData()
        {
            return _context.Categories;
        }

        protected void LinkButtonAddNewBook_Click(object sender, EventArgs e)
        {
            LinkButton LinkButtonAddNewBook = UpdatePanelCreate.FindControl("LinkButtonAddNewBook") as LinkButton;
            LinkButtonAddNewBook.Visible = false;

            FormView FormViewCreate = UpdatePanelCreate.FindControl("FormViewCreate") as FormView;
            FormViewCreate.Visible = true;
        }

        public void FormViewCreate_InsertItem()
        {
            var item = new Book();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                _context.Books.Add(item);
                _context.SaveChanges();
            }

            FormView FormViewCreate = UpdatePanelCreate.FindControl("FormViewCreate") as FormView;
            FormViewCreate.Visible = false;

            LinkButton LinkButtonAddNewBook = UpdatePanelCreate.FindControl("LinkButtonAddNewBook") as LinkButton;
            LinkButtonAddNewBook.Visible = true;

            GridView GridViewBooks = UpdatePanelBooks.FindControl("GridViewBooks") as GridView;
            GridViewBooks.PageIndex = GridViewBooks.PageCount - 1;
            UpdatePanelBooks.Update();
        }
    }
}