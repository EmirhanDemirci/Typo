using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Typo.Models
{
    public class Profile
    {
        public int ProfileID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
