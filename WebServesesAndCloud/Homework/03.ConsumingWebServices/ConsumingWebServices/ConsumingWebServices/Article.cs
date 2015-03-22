using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumingWebServices
{
    class Article
    {
        public string author { get; set; }

        public DateTime publish_date { get; set; }

        public string source { get; set; }

        public string source_url { get; set; }

        public string summary { get; set; }

        public string title { get; set; }

        public string url { get; set; }
    }
}
