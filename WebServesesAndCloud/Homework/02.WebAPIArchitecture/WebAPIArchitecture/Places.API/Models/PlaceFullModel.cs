using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Places.API.Models
{
    [DataContract]
    public class PlaceFullModel:PlaceModel
    {
        [DataMember(Name = "longitude")]
        public decimal Longitude { get; set; }

        [DataMember(Name = "latitude")]
        public decimal Latitude { get; set; }
    }
}