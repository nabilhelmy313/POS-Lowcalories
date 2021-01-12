using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class HoldVM
    {
        public IEnumerable<Order>Orders{ get; set; }
        public string CustPhone { get; set; }

    }
}
