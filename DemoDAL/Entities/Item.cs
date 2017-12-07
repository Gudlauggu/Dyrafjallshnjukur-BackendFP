using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
     public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ITypeId { get; set; }
        public ItemType IType { get; set; }

        public List<PubItem> PubItems { get; set; }
    }
}
