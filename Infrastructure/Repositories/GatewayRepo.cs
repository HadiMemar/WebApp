using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Models;
using WebApp.Interfaces.Repository;

namespace WebApp.Infrastructure.Repositories
{
    public class GatewayRepo : GenericRepository<Gateway>, IGatewayRepo
    {
        public GatewayRepo(AppDbContext context) : base(context)
        {
        }
    }
}
