﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.BusinessObjects
{
    public class ItemTypeBO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Name { get; set; }
    }
}
