using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Models;

namespace ATM.Data
{
    public class ATMContext:DbContext
    {
        public ATMContext()
            : base("ATMDB")
        {
        }

        public DbSet<CardAccount> CardAccount { get; set; }
        public DbSet<TransactionHistory> TransactionHistory { get; set; }
    }
}
