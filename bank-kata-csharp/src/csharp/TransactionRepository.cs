using System;
using System.Collections.Generic;

namespace com.finix.kata.bankkata
{
    public class TransactionRepository: ITransactionRepository
    {
        private List<ITransaction> transactions = new List<ITransaction>();
        private IClock clock;

        public TransactionRepository(IClock clock)
        {
            this.clock = clock;
        }

        public List<ITransaction> AllTransactions()
        {
            return this.transactions;
        }

        public void depositTransaction(double amount)
        {
            AllTransactions().Add(new Transaction(date: clock.TodayToString(), amount: amount));
        }

        public void withdrawTransaction(double amount)
        {
            AllTransactions().Add(new Transaction(date: clock.TodayToString(), amount: -amount));
        }
    }
}
