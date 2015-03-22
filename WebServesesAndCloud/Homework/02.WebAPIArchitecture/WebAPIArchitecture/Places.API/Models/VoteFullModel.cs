using Places.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Places.API.Models
{
    [DataContract]
    public class VoteFullModel:VoteModel
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "place")]
        public Place Place { get; set; }
    }
}