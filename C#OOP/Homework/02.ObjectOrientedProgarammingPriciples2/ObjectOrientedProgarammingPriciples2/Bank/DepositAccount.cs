using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DepositAccount:Account
{
    public DepositAccount(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
    {
        if (Balance > 0 && balance < 1000)
        {
            InterestRate = 0;
        }
    }

    public override decimal CalculateAmountFor(int months)
    {
        return months*InterestRate;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void WithDraw(decimal amount)
    {
        if (Balance > amount)
        {
            Balance -= amount;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Can't withdraw because there isn't enough money!");
        }
    }
}
