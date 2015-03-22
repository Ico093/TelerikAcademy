using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Bank
{
    static void Main()
    {
        Customer Pesho=new Individual("Pesho",42);

        DepositAccount naPesho = new DepositAccount(Pesho, 1245.123M, 0.06M);

        Customer IBM = new Company("IBM", 34);

        MortgageAccount naIBM = new MortgageAccount(IBM, 12345152412, 0.23M);

        Console.WriteLine(naPesho.CalculateAmountFor(13));

        Console.WriteLine(naIBM.CalculateAmountFor(14));

        Account a = new LoanAccount(Pesho, 123123, 32);

        Console.WriteLine(a.CalculateAmountFor(6));
    }
}
