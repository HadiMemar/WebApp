using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Common.Exceptions;
using WebApp.Domain.Models.CompundTransactions;
using WebApp.Interfaces.Repository;

namespace WebApp.Infrastructure.Repositories
{
    public class PORepository : GenericRepository<PO>, IPORepository
    {
        public PORepository(AppDbContext context) : base(context)
        {

        }

        public PO GetPODetails(int id)
        {
            var result = this._context.POs.AsNoTracking().Where(p => p.Id == id).Include(p => p.Entries).SingleOrDefault();
            if (result == null)
            {
                throw new NotFoundException("Po transaction not found", "403");
            }
            return result;
        }

        public bool Post(PO po, int id)
        {
            var result = _context.POs.AsNoTracking().Where(p => p.Id == id).Include(p => p.Entries).SingleOrDefault();
            if (result == null)
            {
                throw new NotFoundException("Po transaction not found", "403");
            }
            po.Id = result.Id;
            po.TargetId = result.TargetId;
            po.Entries = result.Entries;
            po.Total = result.Total;
            po.Direction = result.Direction;
            po.Post();
            return true;
        }
    }
}
