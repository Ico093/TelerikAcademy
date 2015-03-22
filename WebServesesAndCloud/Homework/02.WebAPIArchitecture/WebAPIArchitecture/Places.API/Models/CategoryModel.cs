using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Places.API.Models
{
    [DataContract]
    public class CategoryModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}