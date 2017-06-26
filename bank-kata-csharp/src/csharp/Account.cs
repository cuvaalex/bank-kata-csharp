﻿using System;
namespace com.finix.kata.bankkata
{
	public class Account
{
        private ITransactionRepository @transaction;
        private IStatementPrinter @printer;

        public Account()
    {
    }

        public Account(ITransactionRepository @transaction)
        {
            this.@transaction = @transaction;
        }

        public Account(ITransactionRepository transaction, IStatementPrinter @printer) : this(transaction)
        {
            this.@printer = @printer;
        }

        public void deposit(double amount)
        {
            @transaction.depositTransaction(amount);
        }

        public void withdraw(double amount)
        {
            @transaction.withdrawTransaction(amount);
        }

        public void printStatement()
        {
            var transactions = this.@transaction.AllTransactions();
            this.@printer.print(transactions);

        }
    }
}
