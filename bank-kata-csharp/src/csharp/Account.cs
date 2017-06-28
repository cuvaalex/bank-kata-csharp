﻿using System;
namespace com.finix.kata.bankkata
{
	public class Account
{
        private ITransactionRepository @transaction;
        private IStatementPrinter @printer;


        public Account(ITransactionRepository transaction, IStatementPrinter @printer)
        {
            this.@printer = @printer;
            this.@transaction = transaction;
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
