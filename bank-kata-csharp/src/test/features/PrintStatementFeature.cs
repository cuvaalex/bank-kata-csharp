﻿using NUnit.Framework;
using System;
using Moq;

namespace com.finix.kata.bankkata.feature
{
    [TestFixture()]
    public class PrintStatementFeature
    {
        [Test()]
        public void Should_print_statement()
        {
            var consoleMoq = new Moq.Mock<IConsole>();
            var clockMoq = new Mock<IClock>();
            clockMoq.SetupSequence(clock => clock.TodayToString())
                    .Returns("10/01/2012")
                    .Returns("13/01/2012")
                    .Returns("14/01/2012");
            var repository = new TransactionRepository(clockMoq.Object);
            var statement = new StatementPrinter(consoleMoq.Object);
            var account = new Account(repository, statement);

            account.Deposit(1000);
            account.Deposit(2000);
            account.Withdraw(500);
            account.PrintStatement();

            consoleMoq.Verify(console => console.print("date || credit || debit || balance"));
            consoleMoq.Verify(console => console.print("14/01/2012 ||  || 500.00 || 2,500.00"));
            consoleMoq.Verify(console => console.print("13/01/2012 || 2,000.00 ||  || 3,000.00"));
            consoleMoq.Verify(console => console.print("10/01/2012 || 1,000.00 ||  || 1,000.00"));

		}
    }
}
