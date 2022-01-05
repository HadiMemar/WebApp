using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Domain.Models.Gateways
{
    public class HubOnPoGateway:HubGateway
    {
        public HubOnPoGateway(int hubId):base(hubId,"Items", "OnPO")
        {
        }
    }
}
