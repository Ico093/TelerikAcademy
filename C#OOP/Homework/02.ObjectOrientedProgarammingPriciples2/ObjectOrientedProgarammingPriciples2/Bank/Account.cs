using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Account : ICalculate
{
    private Customer customer;
    private decimal balance;
    private decimal interestRate;

    public Customer Customer
    {
        get { return customer; }
    }

    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public decimal InterestRate
    {
        get { return interestRate; }
        set
        {
            if (value >= 0)
            {
                interestRate = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Interest rate can't be negative!");
            }
        }
    }

    public Account(Customer customer, decimal balance, decimal interestRate)
    {
        this.customer = customer;
        this.balance = balance;
        this.interestRate = interestRate;
    }

    public abstract decimal CalculateAmountFor(int months);
}

