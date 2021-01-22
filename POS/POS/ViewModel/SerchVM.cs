using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class SerchVM
    {
        public List<Order> Orders { get; set; }
        public string Custphone { get; set; }
    }
}
