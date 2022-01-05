using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Models;
using WebApp.Infrastructure;

namespace WebApp.Interfaces.Repository
{
    public interface ITargetRepo
    {
        public Target GetTarget(string tableName, int id);
        //public Target GetTarget(string tableName, int id,int hubId);
        void UpdateTarget(string type, Target tar);
    }
}
