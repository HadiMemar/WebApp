using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Models;
using WebApp.Infrastructure;

namespace WebApp.Services.Repository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}
