using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkingWithData.Models
{
    public class Tweet
    {
        public Tweet()
        {
            this.Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public string UserId { get; set; }
    }
}