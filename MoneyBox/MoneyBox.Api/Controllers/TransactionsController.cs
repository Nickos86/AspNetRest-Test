using MoneyBox.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MoneyBox.Api.Controllers
{
    public class TransactionsController : ApiController
    {
        private ITransactionRepository _repository;
        public TransactionsController(ITransactionRepository repository)
        {
            this._repository = repository;
        }

        public IHttpActionResult Get()
        {
            try
            {
                var transactions = _repository.Get();
                return Ok(transactions);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(long id)
        {
            try
            {
                var transaction = _repository.Get(id);

                if (transaction == null)
                {
                    return NotFound();
                }

                return Ok(transaction);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Post([FromBody] Transaction transaction)
        {
            if (transaction == null)
            {
                return BadRequest();
            }

            try
            {
                _repository.Save(transaction);
                return Created<Transaction>(Request.RequestUri
                        + "/" + transaction.TransactionId.ToString(), transaction);

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(int id, [FromBody] Transaction transaction)
        {
            try
            {
                _repository.Update(transaction);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

    }
}