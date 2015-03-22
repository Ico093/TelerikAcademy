using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.Models
{
    public class Category
    {
        public Category()
        {
            this.Places = new HashSet<Place>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual HashSet<Place> Places{ get; set; }
    }
}
