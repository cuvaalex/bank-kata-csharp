using NUnit.Framework;
using System;
using System.Collections.Generic;
using NFluent;
using Moq;
namespace com.finix.kata.bankkata.src.test
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
			clockMoq.Setup(clock => clock.todayToString()).Returns(TODAY);
			transactions = new List<ITransaction>();
			repository = new TransactionRepository(clockMoq.Object, transactions);    
        }

        [Test()]
        public void Should_store_a_deposit_transaction()
        {
            repository.depositTransaction(100);
            var result = repository.AllTransactions();

            Check.That(result).HasSize(1);
            Check.That(result[0].Amount).IsEqualTo(100);
        }
		[Test()]
		public void Should_store_a_withdraw_transaction()
		{
            repository.withdrawTransaction(100);
			var result = repository.AllTransactions();

			Check.That(result).HasSize(1);
			Check.That(result[0].Amount).IsEqualTo(-100);
		}
    }
}
