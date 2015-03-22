using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBinding.Task01.Models;

namespace DataBinding.Task01
{
    public partial class Index : System.Web.UI.Page
    {
        private readonly List<Producer> _producersList = new List<Producer>
        {
            new Producer{Name = "", Models = new string[]{}},
            new Producer{Name = "Audi", Models = new string[]{"A6","A5","A4","A3"}},
            new Producer{Name = "Mercedes", Models = new string[]{"Benz","C","E"}},
            new Producer{Name = "Peugeot", Models = new string[]{"307","206","407"}}
        };

        private readonly List<Extra> _extras = new List<Extra>
        {
            new Extra{Name = "Kormilo", IsChecked = false},
            new Extra{Name = "Dvigatel", IsChecked = true},
            new Extra{Name = "Gumi", IsChecked = true},
            new Extra{Name = "Pokriv", IsChecked = false}
        };

        private readonly List<string> _engines = new List<string>
        {
            "dizel",
            "benzin"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            this.producers.DataSource = _producersList;
            this.extras.DataSource = _extras;
            this.engines.DataSource = _engines;

            this.producers.SelectedIndexChanged += Producers_SelectedIndexChanged;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.DataBind();
            }
        }

        private void Producers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = sender as DropDownList;

            if (sender != null)
            {
                this.models.DataSource = _producersList[list.SelectedIndex].Models;
                this.models.DataBind();
            }
        }


    }
}