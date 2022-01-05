using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Models;
using WebApp.Interfaces.Repository;

namespace WebApp.Infrastructure.Repositories
{
    public class TargetRepo : ITargetRepo
    {
        protected readonly AppDbContext _context;
        public TargetRepo(AppDbContext context)
        {
            this._context = context;
        }

        public Target GetTarget(string tableName, int id)
        {
            var target = (Target)this._context.GetTable(tableName).Find(id);
            if (target != null)
            {

                return target;
            }
            return null;
        }
        //public Target GetTarget(string tableName, int id, int hubId)
        //{
        //    var target = (Target)_context.Items.AsNoTracking().Where(i => i.HubId == hubId).FirstOrDefault();

        //    if (target != null)
        //    {

        //        return target;
        //    }
        //    return null;
        //}

        public void UpdateTarget(string tableName, Target tar)
        {
            _context.Entry(tar).State = EntityState.Modified;
            _context.SaveChanges();

        }
    }
}
