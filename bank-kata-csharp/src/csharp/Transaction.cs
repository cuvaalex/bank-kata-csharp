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

        public override int GetHashCode()
        {
            int hash = 0;
            hash += date.GetHashCode();
            hash += amount.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
			if (obj == null || GetType() != obj.GetType())
				return false;

            Transaction fooItem = obj as Transaction;

            return (fooItem.amount == this.amount) && (fooItem.date == this.date);
        }
    }
}