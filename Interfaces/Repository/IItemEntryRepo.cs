using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Models;
using WebApp.Infrastructure;

namespace WebApp.Interfaces.Repository
{
    public interface IItemEntryRepo : IGenericRepository<ItemEntry>
    {
        ItemEntry GetItemEntryDetail(int id);

    }
}
