using Microsoft.AspNetCore.Identity;
using POS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class RegisterVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Branch { get; set; }
        public List<Branch> Branches { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public string RoleId { get; set; }

    }
}