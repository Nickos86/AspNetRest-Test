using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBox.Core
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> Get();
        Transaction Get(long id);
        void Save(Transaction transaction);
        void Update(Transaction transaction);
        void Delete(long id);
    }
}
