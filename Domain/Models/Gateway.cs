using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Infrastructure;
using WebApp.Infrastructure.UnitOfWork;
using WebApp.Services;

namespace WebApp.Domain.Models
{
    public partial class Gateway
    {
        [Key]
        public int GatewayId { get; set; }
        public virtual string Type { get; set; }
        public virtual string Attribute { get; set; }

    }
    public partial class Gateway
    {
        [NotMapped]
        public  IUnitOfWork _unitOfWork;
        public Gateway()
        {

        }
        public Gateway(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public virtual bool GetTargetObjectAndUpdate(int targetId, double quantity)
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
