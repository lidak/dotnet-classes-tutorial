using System;

namespace classes {
    public class Transaction {
        public double Amount {get;}
        public string Note {get;}
        public DateTime Date {get;}

        public Transaction(double amount, string note, DateTime date)
        {
            this.Amount = amount;
            this.Note = note;
            this.Date  = date;
        }
    }
}