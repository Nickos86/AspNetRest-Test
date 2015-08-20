using System;
using NUnit.Framework;
using MoneyBox.Core;
using System.Collections.Generic;
using MoneyBox.Api.Controllers;
using Moq;
using System.Web.Http.Results;
using System.Web.Http;
using System.Linq;
using MoneyBox.Data.Simulation;

namespace MoneyBox.Api.Tests
{
    [TestFixture]
    public class TransactionsControllerTests
    {
        [Test]
        public void Get_ReturnsListOfTransactions()
        {
            TransactionRepository repo = new TransactionRepository();
            var transactionController = new TransactionsController(repo);

            IHttpActionResult result = transactionController.Get();

            Assert.That(result, Is.TypeOf<OkNegotiatedContentResult<IEnumerable<Transaction>>>());

            var okResult = result as OkNegotiatedContentResult<IEnumerable<Transaction>>;
            Assert.That(repo.Get().Count(), Is.EqualTo(okResult.Content.Count()));
        }

        [Test]
        public void Get_ShouldReturnCorrectTransaction()
        {
            var mockRepository = new Mock<ITransactionRepository>();
            var expected = new Transaction() { TransactionId = 4};
            mockRepository
                .Setup(x => x.Get(It.IsAny<long>()))
                .Returns(expected);

            var transactionController = new TransactionsController(mockRepository.Object);

            IHttpActionResult result = transactionController.Get(4);

            mockRepository.VerifyAll();
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<OkNegotiatedContentResult<Transaction>>());

            var okResult = result as OkNegotiatedContentResult<Transaction>;
            Assert.AreEqual(expected.TransactionId, okResult.Content.TransactionId);
        }

        [Test]
        public void Get_ShouldNotFindTransaction()
        {
            TransactionRepository repo = new TransactionRepository();
            var transactionController = new TransactionsController(repo);

            var result = transactionController.Get(-1);

            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public void TransactionApi_Post_SaveIsCalled()
        {
            var mockRepository = new Mock<ITransactionRepository>();

            var transactionController = new TransactionsController(mockRepository.Object);

            transactionController.Post(new Transaction());

            mockRepository.Verify(x => x.Save(It.IsAny<Transaction>()));
        }

        [Test]
        public void TransactionApi_Put_UpdateIsCalled()
        {
            var mockRepository = new Mock<ITransactionRepository>();

            var transactionController = new TransactionsController(mockRepository.Object);

            transactionController.Put(1, new Transaction());

            mockRepository.Verify(x => x.Update(It.IsAny<Transaction>()));
        }

        [Test]
        public void TransactionApi_Delete_DeleteIsCalled()
        {
            var mockRepository = new Mock<ITransactionRepository>();

            var transactionController = new TransactionsController(mockRepository.Object);

            transactionController.Delete(1);

            mockRepository.Verify(x => x.Delete(It.IsAny<long>()));
        }
    }
}
