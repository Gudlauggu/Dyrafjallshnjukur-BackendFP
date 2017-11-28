using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.BusinessObjects
{
    public class SupplierBO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MaxLength(35)]
        [MinLength(5)]
        public string Address { get; set; }

        [Required]
        [MaxLength(8)]
        [MinLength(8)]
        [Phone]
        public int PhoneNumber { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
