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

            account.printStatement();

            consoleMoq.Verify(console => console.print("date || credit || debit || balance"));
            consoleMoq.Verify(console => console.print("14/01/2012 ||          || 500.00 || 2500.00"));
            consoleMoq.Verify(console => console.print("13/01/2012 || 2000.00 ||          || 3000.00"));
            consoleMoq.Verify(console => console.print("10/01/2012 || 1000.00 ||          || 1000.00"));

		}
    }
}
