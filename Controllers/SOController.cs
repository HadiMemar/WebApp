using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Models.CompundTransactions;
using WebApp.Infrastructure.UnitOfWork;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SOController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SOController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetSOs()
        {
            var results = _unitOfWork.SOs.GetAll();
            return Ok(results);

        }
        [HttpGet("{id}")]
        public IActionResult GetSOById(int id)
        {
            var result = _unitOfWork.SOs.GetById(id);
            return Ok(result);

        }
        [HttpPost]
        public IActionResult AddSO([FromBody] SO trans)
        {
            var result = _unitOfWork.SOs.Add(trans);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult EditSO(int id, [FromBody] SO trans)
        {
            if (trans.Id == 0)
            {
                trans.Id = id;
            }
            if (id != trans.Id)
            {
                return BadRequest();
            }
            _unitOfWork.SOs.Update(trans);
            var result = _unitOfWork.SOs.Update(trans);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSO(int id)
        {
            var result = _unitOfWork.SOs.Remove(id);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpGet("{id}/post")]
        public IActionResult PostSO(int id)
        {
            SO so = new SO(_unitOfWork);
            _unitOfWork.SOs.Post(so, id);
            return Ok();

        }
    }
}
