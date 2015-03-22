using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Essentials.Models
{
    public class Params
    {
        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Kilo { get; set; }
    }
}