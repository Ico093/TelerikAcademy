using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATM.Models
{
    public class TransactionHistory
    {
        private DateTime? transactionDate;

        public int TransactionHistoryId { get; set; }

        [MaxLength(10)]
        public string CardNumber { get; set; }

        [Required]
        public DateTime TransactionDate
        {
            get
            {
                if (transactionDate == null)
                {
                    transactionDate = DateTime.Now;
                }
                return transactionDate.Value;
            }
            private set { transactionDate = value; }
        }

        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }
    }
}
