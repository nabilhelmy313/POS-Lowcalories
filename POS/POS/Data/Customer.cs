using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Photo { get; set; }
        public string Note { get; set; }
        public ICollection<Address> Addresses { get; set; }

    }
}
