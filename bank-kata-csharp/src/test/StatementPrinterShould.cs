using NUnit.Framework;
using System;
using Moq;
using System.Collections.Generic;

namespace com.finix.kata.bankkata
{
    [TestFixture()]
    public class StatementPrinterShould
    {
        private List<ITransaction> NO_TRANSACTIONS = new List<ITransaction>();

        [Test()]
        public void Should_always_print_header()
        {
            var consoleMoq = new Mock<IConsole>();
            var statement = new StatementPrinter(consoleMoq.Object);


            statement.print(NO_TRANSACTIONS);

            consoleMoq.Verify(console => console.print("date || credit || debit || balance"));

        }
    }
}
