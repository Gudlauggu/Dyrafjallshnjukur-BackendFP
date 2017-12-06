using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.BusinessObjects
{
    public class ItemBO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Name { get; set; }

        public int ItemTypeId { get; set; }
        public ItemTypeBO ItemType { get; set; }
    }
}
