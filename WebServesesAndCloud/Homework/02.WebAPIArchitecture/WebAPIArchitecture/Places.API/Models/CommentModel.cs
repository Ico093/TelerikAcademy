using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Places.API.Models
{
    [DataContract]
    public class CommentModel
    {
        [DataMember(Name = "value")]
        public string Value { get; set; }
    }
}