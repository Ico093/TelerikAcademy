using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MortgageAccount : Account
{
    public MortgageAccount(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate) { }

    public override decimal CalculateAmountFor(int months)
    {
        if (Customer.GetType().Name == "Individual")
        {
            if((months-6)>=0)
            {
            return (months-6)*InterestRate;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            if ((months - 12) >= 0)
            {
                return (12 * InterestRate / 2) + (months - 12) * InterestRate;
            }
            else
            {
                return months * InterestRate;
            }
        }
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }
}
