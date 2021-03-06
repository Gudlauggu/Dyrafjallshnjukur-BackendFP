﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessObjects
{
    public class OrderBO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int OrderPrice { get; set; }
        public string Supplier { get; set; }

        public int PubId { get; set; }
        public PubBO Pub { get; set; }

        public List<int> ItemIds { get; set; }
        public List<ItemBO> Items { get; set; }
    }
}
