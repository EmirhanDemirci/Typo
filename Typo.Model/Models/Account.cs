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
        public int UserId { get; set; }
        [Required]
        public string MailUser { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string LicenseKey { get; set; }
        [Required]
        public DateTime LicenseDate { get; set; }
    }
}


