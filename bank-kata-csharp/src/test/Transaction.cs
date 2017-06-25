namespace com.finix.kata.bankkata.test
{
    internal class Transaction : ITransaction
    {
        private string date;
        private double amount;

        public Transaction(string date, double amount)
        {
            this.date = date;
            this.amount = amount;
        }
    }
}