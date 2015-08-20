using FizzWare.NBuilder;
using FizzWare.NBuilder.Generators;
using MoneyBox.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBox.Data.Simulation
{
    public class TransactionRepository : ITransactionRepository
    {
        private IList<Transaction> _transactions;

        public TransactionRepository()
        {
            _transactions = new List<Transaction>();

            //var transaction = new Transaction
            //{
            //    TransactionId = 4,
            //    CreatedDate = GetRandom.DateTimeFrom(DateTime.Now.AddMonths(-01)),
            //    CurrencyCode = "en-GB",
            //    Description = "Telsa",
            //    TransactionAmount = 275000,
            //    TransactionDate = GetRandom.DateTimeFrom(DateTime.Now.AddMonths(-1)),
            //    Merchant = "Telsa",
            //    ModifiedDate = GetRandom.DateTimeFrom(DateTime.Now.AddMonths(-01))
            //};

            _transactions = Builder<Transaction>.CreateListOfSize(50)
                .All()
                    .With(x => x.TransactionId = GetRandom.Long(_transactions.Count(), 10000))
                    .With(x => x.CreatedDate = GetRandom.DateTimeFrom(DateTime.Now.AddMonths(-01)))
                    .With(x => x.CurrencyCode = "en-GB")
                    .With(x => x.Description = "Lamborghini")
                    .With(x => x.TransactionAmount = 275000)
                    .With(x => x.TransactionDate = GetRandom.DateTimeFrom(DateTime.Now.AddMonths(-1)))
                    .With(x => x.Merchant = "Lamborghini")
                    .With(x => x.ModifiedDate = GetRandom.DateTimeFrom(DateTime.Now.AddMonths(-01)))
                .Build();
        }

        public IEnumerable<Transaction> Get()
        {
            return _transactions;
        }

        public Transaction Get(long id)
        {
            return _transactions.FirstOrDefault(x => x.TransactionId == id);
        }

        public void Save(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public void Update(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}

