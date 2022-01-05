using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Domain.Models.Gateways
{
    public class HubOnSOGateway : HubGateway
    {
        public HubOnSOGateway(int hubId) : base(hubId,"Customers", "OnSO")
        {
        }
    }
}
