using System;
using classes;

namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Oleksandr Lidak", 20.00);
            Console.WriteLine($"New account created. The balance is {account.Balance}. The owner is {account.Owner}. Account number is {account.Number}");
            account.MakeDeposit(100.00, DateTime.Now, "My first savings");
            account.MakeDeposit(40.00, DateTime.Now, "Sent from the lender.");

            Console.WriteLine(account.Balance.ToString());

            account.MakeWithdrawal(20, DateTime.Now, "Buying a book.");
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.GetAccountHistory());
        }
    }
}
