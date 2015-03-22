using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Places.Models;
using System.Runtime.Serialization;

namespace Places.API.Models
{
    [DataContract]
    public class CommentFullModel:CommentModel
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "place")]
        public Place Place { get; set; }
    }
}