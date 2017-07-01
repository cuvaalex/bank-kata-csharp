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

        public void Deposit(double amount)
        {
            @transaction.depositTransaction(amount);
        }

        public void Withdraw(double amount)
        {
            @transaction.withdrawTransaction(amount);
        }

        public void PrintStatement()
        {
            var transactions = this.@transaction.AllTransactions();
            this.@printer.print(transactions);

        }
    }
}
