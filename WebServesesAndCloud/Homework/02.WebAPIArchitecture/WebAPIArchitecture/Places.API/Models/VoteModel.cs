﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Places.API.Models
{
    [DataContract]
    public class VoteModel
    {
        [DataMember(Name = "value")]
        public int Value { get; set; }
    }
}