using System;

namespace com.finix.kata.bankkata
{
    public class Transaction : ITransaction
    {
        private string date;
        private double amount;

        public Transaction(string date, double amount)
        {
            this.date = date;
            this.amount = amount;
        }

        public double Amount {
            get{
                return amount;
            }
        }

        public string Date {
            get {
                return date;
            }
        }
    }
}