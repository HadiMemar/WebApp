using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Domain.Models
{
    public class Hub
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
    }
}
