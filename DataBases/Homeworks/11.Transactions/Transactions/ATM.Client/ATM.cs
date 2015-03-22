using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Models;
using System.Data.Entity;
using ATM.Data.Migrations;
using System.Transactions;

namespace ATM.Client
{
    class ATM
    {
        static void Main(string[] args)
        {
            using (var db = new ATMContext())
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATMContext, Configuration>());

                Console.WriteLine("What is your card number: ");
                string cardNumber = Console.ReadLine();

                 Console.WriteLine("What is your card pin: ");
                string cardPin = Console.ReadLine();

                Console.WriteLine("How much money to withdraw: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                Withdraw(cardNumber, cardPin, amount);
            }
        }


        static void Withdraw(string cardNumber, string cardPin, decimal amount)
        {
            using (var db = new ATMContext())
            {
                using (var scope = new TransactionScope(
                       TransactionScopeOption.RequiresNew,
                       new TransactionOptions()
                       {
                           IsolationLevel = IsolationLevel.RepeatableRead
                       }
                   ))
                {
                    var cardAccount = db.CardAccount.Where(x => x.CardNumber == cardNumber && x.CardPIN == cardPin).FirstOrDefault();

                    if (cardAccount != null)
                    {
                        if (cardAccount.CardCash >= amount)
                        {

                            SaveWithdraw(cardAccount, amount, db);

                            Console.WriteLine("Withdraw was successful!");
                        }
                        else
                        {
                            Console.WriteLine("You have {0:0.00} which is not enough for the withdraw you want!", cardAccount.CardCash);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong card number or PIN!");
                    }

                    scope.Complete();
                }
            }
        }

        static void SaveWithdraw(CardAccount cardAccount, decimal amount, ATMContext db)
        {
            cardAccount.CardCash -= amount;

            db.TransactionHistory.Add(new TransactionHistory() { CardNumber = cardAccount.CardNumber, Amount = amount });

            db.SaveChanges();
        }
    }
}
