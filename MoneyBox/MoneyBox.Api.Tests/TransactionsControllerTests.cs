using System;
using NUnit.Framework;

namespace MoneyBox.Api.Tests
{
    [TestFixture]
    public class TransactionsControllerTests
    {
        [Test]
        public void Get_CallGet_ReturnsListOfTransactions()
        {
            var mockRepository = new Mock<ITransactionRepository>();
            var transactionController = new TransactionsController(mockRepository.Object);

            var transactions = transactionController.Get();

            Assert.That(transactions.length, Is.GreaterThan(0));
        }
    }
}
