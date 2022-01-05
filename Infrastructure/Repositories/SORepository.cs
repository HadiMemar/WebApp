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
    public class SORepository : GenericRepository<SO>, ISORepository
    {
        public SORepository(AppDbContext context) : base(context)
        {

        }
        public bool Post(SO so, int id)
        {
            var result = _context.Sos.AsNoTracking().Where(s => s.Id == id).Include(s => s.Entries).SingleOrDefault();
            if (result == null)
            {
                throw new NotFoundException("Po transaction not found", "403");
            }
            so.Id = result.Id;
            so.TargetId = result.TargetId;
            so.Entries = result.Entries;
            so.Total = result.Total;
            so.Direction = result.Direction;
            so.Post();
            return true;
        }
    }
}
