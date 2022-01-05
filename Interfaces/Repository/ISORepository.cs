using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Models.CompundTransactions;
using WebApp.Infrastructure;

namespace WebApp.Interfaces.Repository
{
    public interface ISORepository : IGenericRepository<SO>
    {
        bool Post(SO so, int id);
    }
}
