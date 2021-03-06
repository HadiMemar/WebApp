using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Models.CompundTransactions;
using WebApp.Infrastructure;

namespace WebApp.Interfaces.Repository
{
    public interface IPORepository : IGenericRepository<PO>
    {
        PO Post(PO po,int id);
        PO GetPODetails(int id);
    }
}
