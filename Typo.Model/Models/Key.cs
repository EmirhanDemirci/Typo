using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typo.Model.Models
{
    public class Key
    {
        public int LicenseId { get; set; }
        public int UserId { get; set; }
        public string LicenseKey { get; set; }
        public DateTime LicenseDate { get; set; }

    }
}
