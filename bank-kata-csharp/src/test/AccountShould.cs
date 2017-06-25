﻿using NUnit.Framework;
using System;
using Moq;
using com.finix.kata.bankkata;

namespace com.finix.kata.bankkata.test
{
    [TestFixture()]
    public class AccountShould
    {
        [Test()]
        public void should_store_deposit()
        {
            var transactionMoq = new Mock<ITransactionRepository>();
            var account = new Account(transactionMoq.Object);

            account.deposit(100.00);

            transactionMoq.Verify(transaction => transaction.depositTransaction(100), Times.Once());
        }
        [Test()]
        public void should_store_withdraw()
        {
            var transactionMoq = new Mock<ITransactionRepository>();
            var account = new Account(transactionMoq.Object);

            account.withdraw(100.00);

            transactionMoq.Verify(transaction => transaction.withdrawTransaction(100), Times.Once());
        }

        [Test()]
        public void should_print_statement()
        {
            var transactions = new ITransaction[] { new Transaction("25/12/2017", 100) { } };
            var transactionMoq = new Mock<ITransactionRepository>();
            transactionMoq.Setup(transaction => transaction.AllTransactions()).Returns(transactions);
            var statementMoq = new Mock<IStatementPrinter>();


            var account = new Account(transactionMoq.Object, statementMoq.Object);

            account.printStatement();

            transactionMoq.Verify(transaction 
                                  => transaction.AllTransactions());
            statementMoq.Verify(statement 
                                => statement.print(transactions));
        }
    }
}
