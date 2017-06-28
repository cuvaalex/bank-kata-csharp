using NUnit.Framework;
using System;
using System.Collections.Generic;
using NFluent;
using Moq;
namespace com.finix.kata.bankkata
{
    [TestFixture()]
    public class TransactionRepositoryShould
    {
        const string TODAY = "25/05/2017";
        Mock<IClock> clockMoq;
        List<ITransaction> transactions = new List<ITransaction>();
        TransactionRepository repository;

        [SetUp]
        public void Init() {
			clockMoq = new Mock<IClock>();
			clockMoq.Setup(clock => clock.TodayToString()).Returns(TODAY);
			repository = new TransactionRepository(clockMoq.Object);    
        }

        [Test()]
        public void Should_store_a_deposit_transaction()
        {
            repository.depositTransaction(100);
            var result = repository.AllTransactions();

            Check.That(result).HasSize(1);
            Check.That(result[0]).IsEqualTo(Transaction(TODAY, 100));
        }
		[Test()]
		public void Should_store_a_withdraw_transaction()
		{
            repository.withdrawTransaction(100);
			var result = repository.AllTransactions();

			Check.That(result).HasSize(1);
            Check.That(result[0]).IsEqualTo(Transaction(TODAY, -100));
		}

        internal ITransaction Transaction(string date, double amount){
            return new Transaction(date: date, amount: amount);
        }
    }
}
