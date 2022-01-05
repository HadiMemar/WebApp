using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Domain.Models.CompundTransactions;
using WebApp.Infrastructure;
using WebApp.Infrastructure.UnitOfWork;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public POsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetPOs()
        {
            var results = _unitOfWork.POs.GetAll();
            return Ok(results);

        }
        [HttpGet("{id}")]
        public IActionResult GetPOById(int id)
        {
            var result = _unitOfWork.POs.GetPODetails(id);
            return Ok(result);

        }
        [HttpPost]
        public IActionResult AddPO([FromBody] PO trans)
        {
            var result = _unitOfWork.POs.Add(trans);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult EditPO(int id, [FromBody] PO trans)
        {
            if (trans.Id == 0)
            {
                trans.Id = id;
            }
            if (id != trans.Id)
            {
                return BadRequest();
            }
            _unitOfWork.POs.Update(trans);
            var result = _unitOfWork.POs.Update(trans);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePO(int id)
        {
            var result = _unitOfWork.POs.Remove(id);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpGet("{id}/post")]
        public IActionResult PostPO(int id)
        {
            PO po = new PO(_unitOfWork);
            _unitOfWork.POs.Post(po, id);
            return Ok();

        }
        //[HttpGet("{id}/total")]
        //public IActionResult GetTotalPO(int id)
        //{
        //    _unitOfWork.POs.GetTotal(id);
        //    return Ok();

        //}
    }
}
