using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumingWebServices
{
    class RequestedObject
    {
        public IEnumerable<Article> articles { get; set; }
        public string description { get; set; }
        public string syndication_url { get; set; }
        public string title { get; set; }
    }
}
