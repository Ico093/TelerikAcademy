using CodeJewels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CodeJewels.API.Models
{
    [DataContract]
    public class CodeJewelModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; }

        [DataMember(Name = "authorMail")]
        public string AuthorMail { get; set; }

        [DataMember(Name = "Rating")]
        public HashSet<Vote> Rating { get; set; }
    }
}