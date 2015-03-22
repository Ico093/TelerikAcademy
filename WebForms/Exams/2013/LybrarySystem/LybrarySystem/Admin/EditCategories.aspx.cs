using LybrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LybrarySystem.Admin
{
    public partial class EditCategories : System.Web.UI.Page
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

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategories_UpdateItem(int Id)
        {
            Category item = null;
            item = _context.Categories.Find(Id);
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
        public void ListViewCategories_DeleteItem(int Id)
        {
            Category item = null;
            item = _context.Categories.Find(Id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", Id));
                return;
            }

            _context.Categories.Remove(item);
            _context.SaveChanges();

            ListView ListViewCategories = UpdatePanelCategories.FindControl("ListViewCategories") as ListView;
            DataPager DataPagerCategories = ListViewCategories.FindControl("DataPagerCategories") as DataPager;

            int lastpage = (DataPagerCategories.TotalRowCount - 1) / DataPagerCategories.PageSize;
            if (((DataPagerCategories.TotalRowCount - 1) % DataPagerCategories.PageSize) == 0)
            {
                lastpage--;
            }
            DataPagerCategories.SetPageProperties((lastpage) * DataPagerCategories.PageSize, DataPagerCategories.MaximumRows, true);
        }

        protected void LinkButtonAdd_Click(object sender, EventArgs e)
        {
            FormView FormViewCreate = UpdatePanelCreate.FindControl("FormViewCreate") as FormView;
            FormViewCreate.Visible = true;
        }

        public void FormViewCreate_InsertItem()
        {
            var item = new Category();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                _context.Categories.Add(item);
                _context.SaveChanges();
            }

            FormView FormViewCreate = UpdatePanelCreate.FindControl("FormViewCreate") as FormView;
            FormViewCreate.Visible = false;

            ListView ListViewCategories = UpdatePanelCategories.FindControl("ListViewCategories") as ListView;
            DataPager DataPagerCategories = ListViewCategories.FindControl("DataPagerCategories") as DataPager;

            int lastpage = (DataPagerCategories.TotalRowCount + 1) / DataPagerCategories.PageSize;
            if (((DataPagerCategories.TotalRowCount + 1) % DataPagerCategories.PageSize) == 0)
            {
                lastpage--;
            }

            DataPagerCategories.SetPageProperties(lastpage * DataPagerCategories.PageSize, DataPagerCategories.MaximumRows, true);
        }
    }
}