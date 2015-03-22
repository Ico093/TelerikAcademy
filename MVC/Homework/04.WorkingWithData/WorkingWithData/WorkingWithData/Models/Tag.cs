using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkingWithData.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Tweets = new HashSet<Tweet>();
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}