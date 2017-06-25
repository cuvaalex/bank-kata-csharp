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
            var transactionMoq = new Mock<ITransactionRepository>();
            var account = new Account(transactionMoq.Object);

            account.printStatement();

            consoleMoq.Verify(console => console.print("date || credit || debit || balance"));
            consoleMoq.Verify(console => console.print("14 / 01 / 2012 ||          || 500.00 || 2500.00"));
            consoleMoq.Verify(console => console.print("13 / 01 / 2012 || 2000.00 ||          || 3000.00"));
            consoleMoq.Verify(console => console.print("10 / 01 / 2012 || 1000.00 ||          || 1000.00"));

		}
    }
}
