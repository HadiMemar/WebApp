using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Common.Base
{
    public class BaseEntity
    {
        [MaxLength(100)]
        public virtual string CreatedBy { get; set; }

        [MaxLength(100)]
        public virtual string ModifiedBy { get; set; }

        public virtual DateTime? CreatedDate { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }
    }
}
