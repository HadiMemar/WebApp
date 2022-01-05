using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Models;
using WebApp.Infrastructure.UnitOfWork;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetTransactions()
        {
            var results = _unitOfWork.Transactions.GetAll();
            return Ok(results);

        }
        [HttpGet("{id}")]
        public IActionResult GetTransactionById(int id)
        {
            var result = _unitOfWork.Transactions.GetById(id);
            return Ok(result);

        }
        [HttpPost]
        public IActionResult AddTransaction([FromBody] Transaction transaction)
        {
            var result = _unitOfWork.Transactions.Add(transaction);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult EditTransaction(int id, [FromBody] Transaction transaction)
        {
            if (transaction.Id == 0)
            {
                transaction.Id = id;
            }
            if (id != transaction.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Transactions.Update(transaction);
            var result = _unitOfWork.Transactions.Update(transaction);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTranscation(int id)
        {
            var result = _unitOfWork.Transactions.Remove(id);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpGet("{id}/postTrans")]
        public IActionResult ApplyTrans(int id)
        {
            Transaction t = _unitOfWork.Transactions.GetTransById(id);
            if (t != null)
            {
                Gateway g = new Gateway(_unitOfWork);
                g.GatewayId = t.Gateway.GatewayId;
                g.Attribute = t.Gateway.Attribute;
                g.Type = t.Gateway.Type;
                t.Gateway = g;
                t.Post();
            }

            return Ok();
        }
    }
}
