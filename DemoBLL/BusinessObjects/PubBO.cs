using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.BusinessObjects
{
    public class PubBO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Address { get; set; }

        public List<OrderBO> Orders { get; set; }

        public List<int> ItemIds { get; set; }
        public List<ItemBO> Items { get; set; }
    }
}
