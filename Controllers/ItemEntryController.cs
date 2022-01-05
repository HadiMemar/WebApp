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
    public class ItemEntryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemEntryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetItemEntries()
        {
            var results = _unitOfWork.ItemEntries.GetAll();
            return Ok(results);

        }
        [HttpGet("{id}")]
        public IActionResult GetItemEntryById(int id)
        {
            var result = _unitOfWork.ItemEntries.GetItemEntryDetail(id);
            return Ok(result);

        }
        [HttpPost]
        public IActionResult AddItemEntry([FromBody] ItemEntry item)
        {
            var result = _unitOfWork.ItemEntries.Add(item);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult EditItemEntry(int id, [FromBody] ItemEntry item)
        {
            if (item.Id == 0)
            {
                item.Id = id;
            }
            if (id != item.Id)
            {
                return BadRequest();
            }
            _unitOfWork.ItemEntries.Update(item);
            var result = _unitOfWork.ItemEntries.Update(item);
            _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteItemEntry(int id)
        {
            var result = _unitOfWork.ItemEntries.Remove(id);
            _unitOfWork.Complete();
            return Ok(result);
        }
    }
}
