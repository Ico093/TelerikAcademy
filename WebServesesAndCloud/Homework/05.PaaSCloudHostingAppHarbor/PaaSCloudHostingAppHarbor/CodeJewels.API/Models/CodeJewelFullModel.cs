using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CodeJewels.API.Models
{
    [DataContract]
    public class CodeJewelFullModel:CodeJewelModel
    {
        [DataMember(Name = "sourceCode")]
        public string SourceCode { get; set; }
    }
}