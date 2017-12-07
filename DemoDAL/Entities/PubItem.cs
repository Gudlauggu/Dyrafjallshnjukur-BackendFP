using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class PubItem
    {
        public int PubId { get; set; }
        public Pub Pub { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
