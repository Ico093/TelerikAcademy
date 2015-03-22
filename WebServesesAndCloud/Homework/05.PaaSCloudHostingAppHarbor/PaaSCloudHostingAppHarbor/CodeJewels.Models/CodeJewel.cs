using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJewels.Models
{
    public class CodeJewel
    {
        public CodeJewel()
        {
            this.Rating = new HashSet<Vote>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string AuthorMail { get; set; }

        public virtual HashSet<Vote> Rating { get; set; }

        public string SourceCode { get; set; }
    }
}
