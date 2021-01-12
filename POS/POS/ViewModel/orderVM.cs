using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class orderVM
    {
        public List<OrderdetailVM> OrderdetailVMs { get; set; }
        public string Type { get; set; }
        public string Phone { get; set; }
        public int BranchId { get; set; }
        public string UserId { get; set; }
        public int AddressId { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        public double Net { get; set; }
        public double Service { get; set; }
    }
}
