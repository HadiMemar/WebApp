using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Domain.Models.Gateways
{
    public class HubGateway : Gateway
    {
        public int HubId { get; set; } = 1;
        public Hub Hub { get; set; }
        public HubGateway(int id)
        {
            this.HubId = id;
        }
        public HubGateway(int hubId,string type, string attribute)
        {
            this.HubId = hubId;
            this.Type = type;
            this.Attribute = attribute;
        }
        public HubGateway( string type, string attribute)
        {
            
            this.Type = type;
            this.Attribute = attribute;
        }
        public override bool GetTargetObjectAndUpdate(int targetId, double quantity)
        {
            Target tar = _unitOfWork.Targets.GetTarget(Type, targetId);
            if (tar != null)
            {
                tar.Update(quantity, Attribute);
                _unitOfWork.Targets.UpdateTarget(Type, tar);
            }
            return true;
        }

    }
}
