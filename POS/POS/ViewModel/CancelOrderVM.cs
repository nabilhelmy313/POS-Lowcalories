using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class CancelOrderVM
    {
        public Order order{ get; set; }
        public string BranchName { get; set; }
        public int OId { get; set; }
    }
}
