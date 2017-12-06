using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int OrderPrice { get; set; }
        public string Supplier { get; set; }

        public int PubId { get; set; }
        public Pub Pub { get; set; }
    }
}
