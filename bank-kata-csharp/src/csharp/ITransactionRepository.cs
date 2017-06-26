using System;
using System.Collections.Generic;
using com.finix.kata.bankkata;

namespace com.finix.kata.bankkata
{
    public interface ITransactionRepository
    {
        void depositTransaction(double amount);
        void withdrawTransaction(double v);
        List<ITransaction> AllTransactions();
    }
}
