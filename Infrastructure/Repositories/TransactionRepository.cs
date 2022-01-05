using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Common.Exceptions;
using WebApp.Domain.Models;
using WebApp.Interfaces.Repository;

namespace WebApp.Infrastructure.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context) : base(context)
        {
        }
        public Transaction GetTransById(int id)
        {
            var result = this._context.Set<Transaction>().Where(t => t.Id == id).Include(t => t.Gateway).AsNoTracking().FirstOrDefault();
            if (result == null)
            {
                throw new NotFoundException("Trans not found", "403");
            }
            return result;
        }

    }
}
