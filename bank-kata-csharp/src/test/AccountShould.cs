﻿using NUnit.Framework;
using System;
using Moq;
using com.finix.kata.bankkata;
using System.Collections.Generic;

namespace com.finix.kata.bankkata.test
{
    [TestFixture()]
    public class AccountShould
    {
        IStatementPrinter statement;

        [SetUp()]
        public void initialize() {
            var consoleMoq = new Mock<IConsole>();
            statement = new StatementPrinter(consoleMoq.Object);
        }

        [Test()]
        public void should_store_deposit()
        {

            var transactionMoq = new Mock<ITransactionRepository>();
            var account = new Account(transactionMoq.Object, statement);

            account.deposit(100.00);

            transactionMoq.Verify(transaction => transaction.depositTransaction(100), Times.Once());
        }
        [Test()]
        public void should_store_withdraw()
        {
            var repositoryMoq = new Mock<ITransactionRepository>();
            var account = new Account(repositoryMoq.Object, statement);

            account.withdraw(100.00);

            repositoryMoq.Verify(repository => repository.withdrawTransaction(100), Times.Once());
        }

        [Test()]
        public void should_print_statement()
        {
            var transactions = new List<ITransaction>(new Transaction[] { new Transaction("25/12/2017", 100) });
            var repositoryMoq = new Mock<ITransactionRepository>();
            repositoryMoq.Setup(repository => repository.AllTransactions()).Returns(transactions);
            var statementMoq = new Mock<IStatementPrinter>();


            var account = new Account(repositoryMoq.Object, statementMoq.Object);

            account.printStatement();

            repositoryMoq.Verify(transaction 
                                  => transaction.AllTransactions());
            statementMoq.Verify(statement 
                                => statement.print(transactions));
        }
    }
}
