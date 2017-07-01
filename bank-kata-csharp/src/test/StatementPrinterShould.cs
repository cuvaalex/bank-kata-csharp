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
		Mock<IConsole> consoleMoq;

        [SetUp]
        public void Initialisation() {
            consoleMoq = new Mock<IConsole>();    
        }

		[Test()]
        public void Should_always_print_header()
        {
            
            var statement = new StatementPrinter(consoleMoq.Object);

            statement.print(NO_TRANSACTIONS);

            consoleMoq.Verify(console => console.print("date || credit || debit || balance"));

        }

        [Test()]
        public void Should_always_print_statement_in_reverse_order() {
			var statement = new StatementPrinter(consoleMoq.Object);

            List<ITransaction> transactions = transactionContaining(
                deposit("10/01/2012", 1000.00),
                deposit("13/01/2012", 2000.00),
                withdraw("14/01/2012", 500.00));

            statement.print(transactions);

			consoleMoq.Verify(console => console.print("date || credit || debit || balance"));
			consoleMoq.Verify(console => console.print("14/01/2012 ||  || 500.00 || 2,500.00"));
			consoleMoq.Verify(console => console.print("13/01/2012 || 2,000.00 ||  || 3,000.00"));
			consoleMoq.Verify(console => console.print("10/01/2012 || 1,000.00 ||  || 1,000.00"));

		}

        private ITransaction withdraw(string date, double amount)
        {
            return new Transaction(date, -amount);
        }

        private ITransaction deposit(string date, double amount)
        {
            return new Transaction(date, amount);
        }

        private List<ITransaction> transactionContaining(params ITransaction[] transactions)
        {
            return new List<ITransaction>(transactions);
        }
    }
}
