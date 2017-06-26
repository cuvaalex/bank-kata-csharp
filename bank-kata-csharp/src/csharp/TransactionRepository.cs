using System;
using System.Collections.Generic;

namespace com.finix.kata.bankkata
{
    public class TransactionRepository: ITransactionRepository
    {
        private List<ITransaction> transactions;
        private IClock clock;

        public TransactionRepository(IClock clock, List<ITransaction> transactions)
        {
            this.clock = clock;
            this.transactions = transactions;
        }

        public List<ITransaction> AllTransactions()
        {
            return this.transactions;
        }

        public void depositTransaction(double amount)
        {
            AllTransactions().Add(new Transaction(date: clock.todayToString(), amount: amount));
        }

        public void withdrawTransaction(double amount)
        {
            AllTransactions().Add(new Transaction(date: clock.todayToString(), amount: -amount));
        }
    }
}
