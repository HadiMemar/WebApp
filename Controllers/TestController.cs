using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Domain.Models;
using WebApp.Domain.Models.CompundTransactions;
using WebApp.Domain.Models.Gateways;
using WebApp.Infrastructure;
using WebApp.Infrastructure.UnitOfWork;

namespace WebApp.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        #region Constructor
        private readonly IUnitOfWork _unitOfWork;

        public TestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        [HttpGet("onPoItems")]
        public IActionResult GatewayUpdate2()
        {
            Gateway gateway = new HubOnHandGateway(1);
            gateway._unitOfWork = _unitOfWork;
            gateway.GetTargetObjectAndUpdate(1, 2);

            return Ok(gateway);
        }
        [HttpGet("compound")]
        public IActionResult compound()
        {
            List<ItemEntry> entries = new List<ItemEntry>
            {
                new ItemEntry{Id=1,ItemId=1,Qty=1,Price=10}
            };
            PO t = new PO(_unitOfWork);

            t.TargetId = 1;
            t.Direction = true;
            t.Entries = entries;
            t.Post();
            return Ok(t.Total);
        }


    }
}
