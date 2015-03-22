using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LoanAccount : Account
{
    public LoanAccount(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate) { }

    public override decimal CalculateAmountFor(int months)
    {
        if (Customer.GetType().ToString() == "Individual")
        {
            months -= 3;
        }
        else
        {
            months -= 2;
        }

        if (months <= 0)
        {
            return 0;
        }
        else
        {
            return months * InterestRate;
        }
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }
}
