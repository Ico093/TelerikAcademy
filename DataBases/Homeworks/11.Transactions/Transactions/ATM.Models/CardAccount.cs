using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATM.Models
{
    public class CardAccount
    {
        
        public int CardAccountId { get; set; }

        [MaxLength(10)]
        public string CardNumber { get; set; }

        [MaxLength(4)]
        public string CardPIN { get; set; }

        [Column(TypeName="Money")]
        public decimal CardCash { get; set; }
    }
}
