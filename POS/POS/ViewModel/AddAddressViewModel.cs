using POS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class AddAddressViewModel
    {
        public IEnumerable<Zoon> Zoons { get; set; }
        [Required]
        public string CustPhone { get; set; }
        public Address Address { get; set; }
        public string Floor { get; set; }
        [Required]
        public string Street { get; set; }
        public string Flat { get; set; }
        public string Landmark { get; set; }
    }
}
