using System;

namespace com.finix.kata.bankkata
{
    public class Transaction : ITransaction
    {
        private string date;
        private double amount;

        public string Date { get => date; set => date = value; }
        public double Amount { get => amount; set => amount = value; }

        public Transaction(string date, double amount)
        {
            this.Date = date;
            this.Amount = amount;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            hash += Date.GetHashCode();
            hash += Amount.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Transaction fooItem = obj as Transaction;

            return (fooItem.Amount == this.Amount) && (fooItem.Date == this.Date);
        }
    }
}