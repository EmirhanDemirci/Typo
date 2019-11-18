﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Typo.Models
{
    public class Account
    {
        public int userId { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
