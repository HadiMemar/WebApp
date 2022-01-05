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
    public class ItemEntryRepo : GenericRepository<ItemEntry>, IItemEntryRepo
    {
        public ItemEntryRepo(AppDbContext context) : base(context)
        {
        }
        public ItemEntry GetItemEntryDetail(int id)
        {
            var result = this._context.Set<ItemEntry>().Where(i => i.Id == id).Include(i => i.Item).AsNoTracking().FirstOrDefault();
            if (result == null)
            {
                throw new NotFoundException("Item not found", "403");
            }
            return result;
        }
    }
}
