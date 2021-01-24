using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class DailyOrderVM
    {
        public List<Order> Orders { get; set; }
        public List<Branch> Branches { get; set; }
        public DateTime Serchdate { get; set; }
        public string CustPhone { get; set; }
        public int BranchId { get; set; }
    }
}
