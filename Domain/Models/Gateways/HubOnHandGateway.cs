using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Domain.Models.Gateways
{
    public class HubOnHandGateway:HubGateway
    {
        public HubOnHandGateway() : base("Items", "OnHand")
        {
        }
        public HubOnHandGateway(int id):base(id,"Items", "OnHand")
        {
        }
        
    }
    
}
