using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string Branch { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
