﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }
    }
}
