using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApp.Common.Base
{
    public class BaseDbContext : DbContext
    {
        #region Constructors
        public BaseDbContext(DbContextOptions options) : base(options)
        { 
        }
        #endregion
    }


}
