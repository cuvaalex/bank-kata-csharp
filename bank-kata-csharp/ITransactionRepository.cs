using System;
using com.finix.kata.bankkata.test;

namespace com.finix.kata.bankkata
{
    public interface ITransactionRepository
    {
        void depositTransaction(double amount);
        void withdrawTransaction(double v);
        ITransaction[] AllTransactions();
    }
}
