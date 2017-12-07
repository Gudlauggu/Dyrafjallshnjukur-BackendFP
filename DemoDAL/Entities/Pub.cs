using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Pub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<PubItem> PubItems { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
