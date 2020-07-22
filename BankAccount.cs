using System;
using System.Collections.Generic;

namespace classes
{
    public class BankAccount
    {
        private static int NextAccountNumber = 1;
        private List<Transaction> AllTransactions = new List<Transaction>();
        public int Number {get;}
        public string Owner {get;set;}
        public double Balance
        {
            get
            {
                double balance = 0;
                foreach(var transaction in this.AllTransactions)
                {
                    balance += transaction.Amount;
                }
                return balance;
            }
        }

        public BankAccount(string name, double initialBalance)
        {
            this.Owner = name;
            this.Number = NextAccountNumber;
            NextAccountNumber++;

            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
        }
        public void MakeDeposit(double amount, DateTime time, String note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit can not be less than zero.");
            }
            var deposit = new Transaction(amount, note, time);
            AllTransactions.Add(deposit);
        }
        

        public void MakeWithdrawal(double amount, DateTime time, string note)
        {
            if(amount <= 0)
            {
                throw(new ArgumentOutOfRangeException(nameof(amount), "Can not witdraw not positive amount"));
            }

            if (Balance - amount < 0)
            {
                throw(new InvalidOperationException("Not enouph founds to perform withdrawal"));
            }
            var withdrawal = new Transaction(-amount, note, time);
            AllTransactions.Add(withdrawal);
        }

        public string GetAccountHistory ()
        {
            var report = new System.Text.StringBuilder();
            report.Append("Date\tAmount\tNote\n");

            foreach(var transaction in AllTransactions)
            {
                report.Append($"{transaction.Date.ToString()}\t{transaction.Amount.ToString()}\t{transaction.Note}\n");
            }
            return report.ToString();
        }
    }
}