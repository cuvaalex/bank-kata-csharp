using System.Collections.Generic;
using com.finix.kata.bankkata.test;

namespace com.finix.kata.bankkata
{
    public interface IStatementPrinter
    {
        void print(List<ITransaction> transactions);
    }
}