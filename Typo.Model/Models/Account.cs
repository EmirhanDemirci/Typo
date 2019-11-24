using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typo.Model.Models
{
    
        public class Account
        {
            public static Account Accounts { get; set; }
            public int userId { get; set; }
            [Required]
            public string username { get; set; }
            [Required]
            public string password { get; set; }

        }
    }


