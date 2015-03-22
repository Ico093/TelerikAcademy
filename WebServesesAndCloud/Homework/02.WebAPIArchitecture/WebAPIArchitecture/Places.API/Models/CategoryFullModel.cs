using Places.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Places.API.Models
{
    [DataContract]
    public class CategoryFullModel:CategoryModel
    {
        [DataMember(Name = "places")]
        public HashSet<Place> Places { get; set; }
    }
}